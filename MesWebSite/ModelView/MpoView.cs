using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 生产订单视图
    /// </summary>
    [Serializable]
    public class MpoView
    { 
        public string id
        {
            set;
            get;
        }
        public string status_no
        {
            set;
            get;
        }
        public string status_name
        {
            set;
            get;
        }
        public string crt_user_no
        {
            set;
            get;
        }
        public string crt_user_name
        {
            set;
            get;
        }
        public string crt_time
        {
            set;
            get;
        }
        public string upd_user_no
        {
            set;
            get;
        }
        public string upd_user_name
        {
            set;
            get;
        }
        public string upd_time
        {
            set;
            get;
        }
        public string mpo_no
        {
            set;
            get;
        }
        public string mpo_type_no
        {
            set;
            get;
        }
        public string mpo_type_name
        {
            set;
            get;
        }
        public string part_no
        {
            set;
            get;
        }
        public string part_name
        {
            set;
            get;
        }
        public string part_spec
        {
            set;
            get;
        }
        public string part_unit
        {
            set;
            get;
        }
        public string mpo_qty
        {
            set;
            get;
        }
        public string mpo_hope_start_datetime
        {
            set;
            get;
        }
        public string mpo_hope_end_datetime
        {
            set;
            get;
        }
        public string workshop_no
        {
            set;
            get;
        }
        public string factory_no
        {
            set;
            get;
        }
        public string line_no
        {
            set;
            get;
        }
        public string job_no
        {
            set;
            get;
        }
        public string shift_no
        {
            set;
            get;
        }
        public string client_no
        {
            set;
            get;
        }
        public string client_name
        {
            set;
            get;
        }
        public string commit_status_no
        {
            set;
            get;
        }
        public string commit_status_name
        {
            set;
            get;
        }
        public string procedure_finished_qty
        {
            set;
            get;
        }
        public string procedure_status_name
        {
            set;
            get;
        }
    }
}
