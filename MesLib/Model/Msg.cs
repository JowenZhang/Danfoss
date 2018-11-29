using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Msg
    {
        public Msg() { }
        public Msg(int no, string msgTxt) 
        {
            No = no;
            MsgTxt = msgTxt;
        }
        private int _no=0;

        public int No
        {
            get { return _no; }
            set { _no = value; }
        }
        private string _msgTxt = string.Empty;

        public string MsgTxt
        {
            get { return _msgTxt; }
            set { _msgTxt = value; }
        }
    }
}
