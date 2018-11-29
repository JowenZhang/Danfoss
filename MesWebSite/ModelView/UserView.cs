using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    [Serializable]
    public class UserView
    {
        public string Id { get; set; }
        public string UserNo { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string UserHost { get; set; }
        public DateTime LoginTime { get; set; }
        public string LoginTimeStr { get { return LoginTime.ToString("yyyy-MM-dd HH:mm:ss.fff"); } }        
    }
}
