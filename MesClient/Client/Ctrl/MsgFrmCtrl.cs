using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Ctrl
{
    /// <summary>
    /// 消息窗体控制类
    /// </summary>
    public class MsgFrmCtrl
    {
        /// <summary>
        /// 窗口形式显示提示信息
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowResult(string msg)
        {
            frmMsgBox msgFrm = new frmMsgBox(msg);
            msgFrm.ShowDialog();
        }
    }
}
