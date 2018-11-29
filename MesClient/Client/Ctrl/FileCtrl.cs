using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Client.Ctrl
{
    /// <summary>
    /// 文件控制类文件
    /// </summary>
    public class FileCtrl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        private FileCtrl() { }

        /// <summary>
        /// 私有单例字段
        /// </summary>
        private static FileCtrl _fileCtrl = null;

        /// <summary>
        /// 线程同步标识
        /// </summary>
        private static readonly object _locker = new object();

        /// <summary>
        /// 类的单例创建函数
        /// </summary>
        /// <param name="sqlConStr">sqlServer连接字符串</param>
        /// <param name="accessConStr">access连接字符串</param>
        /// <returns>创建类的构造函数</returns>
        public static FileCtrl CreateInstance(string sqlConStr, string accessConStr)
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (_fileCtrl == null)
            {
                lock (_locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (_fileCtrl == null)
                    {
                        _fileCtrl = new FileCtrl();
                    }
                }
            }
            _fileCtrl.SqlConStr = sqlConStr;
            _fileCtrl.AccessConStr = accessConStr;
            return _fileCtrl;
        }

        
        /// <summary>
        /// 公有属性，Sql连接字符串
        /// </summary>
        public string SqlConStr { get; set; }

        /// <summary>
        /// 公有属性，Access连接字符串
        /// </summary>
        public string AccessConStr { get; set; }


        private DAO.GeneralDbEngine DbEngine
        {
            get 
            {
                return DAO.GeneralDbEngine.CreateInstance(SqlConStr, AccessConStr);
            }
        }


        /// <summary>
        /// 获取某一工站的合法文件
        /// </summary>
        /// <param name="eqmNo">工站编号</param>
        /// <returns>获取到的所有文件列表</returns>//文件状态：停止使用，使用中，未确认
        public List<Model.TableModel.Dms_file> LoadFile(string eqmNo, string fileTypeNo)
        {
            StringBuilder where = new StringBuilder();
            if (string.IsNullOrEmpty(eqmNo))
            {
                where.AppendFormat(" is_passed='1' and file_status='使用中' and ralate_file_name is not null and valid_date_start<='{0}' and (valid_date_end is null or valid_date_end>='{0}')",DateTime.Now.ToString("yyyy-MM-dd"));
                if (string.IsNullOrEmpty(fileTypeNo))
                {
                    where.Append(" and file_type_no in (select file_type_no from dms_file_type where file_type_name not in ('BOM','PLM_PMS'))");
                }
                else
                {
                    where.AppendFormat(" and file_type_no='{0}'", fileTypeNo);
                }

            }
            else
            {
                where.AppendFormat("eqm_no='{0}' and is_passed='1' and file_status='使用中' and ralate_file_name is not null and valid_date_start<='{1}' and (valid_date_end is null or valid_date_end>='{1}')", eqmNo,DateTime.Now.ToString("yyyy-MM-dd"));
                if (string.IsNullOrEmpty(fileTypeNo))
                {
                    where.Append(" and file_type_no in (select file_type_no from dms_file_type where file_type_name not in ('BOM','PLM_PMS'))");
                }
                else
                {
                    where.AppendFormat(" and file_type_no='{0}'", fileTypeNo);
                }
            }
            return DbEngine.QueryList<Model.TableModel.Dms_file>(where.ToString());
        }

        /// <summary>
        /// 根据文件编号获取审核动作列表
        /// </summary>
        /// <param name="fileNo">文件编号</param>
        /// <returns>所有动作列表</returns>
        public List<Model.TableModel.Apo_act> GetFileFlow(string fileNo = "")
        {
            List<Model.TableModel.Apo_act> result = new List<Model.TableModel.Apo_act>();
            string where = string.Empty;
            if (string.IsNullOrEmpty(fileNo))
            {
                return null;
            }
            else
            {
                string sqlSteps = "select act_step from apo_act where ralate_no=@ralate_no and next_item_no='-1'";
                Dictionary<string, object> pms = new Dictionary<string, object>();
                pms.Add("@ralate_no", fileNo);
                DataTable dtTmp = DbEngine.QueryTable(sqlSteps, pms);
                if (dtTmp == null || dtTmp.Rows.Count <= 0)
                {
                    return null;
                }
                else
                {
                    int max = -1;
                    foreach (DataRow item in dtTmp.Rows)
                    {
                        int tmp = -1;
                        if (!int.TryParse((item["act_step"] ?? "0").ToString(), out tmp))
                        {
                            tmp = -1;
                        }
                        max = tmp > max ? tmp : max;
                    }
                    string sqlCount = "select count(1) from apo_act where ralate_no=@ralate_no and act_step>@act_step;";
                    pms.Add("@act_step", max);
                    object obj = DbEngine.QueryObj(sqlCount, pms);
                    int tmpCount = -1;
                    if (!int.TryParse((obj ?? "0").ToString(), out tmpCount))
                    {
                        tmpCount = -1;
                    }
                    if (tmpCount > 0)
                    {
                        return null;
                    }
                    else
                    {
                        for (int i = max; i >= 0; i--)
                        {
                            where = string.Format("ralate_no='{0}' and act_step={1}", fileNo, i);
                            List<Model.TableModel.Apo_act> listTmp = DbEngine.QueryList<Model.TableModel.Apo_act>(where);
                            result.AddRange(listTmp);
                            Model.TableModel.Apo_act modelTmp = listTmp.Find(a => a.apo_index == 0);
                            if (modelTmp != null)
                            {
                                break;
                            }
                        }
                        result.Reverse();
                        return result;
                    }
                }
            }
        }

        /// <summary>
        /// 获取文件创建人和创建时间
        /// </summary>
        /// <param name="fileNo">文件编号</param>
        /// <param name="fileTime">创建时间</param>
        /// <returns>文件创建人姓名</returns>
        public string GetFileCreatorAndTime(string fileNo, out string fileTime)
        {
            if (string.IsNullOrEmpty(fileNo))
            {
                fileTime = string.Empty;
                return string.Empty;
            }
            string sql = "select top 1 act_user_no,act_user_name,act_time from apo_act where act_step=0 and ralate_no=@ralate_no";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@ralate_no", fileNo);
            DataTable dt = DbEngine.QueryTable(sql, pms);
            if (dt == null || dt.Rows.Count != 1)
            {
                fileTime = string.Empty;
                return string.Empty;
            }
            fileTime = (dt.Rows[0]["act_time"] ?? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).ToString();
            return (dt.Rows[0]["act_user_name"] ?? "Server").ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        private DataTable GetBomDt(string eqmNo)
        {
            DataTable dt = new DataTable();
            try
            {
                DataTable dtRes = new DataTable();
                string bomWhere = string.Format(" eqm_no='{0}' and file_type_no='08' and file_status='使用中' order by file_no asc", eqmNo);
                List<Model.TableModel.Dms_file> list = DbEngine.QueryList<Model.TableModel.Dms_file>(bomWhere);
                if (list.Count <= 0)
                {
                    return dtRes;
                }
                string fileName = list[0].file_md5 + "_" + list[0].file_name + list[0].file_extension;
                string localPath = Common.ConfigHelper.GetConfigValueFromXml("generalSet", "fileDirectory", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesClientConfig.xml");
                if (!System.IO.File.Exists(localPath + @"\current\" + fileName))
                {
                    string ftpUserNo = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "readUser", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesClientConfig.xml");
                    string ftpUserPwd = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "readPwd", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesClientConfig.xml");
                    string ftpHost = Common.ConfigHelper.GetConfigValueFromXml("ftpSet", "host", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesClientConfig.xml");
                    Common.FTPStreamHelper.DownloadFile(localPath + @"\current\", "current", fileName, ftpHost, ftpUserNo, ftpUserPwd);
                }
                dt = Common.ExcelHelper.ExcelToDataTable(localPath + @"\current\" + fileName, "BOM", true, 2);
                if (dt.Rows.Count <= 0)
                {
                    return dtRes;
                }
            }
            catch (Exception)
            {                
            }            
            return dt;
        }

        /// <summary>
        /// 加载BOM信息
        /// </summary>
        /// <param name="filterData">过滤条件</param>
        /// <param name="eqmNo">设备编号</param>
        /// <returns>BOM信息列表</returns>
        public DataTable LoadBom(string filterData, string eqmNo)
        {
            DataTable dt = GetBomDt(eqmNo);
            DataTable dtNew=new DataTable();
            try
            {
                dtNew = dt.Clone();
                DataRow[] drs = dt.Select(string.Format("part_no like '%{0}%'", filterData));
                foreach (DataRow item in drs)
                {
                    dtNew.Rows.Add(item.ItemArray);
                }
            }
            catch (Exception)
            {
            }
            
            return dtNew;
        }

        /// <summary>
        /// 加载已获取的品号
        /// </summary>
        /// <param name="eqmNo"></param>
        /// <returns></returns>
        public List<string> LoadType(string eqmNo)
        {
            List<string> res = new List<string>();
            try
            {
                DataTable dt = GetBomDt(eqmNo);
                foreach (DataRow item in dt.Rows)
                {
                    string partNo = (item["part_no"] ?? "UNKNOWN").ToString();
                    if (res.Contains(partNo))
                    {
                        continue;
                    }
                    res.Add(partNo);
                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
