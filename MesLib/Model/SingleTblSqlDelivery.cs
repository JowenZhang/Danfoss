using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SingleTblSqlDelivery
    {
        string TblName { get; set; }
        string[] ColNames { get; set; }
        string[] OrderBy { get; set; }
        string Where { get; set; }
        string ListObj { get; set; }
    }
}
