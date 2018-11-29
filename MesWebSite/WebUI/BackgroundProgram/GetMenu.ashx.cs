using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// getTopMenu 的摘要说明
    /// </summary>
    public class GetMenu : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Ctrl.TopMenuCtrl tmc = new Ctrl.TopMenuCtrl();
            string userNo=context.Request["userNo"]??"userNo";
            List<ModelView.TopMenuView> modelViewList = tmc.GetList(userNo);
            context.Response.Write(Common.JsonHelper.SerializeJsonList<ModelView.TopMenuView>(modelViewList));
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