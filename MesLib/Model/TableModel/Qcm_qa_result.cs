using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{
    [Serializable]
    public class Qcm_qa_result
    {
        public string id
        {
            set;
            get;
        }
        public string status_no
        {
            set;
            get;
        }
        public string status_name
        {
            set;
            get;
        }
        public string result_no
        {
            set;
            get;
        }
        public string result_name
        {
            set;
            get;
        }
    }
}
