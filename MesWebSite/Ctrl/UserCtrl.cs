using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 使用者管理类
    /// </summary>
    public class UserCtrl
    {
        /// <summary>
        /// 私有字段，通用全局数据操作类
        /// </summary>
        private GlobalDataCtrl _gdc = new GlobalDataCtrl();

        /// <summary>
        /// 用户校验
        /// </summary>
        /// <param name="userNo">用户编号</param>
        /// <param name="userPwd">用户密码</param>
        /// <returns>校验结果</returns>
        public bool UserValid(string userNo, string userPwd)
        {            
            string encryptPwd=_gdc.GetStrByField("user_pwd", "sys_user", "user_no", userNo);
            return Common.Md5Operate.GetMD5String(userPwd) == encryptPwd;
        }

        /// <summary>
        /// 根据用户编号获取用户名
        /// </summary>
        /// <param name="userNo">用户编号</param>
        /// <returns>用户名</returns>
        public string GetUserName(string userNo)
        {
            return _gdc.GetStrByField("user_name", "sys_user", "user_no", userNo);
        }
    }
}
