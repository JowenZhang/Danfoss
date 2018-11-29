using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// GetListApprove 的摘要说明
    /// </summary>
    public class GetListApprove : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string ralateNo = context.Request["ralateNo"] ?? string.Empty;
            string apoNo = context.Request["apoNo"] ?? string.Empty;
            Ctrl.ApoActCtrl aac = new Ctrl.ApoActCtrl();
            List<ModelView.ApoActView> list=aac.GetList(apoNo, ralateNo);
            if (list==null)
            {
                list = new List<ModelView.ApoActView>();
            }
            context.Response.Write(Common.JsonHelper.SerializeObject(new { total=list.Count,rows=list}));
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