using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{
    public class Sys_product_record_setting
    {
        public string id { set; get; }
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
        public DateTime crt_time
        {
            set;
            get;
        }
        public string product_record_no
        {
            set;
            get;
        }
        public string product_record_name
        {
            set;
            get;
        }
        public string eqm_no
        {
            set;
            get;
        }
        public int row_index
        {
            set;
            get;
        }
        public int col_index
        {
            set;
            get;
        }
    }
}
