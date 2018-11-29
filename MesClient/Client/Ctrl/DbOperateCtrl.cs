using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Client.Ctrl
{
    /// <summary>
    /// 数据库表级操作类
    /// </summary>
    class DbOperateCtrl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DbOperateCtrl() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        public DbOperateCtrl(string eqmNo)
        {
            EqmNo = eqmNo;
        }

        /// <summary>
        /// 工位参数
        /// </summary>
        public string EqmNo { get; set; }

        /// <summary>
        /// 私有的通用数据库引擎
        /// </summary>
        private DAO.GeneralDbEngine DbEngine
        {
            get
            {
                Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
                return DAO.GeneralDbEngine.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetAccessConStr("defaultAccessDb"));
            }
        }

        /// <summary>
        /// 私有属性，本地数据库引擎
        /// </summary>
        private DAO.AccessDbHelper AccessDbEngine
        {
            get
            {
                Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
                return DAO.AccessDbHelper.CreateInstance(conFactory.GetAccessConStr("defaultAccessDb"));
            }
        }

        /// <summary>
        /// 上传数据
        /// </summary>
        /// <param name="state">异步状态同步变量</param>
        public void UploadTable(object state)
        {
            List<string> tableName = GetTableToBeUploaded();
            List<Model.TableModel.Sys_tbl_operate_record> recordToBeAdded = new List<Model.TableModel.Sys_tbl_operate_record>();
            try
            {
                foreach (var item in tableName)
                {
                    string sql = string.Format("select * from {0}", item);
                    DataTable dtData = AccessDbEngine.QueryTable(sql);
                    StringBuilder idToBeDelete = new StringBuilder();
                    idToBeDelete.Append("'");
                    if (dtData != null && dtData.Rows.Count > 0)
                    {
                        bool containId = true;
                        DataTable dtToBeAdded = dtData.Clone();
                        dtToBeAdded.Clear();
                        foreach (DataColumn dc in dtData.Columns)
                        {
                            if (dc.ColumnName.ToLower() == "id")
                            {
                                containId = true;
                                break;
                            }
                            containId = false;
                        }
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Model.TableModel.Sys_tbl_operate_record model = new Model.TableModel.Sys_tbl_operate_record();
                            string currentId = string.Empty;
                            if (!containId)
                            {
                                currentId = CreateIdByRow(dr);
                            }
                            else
                            {
                                currentId = (dr["id"] ?? "UNKNOWN").ToString();
                            }
                            if (AlreadyOpreate(currentId, "upload"))
                            {
                                continue;
                            }
                            model.id = currentId;
                            model.status_name = "已确认";
                            model.status_no = "310";
                            model.tbl_name = item;
                            model.tbl_operate_time = DateTime.Now;
                            model.tbl_oprate_type = "upload";
                            recordToBeAdded.Add(model);
                            dtToBeAdded.Rows.Add(dr);
                            idToBeDelete.Append(currentId);
                            idToBeDelete.Append("','");
                        }
                        if (idToBeDelete.Length > 2)
                        {
                            idToBeDelete.Remove(idToBeDelete.Length - 2, 2);
                        }
                        string sqlDelete = string.Format("delete from {0} where id in ({1})", item, idToBeDelete);
                        DbEngine.QueryInt<Model.TableModel.Sys_tbl_operate_record>("Insert", recordToBeAdded);
                        recordToBeAdded.Clear();
                        DbEngine.InsertBulk(item, dtToBeAdded);

                    }
                }
                GC.Collect(1);
                state = true;
            }
            catch (Exception ex)
            {
                throw ex;
                //state = false;                
            }

        }

        /// <summary>
        /// 判定是否该ID或行快照已经处理
        /// </summary>
        /// <param name="currentId">当前ID或行快照</param>
        /// <param name="operate">操作</param>
        /// <returns>是否已处理：真已处理，假未处理</returns>
        private bool AlreadyOpreate(string currentId, string operate)
        {
            try
            {
                string where = string.Format("id='{0}' and opreate='{1}'", currentId, operate);
                List<Model.TableModel.Sys_tbl_operate_record> list = DbEngine.QueryList<Model.TableModel.Sys_tbl_operate_record>(where);
                if (list == null || list.Count <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 行快照生成
        /// </summary>
        /// <param name="dr">内容行</param>
        /// <returns>行快照</returns>
        private string CreateIdByRow(DataRow dr)
        {
            StringBuilder dataAll = new StringBuilder();
            foreach (var item in dr.ItemArray)
            {
                dataAll.Append((item ?? string.Empty).ToString());
            }
            return Common.Md5Operate.GetMD5String(dataAll.ToString());
        }

        /// <summary>
        /// 获取要升级的表
        /// </summary>
        /// <returns>要升级的表名列表</returns>
        public List<string> GetTableToBeUploaded()
        {
            string whereTableToBeUploaded = string.Format("tbl_operate_type='upload' and status_no='310'");
            List<Model.TableModel.Sys_tbl_operate> listModels = DbEngine.QueryList<Model.TableModel.Sys_tbl_operate>(whereTableToBeUploaded);
            return listModels.Select<Model.TableModel.Sys_tbl_operate, string>(a => a.tbl_operate_table_name).ToList();
        }


        /// <summary>
        /// 工艺参数下载函数（多线程函数）
        /// </summary>
        /// <param name="state">当前线程的状态或参数</param>
        /// <returns>是否下载成功</returns>
        public bool PeDataDownLoad(object state)
        {
            Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
            DAO.AccessDbHelper PmsDbEngine = DAO.AccessDbHelper.CreateInstance(conFactory.GetAccessConStr("pmsAccessDb"));
            DataTable dt = GetPeData();
            if (dt == null || dt.Rows.Count <= 0)
            {
                return false;
            }
            string sqlClear = "delete from Parameter where 1=1;";
            PmsDbEngine.QueryInt(sqlClear);
            StringBuilder sql = new StringBuilder();            
            foreach (DataColumn item in dt.Columns)
            {
                sql.Append("@");
                sql.Append(item.ColumnName);
                sql.Append(",");
            }
            if (sql.Length > 0)
            {
                sql.Remove(sql.Length - 1, 1);
            }
            else
            {
                return false;
            }
            string cols = sql.ToString().Replace("@", "");
            string sqlToCheange = string.Format("insert into Parameter({0}) values ({1})", cols, sql.ToString());
            foreach (DataRow item in dt.Rows)
            {
                try
                {
                    if (string.IsNullOrEmpty((item["ID"] ?? string.Empty).ToString()))
                    {
                        continue;
                    }
                }
                catch (Exception)
                {                    
                    continue;
                }                
                Dictionary<string, object> pms = new Dictionary<string, object>();
                for (int i = 0; i < item.ItemArray.Length; i++)
                {
                    pms.Add("@" + dt.Columns[i].ColumnName, item.ItemArray[i] ?? "");
                }
                PmsDbEngine.QueryInt(sqlToCheange, pms);
            }
            GC.Collect(1);
            state = true;
            return true;
        }

        /// <summary>
        /// 获取工艺参数数据表
        /// </summary>
        /// <returns>工艺参数数据表</returns>
        private DataTable GetPeData()
        {
            DataTable res = new DataTable();
            string where = string.Format("eqm_no='{0}' and file_type_no='09' and is_passed='true' and file_status='使用中'", EqmNo);
            //string where = string.Format("eqm_no='{0}' and is_passed='true' and file_status='使用中' and ralate_file_name is not null and valid_date_start<='{1}' and (valid_date_end>='{1}' or valid_date_end is null)", EqmNo,DateTime.Now.ToString("yyyy-MM-dd"));
            try
            {
                List<Model.TableModel.Dms_file> listFile = DbEngine.QueryList<Model.TableModel.Dms_file>(where);
                if (listFile==null)
                {
                    return null;
                }
                if (listFile.Count != 1)
                {
                    return res;
                }
                string fileName = listFile[0].file_md5+"_"+listFile[0].file_name + listFile[0].file_extension;
                string ftpHost = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "host", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesClientConfig.xml");
                string ftpUser = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "readUser", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesClientConfig.xml");
                string ftpUserPwd = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "readPwd", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesClientConfig.xml");
                string ftpPath = "current";
                Common.FTPHelper ftp = new Common.FTPHelper(ftpHost, ftpPath, ftpUser, ftpUserPwd);
                string localPath = Common.ConfigHelper.GetConfigValueFromXml("generalSet", "fileDirectory", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesClientConfig.xml");
                if (!System.IO.File.Exists(localPath + @"\current\" + fileName))
                {
                    ftp.Download(localPath + @"\current\", fileName);
                }
                string newFileName = listFile[0].file_name + listFile[0].file_extension;
                if (!System.IO.File.Exists(localPath+@"\current\"+newFileName))
                {
                    System.IO.File.Copy(localPath + @"\current\" + fileName, localPath + @"\current\" + newFileName, true);
                }
                res = Common.ExcelHelper.ExcelToDataTableExchange(localPath + @"\current\" + newFileName, "PLM_PMS", true, 2);
                System.IO.File.Delete(localPath + @"\current" + newFileName);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
