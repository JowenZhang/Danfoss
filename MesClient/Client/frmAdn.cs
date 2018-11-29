using CCWin;
using Client.Ctrl;
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
    public partial class frmAdn : Skin_Color
    {
        private string _adnTypeNo;
        private string _eqmNo;
        private Model.User_P _user = null;
        private Andon _andon = null;
        private string _operate;
        private string _andonNo;

        public frmAdn()
        {
            InitializeComponent();
        }
        public frmAdn(string operate, string adnType,string adnName,string eqmNo,string eqmName,Model.User_P user,string andonNo)
        {
            InitializeComponent();
            _user = new Model.User_P();
            _user = user;
            _adnTypeNo = adnType;
            _operate = operate;
            SetLblTxt(_operate);
            lblAdnTypeName.Text = adnName;
            _eqmNo = eqmNo;
            _andonNo = andonNo;
            btnCall.Text=_operate;
            GetAndonDept(adnType);
            if (!string.IsNullOrEmpty(andonNo))
            {
                _andon = new Andon();
                _andon.GetAdnByNo(andonNo);
            }
            lblEqmName.Text = eqmName;
        }

        private void GetAndonDept(string adnType)
        {
            switch (adnType)
            {
                case "01":
                    lblCurrentDept.Tag = "01";
                    lblCurrentDept.Text = "设备部";
                    break;
                case "02":
                    lblCurrentDept.Tag = "02";
                    lblCurrentDept.Text = "工艺部";
                    break;
                case "03":
                    lblCurrentDept.Tag = "03";
                    lblCurrentDept.Text = "生产部";
                    break;
                case "04":
                    lblCurrentDept.Tag = "04";
                    lblCurrentDept.Text = "质量部";
                    break;
                case "05":
                    lblCurrentDept.Tag = "05";
                    lblCurrentDept.Text = "工程部";
                    break;
                default:
                    lblCurrentDept.Tag = "UNKNOWN";
                    lblCurrentDept.Text = "部门未知";
                    break;
            }
        }

        private void SetLblTxt(string text)
        {
            switch (text)
            {
                case "呼叫":
                    lblCurrentStatus.Text = "已完成";
                    lblCallTip.Text = "请选择呼叫的部门";
                    break;
                case "回复":
                    lblCallTip.Text = "请选择响应的部门";
                    lblCurrentStatus.Text = "未处理";
                    break;
                case "复位":
                    lblCallTip.Text = "请选择响应的部门";
                    lblCurrentStatus.Text = "处理中";
                    break;
                default:
                    lblCurrentStatus.Text = "未知";
                    lblCallTip.Text = "请选择呼叫的部门";
                    break;
            }
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            Model.TableModel.Adn adn = new Model.TableModel.Adn();
            string dept_no=(lblCurrentDept.Tag??"Wrong").ToString();
            string dept_name=(lblCurrentDept.Text??"Wrong").ToString();
            if (_operate == "呼叫")
            {
                _andon = new Andon(string.Empty, _adnTypeNo, dept_no, _eqmNo, _user);
                _andon.NewAndon();
                
            }
            else
            {
                _andon = new Andon(_andonNo, _adnTypeNo, dept_no, _eqmNo, _user);
                _andon.GetAdnByNo(_andonNo);
                _andon.NextStep(_user.UserNo, _eqmNo, _andon.Adn.andon_no);
            }
            this.Close();
        }
    }
}
