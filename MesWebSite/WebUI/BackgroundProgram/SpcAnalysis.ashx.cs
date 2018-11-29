using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// SpcAnalysis 的摘要说明
    /// </summary>
    public class SpcAnalysis : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string eqmNo = context.Request["eqmNo"] ?? string.Empty;
            string information = context.Request["information"] ?? string.Empty;
            string tmpStr = context.Request["normalValue"] ?? string.Empty;
            if (string.IsNullOrEmpty(tmpStr))
            {
                context.Response.Write(Common.JsonHelper.SerializeObject(null));
                context.Response.End();
            }
            double normalValue = 0;
            normalValue = double.TryParse(tmpStr, out normalValue)?normalValue:0;
            tmpStr = context.Request["toleranceValue"] ?? string.Empty;
            if (string.IsNullOrEmpty(tmpStr))
            {
                context.Response.Write(Common.JsonHelper.SerializeObject(null));
                context.Response.End();
            }
            double toleranceValue = 0;
            toleranceValue = double.TryParse(tmpStr, out toleranceValue) ? toleranceValue : 0;
            tmpStr = context.Request["startTime"] ?? string.Empty;
            if (string.IsNullOrEmpty(tmpStr))
            {
                context.Response.Write(Common.JsonHelper.SerializeObject(null));
                context.Response.End();
            }
            DateTime startTime = DateTime.Now;
            startTime = DateTime.TryParse(tmpStr, out startTime) ? startTime : DateTime.Now;
            tmpStr = context.Request["endTime"] ?? string.Empty;
            if (string.IsNullOrEmpty(tmpStr))
            {
                context.Response.Write(Common.JsonHelper.SerializeObject(null));
                context.Response.End();
            }
            DateTime endTime = DateTime.Now;
            endTime = DateTime.TryParse(tmpStr, out endTime) ? endTime : DateTime.Now;
            string partNo =  context.Request["partNo"] ?? string.Empty;
            Ctrl.Bll.SpcDataAnalysisBll spcDataAnalysisBll = new Ctrl.Bll.SpcDataAnalysisBll();

            ModelView.DataAnalysisSpcView dataAnalysisSpcView = spcDataAnalysisBll.CalculateSpc(eqmNo, information, partNo, normalValue, toleranceValue, startTime, endTime);
            //ModelView.DataAnalysisSpcView dataAnalysisSpcView = spcDataAnalysisBll.CalculateSpc("DAOP 090/100", "涡旋拧紧7角度", 97.5, 50
//, new DateTime(2018, 11, 10, 23, 0, 0), new DateTime(2018, 11, 11, 23, 0, 0));
            context.Response.Write(Common.JsonHelper.SerializeObject(dataAnalysisSpcView));
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}