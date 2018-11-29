using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// FetchKanpanData 的摘要说明
    /// </summary>
    public class FetchKanpanData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Ctrl.KanpanCtrl kpCtrl = new Ctrl.KanpanCtrl();
            string res = kpCtrl.GetKanpanData();
            context.Response.Write(res);
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