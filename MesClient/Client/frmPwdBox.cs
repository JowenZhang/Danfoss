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
    public partial class frmPwdBox : Skin_Color
    {
        public frmPwdBox(string eqmNo)
        {
            InitializeComponent();            
            EqmNo = eqmNo;
        }

        public string EqmNo { set; get; }

        /// <summary>
        /// 私有的通用数据库引擎
        /// </summary>
        private DAO.GeneralDbEngine DbEngine
        {
            get
            {
                Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
                return DAO.GeneralDbEngine.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetAccessConStr("defaultAccessDb"));
            }
        }

        private void btnPeDataDownLoad_Click(object sender, EventArgs e)
        {
            string where = string.Format("user_no like '%{0}%'", txtType.Text.Trim());
            List<Model.TableModel.Sys_user> list = DbEngine.QueryList<Model.TableModel.Sys_user>(where);

            if (list.Count > 0)
            {
                Ctrl.DbOperateCtrl dbOperateCtrl = new Ctrl.DbOperateCtrl(EqmNo);
                object state = false;

                bool flag = dbOperateCtrl.PeDataDownLoad(state);
                if (flag)
                {
                    frmMsgBox msg = new frmMsgBox("下载成功！");
                    msg.ShowDialog();
                }
                else
                {
                    frmMsgBox msg = new frmMsgBox("下载失败！");
                    msg.ShowDialog();
                }
                this.Close();
            }
            else
            {
                frmMsgBox msg = new frmMsgBox("用户校验失败无法上传！");
                msg.Show();
            }
        }
    }
}
