using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{
    [Serializable]
    public class Apo_act
    {
        public string id { set; get; }
        public string status_no { set; get; }
        public string status_name { set; get; }
        public string act_no { set; get; }
        public string apo_no { set; get; }
        public string apo_item_no { set; get; }
        public string apo_item_name { set; get; }
        public int apo_index { set; get; }
        public string next_item_no { set; get; }
        public string next_item_name { set; get; }
        public string next_user_name { set; get; }
        public string act_desc { set; get; }
        public bool act_result { set; get; }
        public int act_step { set; get; }
        public string act_user_no { set; get; }
        public string act_user_name { set; get; }
        public DateTime act_time { set; get; }
        public string ralate_no { set; get; }
        public string ralate_file_name { set; get; }
        public string ralate_file_extension { set; get; }
        public string ralate_type_no { set; get; }
        public bool step_finished { set; get; }
        public bool apo_finished { set; get; }
    }
}
