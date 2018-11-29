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
    /// 工艺窗体
    /// </summary>
    public partial class frmPe : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataUniversal">共享数据类</param>
        public frmPe(Ctrl.DataUniversal dataUniversal)
        {
            InitializeComponent();
            FrmDataUniversal = dataUniversal;
        }

        /// <summary>
        /// 公有属性，数据共享类
        /// </summary>
        public Ctrl.DataUniversal FrmDataUniversal{get;set;}

        /// <summary>
        /// 私有属性，当前窗体的数据加载类
        /// </summary>
        private Ctrl.DataLoadCtrl MyDataLoadCtrl
        {
            get
            {
                Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
                return Ctrl.DataLoadCtrl.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetAccessConStr("defaultAccessDb"));
            }
        }

        /// <summary>
        /// 私有属性，当前窗体的数据业务类
        /// </summary>
        private Ctrl.DataBllCtrl MyDataBllCtrl
        {
            get
            {
                Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
                return Ctrl.DataBllCtrl.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetAccessConStr("defaultAccessDb"));
            }
        }       

        /// <summary>
        /// 窗体数据加载
        /// </summary>
        /// <param name="sender">窗体加载事件对象</param>
        /// <param name="e">窗体加载事件句柄</param>
        private void frmPe_Load(object sender, EventArgs e)
        {
            ReloadData();
        }

        /// <summary>
        /// 重新加载数据
        /// </summary>
        private void ReloadData()
        {
            cmbPeWkc.DataSource = MyDataLoadCtrl.LoadEqm();
            cmbPeWkc.DisplayMember = "eqm_name";
            cmbPeWkc.ValueMember = "eqm_no";
            LoadFile();
        }

        /// <summary>
        /// 加载文件列表
        /// </summary>
        private void LoadFile()
        {
            string fileTypeNo = GetFileTypeNo();
            string eqmNo = GetCmbEqmValue();
            Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
            Ctrl.FileCtrl fileCtrl = Ctrl.FileCtrl.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetAccessConStr("defaultAccessDb"));
            List<Model.TableModel.Dms_file> list = fileCtrl.LoadFile(eqmNo, fileTypeNo);
            dgvFileFlow.Rows.Clear();
            int i = 0;
            foreach (Model.TableModel.Dms_file item in list)
            {
                dgvFileFlow.Rows.Add();
                dgvFileFlow.Rows[i].Cells["colPeFileName"].Value = item.file_name + item.file_extension;
                string fileTime;
                string crtUser = fileCtrl.GetFileCreatorAndTime(item.file_no, out fileTime);
                dgvFileFlow.Rows[i].Cells["colPeFileDateTime"].Value = fileTime;
                dgvFileFlow.Rows[i].Cells["colPeFileCreater"].Value = crtUser;
                dgvFileFlow.Rows[i].Tag = item.file_no;
                i++;
            }
        }

        /// <summary>
        /// 异步获取文件类型
        /// </summary>
        /// <returns>文件类型编号</returns>
        private string GetFileTypeNo()
        {
            string res = string.Empty;
            if (rdbPeSop.InvokeRequired == true)
            {
                rdbPeSop.Invoke(new Func<string>(GetFileTypeNo));
            }
            else
            {
                if (rdbPeSop.Checked)
                {
                    return "01";
                }
            }
            if (rdbPeCi.InvokeRequired == true)
            {
                rdbPeCi.Invoke(new Func<string>(GetFileTypeNo));
            }
            else
            {
                if (rdbPeCi.Checked)
                {
                    return "02";
                }
            }
            if (rdbPeSi.InvokeRequired == true)
            {
                rdbPeSi.Invoke(new Func<string>(GetFileTypeNo));
            }
            else
            {
                if (rdbPeSi.Checked)
                {
                    return "03";
                }
            }
            if (rdbPeVi.InvokeRequired == true)
            {
                rdbPeVi.Invoke(new Func<string>(GetFileTypeNo));
            }
            else
            {
                if (rdbPeVi.Checked)
                {
                    return "04";
                }
            }
            if (rdbPeFi.InvokeRequired == true)
            {
                rdbPeFi.Invoke(new Func<string>(GetFileTypeNo));
            }
            else
            {
                if (rdbPeFi.Checked)
                {
                    return "05";
                }
            }
            if (rdbPeJsa.InvokeRequired == true)
            {
                rdbPeJsa.Invoke(new Func<string>(GetFileTypeNo));
            }
            else
            {
                if (rdbPeJsa.Checked)
                {
                    return "06";
                }
            }
            if (rdbPeSaf.InvokeRequired == true)
            {
                rdbPeSaf.Invoke(new Func<string>(GetFileTypeNo));
            }
            else
            {
                if (rdbPeSaf.Checked)
                {
                    return "07";
                }
            }
            return res;
        }

        /// <summary>
        /// 异步获取选中的工艺机台编号
        /// </summary>
        /// <returns>机台编号</returns>
        private string GetCmbEqmValue()
        {
            string res = string.Empty;
            if (cmbPeWkc.InvokeRequired == true)
            {
                cmbPeWkc.Invoke(new Func<string>(GetCmbEqmValue));
            }
            else
            {
                return (cmbPeWkc.SelectedValue ?? "").ToString();
            }
            return res;
        }

        /// <summary>
        /// 文件单选按钮事件
        /// </summary>
        /// <param name="sender">文件单选按钮事件对象</param>
        /// <param name="e">文件单选按钮事件句柄</param>
        private void rdbPeSop_CheckedChanged(object sender, EventArgs e)
        {
            LoadFile();
        }

        /// <summary>
        /// 文件单选按钮事件
        /// </summary>
        /// <param name="sender">文件单选按钮事件对象</param>
        /// <param name="e">文件单选按钮事件句柄</param>
        private void rdbPeCi_CheckedChanged(object sender, EventArgs e)
        {
            LoadFile();
        }

        /// <summary>
        /// 文件单选按钮事件
        /// </summary>
        /// <param name="sender">文件单选按钮事件对象</param>
        /// <param name="e">文件单选按钮事件句柄</param>
        private void rdbPeSi_CheckedChanged(object sender, EventArgs e)
        {
            LoadFile();
        }

        /// <summary>
        /// 文件单选按钮事件
        /// </summary>
        /// <param name="sender">文件单选按钮事件对象</param>
        /// <param name="e">文件单选按钮事件句柄</param>
        private void rdbPeVi_CheckedChanged(object sender, EventArgs e)
        {
            LoadFile();
        }

        /// <summary>
        /// 文件单选按钮事件
        /// </summary>
        /// <param name="sender">文件单选按钮事件对象</param>
        /// <param name="e">文件单选按钮事件句柄</param>
        private void rdbPeFi_CheckedChanged(object sender, EventArgs e)
        {
            LoadFile();
        }

        /// <summary>
        /// 文件单选按钮事件
        /// </summary>
        /// <param name="sender">文件单选按钮事件对象</param>
        /// <param name="e">文件单选按钮事件句柄</param>
        private void rdbPeJsa_CheckedChanged(object sender, EventArgs e)
        {
            LoadFile();
        }

        /// <summary>
        /// 文件单选按钮事件
        /// </summary>
        /// <param name="sender">文件单选按钮事件对象</param>
        /// <param name="e">文件单选按钮事件句柄</param>
        private void rdbPeSaf_CheckedChanged(object sender, EventArgs e)
        {
            LoadFile();
        }

        /// <summary>
        /// 文件单选按钮事件
        /// </summary>
        /// <param name="sender">文件单选按钮事件对象</param>
        /// <param name="e">文件单选按钮事件句柄</param>
        private void cmbPeWkc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFile();
        }

        /// <summary>
        /// 工艺文件审核流查看按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPeFileFlow_Click(object sender, EventArgs e)
        {
            if (dgvFileFlow.SelectedRows.Count <= 0)
            {
                Ctrl.MsgFrmCtrl.ShowResult("未选择对象，请重试！");
                return;
            }
            string fileName = (dgvFileFlow.SelectedRows[0].Cells["colPeFileName"].Value ?? "").ToString();
            string fileNo = (dgvFileFlow.SelectedRows[0].Tag ?? "").ToString();
            if (string.IsNullOrEmpty(fileName))
            {
                Ctrl.MsgFrmCtrl.ShowResult("文件名称有误，请重试！");
                return;
            }
            frmApoAct frm = new frmApoAct(FrmDataUniversal.EqmNo, fileNo);
            frm.Show();
        }

        private void btnPeFileWatch_Click(object sender, EventArgs e)
        {
            if (dgvFileFlow.SelectedRows.Count <= 0)
            {
                Ctrl.MsgFrmCtrl.ShowResult("未选则中对象，请重试！");
                return;
            }
            string fileName = (dgvFileFlow.SelectedRows[0].Cells["colPeFileName"].Value ?? "").ToString();
            string fileNo = (dgvFileFlow.SelectedRows[0].Tag ?? "").ToString();
            if (string.IsNullOrEmpty(fileName))
            {
                Ctrl.MsgFrmCtrl.ShowResult("文件名称有误，请重试！");
                return;
            }
            Ctrl.FileLoad fileLoad = new Ctrl.FileLoad();
            fileLoad.FileShow(fileName, fileNo);
        }

        private void btnLocalDataUpload_Click(object sender, EventArgs e)
        {
            Ctrl.DbOperateCtrl dbOperateCtrl = new Ctrl.DbOperateCtrl();

            bool b = true;
            if (b)
            {
                Ctrl.MsgFrmCtrl.ShowResult("上传成功！");
            }
            else
            {
                Ctrl.MsgFrmCtrl.ShowResult("上传失败！");
                //msgFrm.ShowDialog();
            }
        }

        private void btnPeDataDownload_Click(object sender, EventArgs e)
        {
            frmPwdBox msg = new frmPwdBox(FrmDataUniversal.EqmNo);
            msg.Show();
        }
    }
}
