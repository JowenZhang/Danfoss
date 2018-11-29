using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Ctrl
{
    /// <summary>
    /// 生产情况统计类
    /// </summary>
    public class StatisticCtrl
    {
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
        /// 统计当日良品数量
        /// </summary>
        /// <param name="eqmNo"></param>
        /// <returns>良品数</returns>
        public string CountTotalOkToday(string eqmNo)
        {
            DateTime dtStart = DateTime.Now.Date;
            DateTime dtEnd = DateTime.Now.Date + new TimeSpan(1, 0, 0, 0);
            string sql = "select distinct count(serial_no) from mes_fb_item where eqm_no=@eqm_no and (fb_datetime between @start_time and @end_time) and quality_no='QA01';";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@eqm_no", eqmNo);
            pms.Add("@start_time", dtStart);
            pms.Add("@end_time", dtEnd);
            object obj=DbEngine.QueryObj(sql, pms);
            return (obj ?? "0").ToString();
        }

        /// <summary>
        /// 统计当天不良品数量
        /// </summary>
        /// <param name="eqmNo"></param>
        /// <returns>不良数量</returns>
        public string CountTotalNgToday(string eqmNo)
        {
            DateTime dtStart = DateTime.Now.Date;
            DateTime dtEnd = DateTime.Now.Date + new TimeSpan(1, 0, 0, 0);
            string sql = "select distinct count(serial_no) from mes_fb_item where eqm_no=@eqm_no and (fb_datetime between @start_time and @end_time) and quality_no='QA04';";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@eqm_no", eqmNo);
            pms.Add("@start_time", dtStart);
            pms.Add("@end_time", dtEnd);
            object obj = DbEngine.QueryObj(sql, pms);
            return (obj ?? "0").ToString();
        }
        
        /// <summary>
        /// 根据生产订单号获得生产订单数
        /// </summary>
        /// <param name="mpoNo">生产订单号</param>
        /// <returns>返回生产订单数</returns>
        public string CountMpoQty(string mpoNo)
        {
            string sql = "select mpo_qty from mpo where mpo_no=@mpo_no;";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@mpo_no", mpoNo);
            object obj = DbEngine.QueryObj(sql, pms);
            int intTmp = 0;
            return (int.TryParse((obj ?? "0").ToString(), out intTmp) ? intTmp : 0).ToString();
        }

        /// <summary>
        /// 统计当站生产数量
        /// </summary>
        /// <param name="mpoNo">生产订单号</param>
        /// <param name="eqmNo">设备编号</param>
        /// <returns>返回生产订单数</returns>
        public string CountMpoQtyByEqm(string mpoNo, string eqmNo)
        {
            string sql = "select distinct count(serial_no) from mes_fb_item where eqm_no=@eqm_no and mpo_no=@mpo_no and quality_no='QA01';";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@eqm_no", eqmNo);
            pms.Add("@mpo_no", mpoNo);
            object obj = DbEngine.QueryObj(sql, pms);
            return (obj ?? "0").ToString();
        }
    }
}
