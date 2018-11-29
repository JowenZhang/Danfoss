using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class ProductBarcode
    {
        public long ID { set; get; }
        public string ProductDate { set; get; }
        public string ProductTime { set; get; }
        public string ProductTypeNo { set; get; }
        public string ProductSerialNo { set; get; }
        public string MpoNo { set; get; }
        public string User { set; get; }
        public string Result { set; get; }
        public bool SerialNoExist { set; get; }
        public bool IsLastSubmit { set; get; }


        public List<Model.TableModel.Mes_fb_info> SubmitInfo { set; get; }
    }
}
