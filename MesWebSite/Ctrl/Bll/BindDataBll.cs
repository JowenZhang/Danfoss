using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Ctrl.Bll
{
    /// <summary>
    /// 业务控制，数据绑定操作
    /// </summary>
    public class BindDataBll
    {
        /// <summary>
        /// 私有字段，数据库引擎
        /// </summary>
        private DAO.SqlServerHelper _dbEngine = DAO.SqlServerHelper.CreateInstance(Common.ConfigHelper.GetConfigValueFromXml("connectionStr", "dfsDb", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml"));

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
        /// 根据参数返回绑定数据的查询绑定数据
        /// </summary>
        /// <param name="fields">字段列表，英文逗号隔开</param>
        /// <param name="table">表名</param>
        /// <param name="where">条件列表</param>
        /// <returns>返回表</returns>
        public DataTable BindData(string fields,string table,string where)
        {
            if (string.IsNullOrEmpty(fields)||fields=="FIELDS")
            {
                return new DataTable();
            }
            if (string.IsNullOrEmpty(fields)||fields=="TABLE")
            {
                return new DataTable();
            }
            string wherePro = Common.Base64Convert.Base64Decode(where);
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select {0} from {1}", fields, table);
            if (!string.IsNullOrEmpty(wherePro)&&wherePro!="WHERE")
            {
                sql.AppendFormat(" where {0};", wherePro);
            }
            return DbEngine.QueryTable(sql.ToString());             
        }
    }
}
