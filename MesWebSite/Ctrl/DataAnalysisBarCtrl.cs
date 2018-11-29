using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 数据分析控制类
    /// </summary>
    public class DataAnalysisBarCtrl
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
        /// 获取起止时间内的以产品序列号分析后的产量结果
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns>结果数据集合</returns>
        private List<ModelView.DataAnalysisValuePairView> GetProductQtyByPartNo(DateTime startTime, DateTime endTime)
        {
            string sql = "select distinct part_no,count(serial_no) Qty from mes_fb_item where (fb_datetime between @startTime and @endTime) and eqm_no=(select eqm_no from pdm_eqm where eqm_index=(select max(eqm_index) from pdm_eqm)) group by part_no order by part_no desc;";
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
                return null;
            }
            List<ModelView.DataAnalysisValuePairView> list = new List<ModelView.DataAnalysisValuePairView>();
            foreach (DataRow item in dt.Rows)
            {
                ModelView.DataAnalysisValuePairView model = new ModelView.DataAnalysisValuePairView();
                try
                {
                    decimal numbers = Math.Round((item.Field<int>("Qty") / 1.0M), 2);
                    model.xAxis_value = item.Field<string>("part_no");
                    model.yAxis_value = numbers.ToString();
                }
                catch (Exception)
                {
                    continue;
                }
                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 获取起止时间内的以时间分析后的产量结果
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="timeSpacy">时间精度</param>
        /// <returns>结果数据集合</returns>
        private List<ModelView.DataAnalysisValuePairView> GetProductQtyByTime(DateTime startTime, DateTime endTime, string timeSpacy)
        {
            string sql = "select distinct datepart(yyyy,fb_datetime)[Year],datepart(mm,fb_datetime)[Month],datepart(dd,fb_datetime)[Date],datepart(hh,fb_datetime)[Hour],datepart(mi,fb_datetime) [Minute],count(serial_no) [Qty] from mes_fb_item where (fb_datetime between @startTime and @endTime) and eqm_no=(select eqm_no from pdm_eqm where eqm_index=(select max(eqm_index) from pdm_eqm)) group by datepart(yyyy,fb_datetime),datepart(mm,fb_datetime),datepart(dd,fb_datetime),datepart(hh,fb_datetime),datepart(mi,fb_datetime) order by datepart(yyyy,fb_datetime) asc,datepart(mm,fb_datetime) asc,datepart(dd,fb_datetime) asc,datepart(hh,fb_datetime) asc,datepart(mi,fb_datetime) asc;";
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
                return null;
            }
            List<ModelView.DataAnalysisValuePairView> list = new List<ModelView.DataAnalysisValuePairView>();
            DateTime dtStart = GetNextTimeSpot(startTime, timeSpacy);
            List<DataRow> listRows = dt.AsEnumerable().ToList();
            while (dtStart <= endTime)
            {
                ModelView.DataAnalysisValuePairView model = new ModelView.DataAnalysisValuePairView();
                int year = dtStart.Date.Year;
                int month = dtStart.Date.Month;
                int date = dtStart.Date.Day;
                int hour = dtStart.TimeOfDay.Hours;
                int minute = dtStart.TimeOfDay.Minutes;
                decimal decimalTmp = 0;
                try
                {
                    if (timeSpacy.ToLower() == "month")
                    {
                        model.xAxis_value = year.ToString() + "-" + month.ToString();
                        decimalTmp = listRows.FindAll(a => a.Field<int>("Year") == year && a.Field<int>("Month") == month).Sum(a => a.Field<int>("Qty"));

                    }
                    else if (timeSpacy.ToLower() == "date")
                    {
                        model.xAxis_value = year.ToString() + "-" + month.ToString() + "-" + date.ToString();
                        decimalTmp = listRows.FindAll(a => a.Field<int>("Year") == year && a.Field<int>("Month") == month && a.Field<int>("Date") == date).Sum(a => a.Field<int>("Qty"));
                    }
                    else if (timeSpacy.ToLower() == "hour")
                    {
                        model.xAxis_value = year.ToString() + "-" + month.ToString() + "-" + date.ToString() + " " + hour.ToString()+":00:00";
                        decimalTmp = listRows.FindAll(a => a.Field<int>("Year") == year && a.Field<int>("Month") == month && a.Field<int>("Date") == date && a.Field<int>("Hour") == hour).Sum(a => a.Field<int>("Qty"));
                    }
                    else if (timeSpacy.ToLower() == "minute")
                    {
                        model.xAxis_value = year.ToString() + "-" + month.ToString() + "-" + date.ToString() + " " + hour.ToString() + ":" + minute.ToString()+":00";
                        decimalTmp = listRows.FindAll(a => a.Field<int>("Year") == year && a.Field<int>("Month") == month && a.Field<int>("Date") == date && a.Field<int>("Hour") == hour && a.Field<int>("Minute") == minute).Sum(a => a.Field<int>("Qty"));
                    }
                }
                catch (Exception)
                {
                    dtStart = GetNextTimeSpot(dtStart, timeSpacy);
                    continue;
                }
                model.yAxis_value = Math.Round(decimalTmp, 2).ToString();
                list.Add(model);
                dtStart = GetNextTimeSpot(dtStart, timeSpacy);
            }
            return list;
        }


        /// <summary>
        /// 获取起止时间内的以产品序列号分析后的质量不良结果
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns>结果数据表</returns>
        private List<ModelView.DataAnalysisValuePairView> GetQcmQaNgByPartNo(DateTime startTime, DateTime endTime)
        {
            string sql = "select distinct part_no,count(serial_no) Qty from (select distinct a.serial_no,a.submit_time,b.part_no from qcm_qa_record a left join mes_fb_item b on a.serial_no=b.serial_no) as t where (submit_time between @startTime and @endTime) group by part_no order by Qty desc,part_no desc;";
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
                return null;
            }
            List<ModelView.DataAnalysisValuePairView> list = new List<ModelView.DataAnalysisValuePairView>();
            foreach (DataRow item in dt.Rows)
            {
                ModelView.DataAnalysisValuePairView model = new ModelView.DataAnalysisValuePairView();
                try
                {
                    decimal numbers = Math.Round((item.Field<int>("Qty") / 1.0M), 2);
                    model.xAxis_value = item.Field<string>("part_no");
                    model.yAxis_value = numbers.ToString();
                }
                catch (Exception)
                {
                    continue;
                }
                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 获取起止时间内的以时间分析后的质量不良结果
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>结果数据表</returns>
        private List<ModelView.DataAnalysisValuePairView> GetQcmQaNgByTime(DateTime startTime, DateTime endTime, string timeSpacy)
        {
            string sql = "select distinct datepart(yyyy,submit_time)[Year],datepart(mm,submit_time)[Month],datepart(dd,submit_time)[Date],datepart(hh,submit_time)[Hour],datepart(mi,submit_time) [Minute],count(serial_no) [Qty] from (select distinct a.serial_no,a.submit_time,b.part_no from qcm_qa_record a left join mes_fb_item b on a.serial_no=b.serial_no) as t where (submit_time between @startTime and @endTime) group by datepart(yyyy,submit_time),datepart(mm,submit_time),datepart(dd,submit_time),datepart(hh,submit_time),datepart(mi,submit_time) order by datepart(yyyy,submit_time) asc,datepart(mm,submit_time) asc,datepart(dd,submit_time) asc,datepart(hh,submit_time) asc,datepart(mi,submit_time) asc;";
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
                return null;
            }
            List<ModelView.DataAnalysisValuePairView> list = new List<ModelView.DataAnalysisValuePairView>();
            DateTime dtStart = GetNextTimeSpot(startTime, timeSpacy);
            List<DataRow> listRows = dt.AsEnumerable().ToList();
            while (dtStart <= endTime)
            {
                ModelView.DataAnalysisValuePairView model = new ModelView.DataAnalysisValuePairView();
                int year = dtStart.Date.Year;
                int month = dtStart.Date.Month;
                int date = dtStart.Date.Day;
                int hour = dtStart.TimeOfDay.Hours;
                int minute = dtStart.TimeOfDay.Minutes;
                decimal decimalTmp = 0;
                try
                {
                    if (timeSpacy.ToLower() == "month")
                    {
                        model.xAxis_value = year.ToString() + "-" + month.ToString();
                        decimalTmp = listRows.FindAll(a => a.Field<int>("Year") == year && a.Field<int>("Month") == month).Sum(a => a.Field<int>("Qty"));

                    }
                    else if (timeSpacy.ToLower() == "date")
                    {
                        model.xAxis_value = year.ToString() + "-" + month.ToString() + "-" + date.ToString();
                        decimalTmp = listRows.FindAll(a => a.Field<int>("Year") == year && a.Field<int>("Month") == month && a.Field<int>("Date") == date).Sum(a => a.Field<int>("Qty"));
                    }
                    else if (timeSpacy.ToLower() == "hour")
                    {
                        model.xAxis_value = year.ToString() + "-" + month.ToString() + "-" + date.ToString() + " " + hour.ToString()+":00:00";
                        decimalTmp = listRows.FindAll(a => a.Field<int>("Year") == year && a.Field<int>("Month") == month && a.Field<int>("Date") == date && a.Field<int>("Hour") == hour).Sum(a => a.Field<int>("Qty"));
                    }
                    else if (timeSpacy.ToLower() == "minute")
                    {
                        model.xAxis_value = year.ToString() + "-" + month.ToString() + "-" + date.ToString() + " " + hour.ToString() + ":" + minute.ToString()+":00";
                        decimalTmp = listRows.FindAll(a => a.Field<int>("Year") == year && a.Field<int>("Month") == month && a.Field<int>("Date") == date && a.Field<int>("Hour") == hour && a.Field<int>("Minute") == minute).Sum(a => a.Field<int>("Qty"));
                    }
                }
                catch (Exception)
                {
                    dtStart = GetNextTimeSpot(dtStart, timeSpacy);
                    continue;
                }

                model.yAxis_value = Math.Round(decimalTmp, 2).ToString();
                list.Add(model);
                dtStart = GetNextTimeSpot(dtStart, timeSpacy);
            }
            return list;
        }

        /// <summary>
        /// 根据停机原因统计设备停机时间
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>设备停机时间记录，秒级</returns>
        private List<ModelView.DataAnalysisValuePairView> GetEqmJamTimeByCause(DateTime startTime, DateTime endTime)
        {
            string sql = "select jam_cause_name,sum(DATEDIFF(ss,submit_time,reply_time)) as [time] from eqm_jam_record where reply_time is not null and (reply_time between @startTime and @endTime) and (submit_time between @startTime and @endTime) group by jam_cause_name order by [time] desc;";
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
                return null;
            }
            List<ModelView.DataAnalysisValuePairView> list = new List<ModelView.DataAnalysisValuePairView>();
            foreach (DataRow item in dt.Rows)
            {
                ModelView.DataAnalysisValuePairView model = new ModelView.DataAnalysisValuePairView();
                try
                {
                    decimal numbers = Math.Round((item.Field<int>("time") / 60.0M), 2);
                    model.xAxis_value = item.Field<string>("jam_cause_name");
                    model.yAxis_value = numbers.ToString();
                }
                catch (Exception)
                {
                    continue;
                }
                list.Add(model);
            }
            return list;
        }

        

        /// <summary>
        /// 根据停机时间统计设备停机时间的原始数据
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="timeSpacy">时间精度</param>
        /// <returns>设备停机时间初始数据</returns>
        private List<ModelView.DataAnalysisValuePairView> GetEqmJamTimeByTime(DateTime startTime, DateTime endTime, string timeSpacy)
        {
            string sql = "select reply_time,submit_time from eqm_jam_record where reply_time is not null and (reply_time between @startTime and @endTime) and (submit_time between @startTime and @endTime) order by reply_time asc;";
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
                return null;
            }
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            DataTable dtTmp = new DataTable();
            DataColumn dc1 = new DataColumn("Year");
            DataColumn dc2 = new DataColumn("Month");
            DataColumn dc3 = new DataColumn("Date");
            DataColumn dc4 = new DataColumn("Hour");
            DataColumn dc5 = new DataColumn("Minute");
            DataColumn dc6 = new DataColumn("Time");
            dtTmp.Columns.Add(dc1);
            dtTmp.Columns.Add(dc2);
            dtTmp.Columns.Add(dc3);
            dtTmp.Columns.Add(dc4);
            dtTmp.Columns.Add(dc5);
            dtTmp.Columns.Add(dc6);
            DateTime dtStart = startTime;
            DateTime dtEnd = GetNextTimeSpot(dtStart, timeSpacy);
            List<DataRow> dtRows = dt.AsEnumerable().ToList();
            while (dtEnd <= endTime)
            {
                DataRow dr = dtTmp.NewRow();
                dr["Year"] = dtStart.Year;
                dr["Month"] = dtStart.Month;
                dr["Date"] = dtStart.Day;
                dr["Hour"] = dtStart.Hour;
                dr["Minute"] = dtStart.Minute;
                dr["Time"] = CalculateTime(dtRows, dtStart, dtEnd);//精确到分钟后小数点2位
                dtStart = GetNextTimeSpot(dtStart, timeSpacy);
                dtEnd = GetNextTimeSpot(dtEnd, timeSpacy);
                dtTmp.Rows.Add(dr);
            }
            List<ModelView.DataAnalysisValuePairView> list = new List<ModelView.DataAnalysisValuePairView>();
            List<DataRow> listRows = dtTmp.AsEnumerable().ToList();
            dtStart = startTime;
            while (dtStart <= endTime)
            {
                ModelView.DataAnalysisValuePairView model = new ModelView.DataAnalysisValuePairView();
                string year = dtStart.Date.Year.ToString();
                string month = dtStart.Date.Month.ToString();
                string date = dtStart.Date.Day.ToString();
                string hour = dtStart.TimeOfDay.Hours.ToString();
                string minute = dtStart.TimeOfDay.Minutes.ToString();
                decimal decimalTmp = 0;
                try
                {
                    if (timeSpacy.ToLower() == "month")
                    {
                        model.xAxis_value = year.ToString() + "-" + month.ToString();
                        decimalTmp = listRows.FindAll(a => a.Field<string>("Year") == year && a.Field<string>("Month") == month).Sum(a => decimal.Parse(a.Field<string>("Time")));
                    }
                    else if (timeSpacy.ToLower() == "date")
                    {
                        model.xAxis_value = year.ToString() + "-" + month.ToString() + "-" + date.ToString();
                        decimalTmp = listRows.FindAll(a => a.Field<string>("Year") == year && a.Field<string>("Month") == month && a.Field<string>("Date") == date).Sum(a => decimal.Parse(a.Field<string>("Time")));
                    }
                    else if (timeSpacy.ToLower() == "hour")
                    {
                        model.xAxis_value = year.ToString() + "-" + month.ToString() + "-" + date.ToString() + " " + hour.ToString()+":00:00";
                        decimalTmp = listRows.FindAll(a => a.Field<string>("Year") == year && a.Field<string>("Month") == month && a.Field<string>("Date") == date && a.Field<string>("Hour") == hour).Sum(a => decimal.Parse(a.Field<string>("Time")));
                    }
                    else if (timeSpacy.ToLower() == "minute")
                    {
                        model.xAxis_value = year.ToString() + "-" + month.ToString() + "-" + date.ToString() + " " + hour.ToString() + ":" + minute.ToString()+":00";
                        decimalTmp = listRows.FindAll(a => a.Field<string>("Year") == year && a.Field<string>("Month") == month && a.Field<string>("Date") == date && a.Field<string>("Hour") == hour && a.Field<string>("Minute") == minute).Sum(a => decimal.Parse(a.Field<string>("Time")));
                    }
                }
                catch (Exception)
                {
                    dtStart = GetNextTimeSpot(dtStart, timeSpacy);
                    continue;
                }

                model.yAxis_value = Math.Round(decimalTmp, 2).ToString();
                list.Add(model);
                dtStart = GetNextTimeSpot(dtStart, timeSpacy);
            }
            return list;
        }

        /// <summary>
        /// 根据时间精度和基础时间点获取下一个时间点
        /// </summary>
        /// <param name="dtBase">基础时间点</param>
        /// <param name="timeSpacy">时间精度</param>
        /// <returns>下一个时间点</returns>
        private DateTime GetNextTimeSpot(DateTime dtBase, string timeSpacy)
        {
            switch (timeSpacy)
            {
                case "month":
                    return dtBase.AddMonths(1);
                case "date":
                    return dtBase.AddDays(1);
                case "hour":
                    return dtBase.AddHours(1);
                case "minute":
                    return dtBase.AddMinutes(1);
                default:
                    return dtBase;
            }
        }

        /// <summary>
        /// 计算传入的行列表中所有的时间交集之和，以秒计算
        /// </summary>
        /// <param name="dtRows"></param>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        private decimal CalculateTime(List<DataRow> dtRows, DateTime dtStart, DateTime dtEnd)
        {
            decimal res = 0;
            long tmp = 0;
            foreach (DataRow item in dtRows)
            {
                DateTime startTime = item.Field<DateTime>("submit_time");
                DateTime endTime = item.Field<DateTime>("reply_time");
                DateTime dtS = startTime > dtStart ? startTime : dtStart;
                DateTime dtE = endTime > dtEnd ? dtEnd : endTime;
                int tmp1 = (dtE - dtS).TotalSeconds > 0 ? (int)(dtE - dtS).TotalSeconds : 0;
                tmp = tmp + tmp1;
            }
            res = Math.Round((tmp / 60.0M), 2);
            return res;
        }

        /// <summary>
        /// 依据分析目标、分析精度和分析时间处理数据
        /// </summary>
        /// <param name="analysisItem">分析项目</param>
        /// <param name="analysisDestiny">分析维度</param>
        /// <param name="timeSpacy">时间精度</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>处理完毕的数据</returns>
        public ModelView.DataAnalysisBarView GetDataAnalysis(string analysisItem, string analysisDestiny, string timeSpacy, DateTime startTime, DateTime endTime, int pageSize, int pageIndex)
        {
            ModelView.DataAnalysisBarView res = new ModelView.DataAnalysisBarView();
            string strTimeTmp = string.Empty;
            switch (timeSpacy)
            {
                case "month":
                    strTimeTmp = "月";
                    break;
                case "date":
                    strTimeTmp = "日";
                    break;
                case "hour":
                    strTimeTmp = "小时";
                    break;
                case "minute":
                    strTimeTmp = "分钟";
                    break;
            }
            switch (analysisItem)
            {
                case "001":
                    switch (analysisDestiny)
                    {
                        case "D001":
                            res.title_text = string.Format("{0}至{1}{2}产量分析", startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"), strTimeTmp);
                            res.xAxis_name = "时间";
                            res.yAxis_name = "数量";
                            res.Rows = new List<ModelView.DataAnalysisValuePairView>();
                            res.Rows = GetProductQtyByTime(startTime, endTime, timeSpacy);
                            res.Count = res.Rows.Count();
                            res.Rows = res.Rows.OrderBy(a => DateTime.Parse(a.xAxis_value)).ToList();
                            break;
                        case "D002":
                            res.title_text = string.Format("{0}至{1}{2}产量分析", startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"), "型号-");
                            res.xAxis_name = "型号";
                            res.yAxis_name = "数量";
                            res.Rows = new List<ModelView.DataAnalysisValuePairView>();
                            res.Rows = GetProductQtyByPartNo(startTime, endTime);
                            res.Count = res.Rows.Count();
                            res.Rows = res.Rows.OrderBy(a => decimal.Parse(a.yAxis_value)).Reverse().ToList();
                            break;
                        default:
                            res = new ModelView.DataAnalysisBarView();
                            res.Rows = new List<ModelView.DataAnalysisValuePairView>();
                            break;
                    }
                    break;
                case "002":
                    switch (analysisDestiny)
                    {
                        case "D001":
                            res.title_text = string.Format("{0}至{1}{2}不良分析", startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"), strTimeTmp);
                            res.xAxis_name = "时间";
                            res.yAxis_name = "数量";
                            res.Rows = new List<ModelView.DataAnalysisValuePairView>();
                            res.Rows = GetQcmQaNgByTime(startTime, endTime, timeSpacy);
                            res.Count = res.Rows.Count();
                            res.Rows = res.Rows.OrderBy(a => DateTime.Parse(a.xAxis_value)).ToList();
                            break;
                        case "D002":
                            res.title_text = string.Format("{0}至{1}{2}不良分析", startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"), "型号-");
                            res.xAxis_name = "时间";
                            res.yAxis_name = "数量";
                            res.Rows = new List<ModelView.DataAnalysisValuePairView>();
                            res.Rows = GetQcmQaNgByPartNo(startTime, endTime);
                            res.Count = res.Rows.Count();
                            res.Rows = res.Rows.OrderBy(a => decimal.Parse(a.yAxis_value)).Reverse().ToList();
                            break;
                        default:
                            res = new ModelView.DataAnalysisBarView();
                            res.Rows = new List<ModelView.DataAnalysisValuePairView>();
                            break;
                    }
                    break;
                case "003":
                    switch (analysisDestiny)
                    {
                        case "D001":
                            res.title_text = string.Format("{0}至{1}{2}停机分析", startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"), strTimeTmp);
                            res.xAxis_name = "时间";
                            res.yAxis_name = "分钟";
                            res.Rows = new List<ModelView.DataAnalysisValuePairView>();
                            res.Rows = GetEqmJamTimeByTime(startTime, endTime, timeSpacy);
                            res.Count = res.Rows.Count();
                            res.Rows = res.Rows.OrderBy(a => DateTime.Parse(a.xAxis_value)).ToList();
                            break;
                        case "D003":
                            res.title_text = string.Format("{0}至{1}{2}停机分析", startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"), "停机原因-");
                            res.xAxis_name = "时间";
                            res.yAxis_name = "分钟";
                            res.Rows = new List<ModelView.DataAnalysisValuePairView>();
                            res.Rows = GetEqmJamTimeByCause(startTime, endTime);
                            res.Count = res.Rows.Count();
                            res.Rows = res.Rows.OrderBy(a => decimal.Parse(a.yAxis_value)).Reverse().ToList();
                            break;
                        default:
                            res = new ModelView.DataAnalysisBarView();
                            res.Rows = new List<ModelView.DataAnalysisValuePairView>();
                            break;
                    }
                    break;
                default:
                    res = new ModelView.DataAnalysisBarView();
                    res.Rows = new List<ModelView.DataAnalysisValuePairView>();
                    break;
            }
            List<string> xAxis = res.Rows.Select(a => a.xAxis_value).ToList(); 
            List<string> yAxis = res.Rows.Select(a => a.yAxis_value).ToList();
            res.xAxis_data = xAxis;
            res.yAxis_data = yAxis;
            return res;
        }

        /// <summary>
        /// 创建数据分析结果表格
        /// </summary>
        /// <param name="analysisItem">分析项目</param>
        /// <param name="analysisDestiny">分析维度（目标）</param>
        /// <param name="timeSpacy">时间精度</param>
        /// <returns>返回空表</returns>
        private DataTable CreateResultDataTable(string analysisItem, string analysisDestiny, string timeSpacy)
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("horizontal");
            DataColumn dc2 = new DataColumn("vertical");
            if (analysisItem == "001")
            {
                if (analysisDestiny == "D001")
                {
                    dc1.Caption = CreateTimeSpaceString(timeSpacy);
                }
                else if (analysisDestiny == "D002")
                {
                    dc1.Caption = "型号";
                }
                else
                {
                    dc1.Caption = string.Empty;
                }
                dc2.Caption = "产量(Pcs)";
            }
            else if (analysisItem == "002")
            {
                if (analysisDestiny == "D001")
                {
                    dc1.Caption = CreateTimeSpaceString(timeSpacy);
                }
                else if (analysisDestiny == "D002")
                {
                    dc1.Caption = "型号";
                }
                else
                {
                    dc1.Caption = string.Empty;
                }
                dc2.Caption = "不良(Pcs)";
            }
            else if (analysisItem == "003")
            {
                if (analysisDestiny == "D001")
                {
                    dc1.Caption = CreateTimeSpaceString(timeSpacy);
                }
                else if (analysisDestiny == "D002")
                {
                    dc1.Caption = "停机原因";
                }
                else
                {
                    dc1.Caption = string.Empty;
                }
                dc2.Caption = "时长(Min)";
            }
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Rows.Clear();
            return dt;
        }

        /// <summary>
        /// 根据时间精度处理成时间字符串
        /// </summary>
        /// <param name="timeSpacy">时间精度</param>
        /// <returns>时间字符串</returns>
        private string CreateTimeSpaceString(string timeSpacy)
        {
            switch (timeSpacy)
            {
                case "month":
                    return "月份";
                case "date":
                    return "日期";
                case "hour":
                    return "小时";
                case "minute":
                    return "分钟";
                default:
                    return string.Empty;
            }
        }
    }
}
