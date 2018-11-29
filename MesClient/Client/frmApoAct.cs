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
    public partial class frmApoAct: Skin_Color
    {
        private string _fileNo;
        private string _eqmNo;

        public frmApoAct()
        {
            InitializeComponent();
        }
        public frmApoAct(string eqmNo, string fileNo)
        {
            InitializeComponent();
            this._fileNo = fileNo;
            this._eqmNo = eqmNo;
        }

        private void frmApoAct_Load(object sender, EventArgs e)
        {
            Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
            Ctrl.FileCtrl fileCtrl = Ctrl.FileCtrl.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetAccessConStr("defaultAccessDb"));
            List<Model.TableModel.Apo_act> list = fileCtrl.GetFileFlow(_fileNo);
            dgvApoAct.Rows.Clear();
            int i = 0;
            if (list==null)
            {
                return;
            }
            if (list.Count <= 0)
            {
                return;
            }
            foreach (Model.TableModel.Apo_act item in list)
            {
                dgvApoAct.Rows.Add();
                dgvApoAct.Rows[i].Cells["colApoActStep"].Value = item.act_step;
                dgvApoAct.Rows[i].Cells["colApoActUser"].Value = item.act_user_name;
                dgvApoAct.Rows[i].Cells["colApoActName"].Value = item.apo_item_name;
                dgvApoAct.Rows[i].Cells["colApoActTime"].Value = item.act_time;
                i++;
            }
        }
    }
}
