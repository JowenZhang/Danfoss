using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl.Bll
{
    /// <summary>
    /// 用户视图业务类
    /// </summary>
    public class SysUserBll
    {
        /// <summary>
        /// 用户校验
        /// </summary>
        /// <param name="userNo">用户编号</param>
        /// <param name="userPwd">用户密码</param>
        /// <returns>校验结果</returns>
        public bool UserValid(string userNo, string userPwd)
        {
            Ctrl.SysUserCtrl sysUserCtrl = new SysUserCtrl();
            Model.TableModel.Sys_user userModel = sysUserCtrl.GetUserModel(userNo);
            if (userModel == null)
            {
                return false;
            }
            return Common.Md5Operate.GetMD5String(userPwd) == userModel.user_pwd;
        }

        /// <summary>
        /// 根据用户编号获取用户名
        /// </summary>
        /// <param name="userNo">用户编号</param>
        /// <returns>用户名</returns>
        public string GetUserName(string userNo) 
        {
            Ctrl.SysUserCtrl sysUserCtrl = new SysUserCtrl();
            Model.TableModel.Sys_user userModel = sysUserCtrl.GetUserModel(userNo);
            if (userModel == null)
            {
                return string.Empty;
            }
            return userModel.user_name;
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="userNo">用户编号</param>
        /// <returns>修改结果</returns>
        public bool ChangePwd(string userNo,string oldPwd,string newPwd)
        {
            Ctrl.SysUserCtrl sysUserCtrl = new SysUserCtrl();
            Model.TableModel.Sys_user userModel = sysUserCtrl.GetUserModel(userNo);
            if (userModel == null)
            {
                return false;
            }
            if (Common.Md5Operate.GetMD5String(oldPwd) != userModel.user_pwd)
            {
                return false;
            }
            userModel.user_pwd = Common.Md5Operate.GetMD5String(newPwd);
            return sysUserCtrl.Update(userModel) > 0;
        }
    }
}
