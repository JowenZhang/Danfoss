using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Client
{
    /// <summary>
    /// 关闭程序确认窗体
    /// </summary>
    public partial class frmCloseConfirm : Skin_Color
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmCloseConfirm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 确定按钮单击事件
        /// </summary>
        /// <param name="sender">事件的所属对象</param>
        /// <param name="e">单击事件句柄</param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        /// <summary>
        /// 取消按钮单击事件
        /// </summary>
        /// <param name="sender">事件的所属对象</param>
        /// <param name="e">单击事件句柄</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
