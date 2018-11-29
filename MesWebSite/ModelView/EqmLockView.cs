using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelView
{
    /// <summary>
    /// 设备锁定视图
    /// </summary>
    [Serializable]
    public class EqmLockView
    {
        public string id
        {
            set;
            get;
        }
        public string eqm_index 
        { 
            set; 
            get; 
        }
        public string eqm_no
        {
            set;
            get;
        }
        public string eqm_name
        {
            set;
            get;
        }
        public string eqm_lock
        {
            set;
            get;
        }
    }
}