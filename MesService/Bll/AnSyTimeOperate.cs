using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bll
{
    /// <summary>
    /// 异步时间控制器，负责启动不同的任务
    /// </summary>
    public class AnSyTimeOperate
    {
        /// <summary>
        /// 公有构造函数
        /// </summary>
        public AnSyTimeOperate()
        {
            //事件绑定
            _myTimer.Elapsed += _myTimer_Elapsed;
        }

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
        /// 私有字段，通用计时器
        /// </summary>
        private System.Timers.Timer _myTimer = new System.Timers.Timer(10  *1000);

        /// <summary>
        /// 私有字段，记录是否首次运行进程或软件
        /// </summary>
        private bool _isFirstStart = true;

        /// <summary>
        /// 私有字段，记录上次循环时间
        /// </summary>
        private DateTime _lastCycleTime = DateTime.Now;

        /// <summary>
        /// 私有字段，记录上次运行新进程时间
        /// </summary>
        private DateTime _lastRunTime = DateTime.Now;
        
        /// <summary>
        /// 公有方法，外部调用，启动通用计时器
        /// </summary>
        public void StartTimer()
        {            
            _myTimer.Start();
        }

        /// <summary>
        /// 私有方法，通用计时器的计时函数
        /// </summary>
        /// <param name="sender">该事件的所属对象</param>
        /// <param name="e">触发该事件时的时间参数</param>
        private void _myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _myTimer.Stop();
            DateTime dtEvent = e.SignalTime;//事件事件
            TimeTrigger(dtEvent);
            _myTimer.Start();
        }

        /// <summary>
        /// 公有方法，时间触发器
        /// </summary>
        /// <param name="dtEvent">事件触发事件</param>
        public void TimeTrigger(DateTime dtEvent)
        {
            if (_isFirstStart)
            {
                _lastRunTime = dtEvent;
                _lastCycleTime = dtEvent;
                _isFirstStart = false;
            }
            double lastRunSecond = _lastCycleTime.TimeOfDay.TotalSeconds;
            double eventSecond = dtEvent.TimeOfDay.TotalSeconds;
            if (_lastCycleTime.Date != dtEvent.Date)
            {
                eventSecond += 60 * 60 * 3600;
            }
            int diffDays = (dtEvent.Date - _lastRunTime.Date).Days;
            TriggerFunction(dtEvent, "download_plan_time_spot", lastRunSecond, eventSecond, diffDays, FetchPlanFromItServer);
            TriggerFunction(dtEvent, "download_data_time_spot", lastRunSecond, eventSecond, diffDays, SyncDataFromItServer);
        }

        /// <summary>
        /// 触发器函数，事件触发器触发执行
        /// </summary>
        /// <param name="dtEvent">触发器函数</param>
        /// <param name="setName"></param>
        /// <param name="lastRunSecond"></param>
        /// <param name="eventSecond"></param>
        /// <param name="diffDays"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        private string TriggerFunction(DateTime dtEvent, string setName, double lastRunSecond, double eventSecond, int diffDays,Func<string> function)
        {
            string res = string.Empty;
            //download_plan_time_spot
            string planTimeSpots = GetSetValueByName(setName);
            List<DateTime> dt = ProcessTimeSpots(planTimeSpots);
            bool needRun = dt.Where(a => a.TimeOfDay.TotalSeconds >= lastRunSecond && a.TimeOfDay.TotalSeconds <= eventSecond).ToList().Count > 0;
            if (needRun)
            {
                if (setName == "download_plan_time_spot")
                {
                    string daysDistant = GetSetValueByName("download_plan_time_distant");
                    int daysDistantInt = int.TryParse(daysDistant, out daysDistantInt) ? daysDistantInt : 0;
                    if (diffDays == daysDistantInt)
                    {
                        res=function();
                    }
                }
                else
                {
                    res=function();
                }
                _lastRunTime = dtEvent;
            }
            _lastCycleTime = dtEvent;
            return res;
        }


        /// <summary>
        /// 从It服务器异步获取数据
        /// </summary>
        private string FetchPlanFromItServer()
        {
            string res = string.Empty;
            try
            {
                Bll.FetchPlanFromGroup fetchPlan = new FetchPlanFromGroup();
                ThreadPool.QueueUserWorkItem(fetchPlan.FetchMpo);                
                res = "success";
            }
            catch (Exception)
            {
                res = "fail";
            }
            return res;
        }

        /// <summary>
        /// 从It服务器异步同步数据
        /// </summary>
        private string SyncDataFromItServer()
        {
            string res = string.Empty;
            try
            {
                Bll.DataImportSync dataImportSync = new Bll.DataImportSync();
                ThreadPool.QueueUserWorkItem(dataImportSync.SyncLocalData);
                res = "success";
            }
            catch (Exception)
            {
                res = "fail";
            }
            return res;
        }

        /// <summary>
        /// 将时间设定值转化为时间节点列表
        /// </summary>
        /// <param name="timeSetStr">时间设定字符串</param>
        /// <returns>时间节点列表</returns>
        private List<DateTime> ProcessTimeSpots(string timeSetStr)
        {
            List<DateTime> res = new List<DateTime>();
            string[] timeSpots = timeSetStr.Split(new char[] { ',', ';', '，', '；' },StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in timeSpots)
            {
                DateTime dtTmp = DateTime.Now;
                bool flag=DateTime.TryParse(item, out dtTmp);
                if (flag)
                {
                    res.Add(dtTmp);
                }
            }
            return res;
        }

        /// <summary>
        /// 根据预定名称获取设定值
        /// </summary>
        /// <param name="setName">预定名称</param>
        /// <returns>获取得到的设定值</returns>
        private string GetSetValueByName(string setName)
        {
            string sqlStr = "select setting_value from sys_setting where setting_name=@setting_name and status_no='310';";
            Dictionary<string, object> prePms = new Dictionary<string, object>();
            prePms.Add("@setting_name", setName);
            try
            {
                return (LocalDbServer.QueryObj(sqlStr, prePms) ?? string.Empty).ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }            
        }

        /// <summary>
        /// 公有方法，外部调用，停止通用计时器
        /// </summary>
        public void StopTimer()
        {
            _myTimer.Stop();
        }        
    }
}
