using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// IR分析控制类
    /// </summary>
    public class IRAnalysisCtrl
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
        /// 私有方法，获取当前产线在某时间段的总产量
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>产量值</returns>
        private decimal GetIRProductQty(DateTime startTime, DateTime endTime)
        {
            string sql = "select distinct count(in_id) qty from mes_fb_item where fb_datetime between @startTime and @endTime and eqm_no=(select eqm_no from pdm_eqm where eqm_index=(select max(eqm_index) from pdm_eqm));";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@startTime", startTime);
            pms.Add("@endTime", endTime);
            decimal res = 0;
            string strTmp = string.Empty;
            try
            {
                strTmp=(DbEngine.QueryObj(sql,pms)??"0").ToString();
            }
            catch (Exception)
            {
                strTmp = "0";
            }
            res = decimal.TryParse(strTmp, out res) ? res : 0.0M;
            return res;
        }

        /// <summary>
        /// 私有方法，获取一段时间内各工站的不良数量
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>返回数据表</returns>
        private DataTable GetIRNgByEqm(DateTime startTime, DateTime endTime)
        {
            string sql = "select eqm_no,eqm_name,count(qa_record_no) as ng_qty from (select a.eqm_no,a.eqm_name,b.qa_record_no,b.qa_result_no,b.qa_result_name from pdm_eqm a left join (select * from qcm_qa_record where status_no='510' and qa_result_no is not null and  crt_time between @startTime and @endTime) b on a.eqm_no=b.eqm_no where 1=1) c group by eqm_no,eqm_name order by ng_qty desc,eqm_no;";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@startTime", startTime);
            pms.Add("@endTime", endTime);
            DataTable dt = new DataTable();
            try
            {
                dt = DbEngine.QueryTable(sql, pms);
            }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }

        /// <summary>
        /// 获取某一段时间内所有有不良的按天统计的不良统计表
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>统计结果表</returns>
        private DataTable GetNgQtyByEachDay(DateTime startTime, DateTime endTime)
        {
            string sql = "select distinct [Year],[Month],[Date],count(qa_record_no) qty from (select DATEPART(yyyy,crt_time) as [Year],DATEPART(mm,crt_time) as [Month],DATEPART(dd,crt_time) as [Date],qa_record_no from qcm_qa_record where status_no='510' and qa_result_no is not null and  crt_time between @startTime and @endTime) b Group by [Year],[Month],[Date] order by [Year],[Month],[Date];";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@startTime", startTime);
            pms.Add("@endTime", endTime);
            DataTable dt = new DataTable();
            try
            {
                dt = DbEngine.QueryTable(sql, pms);
            }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }

        /// <summary>
        /// 获取某一段时间内产量的日统计表
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>产量的日统计表</returns>
        private DataTable GetProductQtyByEachDay(DateTime startTime, DateTime endTime)
        {
            string sql = "select distinct [Year],[Month],[Date],count(in_id) qty from (select DATEPART(yyyy,fb_datetime) as [Year],DATEPART(mm,fb_datetime) as [Month],DATEPART(dd,fb_datetime) as [Date],in_id from mes_fb_item where eqm_no=(select eqm_no from pdm_eqm where eqm_index=(select max(eqm_index) from pdm_eqm)) and fb_datetime between @startTime and @endTime) d Group by [Year],[Month],[Date] order by [Year],[Month],[Date];";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@startTime", startTime);
            pms.Add("@endTime", endTime);
            DataTable dt = new DataTable();
            try
            {
                dt = DbEngine.QueryTable(sql, pms);
            }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }

        /// <summary>
        /// 获取切割不良数量
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>切割不良数量</returns>
        private decimal GetCutNgQty(DateTime startTime,DateTime endTime)
        {
            string sql = "select * from qcm_qa_record where qa_result_no='QR04' and crt_time between @startTime and @endTime;";
            Dictionary<string, object> pms = new Dictionary<string, object>();
            pms.Add("@startTime", startTime);
            pms.Add("@endTime", endTime);
            decimal res = 0;
            string strTmp = string.Empty;
            try
            {
                strTmp=(DbEngine.QueryObj(sql,pms)??"0").ToString();
            }
            catch (Exception)
            {
                strTmp = "0";
            }
            res = decimal.TryParse(strTmp, out res) ? res : 0.0M;
            return res;
        }

        /// <summary>
        /// 按天统计某个时间段的IR值
        /// </summary>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <param name="totalProductQty">总产量</param>
        /// <param name="IRRate">IR比率（纵坐标%）</param>
        /// <returns>日期（横坐标）</returns>
        public List<string> GetIREachDay(DateTime startTime,DateTime endTime,out decimal totalProductQty,out List<decimal> IRRate)
        {
            DataTable dtNgEachDay = GetNgQtyByEachDay(startTime, endTime);
            if (dtNgEachDay==null)
            {
                IRRate = new List<decimal>();
                totalProductQty = 0;
                return new List<string>();
            }
            DataTable dtProductQtyEachDay = GetProductQtyByEachDay(startTime, endTime);
            if (dtProductQtyEachDay==null)
            {
                IRRate = new List<decimal>();
                totalProductQty = 0;
                return new List<string>();
            }
            List<DataRow> rowsNgEachDay = dtNgEachDay.AsEnumerable().ToList();
            List<DataRow> rowsProductQtyEachDay = dtProductQtyEachDay.AsEnumerable().ToList();
            List<string> res = new List<string>();
            IRRate = new List<decimal>();
            totalProductQty=rowsProductQtyEachDay.Sum(a => decimal.Parse(a.Field<int>("qty").ToString()));
            while (startTime.Date <= endTime.Date)
            {
                int year = startTime.Year;
                int month = startTime.Month;
                int day = startTime.Day;
                decimal ngSumDay = rowsNgEachDay.FindAll(a => (a.Field<int>("Year") == year && a.Field<int>("Month") == month && a.Field<int>("Date") == day)).ToList().Sum(a => decimal.Parse(a.Field<int>("qty").ToString()));
                decimal productQtySumDay = rowsProductQtyEachDay.FindAll(a => (a.Field<int>("Year") == year && a.Field<int>("Month") == month && a.Field<int>("Date") == day)).ToList().Sum(a => decimal.Parse(a.Field<int>("qty").ToString()));
                res.Add(string.Format("{0}-{1}-{2}",year.ToString(),month.ToString(),day.ToString()));
                IRRate.Add(productQtySumDay<=0?0M:Math.Round(ngSumDay/productQtySumDay*100,6));
                startTime = startTime.Add(new TimeSpan(1, 0, 0, 0));
            }
            return res;
        }

        /// <summary>
        /// 统计某段时间内每个工站的IR值
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="totalNgQty">不良数合计（第一纵坐标%）</param>
        /// <param name="IRRate">工站IR比例（第一纵坐标%）</param>
        /// <param name="IRRate">累计工站IR比例（第二纵坐标%）</param>
        /// <returns>工站名称（横坐标）</returns>
        public List<string> GetIREachEqm(DateTime startTime, DateTime endTime, out decimal totalNgQty,out List<decimal> IRRate, out List<decimal> IRGainRate)
        {
            decimal productQty = GetIRProductQty(startTime, endTime);
            if (productQty <= 0)
            {
                IRRate = new List<decimal>();
                IRGainRate = new List<decimal>();
                totalNgQty = 0M;
                return new List<string>();
            }
            DataTable dtNgQtyByEqm = GetIRNgByEqm(startTime, endTime);
            if (dtNgQtyByEqm==null)
            {
                IRRate = new List<decimal>();
                IRGainRate = new List<decimal>();
                totalNgQty = 0M;
                return new List<string>();
            }
            List<DataRow> rowsNgQtyByEqm = dtNgQtyByEqm.AsEnumerable().ToList();
            List<string> res=new List<string>();
            IRRate=new List<decimal>();
            IRGainRate=new List<decimal>();
            int ngGain = 0;
            int totalNg=rowsNgQtyByEqm.Sum(a=>a.Field<int>("ng_qty"));
            totalNgQty = totalNg * 1.0M;
            foreach (DataRow item in rowsNgQtyByEqm)
            {
                ngGain += item.Field<int>("ng_qty");
                res.Add(item.Field<string>("eqm_name"));
                IRRate.Add(Math.Round(item.Field<int>("ng_qty") * 100 / productQty,6));
                IRGainRate.Add(totalNg==0?0.00M:Math.Round(ngGain*100/totalNg*1.0M,6));
            }
            return res;
        }

        /// <summary>
        /// 获取某一段时间的IR分析数据
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>IR分析数据视图</returns>
        public ModelView.DataAnalysisIRView CalculateIR(DateTime startTime, DateTime endTime)
        {
            if (startTime>=endTime)
            {
                return null;
            }
            decimal totalNgQty = 0;
            List<decimal> eqmIrRate = new List<decimal>();
            List<decimal> eqmIrGainRate = new List<decimal>();
            decimal totalProductQty=0;
            List<decimal> dailyIrRate = new List<decimal>();
            List<string> eqmName = GetIREachEqm(startTime, endTime, out totalNgQty, out eqmIrRate, out eqmIrGainRate);
            List<string> dailyName=GetIREachDay(startTime,endTime,out totalProductQty,out dailyIrRate);
            decimal cutQty = GetCutNgQty(startTime, endTime);
            ModelView.DataAnalysisIRView res = new ModelView.DataAnalysisIRView();
            res.eqmIrTitle = string.Format("{0}至{1}每工站IR分析", startTime.Date.ToString("yyyy-MM-dd"), endTime.Date.ToString("yyyy-MM-dd"));
            res.eqmxAxisValue = eqmName;
            res.eqmyAxisSingleValue = eqmIrRate;
            res.eqmyAxisGainValue = eqmIrGainRate;
            res.eqmIrxAxisName = "工站";
            res.eqmIryAxisSingleName = "百分比%";
            res.eqmIryAxisGainName = "各站累计百分比%";
            res.eqmIrBottomTitle=string.Format("IR:{0}%\t不良数量:{1}\t产量:{2}\t切割数量:{3}",Math.Round(totalNgQty/totalProductQty*100M,6).ToString(),totalNgQty.ToString(),totalProductQty.ToString(),cutQty.ToString());
            res.dailyIrTitle = string.Format("{0}至{1}每日IR分析", startTime.Date.ToString("yyyy-MM-dd"), endTime.Date.ToString("yyyy-MM-dd"));
            res.dailyIrxAxisName = "日期";
            res.dailyIryAxisName = "百分比%";
            res.dailyxAxisValue = dailyName;
            res.dailyyAxisValue = dailyIrRate;
            return res;
        }
    }
}
