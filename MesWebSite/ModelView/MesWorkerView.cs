using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 作业员视图类
    /// </summary>
    [Serializable]
    public class MesWorkerView
    {
        public string id { set; get; }
        public string status_no { set; get; }
        public string status_name { set; get; }
        public string worker_no { set; get; }
        public string worker_name { set; get; }
        public string worker_card_id { set; get; }
        public string worker_card_no { set; get; }
        public string factory_no { set; get; }
        public string workshop_no { set; get; }
        public string line_no { set; get; }
        public string job_no { set; get; }
        public string shift_no { set; get; }
        public string worker_mobile { set; get; }
        public string worker_email { set; get; }
        public string worker_rate { set; get; }
        public string worker_group_no { set; get; }
        public string in_date { set; get; }
        public string in_date_attach { set; get; }
    }
}
