using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    public class MyArgs
    {
        public DateTime? StartTime { set; get; }
        public DateTime? EndTime { set; get; }
        public string Key { set; get; }
        public string TblName { set; get; }
        public string MinKey { set; get; }
        public string MaxKey { set; get; }
        public int StartIndex { set; get; }
        public int EndIndex { set; get; }
    }
}
