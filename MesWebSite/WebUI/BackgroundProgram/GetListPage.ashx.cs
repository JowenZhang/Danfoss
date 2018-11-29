using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// GetListPage 的摘要说明
    /// </summary>
    public class GetListPage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string viewNeedOperate = context.Request["viewNeedOperate"] ?? "TABLE";
            string tmp= context.Request["where"] ?? string.Empty;
            string where = string.Empty;
            if (string.IsNullOrEmpty(tmp))
            {
                where = string.Empty;
            }
            else
            {
                where = Common.Base64Convert.Base64Decode(tmp);
            }
            string orderByTmp = context.Request["orderBy"] ?? string.Empty;
            Dictionary<string, string> orderBy = Common.JsonHelper.DeserializeJsonToObject<Dictionary<string, string>>(orderByTmp);
            int pageSize = int.Parse(context.Request["rows"] ?? "10");
            int pageIndex = int.Parse(context.Request["page"] ?? "1");
            Ctrl.ICtrlOperate ctrl = Ctrl.CtrlFactroy.CreateViewCtrl(viewNeedOperate);
            if (ctrl == null)
            {
                context.Response.Write(Common.JsonHelper.SerializeObject(new { total = 0, rows = string.Empty }));
            }
            else
            {
                context.Response.Write(ctrl.GetListPage(where, orderBy, pageSize, pageIndex));
            }
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