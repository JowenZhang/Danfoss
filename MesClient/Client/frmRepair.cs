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
    /// 维修窗体
    /// </summary>
    public partial class frmRepair : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataUniversal">共享数据类</param>
        public frmRepair(Ctrl.DataUniversal dataUniversal)
        {
            InitializeComponent();
            FrmDataUniversal = dataUniversal;
        }

        /// <summary>
        /// 公有属性，系统共享数据类
        /// </summary>
        public Ctrl.DataUniversal FrmDataUniversal{get;set;}

        /// <summary>
        /// 私有只读属性，数据加载引擎
        /// </summary>
        private Ctrl.DataLoadCtrl MyDataLoadCtrl 
        {
            get 
            {
                Ctrl.DbConStrFactory conFactory=Ctrl.DbConStrFactory.CreateInstance();
                return Ctrl.DataLoadCtrl.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetAccessConStr("defaultAccessDb"));
            }
        }

        /// <summary>
        /// 私有字段，用来记录设备状态的变动
        /// </summary>
        private Ctrl.DataUniversal.EqmStatus _OrignEqmStatus = Ctrl.DataUniversal.EqmStatus.Working;

        /// <summary>
        /// 窗体加载事件函数
        /// </summary>
        /// <param name="sender">窗体加载所属对象</param>
        /// <param name="e">窗体加载对象句柄</param>
        private void frmRepair_Load(object sender, EventArgs e)
        {
            LoadDataByEqmStatus(FrmDataUniversal.EnumEqmStatus);
            _OrignEqmStatus = FrmDataUniversal.EnumEqmStatus;
            string where = string.Format(" eqm_no='{0}' and reply_time is not null order by submit_time desc", FrmDataUniversal.EqmNo);
            LoadEqmRepairRecord(where);
            LoadMaintainRecord();
        }

        /// <summary>
        /// 根据设备状态加载数据
        /// </summary>
        /// <param name="eqmStatus"></param>
        public void LoadDataByEqmStatus(Ctrl.DataUniversal.EqmStatus eqmStatus)
        {
            switch (eqmStatus)
            {
                case Client.Ctrl.DataUniversal.EqmStatus.Ill:
                    lblEqmStatus.Text = "故障";
                    break;
                case Client.Ctrl.DataUniversal.EqmStatus.Repair:
                    lblEqmStatus.Text = "维修";
                    break;
                case Client.Ctrl.DataUniversal.EqmStatus.Working:
                    lblEqmStatus.Text = "正常";
                    break;
                default:
                    lblEqmStatus.Text = "未知状态";
                    break;
            }            
            if (_OrignEqmStatus!=eqmStatus&&eqmStatus==Ctrl.DataUniversal.EqmStatus.Working)
            {
                string where = string.Format(" eqm_no='{0}' and reply_time is not null order by submit_time desc", FrmDataUniversal.EqmNo);
                LoadEqmRepairRecord(where);
            }
            _OrignEqmStatus = eqmStatus;
        }

        private void LoadEqmRepairRecord(string where)
        {            
            List<Model.TableModel.Eqm_jam_record> list = MyDataLoadCtrl.LoadEqmJamRecordNew(where);
            dgvEqmRepair.Rows.Clear();
            int i = 0;
            foreach (Model.TableModel.Eqm_jam_record item in list)
            {
                dgvEqmRepair.Rows.Add();
                dgvEqmRepair.Rows[i].Cells["colRepairEqmName"].Value = FrmDataUniversal.EqmName;
                dgvEqmRepair.Rows[i].Cells["colRepairContent"].Value = item.jam_cause_name;
                dgvEqmRepair.Rows[i].Cells["colRepairDateTime"].Value = item.reply_time==null?string.Empty:((DateTime)item.reply_time).ToString("yyyy-MM-dd HH:mm:ss");
                i++;
            }
        }

        /// <summary>
        /// 保养信息加载函数
        /// </summary>
        private void LoadMaintainRecord()
        {
            string where = string.Format(" Beginmonth>='{0}' order by Beginmonth desc,AutoID desc", dtpMaintence.Value.ToString("yyyy-MM") + "-01");
            List<Model.TableModel.DStbl_Maintain_Basic> list = MyDataLoadCtrl.LoadMaintainInfo(where);
            dgvEqmMaintaince.Rows.Clear();
            int i = 0;
            foreach (Model.TableModel.DStbl_Maintain_Basic item in list)
            {
                dgvEqmMaintaince.Rows.Add();
                dgvEqmMaintaince.Rows[i].Cells["colMaintainBeginmonth"].Value = item.Beginmonth;
                dgvEqmMaintaince.Rows[i].Cells["colMaintainAftermaintain"].Value = item.Aftermaintain;
                dgvEqmMaintaince.Rows[i].Cells["colMaintaincompel"].Value = item.compel;
                dgvEqmMaintaince.Rows[i].Cells["colMaintainDetectcondition"].Value = item.Detectcondition;
                dgvEqmMaintaince.Rows[i].Cells["colMaintainDeviceName"].Value = item.DeviceName;
                dgvEqmMaintaince.Rows[i].Cells["colMaintainDeviceXh"].Value = item.DeviceXh;
                dgvEqmMaintaince.Rows[i].Cells["colMaintainItem"].Value = item.Item;
                dgvEqmMaintaince.Rows[i].Cells["colMaintainmake_date"].Value = item.make_date;
                dgvEqmMaintaince.Rows[i].Cells["colMaintainNotice"].Value = item.Notice;
                dgvEqmMaintaince.Rows[i].Cells["colMaintainPart"].Value = item.Part;
                dgvEqmMaintaince.Rows[i].Cells["colMaintainPartCode"].Value = item.PartCode;
                dgvEqmMaintaince.Rows[i].Cells["colMaintainPeriod"].Value = item.Period==null?string.Empty:((int)item.Period).ToString();
                dgvEqmMaintaince.Rows[i].Cells["colMaintainSubLine"].Value = item.SubLine;
                dgvEqmMaintaince.Rows[i].Cells["colMaintainTaskinformation"].Value = item.Taskinformation;
                dgvEqmMaintaince.Rows[i].Cells["colMaintainw_man_hour"].Value = item.w_man_hour == null ? string.Empty : ((int)item.w_man_hour).ToString();
                dgvEqmMaintaince.Rows[i].Cells["colMaintainBasicrequest"].Value = item.Basicrequest;
                dgvEqmMaintaince.Rows[i].Cells["colMaintainWorkshop"].Value = item.Workshop;
                i++;
            }
        }

        /// <summary>
        /// 维修记录查询按钮单击事件函数
        /// </summary>
        /// <param name="sender">维修记录查询按钮事件</param>
        /// <param name="e">维修记录按钮事件句柄</param>
        private void btnRepairRecord_Click(object sender, EventArgs e)
        {
            string where = string.Format(" eqm_no='{0}' and submit_time>='{1}' and reply_time is not null order by submit_time desc", FrmDataUniversal.EqmNo, dtpRepair.Value.ToString("yyyy-MM-dd"));
            LoadEqmRepairRecord(where);
        }
        
        /// <summary>
        /// 保养记录查询按钮单击事件函数
        /// </summary>
        /// <param name="sender">保养记录查询按钮对象</param>
        /// <param name="e">保养记录查询按钮句柄</param>
        private void btnWaitingMaintenceRecord_Click(object sender, EventArgs e)
        {
            LoadMaintainRecord();
        }
    }
}
