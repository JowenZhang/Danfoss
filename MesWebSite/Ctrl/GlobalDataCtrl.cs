using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 全局数据操作类
    /// </summary>
    public class GlobalDataCtrl
    {
        /// <summary>
        /// 私有字段，数据库引擎
        /// </summary>
        private DAO.SqlServerHelper _dbEngine = DAO.SqlServerHelper.CreateInstance(Common.ConfigHelper.GetConfigValueFromXml( "connectionStr","dfsDb", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml"));

        /// <summary>
        /// 私有属性，数据库引擎
        /// </summary>
        private DAO.SqlServerHelper DbEngine
        {
            get
            {
                return _dbEngine;
            }
        }

        /// <summary>
        /// 根据字段名获取对象
        /// </summary>
        /// <param name="destinyFiled">目标字段</param>
        /// <param name="tblName">表名</param>
        /// <param name="orignalField">源字段</param>
        /// <param name="value">源字段值</param>
        /// <returns>目标对象</returns>
        public object GetObjectByField(string destinyFiled, string tblName, string orignalField, object value)
        {
            if (value==null)
            {
                return null;
            }
            object obj=null;
            string sql = string.Format("select {0} from {1} where {2}=@{2};",destinyFiled,tblName,orignalField);
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@" + orignalField, value);
            try
            {
                obj = DbEngine.QueryObj(sql, pms);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return obj;
        }

        /// <summary>
        /// 根据字段名获取字符串
        /// </summary>
        /// <param name="destinyFiled">目标字段</param>
        /// <param name="tblName">表名</param>
        /// <param name="orignalField">源字段</param>
        /// <param name="value">源字段值</param>
        /// <returns>目标字符串</returns>
        public string GetStrByField(string destinyFiled, string tblName, string orignalField, object value)
        {
            if (value==null)
            {
                return string.Empty;
            }
            object obj = GetObjectByField(destinyFiled, tblName, orignalField, value);
            return (obj ?? string.Empty).ToString();
        }

        /// <summary>
        /// 根据字段名获取数值
        /// </summary>
        /// <param name="destinyFiled">目标字段</param>
        /// <param name="tblName">表名</param>
        /// <param name="orignalField">源字段</param>
        /// <param name="value">源字段值</param>
        /// <returns>目标数值</returns>
        public int GetIntByField(string destinyFiled, string tblName, string orignalField, object value)
        {
            if (value==null)
            {
                return 0;
            }
            object obj = GetObjectByField(destinyFiled, tblName, orignalField, value);
            string tmp = (obj ?? 0).ToString();
            int res = 0;
            if (int.TryParse(tmp, out res))
            {
                return res;
            }
            else
            {
                return -999999;
            }
        }

        /// <summary>
        /// 根据条件获取对象
        /// </summary>
        /// <param name="destinyFiled">目标字段</param>
        /// <param name="tblName">表名</param>
        /// <param name="where">条件</param>
        /// <param name="pms">参数</param>
        /// <returns>目标对象</returns>
        public object GetObjectByField(string destinyFiled, string tblName, string where, Dictionary<string,object> pms=null)
        {
            object obj = null;
            StringBuilder sql=new StringBuilder();
            sql.Append("select ");
            sql.Append(destinyFiled);
            sql.Append(" from ");
            sql.Append(tblName);
            if (!string.IsNullOrEmpty(where))
            {
                sql.Append(" where ");
                sql.Append(where);
            }
            sql.Append(";");
            try
            {
                obj = DbEngine.QueryObj(sql.ToString(), pms);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        /// <summary>
        /// 根据条件获取数值
        /// </summary>
        /// <param name="destinyFiled">目标字段</param>
        /// <param name="tblName">表名</param>
        /// <param name="where">条件</param>
        /// <param name="pms">参数</param>
        /// <returns>目标数值</returns>
        public int GetIntByField(string destinyFiled, string tblName, string where, Dictionary<string, object> pms=null)
        {
            int res = 0;
            object obj = GetObjectByField(destinyFiled, tblName, where, pms);
            return obj == null ? 0 : int.TryParse(obj.ToString(), out res) ? res : 0;
        }


        /// <summary>
        /// 根据条件获取字符串
        /// </summary>
        /// <param name="destinyFiled">目标字段</param>
        /// <param name="tblName">表名</param>
        /// <param name="where">条件</param>
        /// <param name="pms">参数</param>
        /// <returns>目标字符串</returns>
        public string GetStrByField(string destinyFiled, string tblName, string where, Dictionary<string, object> pms=null)
        {
            string res = string.Empty;
            object obj = GetObjectByField(destinyFiled, tblName, where, pms);
            return obj == null ? string.Empty : obj.ToString();
        }

        /// <summary>
        /// 根据表名记录表No
        /// </summary>
        /// <param name="tblName"></param>
        /// <returns></returns>
        public string GetNextNoByTblName(string tblName)
        {
            string sqlExistTblNo = "select * from sys_tbl_no where tbl_name=@tbl_name";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@tbl_name", tblName);
            DataTable dt = DbEngine.QueryTable(sqlExistTblNo, pms);
            int tblNo = 0;
            if (dt == null)
            {
                sqlExistTblNo = "insert into sys_tbl_no values (@id,@tbl_name,@tbl_no,@last_write_date)";
                pms.Clear();
                pms.Add("@id", Common.Md5Operate.CreateGuidId());
                pms.Add("@tbl_name", tblName);
                pms.Add("@tbl_no", "1");
                pms.Add("@last_write_date", DateTime.Now.Date);
                DbEngine.QueryInt(sqlExistTblNo, pms);
                tblNo = 1;
            }
            else
            {
                if (dt.Rows.Count != 1)
                {
                    sqlExistTblNo = "delete from sys_tbl_no where tbl_name=@tbl_name";
                    DbEngine.QueryInt(sqlExistTblNo, pms);
                    sqlExistTblNo = "insert into sys_tbl_no values (@id,@tbl_name,@tbl_no,@last_write_date)";
                    pms.Clear();
                    pms.Add("@id", Common.Md5Operate.CreateGuidId());
                    pms.Add("@tbl_name", tblName);
                    pms.Add("@tbl_no", "1");
                    pms.Add("@last_write_date", DateTime.Now.Date);
                    DbEngine.QueryInt(sqlExistTblNo, pms);
                    tblNo = 1;
                }
                else
                {
                    string tmpNo = dt.Rows[0].Field<string>("tbl_no");
                    DateTime dtLastDate = dt.Rows[0].Field<DateTime>("last_write_date");
                    string id = dt.Rows[0].Field<string>("id");
                    if (dtLastDate.Date != DateTime.Now.Date)
                    {
                        sqlExistTblNo = "update sys_tbl_no set tbl_no=@tbl_no,last_write_date=@last_write_date where id=@id;";
                        pms.Clear();
                        pms.Add("@id", id);
                        pms.Add("@tbl_no", "1");
                        pms.Add("@last_write_date", DateTime.Now.Date);
                        DbEngine.QueryInt(sqlExistTblNo, pms);
                        tblNo = 1;
                    }
                    else
                    {
                        sqlExistTblNo = "update sys_tbl_no set tbl_no=@tbl_no where id=@id;";
                        pms.Clear();
                        tblNo = int.TryParse(tmpNo, out tblNo) ? tblNo : 0;
                        tblNo = tblNo + 1;
                        pms.Add("@id", id);
                        pms.Add("@tbl_no", tblNo.ToString());
                        DbEngine.QueryInt(sqlExistTblNo, pms);
                    }
                }
            }
            string res = DateTime.Now.ToString("yyyyMMdd") + tblNo.ToString().PadLeft(8, '0');
            return res;
        }
    }
}
