using System;

namespace Model
{
    public class User_P
    {
        public User_P()
        {
        }

        public User_P(string userNo, string userTime, string userHost)
        {
            UserNo = userNo;
            DateTime t;
            DateTime.TryParse(userTime, out t);
            UserTime = t;
            UserHost = userHost;
        }

        public User_P(string userNo, string userName, string userId, string userTime, string userHost)
        {
            UserName = userName;
            UserId = userId;
            UserNo = userNo;
            DateTime t;
            DateTime.TryParse(userTime, out t);
            UserTime = t;
            UserHost = userHost;
        }
        private string _userId = string.Empty;
        private string _host = Environment.MachineName.ToString().ToLower();
        private DateTime _userTime = DateTime.Now;
        public string UserNo { get; set; }
        public string UserId { get { return this._userId; } set { _userId = value; } }
        public string UserHost { get { return _host; } set { _host = value; } }
        public DateTime UserTime { get { return _userTime; } set { _userTime = value; } }
        public string UserName { get; set; }
        public string UserTimeStr { get { return _userTime.ToString("yyyy-MM-dd hh:mm:ss"); } }
    }
}