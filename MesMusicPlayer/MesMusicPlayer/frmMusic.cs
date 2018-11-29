using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MesMusicPlayer
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmMusic: CCWin.Skin_Color
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmMusic()
            : base()
        {
            InitializeComponent();
        }

        private void frmMusic_Load(object sender, EventArgs e)
        {
            this.picLogo.Image = Image.FromFile(@"dfsLogo.png");
            this.picLogo.Location = new Point(this.Size.Width - this.picLogo.Size.Width - this.CloseBoxSize.Width -  this.MiniSize.Width - 5, 7);
            
            string strIndex = Common.ConfigHelper.GetConfigValueFromXml("generalSet", "playerIndex", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesMusicPlayerConfig.xml");
            OpenSftwTime = DateTime.Now;
            int tmp = 0;
            int.TryParse(strIndex, out tmp);
            PlayerIndex = tmp;
            this.Text += tmp.ToString();         
            LoadCkbsStatus();
            timCycle.Enabled = true;
        }

        private void LoadCkbsStatus()
        {
            AndonEqmCtrl andonTypeUpdate = AndonEqmCtrl.CreateInstance(Common.ConfigHelper.GetConfigValueFromXml("connectionStr", "defaultSqlDb", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesMusicPlayerConfig.xml"));
            Dictionary<string, bool> andonStatus = andonTypeUpdate.LoadAndonEqmStatus(PlayerIndex);
            foreach (string item in andonStatus.Keys)
            {
                switch (item)
                {
                    case "01":
                        ckbEqm.Checked = andonStatus[item];
                        break;
                    case "02":
                        ckbPe.Checked = andonStatus[item];
                        break;
                    case "03":
                        ckbProduct.Checked = andonStatus[item];
                        break;
                    case "04":
                        ckbQc.Checked = andonStatus[item];
                        break;
                    case "05":
                        ckbOther.Checked = andonStatus[item];
                        break;
                    default:
                        break;
                }
            }
            andonTypeUpdate.UpdateHistroyAdn(OpenSftwTime, PlayerIndex);
        }

        private int PlayerIndex { get; set; }

        private DateTime OpenSftwTime { get; set; }

        private void timCycle_Tick(object sender, EventArgs e)
        {
            Play();
        }

        private void Play()
        {
            StringBuilder andonTypeStr = new StringBuilder();
            andonTypeStr.Append("'");
            if (ckbEqm.Checked)
            {
                andonTypeStr.Append("01','");
            }
            if (ckbPe.Checked)
            {
                andonTypeStr.Append("02','");
            }
            if (ckbProduct.Checked)
            {
                andonTypeStr.Append("03','");
            }
            if (ckbQc.Checked)
            {
                andonTypeStr.Append("04','");
            }
            if (ckbOther.Checked)
            {
                andonTypeStr.Append("05','");
            }
            if (andonTypeStr.Length >= 2)
            {
                andonTypeStr.Remove(andonTypeStr.Length - 2, 2);
            }
            else
            {
                andonTypeStr.Remove(0, andonTypeStr.Length);
                andonTypeStr.Append("''");
            }
            string path = Common.ConfigHelper.GetConfigValueFromXml("generalSet", "musicDirectory", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesMusicPlayerConfig.xml");
            AndonPlayer adnPlayer = AndonPlayer.CreateInstance(Common.ConfigHelper.GetConfigValueFromXml("connectionStr", "defaultSqlDb", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesMusicPlayerConfig.xml"), andonTypeStr.ToString(), path);
            adnPlayer.Play(OpenSftwTime, PlayerIndex);
        }


        private void ckbCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ckb = sender as CheckBox;
            string andonType="UNKNOWN";
            switch (ckb.Name)
            {
                case "ckbEqm":
                    andonType = "01";
                    break;
                case "ckbPe":
                    andonType = "02";
                    break;
                case "ckbProduct":
                    andonType = "03";
                    break;
                case "ckbQc":
                    andonType = "04";
                    break;                
                case "ckbOther":
                    andonType = "05";
                    break;
                default:
                    andonType = "UNKNOWN";
                    break;
            }
            AndonEqmCtrl andonTypeUpdate = AndonEqmCtrl.CreateInstance(Common.ConfigHelper.GetConfigValueFromXml("connectionStr", "defaultSqlDb", AppDomain.CurrentDomain.BaseDirectory + @"Config\mesMusicPlayerConfig.xml"));
            andonTypeUpdate.Update(PlayerIndex, andonType,ckb.Checked);

        }

    }
}
