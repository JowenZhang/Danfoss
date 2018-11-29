using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class DisplayInformation
    {
        public string MpoNo
        {
            get;
            set;
        }
        public string MpoQty
        { get; set; }
        public string FinishedQty
        {
            get;
            set;
        }
    }
}
