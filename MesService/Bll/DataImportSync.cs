using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Timers;

namespace Bll
{
    /// <summary>
    /// 远程数据向本地同步组件
    /// </summary>
    public class DataImportSync
    {
        /// <summary>
        /// 私有字段，每次循环获取的数据量
        /// </summary>
        private int BATCHQTY = 1000;

        /// <summary>
        /// 本地数据库连接对象
        /// </summary>
        private DAO.SqlServerHelper LocalServer
        {
            get
            {
                Bll.DbConStrFactory conFactory = Bll.DbConStrFactory.CreateInstance();
                return DAO.SqlServerHelper.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"));
            }
        }

        /// <summary>
        /// 远程数据库连接对象
        /// </summary>
        private DAO.SqlServerHelper RemoteServer
        {
            get
            {
                Bll.DbConStrFactory conFactory = Bll.DbConStrFactory.CreateInstance();
                return DAO.SqlServerHelper.CreateInstance(conFactory.GetSqlConStr("remotePlanSqlDb"));
            }
        }

        /// <summary>
        /// 获取需要同步的表
        /// </summary>
        /// <returns>表实体列表</returns>
        public List<Model.TableModel.Sys_tbl_operate> GetTableModelNeedSync()
        {
            try
            {
                return LocalServer.QueryList<Model.TableModel.Sys_tbl_operate>("tbl_operate_type='download' and status_no='310'");

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 同步本地的表
        /// </summary>
        /// <param name="state">线程默认参数</param>
        public void SyncLocalData(object state)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<Model.TableModel.Sys_tbl_operate> ListTables = GetTableModelNeedSync();
            if (ListTables == null)
            {
                return;
            }
            if (ListTables.Count <= 0)
            {
                return;
            }
            List<System.Threading.Thread> myThreadPool = new List<System.Threading.Thread>();
            int i = 0;
            while (i < ListTables.Count)
            {
                try
                {
                    bool addThreadResult = false;
                    myThreadPool = AddAndStartThread(myThreadPool, SyncSingleTable, ListTables[i], out addThreadResult);
                    if (addThreadResult)
                    {
                        i++;
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
            sw.Stop();
            System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "MesServiceLogs.txt", string.Format("{0}:Synchronization Data Success!\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "MesServiceLogs.txt", string.Format("Time Cost:{0} Seconds\n", (sw.ElapsedMilliseconds / 1000).ToString()));
            return;
        }

        /// <summary>
        /// 添加并启动线程
        /// </summary>
        /// <param name="myThreadPool">虚拟线程池列表</param>
        /// <param name="args">线程参数，表实体</param>
        /// <param name="flag">传出参数，线程是否添加成功</param>
        /// <returns>当前虚拟线程池</returns>
        private List<System.Threading.Thread> AddAndStartThread(List<System.Threading.Thread> myThreadPool, Action<object> myAction,object args, out bool flag)
        {
            List<System.Threading.Thread> listRes = new List<System.Threading.Thread>();
            flag = false;
            foreach (System.Threading.Thread item in myThreadPool)
            {
                if (item.IsAlive)
                {
                    listRes.Add(item);
                }
            }
            if (listRes.Count < 5)
            {
                System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(myAction));
                thread.IsBackground = true;
                thread.Start(args);
                flag = true;
                listRes.Add(thread);
            }
            return listRes;
        }

        /// <summary>
        /// 同步单表
        /// </summary>
        /// <param name="obj">同步单表的参数</param>
        private void SyncSingleTable(object obj)
        {
            Model.TableModel.Sys_tbl_operate sysTblOperate = obj as Model.TableModel.Sys_tbl_operate;
            if (sysTblOperate == null)
            {
                return;
            }
            string maxKey = string.Empty;
            string minKey = string.Empty;
            int recordQty = GetRecordQtyAndKeyEdge(sysTblOperate.tbl_operate_table_name, sysTblOperate.tbl_operate_table_key, out maxKey, out minKey);
            if (recordQty <= 0 || string.IsNullOrEmpty(maxKey) || string.IsNullOrEmpty(minKey))
            {
                return;
            }
            ProcessRemainData(sysTblOperate.tbl_operate_table_name,sysTblOperate.tbl_operate_table_key,maxKey,minKey);
            int times = recordQty / BATCHQTY +1;
            List<System.Threading.Thread> myThreadPool = new List<System.Threading.Thread>();
            int i = 0;
            while (i < times)
            {
                MyArgs syncData = new MyArgs();
                syncData.StartIndex = 1 + BATCHQTY * i;
                syncData.EndIndex = BATCHQTY + BATCHQTY * i;
                syncData.TblName = sysTblOperate.tbl_operate_table_name;
                syncData.Key = sysTblOperate.tbl_operate_table_key;
                syncData.MaxKey = maxKey;
                syncData.MinKey = minKey;
                try
                {
                    bool addThreadResult = false;
                    myThreadPool = AddAndStartThread(myThreadPool, ProcessBatchData ,syncData, out addThreadResult);
                    if (addThreadResult)
                    {
                        i++;
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void ProcessBatchData(object obj)
        {
            MyArgs syncData = obj as MyArgs;
            if (syncData==null)
            {
                return;
            }
            if(string.IsNullOrEmpty(syncData.TblName))
            {
                return;
            }
            if (string.IsNullOrEmpty(syncData.Key))
            {
                return;
            }
            DataTable dtSource=GetSourceData(syncData);
            List<DataRow> listSourceRows = dtSource.AsEnumerable().ToList();
            syncData.MaxKey = listSourceRows.Select(a => a.Field<string>(syncData.Key)).ToList().Max();
            syncData.MinKey = listSourceRows.Select(a => a.Field<string>(syncData.Key)).ToList().Min();
            DataTable dtLocal = GetLocalData(syncData);
            List<DataRow> listLocalRows = dtLocal.AsEnumerable().ToList();
            List<DataRow> listRowsNeed2Insert = GetRowsDiffAMinusB(listSourceRows, listLocalRows, syncData.Key);
            List<DataRow> listRowsNeed2Delete = GetRowsDiffAMinusB(listLocalRows, listSourceRows, syncData.Key);
            List<DataRow> listRowsNeed2Update = GetRowsNeed2Update(listSourceRows, listLocalRows, syncData.Key);
            DeleteRowsNeed2Delete(listRowsNeed2Delete,syncData);
            DeleteRowsNeed2Delete(listRowsNeed2Update, syncData);
            InsertRowsNeed2Insert(listRowsNeed2Insert, syncData);
            InsertRowsNeed2Insert(listRowsNeed2Update, syncData);
        }
        
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="listRowsNeed2Insert">需要插入的数据</param>
        /// <param name="syncData">参数对象</param>
        private void InsertRowsNeed2Insert(List<DataRow> listRowsNeed2Insert, MyArgs syncData)
        {
            if (listRowsNeed2Insert==null)
            {
                return;
            }
            if (listRowsNeed2Insert.Count<=0)
            {
                return;
            }
            DataTable dt = listRowsNeed2Insert[0].Table.Clone();
            dt.Rows.Clear();
            listRowsNeed2Insert.ForEach(a => dt.Rows.Add(a.ItemArray));
            if (dt.Columns.Contains("CheckSum"))
            {
                dt.Columns.Remove("CheckSum");
            }
            if (dt.Columns.Contains("RowNum"))
            {
                dt.Columns.Remove("RowNum");
            }
            LocalServer.InsertBulk(syncData.TblName, dt);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="listRowsNeed2Delete">需要删除的数据</param>
        /// <param name="syncData">参数对象</param>
        private void DeleteRowsNeed2Delete(List<DataRow> listRowsNeed2Delete, MyArgs syncData)
        {
            if (listRowsNeed2Delete==null)
            {
                return;
            }
            if (listRowsNeed2Delete.Count<=0)
            {
                return;
            }
            List<string> list = listRowsNeed2Delete.Select(a => a.Field<string>(syncData.Key)).ToList();
            string keysStr = string.Join("','", list.ToArray());
            keysStr = string.Format("'{0}'", keysStr);
            string sqlStr = string.Format("delete from {0} where {1} in ({2})",syncData.TblName,syncData.Key,keysStr);
            LocalServer.QueryInt(sqlStr);
        }        

        /// <summary>
        /// 获取本地需要更新的数据
        /// </summary>
        /// <param name="listSourceRows">原始数据</param>
        /// <param name="listLocalRows">本地数据</param>
        /// <param name="target">比较的目标字段</param>
        /// <returns>本地需要更新的数据</returns>
        private List<DataRow> GetRowsNeed2Update(List<DataRow> listSourceRows, List<DataRow> listLocalRows, string target)
        {
            List<DataRow> res = new List<DataRow>();
            List<string> listTargetSource = listSourceRows.Select(a => a.Field<string>(target)).ToList();
            List<string> listTargetLocal = listLocalRows.Select(a => a.Field<string>(target)).ToList();
            List<string> listTargetSame = listTargetSource.FindAll(a=>listTargetLocal.Contains(a)).ToList();
            foreach (string item in listTargetSame)
            {
                DataRow rowSource = listSourceRows.Find(a => a.Field<string>(target) == item);
                DataRow rowLocal = listLocalRows.Find(a => a.Field<string>(target) == item);
                if (rowSource.Field<int>("CheckSum")!=rowLocal.Field<int>("CheckSum"))
                {
                    res.Add(rowSource);
                }
            }
            return res;
        }

        /// <summary>
        /// 获取两个数据行的差
        /// </summary>
        /// <param name="listRowA">原始数据行集合（源）</param>
        /// <param name="listRowsB">差数数据集合（目标）</param>
        /// <param name="target">比较的目标字段</param>
        /// <returns>差异行集合，所有在原始数据行内且不在差数数据行内的数据行</returns>
        private List<DataRow> GetRowsDiffAMinusB(List<DataRow> listRowsA, List<DataRow> listRowsB,string target)
        {
            List<string> listTargetA = listRowsA.Select(a => a.Field<string>(target)).ToList();
            List<string> listTargetB = listRowsB.Select(a => a.Field<string>(target)).ToList();
            List<string> listTargetMinus = listTargetA.Except(listTargetB).ToList();
            List<DataRow> listResult = listRowsA.FindAll(a => listTargetMinus.Contains(a.Field<string>(target)));
            return listResult;
        }

        private DataTable GetLocalData(MyArgs syncData)
        {
            if (syncData==null)
            {
                return null;
            }
            string sql = string.Format("select * from (select BINARY_CHECKSUM(*) as CheckSum,ROW_NUMBER() over(order by {0} asc) as RowNum,* from {1}) as tblT where {0}>=@minKey and {0}<=@maxKey;", syncData.Key, syncData.TblName);
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@maxKey", syncData.MaxKey);
            pms.Add("@minKey", syncData.MinKey);
            DataTable dt = new DataTable();
            try { dt = LocalServer.QueryTable(sql, pms); }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }

        /// <summary>
        /// 获取原始数据
        /// </summary>
        /// <param name="syncData">参数类</param>
        /// <returns>查出的数据</returns>
        private DataTable GetSourceData(MyArgs syncData)
        {
            if (syncData == null)
            {
                return null;
            }
            string sql = string.Format("select * from (select BINARY_CHECKSUM(*) as CheckSum,ROW_NUMBER() over(order by {0} asc) as RowNum,* from {1}) as tblT where tblT.RowNum>=@startIndex and tblT.RowNum<=@endIndex;", syncData.Key, syncData.TblName);
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@startIndex", syncData.StartIndex);
            pms.Add("@endIndex", syncData.EndIndex);
            DataTable dt = new DataTable();
            try { dt = RemoteServer.QueryTable(sql, pms); }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }

        /// <summary>
        /// 处理多余的数据
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="key">键值</param>
        /// <param name="maxKey">最大键值</param>
        /// <param name="minKey">最小键值</param>
        private void ProcessRemainData(string tblName, string key, string maxKey, string minKey)
        {
            string sql = string.Format("delete from {0} where {1}<@minKey or {1}>@maxKey",tblName,key);
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@maxKey", maxKey);
            pms.Add("@minKey", minKey);
            LocalServer.QueryInt(sql, pms);
        }

        /// <summary>
        /// 获取表中记录条数及最大最小键值
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="key">键值</param>
        /// <param name="maxKey">输出参数，最大的标记键值</param>
        /// <param name="minKey">输出参数，最小的标记键值</param>
        /// <returns>记录总条数</returns>
        private int GetRecordQtyAndKeyEdge(string tblName, string key, out string maxKey, out string minKey)
        {
            if (string.IsNullOrEmpty(tblName) || string.IsNullOrEmpty(key))
            {
                maxKey = string.Empty;
                minKey = string.Empty;
                return 0;
            }
            string sql = string.Format("select Max({0}) as MaxKey,Min({0}) as MinKey,count({0}) as KeyCount from {1};", key, tblName);
            DataTable dt = new DataTable();
            try
            {
                dt = RemoteServer.QueryTable(sql);
            }
            catch (Exception)
            {
                dt = null;
            }
            if (dt == null)
            {
                maxKey = string.Empty;
                minKey = string.Empty;
                return 0;
            }
            if (dt.Rows.Count != 1)
            {
                maxKey = string.Empty;
                minKey = string.Empty;
                return 0;
            }
            maxKey = dt.Rows[0].Field<string>("MaxKey");
            minKey = dt.Rows[0].Field<string>("MinKey");
            int res = dt.Rows[0].Field<int>("KeyCount");
            return res;
        }
    }
}