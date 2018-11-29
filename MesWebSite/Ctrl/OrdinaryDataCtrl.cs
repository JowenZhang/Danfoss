using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 一般数据控制类
    /// </summary>
    public class OrdinaryDataCtrl
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
        /// 根据序列号获取所有的序列号生产记录信息
        /// </summary>
        /// <param name="serialNo">序列号</param>
        /// <returns>记录信息表</returns>
        public DataTable GetProductRecordInfo(string serialNo)
        {
            if (string.IsNullOrEmpty(serialNo))
            {
                return null;
            }
            string sql = "select distinct a.serial_no,a.eqm_no,a.worker_name,a.crt_time,b.information,b.information_value from mes_fb_item a left join mes_fb_info b on a.serial_no=b.serial_no and a.eqm_no=b.eqm_no and a.crt_time=b.create_time where a.crt_time=b.create_time and a.serial_no=@serial_no order by a.serial_no asc,a.eqm_no asc;";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@serial_no", serialNo);
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                dt = DbEngine.QueryTable(sql, pms);
            }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }
    }
}
