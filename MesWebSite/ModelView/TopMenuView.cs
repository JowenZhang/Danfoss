using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    [Serializable]
    public class TopMenuView
    {
        public string id { set; get; }
        public string title { set; get; }        
        public bool selected { set; get; }
        public string content { set; get; }
    }
}
