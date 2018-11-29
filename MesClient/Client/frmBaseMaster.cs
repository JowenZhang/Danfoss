using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Client.Ctrl;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Client
{

    /// <summary>
    /// 基础窗体
    /// </summary>
    public partial class frmBaseMaster: CCWin.Skin_Color
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmBaseMaster()
            : base()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// 私有字段，程序0层数据交换类
        /// </summary>
        private Ctrl.DataUniversal _data = new DataUniversal();

        /// <summary>
        /// 私有属性，数据加载连接类
        /// </summary>
        private Ctrl.DataLoadCtrl MyDataLoadCtrl 
        {
            get 
            {
                Ctrl.DbConStrFactory conFactory=DbConStrFactory.CreateInstance();
                return Ctrl.DataLoadCtrl.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetAccessConStr("defaultAccessDb"));
            }
        }

        /// <summary>
        /// 重载页面按钮图片
        /// </summary>
        private void SetCtrlsImages()
        {
            this.picLogo.Image = Image.FromFile(@"..\Output\pic\dfsLogo.png");
            this.picLogo.Location = new Point(this.Size.Width - this.picLogo.Size.Width - this.CloseBoxSize.Width - this.MaxSize.Width - this.MiniSize.Width - 10, 7);
        }

        /// <summary>
        /// 窗体加载到tab页容器内
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="tpg"></param>
        private void LoadPage(Form frm, TabPage tpg)
        {
            foreach (TabPage item in tclMaster.TabPages)
            {
                if (item.Text == frm.Text)
                {
                    tclMaster.SelectedTab = item;
                    item.Controls.Clear();
                    GC.Collect(3);
                    frm.TopLevel = false;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    item.Controls.Add(frm);
                    frm.Show();
                    return;
                }
            }
            tpg.Text = frm.Text;
            if (!tclMaster.TabPages.Contains(tpg))
            {
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tclMaster.TabPages.Add(tpg);
                tclMaster.SelectedTab = tpg;
                frm.Parent = tpg;
                frm.Show();
            }
        }
        
        /// <summary>
        /// 向tab页中添加窗体
        /// </summary>
        private void LoadFrmToTabCtrl()
        {
            _data.EqmNo = Common.ConfigHelper.GetConfigValueFromXml("wkcSetting", "localWkc", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesClientConfig.xml");
            _data.EnumEqmStatus = Ctrl.DataUniversal.EqmStatus.Working;
            _data.EqmName = MyDataLoadCtrl.LoadFieldByColumn("eqm_name", "eqm_no", _data.EqmNo, "pdm_eqm");
            this.Text += _data.EqmNo;
            switch (_data.EqmNo)
            {
                case "DAOP 020":
                    LoadPage(new FrmHardware.frmOp020(), new TabPage());
                    break;
                case "DAOP 025":
                    LoadPage(new FrmHardware.frmOp025(), new TabPage());
                    break;
                case "DAOP 030":
                    LoadPage(new FrmHardware.frmOp030(), new TabPage());
                    break;
                case "DAOP 040":
                    LoadPage(new FrmHardware.frmOp040(), new TabPage());
                    break;
                case "DAOP 050":
                    LoadPage(new FrmHardware.frmOp050(), new TabPage());
                    break;
                case "DAOP 060":
                    LoadPage(new FrmHardware.frmOp060(), new TabPage());
                    break;
                case "DAOP 070":
                    LoadPage(new FrmHardware.frmOp070(), new TabPage());
                    break;
                case "DAOP 080":
                    LoadPage(new FrmHardware.frmOp080(), new TabPage());
                    break;
                case "DAOP 090/100":
                    LoadPage(new FrmHardware.frmOp090100(), new TabPage());
                    break;
                case "DAOP 110":
                    LoadPage(new FrmHardware.frmOp110(), new TabPage());
                    break;
                default:
                    break;

            }
            frmProduct myFrmProduct = new frmProduct(_data);            
            frmPe myFrmPe = new frmPe(_data);            
            frmRepair myFrmRepair = new frmRepair(_data);
            myFrmProduct.SetEqmStatus += myFrmRepair.LoadDataByEqmStatus;

            LoadPage(myFrmPe, new TabPage());
            LoadPage(myFrmProduct, new TabPage());
            LoadPage(myFrmRepair, new TabPage());
            LoadPage(new frmPartBackup(), new TabPage());
            foreach (TabPage item in tclMaster.TabPages)
            {
                if (item.Text=="主界面")
                {
                    tclMaster.SelectedTab = item;
                    break;
                }
            }            
        }

        /// <summary>
        /// 基础窗体加载事件
        /// </summary>
        /// <param name="sender">基础窗体加载事件对象</param>
        /// <param name="e">基础窗体加载事件句柄</param>
        private void frmBaseMaster_Load(object sender, EventArgs e)
        {
            //重载页面按钮图片
            SetCtrlsImages();
            //加载页面
            LoadFrmToTabCtrl();
        }

        /// <summary>
        /// 基础窗体关闭事件
        /// </summary>
        /// <param name="sender">基础窗体关闭事件对象</param>
        /// <param name="e">基础窗体关闭事件句柄</param>
        private void frmBaseMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmCloseConfirm frm = new frmCloseConfirm();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
