using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Client
{
    public partial class frmMsgBox : Skin_Color
    {
        public frmMsgBox()
        {
            InitializeComponent();
            //this.CloseNormlBack = Image.FromFile(@"..\Output\pic\close.png");
            //this.CloseMouseBack = Image.FromFile(@"..\Output\pic\close_hover.png");
            //this.CloseDownBack = Image.FromFile(@"..\Output\pic\close_hover.png");
        }
        public frmMsgBox(string errorText)
        {
            InitializeComponent();
            this.richTextBox1.Text = errorText;
            //this.CloseNormlBack = Image.FromFile(@"..\Output\pic\close.png");
            //this.CloseMouseBack = Image.FromFile(@"..\Output\pic\close_hover.png");
            //this.CloseDownBack = Image.FromFile(@"..\Output\pic\close_hover.png");
        }
    }
}
