using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{
    [Serializable]
    public class Sys_menu
    {
        public string id { set; get; }
        public string status_no { set; get; }
        public string status_name { set; get; }
        public DateTime? crt_time{set;get;}
        public string crt_user_no { set; get; }
        public string crt_user_name { set; get; }
        public string menu_no { set; get; }
        public string menu_name { set; get; }
        public int menu_level_index { set; get; }
        public int menu_level { set; get; }
        public string menu_parent_no { set; get; }
        public string menu_link { set; get; }
        public bool menu_is_displayed { set; get; }
    }
}
