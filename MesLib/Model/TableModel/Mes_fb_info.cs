using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{
    [Serializable]
    public class Mes_fb_info
    {
        public string id
        {
            set;
            get;
        }
        public string serial_no
        {
            set;
            get;
        }
        public string eqm_no
        {
            set;
            get;
        }
        public string part_no
        {
            set;
            get;
        }
        public string information
        {
            set;
            get;
        }
        public string information_value
        { 
            set;
            get; 
        }
        public DateTime? create_time
        {
            set;
            get;

        }
    }
}
