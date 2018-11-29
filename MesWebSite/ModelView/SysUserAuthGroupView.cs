using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 用户权限组视图类
    /// </summary>
    [Serializable]
    public class SysUserAuthGroupView
    {
        public string id
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string status_no
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string status_name
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_no
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_name
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string auth_group_no
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string auth_group_name
        {
            set;
            get;
        }
    }
}
