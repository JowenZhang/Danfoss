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
    /// <summary>
    /// 备品备件页面
    /// </summary>
    public partial class frmPartBackup : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmPartBackup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender">窗体加载事件对象</param>
        /// <param name="e">窗体加载事件句柄</param>
        private void frmPartBackup_Load(object sender, EventArgs e)
        {
            ReLoadData();
            timPartBackup.Enabled = true;
        }

        /// <summary>
        /// 计时器事件
        /// </summary>
        /// <param name="sender">计时器对象</param>
        /// <param name="e">计时器句柄</param>
        private void timPartBackup_Tick(object sender, EventArgs e)
        {
            ReLoadData();
        }

        /// <summary>
        /// 重载数据
        /// </summary>
        /// <param name="state">参数对象</param>
        private void ReLoadData(string where = null)
        {
            Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
            Ctrl.DataLoadCtrl dataloadCtrl = Ctrl.DataLoadCtrl.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetAccessConStr("defaultAccessDb"));
            DataTable dt1 = dataloadCtrl.LoadPartBackup(where);

            dgvMaintainceInfo.Rows.Clear();
            int i = 0;
            foreach (DataRow item in dt1.Rows)
            {
                dgvMaintainceInfo.Rows.Add();
                dgvMaintainceInfo.Rows[i].Cells["dgvColumnBackupPartNo"].Value = item[0];
                dgvMaintainceInfo.Rows[i].Cells["dgvColumnBackupPartName"].Value = item[1];
                dgvMaintainceInfo.Rows[i].Cells["dgvColumnBackupPartDesc"].Value = item[2];
                dgvMaintainceInfo.Rows[i].Cells["dgvColumnBackupPartQty"].Value = item[3];
                dgvMaintainceInfo.Rows[i].Cells["dgvColumnBackupPartUnitPrice"].Value = item[4];
                dgvMaintainceInfo.Rows[i].Cells["dgvColumnBackupPartManufacter"].Value = item[5];
                dgvMaintainceInfo.Rows[i].Cells["dgvColumnBackupPartSize"].Value = item[6];
                dgvMaintainceInfo.Rows[i].Cells["dgvColumnBackupPartRegistime"].Value = item[7];
                dgvMaintainceInfo.Rows[i].Cells["dgvColumnBackupPartRemark"].Value = item[8];
                i++;
            }
        }

        /// <summary>
        /// 单击查询按钮事件
        /// </summary>
        /// <param name="sender">事件对象</param>
        /// <param name="e">事件句柄</param>
        private void btnPartBackupSearch_Click(object sender, EventArgs e)
        {
            DateTime dt = dtpMaintanceStore.Value;
            string where = string.Format(" where MakeDate>= '{0}'", dt.ToString("yyyy-MM-dd HH:mm:ss"));

            ReLoadData(where);
        }
    }
}
