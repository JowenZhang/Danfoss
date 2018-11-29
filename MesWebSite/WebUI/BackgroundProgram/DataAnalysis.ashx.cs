using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// DataAnalysis 的摘要说明
    /// </summary>
    public class DataAnalysis : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Ctrl.DataAnalysisBarCtrl dataAnalysisCtrl = new Ctrl.DataAnalysisBarCtrl();
            string analysisItem = context.Request["analysisItem"]??string.Empty;
            string analysisDestiny = context.Request["analysisDestiny"] ?? string.Empty;
            string timeSpacy = context.Request["timeSpacy"] ?? string.Empty;
            string startStr = context.Request["startTime"] ?? string.Empty;
            string endStr = context.Request["endTime"] ?? string.Empty;
            DateTime startTime = DateTime.Now;
            startTime = DateTime.TryParse(startStr, out startTime) ? startTime : DateTime.Now;
            DateTime endTime = DateTime.Now;
            endTime = DateTime.TryParse(endStr, out endTime) ? endTime : DateTime.Now;
            int pageSize = int.Parse(context.Request["rows"] ?? "10");
            int pageIndex = int.Parse(context.Request["page"] ?? "1");
            ModelView.DataAnalysisBarView data= dataAnalysisCtrl.GetDataAnalysis(analysisItem, analysisDestiny, timeSpacy, startTime, endTime, pageSize, pageIndex);
            if (data == null)
            {
                data = new ModelView.DataAnalysisBarView();
                data.Rows = new List<ModelView.DataAnalysisValuePairView>();                
            }
            context.Response.Write(Common.JsonHelper.SerializeObject(new { data }));
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