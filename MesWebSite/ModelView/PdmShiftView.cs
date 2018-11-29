using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 班次视图
    /// </summary>
    [Serializable]
    public class PdmShiftView
    {
        public string id { set; get; }
        public string status_no { set; get; }
        public string status_name { set; get; }
        public string shift_no { set; get; }
        public string shift_name { set; get; }
        public string shift_start_time { set; get; }
        public string shift_stop_time { set; get; }
        public string shift_length { set; get; }
        public string shift_1day_ahead { set; get; }
    }
}
