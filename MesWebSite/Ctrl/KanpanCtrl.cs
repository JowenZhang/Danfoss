using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 看板控制类
    /// </summary>
    public class KanpanCtrl
    {
        /// <summary>
        /// 获取看板数据
        /// </summary>
        /// <returns>返回序列化后的看板信息</returns>
        public string GetKanpanData()
        {
            //数据库构建
            DAO.SqlServerHelper dbEngine = DAO.SqlServerHelper.CreateInstance(Common.ConfigHelper.GetConfigValueFromXml("connectionStr", "dfsDb", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesWebSiteConfig.xml"));

            //中间变量
            string res = string.Empty;
            object objTmp=null;
            int intTmp = 0;

            //获取计划数量
            string sql = "select sum(plan_qty) from mpo_plan where plan_date=@plan_date;";
            Dictionary<string,object> pms=new Dictionary<string,object>();
            pms.Add("@plan_date",DateTime.Now.Date.ToString("yyyy-MM-dd"));
            objTmp = dbEngine.QueryObj(sql, pms);
            res = (objTmp ?? "0").ToString();
            decimal dTmp = 0.0M;
            dTmp = decimal.TryParse(res, out dTmp) ? dTmp : 0.0M;
            intTmp=decimal.ToInt32(dTmp);
            string planQty = intTmp.ToString();

            //获取当日产量
            sql = "select distinct count(serial_no) from mes_fb_item where quality_no='QA01' and eqm_no=(select eqm_no from pdm_eqm where eqm_index=(select max(eqm_index) from pdm_eqm)) and fb_datetime >=@start_time and fb_datetime<=@end_time";
            pms.Clear();
            pms.Add("@start_time", DateTime.Now.Date);
            pms.Add("@end_time", DateTime.Now.Date + new TimeSpan(0, 23, 59, 59, 999));
            objTmp = dbEngine.QueryObj(sql, pms);
            res = (objTmp ?? "0").ToString();
            intTmp = int.TryParse(res, out intTmp) ? intTmp : 0;
            string productQty = intTmp.ToString();

            //获取产线停机时间
            sql = "select sum(datediff(MINUTE,case when submit_time<=@start_time then @start_time else submit_time end,case when reply_time>=@end_time then @end_time else reply_time end))from eqm_jam_record where ((submit_time between @start_time and @end_time) or (reply_time between @start_time and @end_time) or ( submit_time <= @start_time and  reply_time>=@end_time ));";
            objTmp = dbEngine.QueryObj(sql, pms);
            res = (objTmp ?? "0").ToString();
            intTmp = int.TryParse(res, out intTmp) ? intTmp : 0;
            string stopTime = intTmp.ToString();

            //获取看板具体信息
            sql = @"select pdm_eqm.eqm_no,pdm_eqm.eqm_status,adn.andon_type_name,adn.status_no from adn inner join (select pdm_eqm.eqm_no,max(adn.call_time) as call_time from adn right join pdm_eqm on adn.eqm_no=pdm_eqm.eqm_no group by pdm_eqm.eqm_no) as c on adn.call_time=c.call_time and adn.eqm_no=c.eqm_no right join pdm_eqm on adn.eqm_no=pdm_eqm.eqm_no order by pdm_eqm.eqm_index asc;
";
            DataTable adnList = dbEngine.QueryTable(sql);
            var data = new { planQty = planQty, productQty = productQty, stopTime = stopTime, adnList = adnList };
            return Common.JsonHelper.SerializeObject(data);
        }
    }
}
