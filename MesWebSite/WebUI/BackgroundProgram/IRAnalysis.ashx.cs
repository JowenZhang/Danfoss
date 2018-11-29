using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// IRAnalysis 的摘要说明
    /// </summary>
    public class IRAnalysis : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string startStr = context.Request["startTime"] ?? string.Empty; 
            string endStr = context.Request["endTime"] ?? string.Empty;
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now;
            startTime = DateTime.TryParse(startStr, out startTime) ? startTime : DateTime.Now;
            endTime = DateTime.TryParse(endStr, out endTime) ? endTime : DateTime.Now;
            Ctrl.IRAnalysisCtrl bll = new Ctrl.IRAnalysisCtrl();
            ModelView.DataAnalysisIRView dataAnalysisIRView=bll.CalculateIR(startTime, endTime);
            context.Response.Write(Common.JsonHelper.SerializeObject(dataAnalysisIRView));
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