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
    public partial class frmBom: Skin_Color
    {
        private string _condition;
        private string _eqmNo;

        public frmBom()
        {
            InitializeComponent();
        }
        public frmBom(string eqmNo, string condition)
        {
            InitializeComponent();
            this._condition = condition;
            this._eqmNo = eqmNo;
        }

        private void frmBom_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> state = new Dictionary<string, string>();
            state.Add("eqmNo", _eqmNo);
            state.Add("condition", _condition);
            System.Threading.ThreadPool.QueueUserWorkItem(LoadBom, state);
        }

        private void LoadBom(object state)
        {
            Dictionary<string, string> pms = state as Dictionary<string, string>;
            Ctrl.DbConStrFactory conFactory = Ctrl.DbConStrFactory.CreateInstance();
            Ctrl.FileCtrl fileCtrl = Ctrl.FileCtrl.CreateInstance(conFactory.GetSqlConStr("defaultSqlDb"), conFactory.GetSqlConStr("defaultAccessDb"));
            DataTable dt = fileCtrl.LoadBom(pms["condition"],pms["eqmNo"]);
            if (dgvBom.InvokeRequired == true)
            {
                dgvBom.Invoke(new Action<object>(LoadBom), state);
            }
            else
            {
                dgvBom.DataSource = null;
                dgvBom.DataSource = dt;
                for (int i = 0; i < dgvBom.Columns.Count; i++)
                {
                    dgvBom.Columns[i].HeaderText = dt.Columns[i].Caption;
                }                
            }
        }
    }
}
