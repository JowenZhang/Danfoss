using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{
    [Serializable]
    public class Apo
    {
        public string id { set; get; }
        public string status_no { set; get; }
        public string status_name { set; get; }
        public DateTime crt_time { set; get; }
        public string crt_user_no { set; get; }
        public string crt_user_name { set; get; }
        public DateTime? upd_time { set; get; }
        public string upd_user_no { set; get; }
        public string upd_user_name { set; get; }
        public string apo_no { set; get; }
        public string apo_name { set; get; }
    }
}
