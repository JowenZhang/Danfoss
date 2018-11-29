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
    /// 生产窗体
    /// </summary>
    public partial class frmProduct : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataUniversal">通用数据类</param>//
        public frmProduct(Ctrl.DataUniversal dataUniversal)
        {
            InitializeComponent();
            MyDataUniversal = dataUniversal;
        }

        /// <summary>
        /// 公有属性，当前窗体的通用数据库类
        /// </summary>
        public Ctrl.DataUniversal MyDataUniversal { set; get; }

        /// <summary>
        /// 私有属性，记录上次报工产品相关的直接信息
        /// </summary>
        private Model.ProductBarcode ProductModel { set; get; }

        /// <summary>
        /// 私有属性，记录从本地获取到的需要报工的产品直接信息
        /// </summary>
        private Model.ProductBarcode NextProductModel { set; get; }

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
        /// 私有方法，窗体加载事件函数
        /// </summary>
        /// <param name="sender">窗体加载事件的触发对象</param>
        /// <param name="e">窗体加载事件的触发句柄</param>
        private void frmProduct_Load(object sender, EventArgs e)
        {
            ReLoadData();            
            timDataRefresh.Enabled = true;
            timDataRefresh_Tick(null, null);
            SetAndonBtnCallText();
            timSubmit.Enabled = true;
        }

        /// <summary>
        /// 私有方法，重新加载数据
        /// </summary>
        private void ReLoadData(string mpoNo=null)
        {
            lblMoNo1.Text = mpoNo ?? "NOTFONUD";
            mpoNo = mpoNo ?? "000000";
            Ctrl.StatisticCtrl staCtrl = new Ctrl.StatisticCtrl();
            lblMoQty1.Text = staCtrl.CountMpoQty(mpoNo);
            lblQtyOk1.Text = staCtrl.CountMpoQtyByEqm(mpoNo, MyDataUniversal.EqmNo);
            lblQtySumByDay1.Text = staCtrl.CountTotalOkToday(MyDataUniversal.EqmNo);
            lblQtyNgSumByDay1.Text = staCtrl.CountTotalNgToday(MyDataUniversal.EqmNo);
        }

        /// <summary>
        /// 私有方法，计时器函数(报工业务)
        /// </summary>
        /// <param name="sender">触发计时器事件的对象</param>
        /// <param name="e">计时器事件的句柄</param>
        private void timSubmit_Tick(object sender, EventArgs e)
        {
            timSubmit.Enabled = false;
            Ctrl.EqmLock eqmLock = new Ctrl.EqmLock();
            eqmLock.GetEqmLock(MyDataUniversal.EqmNo);
            if (MyDataUniversal.EnumEqmStatus !=Client.Ctrl.DataUniversal.EqmStatus.Working)
            {
                timSubmit.Enabled = false;
                return;
            }
            Ctrl.SubmitCtrl subCtrl=new Ctrl.SubmitCtrl();
            Model.ProductBarcode barcode = subCtrl.Submit(MyDataUniversal.EqmNo);
            ReLoadData(barcode.MpoNo);
            if (barcode.Result.ToLower()=="ng")
            {
                timSubmit.Enabled = false;
                NextProductModel = barcode;
                btnQcCauseSave.BackColor = Color.Red;
                return;
            }
            timSubmit.Enabled = true;
        }

        /// <summary>
        /// 故障保存单击函数
        /// </summary>
        /// <param name="sender">触发故障保存单击事件的对象</param>
        /// <param name="e">故障保存单击事件句柄</param>
        private void btnJamSave_Click(object sender, EventArgs e)
        {
            Model.TableModel.Eqm_jam_cause jam = cmbJamCause.SelectedItem as Model.TableModel.Eqm_jam_cause;
            if (jam == null)
            {
                return;
            }
            MyDataBllCtrl.AddJamRecord(jam, MyDataUniversal.EqmNo);
            LoadEqmJamData();
        }

        /// <summary>
        /// 加载数据设备、质量原因列表和工站信息
        /// </summary>
        private void LoadJamQcCauseAndWkcData()
        {
            cmbJamCause.DataSource = MyDataLoadCtrl.GetEqmJamCause();
            cmbJamCause.DisplayMember = "jam_cause_name";
            cmbQcCause.DataSource = MyDataLoadCtrl.GetQcmQaCause();
            cmbQcCause.DisplayMember = "qa_cause_name";
            cmbWkc.DataSource = MyDataLoadCtrl.LoadEqm();
            cmbWkc.DisplayMember = "eqm_name";
            cmbWkc.ValueMember = "eqm_no";
            cmbWkc.SelectedValue = MyDataUniversal.EqmNo;
            LoadPartTypeData();
        }

        /// <summary>
        /// 私有方法，加载BOM型号
        /// </summary>
        private void LoadPartTypeData()
        {
            Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
            Ctrl.FileCtrl fileCtrl = Ctrl.FileCtrl.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetAccessConStr("defaultAccessDb"));
            cmbType.DataSource = null;
            cmbType.DataSource = fileCtrl.LoadType(cmbWkc.SelectedValue.ToString());
        }

        /// <summary>
        /// 工站列表点选框切换项目触发的函数
        /// </summary>
        /// <param name="sender">切换项目事件的触发对象</param>
        /// <param name="e">切换项目事件的句柄</param>
        private void cmbWkc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPartTypeData();
        }

        /// <summary>
        /// 数据刷新函数
        /// </summary>
        /// <param name="sender">数据计时器的时间计数对象</param>
        /// <param name="e">数据计数器的事件句柄</param>
        private void timDataRefresh_Tick(object sender, EventArgs e)
        {
            LoadJamQcCauseAndWkcData();
            LoadQcJamData();
            LoadEqmJamData();
        }

        /// <summary>
        /// 加载质量不良数据
        /// </summary>
        private void LoadQcJamData()
        {
            DataTable dt1 = MyDataLoadCtrl.LoadQcmRecordAll(MyDataUniversal.EqmNo);
            dgvQc.Rows.Clear();
            int i = 0;
            foreach (DataRow item in dt1.Rows)
            {
                dgvQc.Rows.Add();
                dgvQc.Rows[i].Cells["colQcTypeNo"].Value = item[0];
                dgvQc.Rows[i].Cells["colQcSerial"].Value = item[1];
                dgvQc.Rows[i].Cells["colQcCause"].Value = item[2];
                dgvQc.Rows[i].Tag = item[3];
                i++;
            }
        }

        /// <summary>
        /// 加载设备不良数据
        /// </summary>
        private void LoadEqmJamData()
        {
            string where = string.Format(" eqm_no='{0}' order by submit_time desc", MyDataUniversal.EqmNo);
            List<Model.TableModel.Eqm_jam_record> list = MyDataLoadCtrl.LoadEqmJamRecordNew(where);
            dgvJamCause.Rows.Clear();
            int i = 0;
            foreach (Model.TableModel.Eqm_jam_record item in list)
            {
                dgvJamCause.Rows.Add();
                dgvJamCause.Rows[i].Cells["dgvColumnJamStartTime"].Value = item.submit_time.ToString("yyyy-MM-dd HH:mm:ss");
                dgvJamCause.Rows[i].Cells["dgvColumnJamStopTime"].Value = item.reply_time == null ? string.Empty : ((DateTime)item.reply_time).ToString("yyyy-MM-dd HH:mm:ss");
                dgvJamCause.Rows[i].Cells["dgvColumnJamCause"].Value = item.jam_cause_name;
                dgvJamCause.Rows[i].Cells["dgvColumnJamTime"].Value = item.reply_time == null ? string.Empty : ((DateTime)item.reply_time-item.submit_time).Minutes.ToString()+"min";
                i++;
            }
        }

        /// <summary>
        /// 质量不良保存事件函数
        /// </summary>
        /// <param name="sender">质量不良保存事件触发对象</param>
        /// <param name="e">质量不良保存事件句柄</param>
        private void btnQcCauseSave_Click(object sender, EventArgs e)
        {
            if (NextProductModel==null)
            { 
                Ctrl.MsgFrmCtrl.ShowResult("没有找到正在生产的产品！");
                return;
            }

            if (string.IsNullOrEmpty(NextProductModel.ProductSerialNo))
            {
                Ctrl.MsgFrmCtrl.ShowResult("没有找到正在生产的产品！");
                return;
            }
            if (NextProductModel.ID==-1)
            {
                Ctrl.MsgFrmCtrl.ShowResult("没有找到正在生产的产品！");
                return;
            }
            if (NextProductModel.ProductSerialNo == "UNKNOWN" || NextProductModel.ProductSerialNo == "VirtualSerialNo")
            {
                Ctrl.MsgFrmCtrl.ShowResult("没有找到正在生产的产品！");
                return;
            }
            if (NextProductModel.Result.ToString().ToLower() != "ng")
            {
                Ctrl.MsgFrmCtrl.ShowResult("没有找到正在生产的不良品！");
                return;
            }
            Model.TableModel.Qcm_qa_cause qaCause = cmbQcCause.SelectedItem as Model.TableModel.Qcm_qa_cause;
            if (qaCause==null)
            {
                Ctrl.MsgFrmCtrl.ShowResult("质量不良原因选择有误！");
                return;
            }
            if (string.IsNullOrEmpty(qaCause.qa_cause_no))
            {
                Ctrl.MsgFrmCtrl.ShowResult("质量不良原因选择有误！");
                return;
            }
            Model.TableModel.Qcm_qa_record qaRecord = new Model.TableModel.Qcm_qa_record();
            qaRecord.crt_time = DateTime.Now;
            qaRecord.crt_user_name = "worker";
            qaRecord.crt_user_no = "worker";
            qaRecord.eqm_no = MyDataUniversal.EqmNo;
            qaRecord.factory_no = "dfs_f";
            qaRecord.id = Common.Md5Operate.CreateGuidId();
            qaRecord.mpo_item_no = NextProductModel.ProductSerialNo;
            qaRecord.mpo_no = NextProductModel.MpoNo;
            qaRecord.qa_cause_name = qaCause.qa_cause_name;
            qaRecord.qa_cause_no = qaCause.qa_cause_no;
            qaRecord.qa_record_no = MyDataBllCtrl.GetNextNoByTblName("qcm_qa_record");
            qaRecord.serial_no = NextProductModel.ProductSerialNo;
            qaRecord.status_no = "500";
            qaRecord.status_name = "未处理";
            qaRecord.upd_time = qaRecord.crt_time;
            qaRecord.upd_user_name = "worker";
            qaRecord.upd_user_no = "worker";
            qaRecord.submit_time = qaRecord.crt_time;
            qaRecord.submit_user_name = "worker";
            qaRecord.submit_user_no = "worker";
            MyDataBllCtrl.AddQcmQaRecord(qaRecord);
            btnQcCauseSave.BackColor = Color.Transparent;
            timSubmit.Enabled = true; 
            LoadQcJamData();
        }

        /// <summary>
        /// BOM检索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string eqmNo =  MyDataUniversal.EqmNo;
            string condition = cmbType.Text.Trim();
            frmBom frm1 = new frmBom(eqmNo, condition);
            frm1.ShowDialog();
        }

        /// <summary>
        /// 安灯呼叫事件函数
        /// </summary>
        /// <param name="sender">安灯呼叫事件对象</param>
        /// <param name="e">事件句柄</param>
        private void btnCall_Click(object sender, EventArgs e)
        {
            string adn_Type = string.Empty;
            string adn_Name = string.Empty;
            adn_Type = GetAdnType(out adn_Name);
            if (adn_Type == "Wrong")
            {
                Ctrl.MsgFrmCtrl.ShowResult("请选择Andon类型！");
                return;
            }
            string andonNo = string.Empty;
            if (btnCall.Text != "呼叫")
            {
                List<Model.TableModel.Adn> list = MyDataLoadCtrl.LoadAdn(string.Format("eqm_no='{0}' and andon_type_no='{1}' and is_finished='false';", MyDataUniversal.EqmNo, adn_Type));
                if (list == null || list.Count <= 0)
                {
                    Ctrl.MsgFrmCtrl.ShowResult("没有此类型Andon呼叫,请重新选择！");
                    return;
                }
                else
                {
                    andonNo = list[0].andon_no;
                }
            }
            frmAdn frm1 = new frmAdn(btnCall.Text, adn_Type, adn_Name, MyDataUniversal.EqmNo, MyDataUniversal.EqmName, new Model.User_P(), andonNo);
            frm1.FormClosing += frm_FormClosing;
            frm1.ShowDialog();            
        }

        /// <summary>
        /// 声明公有事件，用来修改工位状态
        /// </summary>
        public event Action<Ctrl.DataUniversal.EqmStatus> SetEqmStatus;

        /// <summary>
        /// 公有函数，事件的宿主函数
        /// </summary>
        /// <param name="status">设备状态的一个枚举值</param>
        public void MySetEqmStatus(Ctrl.DataUniversal.EqmStatus status) 
        {
            MyDataUniversal.EnumEqmStatus = status;
            if (SetEqmStatus!=null)
            {
                SetEqmStatus.Invoke(status);
            }
        }

        /// <summary>
        /// 窗口关闭事件函数，处理按钮显示文字
        /// </summary>
        /// <param name="sender">窗口关闭事件触发对象</param>
        /// <param name="e">窗口关闭事件句柄</param>
        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rdbEquipment.Checked)
            {
                if (btnCall.Text=="呼叫")
                {
                    MySetEqmStatus(Ctrl.DataUniversal.EqmStatus.Ill);
                }
                else if(btnCall.Text=="回复")
                {
                    MySetEqmStatus(Ctrl.DataUniversal.EqmStatus.Repair);
                }
                else
                {
                    MySetEqmStatus(Ctrl.DataUniversal.EqmStatus.Working);
                    LoadEqmJamData();
                    timSubmit.Enabled = true;
                }
                
            }
            SetAndonBtnCallText();
        }

        /// <summary>
        /// 设置安灯控制按钮显示文本
        /// </summary>
        private void SetAndonBtnCallText()
        {
            string adnStatus = MyDataLoadCtrl.LoadAdnStatus(MyDataUniversal.EqmNo);
            switch (adnStatus)
            {
                case "510":
                    btnCall.Text = "呼叫";
                    break;
                case "500":
                    btnCall.Text = "回复";
                    break;
                case "520":
                    btnCall.Text = "复位";
                    break;
                default:
                    btnCall.Text = "错误";
                    break;
            }
        }

        /// <summary>
        /// 获取安灯类型和安灯名称
        /// </summary>
        /// <param name="adnTypeName">out参数，返回安灯类型</param>
        /// <returns></returns>
        private string GetAdnType(out string adnTypeName)
        {
            if (rdbEquipment.Checked)
            {
                adnTypeName = "设备";
                return "01";
            }
            else if (rdbPE.Checked)
            {
                adnTypeName = "工艺";
                return "02";
            }
            else if (rdbPartSupply.Checked)
            {
                adnTypeName = "部件供应";
                return "03";
            }
            else if (rdbPartQc.Checked)
            {
                adnTypeName = "部件质量";
                return "04";
            }
            else if (rdbOther.Checked)
            {
                adnTypeName = "其它";
                return "05";
            }
            else
            {
                adnTypeName = "Wrong";
                return "Wrong";
            }
        }
    }
}
