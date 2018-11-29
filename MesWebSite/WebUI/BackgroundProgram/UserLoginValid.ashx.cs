using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// UserLoginValid 的摘要说明
    /// </summary>
    public class UserLoginValid : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userNo = context.Request["userNo"]??"UNKNOWN";
            string pwd = context.Request["password"];
            try
            {
                Ctrl.Bll.SysUserBll sysUserBll = new Ctrl.Bll.SysUserBll();
                bool res = sysUserBll.UserValid(userNo, pwd);
                if (res)
                {
                    if (context.Request.Cookies["MesCookie"] == null)
                    {
                        HttpCookie cookies = new HttpCookie("MesCookie");
                        string userName = sysUserBll.GetUserName(userNo);
                        cookies.Value = Common.JsonHelper.SerializeObject(new { userNo = userNo, userName = Common.UnicodeConvert.String2Unicode(userName), loginTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") });
                        DateTime dtExpires = DateTime.Now + new TimeSpan(0, 20, 0);
                        cookies.Expires = dtExpires;
                        context.Response.AppendCookie(cookies);
                    }
                    else
                    {
                        HttpCookie cookies = context.Request.Cookies["MesCookie"];
                        cookies.Value = Common.JsonHelper.SerializeObject(new { userNo = userNo, userName = sysUserBll.GetUserName(userNo), loginTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") });
                        DateTime dtExpires = DateTime.Now + new TimeSpan(0, 20, 0);
                        cookies.Expires = dtExpires;
                        context.Response.Cookies.Clear();
                        context.Response.AppendCookie(cookies);
                    }
                }
                context.Response.Write(res.ToString().ToLower());
            }
            catch (Exception ex)
            {                
                throw ex;
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