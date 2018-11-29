using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class DisplayTbl
    {
        public string field { get; set; }
        public string title { get; set; }
        public bool checkbox { get; set; }
        public string align { get; set; }
        public int width { get; set; }
    }
}
