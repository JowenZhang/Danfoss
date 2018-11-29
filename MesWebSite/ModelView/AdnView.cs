using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 安灯呼叫记录视图
    /// </summary>
    [Serializable]
    public class AdnView
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
        public string andon_no
        {
            set;
            get;
        }
        public string andon_type_no
        {
            set;
            get;
        }
        public string andon_type_name
        {
            set;
            get;
        }
        public string andon_desc
        {
            set;
            get;
        }
        public string dept_no
        {
            set;
            get;
        }
        public string andon_music_no
        {
            set;
            get;
        }
        public string eqm_no
        {
            set;
            get;
        }
        public string call_user_no
        {
            set;
            get;
        }
        public string call_user_name
        {
            set;
            get;
        }
        public string call_time
        {
            set;
            get;
        }
        public string reply_user_no
        {
            set;
            get;
        }
        public string reply_user_name
        {
            set;
            get;
        }
        public string reply_time
        {
            set;
            get;
        }
        public string ralate_no
        {
            set;
            get;
        }
        public string is_finished
        {
            set;
            get;
        }
        public string play_record
        {
            set;
            get;
        }
    }
}
