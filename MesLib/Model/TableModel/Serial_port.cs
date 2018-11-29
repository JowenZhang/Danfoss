using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{
    [Serializable]
    public class Serial_port
    {
        public Serial_port() { }
        public string serial_no
        {
            get
            {
                return this._serial_no;
            }
            set
            {
                this._serial_no = value;
            }
        }
        public DateTime? scan_time
        {
            get
            {
                return this._scan_time;
            }
            set
            {
                this._scan_time = value;
            }
        }

        private string _serial_no;

        private DateTime? _scan_time;
    }

}
