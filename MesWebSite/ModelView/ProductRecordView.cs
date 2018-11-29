using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 生产记录视图
    /// </summary>
    public class ProductRecordView
    {
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
        public int row_index
        {
            set;
            get;
        }
        public int col_index
        {
            set;
            get;
        }
        public string item_name
        {
            set;
            get;
        }
        public object item_value
        {
            set;
            get;
        }
    }
}
