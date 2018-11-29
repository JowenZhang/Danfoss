using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bll
{
    /// <summary>
    /// 从集团获取生产计划的类
    /// </summary>
    public class FetchPlanFromGroup
    {
        /// <summary>
        /// 私有字段，每次循环获取的数据量
        /// </summary>
        private int BATCHQTY = 5000;

        /// <summary>
        /// 私有只读属性，远程计划数据库服务
        /// </summary>
        private DAO.SqlServerHelper RemoteDbServer
        {
            get
            {
                DbConStrFactory conStr = DbConStrFactory.CreateInstance();
                return DAO.SqlServerHelper.CreateInstance(conStr.GetSqlConStr("remotePlanSqlDb"));
            }
        }

        /// <summary>
        /// 私有只读属性，本地生产数据库服务
        /// </summary>
        private DAO.SqlServerHelper LocalDbServer
        {
            get
            {
                DbConStrFactory conStr = DbConStrFactory.CreateInstance();
                return DAO.SqlServerHelper.CreateInstance(conStr.GetSqlConStr("defaultSqlDb"));
            }
        }

        /// <summary>
        /// 获取上次导入的最大时间
        /// </summary>
        /// <returns>返回上次导入的时间,如果没有获得时间则值为空</returns>
        private DateTime? GetLastImportTime()
        {
            string sql = "select max(print_time) from mpo_item;";
            object obj = null;
            try
            {
                obj = LocalDbServer.QueryObj(sql);
            }
            catch (Exception)
            {
                obj = string.Empty;
            }
            DateTime dt = DateTime.Now;
            return DateTime.TryParse(obj.ToString(), out dt) ? dt : (DateTime?)(null);
        }

        /// <summary>
        /// 获取本次需要导入的最大时间
        /// </summary>
        /// <returns>返回本次需要导入的时间,如果没有获得时间则值为空</returns>
        private DateTime? GetNeed2ImportTime()
        {
            string sql = "select max(CONVERT(DateTime,PrintDate+' '+PrintTime,120)) from tbl_PrintRecord;";
            object obj = null;
            try
            {
                obj = RemoteDbServer.QueryObj(sql);
            }
            catch (Exception)
            {
                obj = string.Empty;
            }
            DateTime dt = DateTime.Now;
            return DateTime.TryParse(obj.ToString(), out dt) ? dt : (DateTime?)(null);
        }

        /// <summary>
        /// 获取需要更新的生产单数量
        /// </summary>
        /// <param name="dtStart">更新的起始时间</param>
        /// <param name="dtEnd">更新的终止时间</param>
        /// <returns>需要更新生产单的条数</returns>
        private int GetMpoCount2Import(DateTime? dtStart, DateTime? dtEnd)
        {
            string sql = "select count(1) from tbl_PrintRecord;";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            if (dtStart.HasValue && !dtEnd.HasValue)
            {
                sql = "select count(1) from tbl_PrintRecord where CONVERT(DateTime,PrintDate+' '+PrintTime,120)>@dtStart;";
                pms.Add("@dtStart", (DateTime)dtStart);
            }
            else if (dtStart.HasValue && dtEnd.HasValue)
            {
                sql = "select count(1) from tbl_PrintRecord where CONVERT(DateTime,PrintDate+' '+PrintTime,120)>@dtStart and CONVERT(DateTime,PrintDate+' '+PrintTime,120)<@dtEnd;";
                pms.Add("@dtStart", (DateTime)dtStart);
                pms.Add("@dtEnd", (DateTime)dtEnd);
            }
            object obj = RemoteDbServer.QueryObj(sql, pms);
            int intTmp = 0;
            return int.TryParse((obj ?? "0").ToString(), out intTmp) ? intTmp : 0;
        }

        /// <summary>
        /// 获取一批源数据
        /// </summary>
        /// <param name="dtStart">起始时间</param>
        /// <param name="dtEnd">终止时间</param>
        /// <param name="startIndex">起始索引</param>
        /// <param name="endIndex">终止索引</param>
        /// <returns>获取到的源数据</returns>
        private DataTable GetBatchSourceData(DateTime? dtStart, DateTime? dtEnd, int startIndex, int endIndex)
        {
            string sql = "SELECT * FROM	(SELECT row_number () OVER (ORDER BY CONVERT(DateTime,PrintDate+' '+PrintTime,121)) 'row_num',tbl_PrintRecord.* FROM	tbl_PrintRecord	WHERE 1=1 ) AS t WHERE row_num >= @startIndex and row_num<=@endIndex;";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            DataTable dt = new DataTable();
            pms.Add("@startIndex", startIndex);
            pms.Add("@endIndex", endIndex);
            if (dtStart.HasValue && !dtEnd.HasValue)
            {
                sql = "SELECT * FROM (SELECT row_number () OVER (ORDER BY CONVERT(DateTime,PrintDate+' '+PrintTime,121)) 'row_num',tbl_PrintRecord.* FROM	tbl_PrintRecord	WHERE CONVERT(DateTime,PrintDate+' '+PrintTime,121)>=@dtStart ) AS t WHERE row_num >= @startIndex and row_num<=@endIndex;";
                pms.Add("@dtStart", (DateTime)dtStart);
            }
            else if (dtStart.HasValue && dtEnd.HasValue)
            {
                sql = "SELECT * FROM (SELECT row_number () OVER (ORDER BY CONVERT(DateTime,PrintDate+' '+PrintTime,121)) 'row_num',tbl_PrintRecord.* FROM	tbl_PrintRecord	WHERE CONVERT(DateTime,PrintDate+' '+PrintTime,121)>=@dtStart and CONVERT(DateTime,PrintDate+' '+PrintTime,121)<=@dtEnd ) AS t WHERE row_num >= @startIndex and row_num<=@endIndex;";
                pms.Add("@dtStart", (DateTime)dtStart);
                pms.Add("@dtEnd", (DateTime)dtEnd);
            }
            try
            {
                dt = RemoteDbServer.QueryTable(sql, pms);
            }
            catch (Exception)
            {

            }
            return dt;
        }

        /// <summary>
        /// 分析一批数据
        /// </summary>
        /// <param name="dtBatch"></param>
        /// <returns>订单号和子单数据集，订单号和此订单号的所有行记录</returns>
        public Dictionary<string, List<DataRow>> AnalysisMpo(DataTable dtBatch)
        {
            Dictionary<string, List<DataRow>> res = new Dictionary<string, List<DataRow>>();
            if (dtBatch == null)
            {
                return res;
            }
            if (dtBatch.Rows.Count <= 0)
            {
                return res;
            }
            //表转行集
            List<DataRow> dtRowsSource = dtBatch.AsEnumerable().ToList();
            Bll.DataRowCompare dataRowCompare = new DataRowCompare();
            List<DataRow> dtRowsSourceNotSame = dtRowsSource.Distinct(dataRowCompare).ToList();
            //行中取出序列号（不重复，但不知道是否已插入）
            List<string> serialNos = dtRowsSourceNotSame.Select(a => a.Field<string>("SerialNo")).ToList().Distinct().ToList();
            StringBuilder strSerialNoCombine=new StringBuilder();
            strSerialNoCombine.Append("'");
            serialNos.ForEach(a=>strSerialNoCombine.AppendFormat("{0}','",a));
            if (strSerialNoCombine.Length<2)
            {
                strSerialNoCombine.Remove(0, strSerialNoCombine.Length);
                strSerialNoCombine.Append("''");
            }
            else
            {
                strSerialNoCombine.Remove(strSerialNoCombine.Length - 2, 2);
            }
            List<Model.TableModel.Mpo_item> list=LocalDbServer.QueryList<Model.TableModel.Mpo_item>(string.Format("serial_no in ({0})",strSerialNoCombine.ToString()));
            List<string> serialNoAlreadyExist = list.Select(a => a.serial_no).ToList();
            List<DataRow> dtRowsNeedImport = dtRowsSourceNotSame.FindAll(a => !serialNoAlreadyExist.Contains(a.Field<string>("SerialNo"))).ToList();

            List<string> mpoNos = dtRowsNeedImport.Select(a => a.Field<string>("ProductOrder")).ToList().Distinct().ToList();
            foreach (string item in mpoNos)
            {
                List<DataRow> dtList = dtRowsNeedImport.FindAll(a => a.Field<string>("ProductOrder") == item);
                if (dtList == null)
                {
                    continue;
                }
                if (dtList.Count <= 0)
                {
                    continue;
                }
                res.Add(item, dtList);
            }
            return res;
        }

        /// <summary>
        /// 数据传输
        /// </summary>
        /// <param name="data">要传输的批次订单数据</param>
        /// <returns>传输结果</returns>
        public bool DataTransport(Dictionary<string, List<DataRow>> data)
        {
            if (data == null)
            {
                return false;
            }
            if (data.Count <= 0)
            {
                return false;
            }
            foreach (var item in data.Keys)
            {
                List<DataRow> rows = data[item];
                if (rows == null)
                {
                    continue;
                }
                if (rows.Count <= 0)
                {
                    continue;
                }
                //获取最大时间
                string maxDate = rows.Select(RowToDateTime).ToList().Max().ToString("yyyy-MM-dd");
                List<DataRow> rowsTmp = rows.FindAll(a => a.Field<string>("PrintDate") == maxDate);
                string maxTime = rowsTmp.Select(RowToDateTime).ToList().Max().ToString("HH:mm:ss.fff");
                //获取最小时间
                string minDate = rows.Select(RowToDateTime).ToList().Min().ToString("yyyy-MM-dd");
                List<DataRow> rowsTmp2 = rows.FindAll(a => a.Field<string>("PrintDate") == minDate);
                string minTime = rowsTmp.Select(RowToDateTime).ToList().Min().ToString("HH:mm:ss.fff");
                //起止时间获得
                DateTime endTime = DateTime.Now;
                DateTime startTime = DateTime.Now;
                endTime = DateTime.TryParse(maxDate + " " + maxTime, out endTime) ? endTime : DateTime.Now;
                startTime = DateTime.TryParse(minDate + " " + minTime, out startTime) ? startTime : DateTime.Now;

                int b = InsertOrUpdateMpo(item, rows.Count, startTime, endTime, rows[0].Field<string>("CprReference"));
                if (b > 0)
                {
                    b = InsertMpoItem(rows);
                }
                if (b <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 从现有行中提取时间
        /// </summary>
        /// <param name="arg">数据行</param>
        /// <returns>时间</returns>
        private DateTime RowToDateTime(DataRow arg)
        {
            string date = arg.Field<string>("PrintDate");
            string time = arg.Field<string>("PrintTime");
            DateTime res=DateTime.TryParse(date + " " + time, out res)?res:DateTime.Now;
            return res;
        }

        /// <summary>
        /// 插入订单详情
        /// </summary>
        /// <param name="rows">订单行</param>
        /// <returns>数据影响行数</returns>
        private int InsertMpoItem(List<DataRow> rows)
        {
            if (rows == null)
            {
                return -1;
            }
            if (rows.Count <= 0)
            {
                return -1;
            }
            string mpoNo = rows[0].Field<string>("ProductOrder");
            string partNo = rows[0].Field<string>("CprReference");
            List<Model.TableModel.Mpo_item> modelList = new List<Model.TableModel.Mpo_item>();
            foreach (DataRow item in rows)
            {
                Model.TableModel.Mpo_item model = new Model.TableModel.Mpo_item();
                model.id = Common.Md5Operate.CreateGuidId();
                model.item_no = item.Field<string>("SerialNo");
                model.item_qty = 1;
                model.mpo_no = mpoNo;
                model.part_no = partNo;
                model.serial_no = item.Field<string>("SerialNo");
                model.status_name = "已确认";
                model.status_no = "310";
                DateTime dt = RowToDateTime(item);
                model.hope_product_time = dt;
                model.print_time = dt;
                modelList.Add(model);
            }
            return LocalDbServer.QueryInt<Model.TableModel.Mpo_item>("Insert", modelList);
        }

        /// <summary>
        /// 插入或更新主生产订单
        /// </summary>
        /// <param name="mpoNo">主生产号</param>
        /// <param name="mpoQty">生产单数量</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="partNo">型号</param>
        /// <returns>数据处理行数</returns>
        private int InsertOrUpdateMpo(string mpoNo, int mpoQty, DateTime startDate, DateTime endDate, string partNo)
        {
            if (startDate < endDate)
            {
                DateTime dtTmp = DateTime.Now;
                dtTmp = startDate;
                startDate = endDate;
                endDate = dtTmp;
            }
            string where = string.Format("mpo_no='{0}'", mpoNo);
            List<Model.TableModel.Mpo> list = LocalDbServer.QueryList<Model.TableModel.Mpo>(where);
            Model.TableModel.Mpo mpoModel = new Model.TableModel.Mpo();
            string operate = "insert";
            if (list == null)
            {
                mpoModel = CreateMpo(mpoNo, mpoQty, startDate, endDate, partNo);
            }
            if (list.Count <= 0)
            {
                mpoModel = CreateMpo(mpoNo, mpoQty, startDate, endDate, partNo);
            }
            else if (list.Count == 1)
            {
                mpoModel = list[0];
                mpoModel.mpo_qty += mpoQty;
                mpoModel.mpo_hope_start_datetime = mpoModel.mpo_hope_start_datetime > startDate ? startDate : mpoModel.mpo_hope_start_datetime;
                mpoModel.mpo_hope_start_datetime = mpoModel.mpo_hope_start_datetime > startDate ? startDate : mpoModel.mpo_hope_start_datetime;
                operate = "update";
            }
            if (list.Count > 1)
            {
                mpoModel = null;
            }
            if (mpoModel == null)
            {
                return -1;
            }
            try
            {
                return LocalDbServer.QueryInt<Model.TableModel.Mpo>(operate, new List<Model.TableModel.Mpo>() { mpoModel });
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 订单实体类的构建
        /// </summary>
        /// <param name="mpoNo">订单号</param>
        /// <param name="mpoQty">订单数量</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="partNo">型号</param>
        /// <returns>订单实体类</returns>
        private Model.TableModel.Mpo CreateMpo(string mpoNo, int mpoQty, DateTime startDate, DateTime endDate, string partNo)
        {
            if (string.IsNullOrEmpty(mpoNo))
            {
                return null;
            }
            mpoQty = mpoQty <= 0 ? 0 : mpoQty;
            Model.TableModel.Mpo resModel = new Model.TableModel.Mpo();
            resModel.id = Common.Md5Operate.CreateGuidId();
            resModel.status_no = "300";
            resModel.status_name = "未确认";
            resModel.crt_user_no = "server";
            resModel.crt_user_name = "server";
            resModel.crt_time = DateTime.Now;
            resModel.upd_user_no = "server";
            resModel.upd_user_name = "server";
            resModel.upd_time = DateTime.Now;
            resModel.mpo_no = mpoNo;
            resModel.mpo_type_no = "01";
            resModel.mpo_type_name = "生产";
            resModel.part_no = partNo;
            resModel.part_name = string.Empty;
            resModel.part_spec = string.Empty;
            resModel.part_unit = string.Empty;
            resModel.mpo_qty = mpoQty;
            resModel.mpo_hope_start_datetime = startDate;
            resModel.mpo_hope_end_datetime = endDate;
            resModel.workshop_no = "ws01";
            resModel.factory_no = "dfs_f";
            resModel.line_no = "line01";
            resModel.job_no = string.Empty;
            resModel.shift_no = string.Empty;
            resModel.client_no = string.Empty;
            resModel.client_name = string.Empty;
            resModel.commit_status_no = "400";
            resModel.commit_status_name = "未下发";
            resModel.procedure_status_name = "未开工";
            resModel.procedure_finished_qty = 0;
            return resModel;
        }

        /// <summary>
        /// 获取订单
        /// </summary>
        /// <param name="state"></param>
        public void FetchMpo(object state)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DateTime? dtStart = GetLastImportTime();
            DateTime? dtEnd = GetNeed2ImportTime();
            int count = GetMpoCount2Import(dtStart, dtEnd);
            int times = count / BATCHQTY + 1;
            for (int i = 0; i < times; i++)
            {
                int startIndex = 1 + i * BATCHQTY;
                int endIndex = BATCHQTY * (i + 1);
                DataTable dtData = GetBatchSourceData(dtStart, dtEnd, startIndex, endIndex);
                Dictionary<string, List<DataRow>> dataAnalysised = AnalysisMpo(dtData);
                DataTransport(dataAnalysised);
            }
            sw.Stop();
            System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "MesServiceLogs.txt", string.Format("{0}:Fetch Plan Success!\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "MesServiceLogs.txt", string.Format("Time Cost:{0} Seconds.\n", (sw.ElapsedMilliseconds / 1000).ToString()));
        }
    }
}
