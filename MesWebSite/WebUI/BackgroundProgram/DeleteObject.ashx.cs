using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.BackgroundProgram
{
    /// <summary>
    /// DeleteObject 的摘要说明
    /// </summary>
    public class DeleteObject : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = "success";
            string viewNeedOperate = context.Request["viewNeedOperate"] ?? "TABLE";
            string objNeedOperate = context.Request["objNeedOperate"] ?? "OBJECT";
            if (!string.IsNullOrEmpty(viewNeedOperate) && viewNeedOperate != "TABLE" && !string.IsNullOrEmpty(objNeedOperate) && objNeedOperate != "OBJECT")
            {
                Ctrl.ICtrlOperate ctrl = Ctrl.CtrlFactroy.CreateViewCtrl(viewNeedOperate);
                int res = 0;
                if (ctrl == null)
                {
                    res = -9999;
                }
                else
                {
                    try
                    {
                        res = ctrl.Delete(objNeedOperate);
                    }
                    catch (Exception)
                    {
                        res = -9998;
                    }
                }
                if (res > 0)
                {
                    msg = "success";
                }
                else if (res == -9999)
                {
                    msg = string.Format("视图{0}：视图不存在！", viewNeedOperate);
                }
                else if (res == -9998)
                {
                    msg = string.Format("视图{0}：数据操作发生错误！", viewNeedOperate);
                }
                else
                {
                    msg = string.Format("视图{0}：数据插入失败！", viewNeedOperate);
                }
            }
            else
            {
                msg = string.Format("视图{0}：目标数据为空！", viewNeedOperate);
            }
            context.Response.Write(Common.JsonHelper.SerializeObject(new { msg = msg }));
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