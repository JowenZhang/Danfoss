using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    [Serializable]
    public class SubMenuView
    {
        public string id { set; get; }
        public string backgroundColor {set;get;}
        public string htmlText { set; get; }
        public string href { set; get; }
    }
}
