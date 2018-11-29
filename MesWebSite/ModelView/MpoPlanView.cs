using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 每日计划下达视图
    /// </summary>
    [Serializable]
    public class MpoPlanView
    {
        public string id
        {
            set;
            get;
        }
        public string plan_date
        {
            set;
            get;
        }
        public string plan_date_value
        {
            set;
            get;
        }
        public string plan_qty
        {
            set;
            get;
        }
    }
}
