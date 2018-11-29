using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{
    [Serializable]
    public class DStbl_Maintain_Basic
    {
        public long AutoID { get; set; }
        public string Workshop{get;set;}
        public string SubLine { get; set; }
        public string DeviceName { get; set; }
        public int DeviceXh { get; set; }
        public string Part { get; set; }
        public string Item { get; set; }
        public string PartCode { get; set; }
        public string Taskinformation { get; set; }
        public string Basicrequest { get; set; }
        public string Notice { get; set; }
        public string Detectcondition { get; set; }
        public string Beginmonth { get; set; }
        public int? Period { get; set; }
        public string Aftermaintain { get; set; }
        public int? compel { get; set; }
        public string make_date { get; set; }
        public int? w_man_hour { get; set; }
    }
}
