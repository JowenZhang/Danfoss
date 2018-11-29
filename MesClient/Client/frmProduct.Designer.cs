namespace Client
{
    partial class frmProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlWkcAndPlan = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblQtyOk1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblMoNo1 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblQtySumByDay1 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblMoQty1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblQtyNgSumByDay1 = new System.Windows.Forms.Label();
            this.pnlOrderPartInfo = new System.Windows.Forms.Panel();
            this.spcProblemAndProduct = new System.Windows.Forms.SplitContainer();
            this.spcProblem = new System.Windows.Forms.SplitContainer();
            this.gpbQcCause = new System.Windows.Forms.GroupBox();
            this.dgvQc = new System.Windows.Forms.DataGridView();
            this.colQcTypeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQcSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQcCause = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbQcCause = new System.Windows.Forms.ComboBox();
            this.btnQcCauseSave = new System.Windows.Forms.Button();
            this.gpbWkcJam = new System.Windows.Forms.GroupBox();
            this.dgvJamCause = new System.Windows.Forms.DataGridView();
            this.dgvColumnJamStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnJamStopTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnJamCause = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnJamTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbJamCause = new System.Windows.Forms.ComboBox();
            this.btnJamSave = new System.Windows.Forms.Button();
            this.spcProduct = new System.Windows.Forms.SplitContainer();
            this.gpbBom = new System.Windows.Forms.GroupBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbWkc = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.gpxAndon = new System.Windows.Forms.GroupBox();
            this.tplAndon = new System.Windows.Forms.TableLayoutPanel();
            this.btnCall = new System.Windows.Forms.Button();
            this.tlpAndonSelect = new System.Windows.Forms.TableLayoutPanel();
            this.rdbOther = new System.Windows.Forms.RadioButton();
            this.rdbPartSupply = new System.Windows.Forms.RadioButton();
            this.rdbPartQc = new System.Windows.Forms.RadioButton();
            this.rdbPE = new System.Windows.Forms.RadioButton();
            this.rdbEquipment = new System.Windows.Forms.RadioButton();
            this.timSubmit = new System.Windows.Forms.Timer();
            this.timDataRefresh = new System.Windows.Forms.Timer();
            this.pnlWkcAndPlan.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlOrderPartInfo.SuspendLayout();
            this.spcProblemAndProduct.Panel1.SuspendLayout();
            this.spcProblemAndProduct.Panel2.SuspendLayout();
            this.spcProblemAndProduct.SuspendLayout();
            this.spcProblem.Panel1.SuspendLayout();
            this.spcProblem.Panel2.SuspendLayout();
            this.spcProblem.SuspendLayout();
            this.gpbQcCause.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQc)).BeginInit();
            this.gpbWkcJam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJamCause)).BeginInit();
            this.spcProduct.Panel1.SuspendLayout();
            this.spcProduct.Panel2.SuspendLayout();
            this.spcProduct.SuspendLayout();
            this.gpbBom.SuspendLayout();
            this.gpxAndon.SuspendLayout();
            this.tplAndon.SuspendLayout();
            this.tlpAndonSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWkcAndPlan
            // 
            this.pnlWkcAndPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWkcAndPlan.BackColor = System.Drawing.Color.Transparent;
            this.pnlWkcAndPlan.Controls.Add(this.tableLayoutPanel1);
            this.pnlWkcAndPlan.Location = new System.Drawing.Point(1, 1);
            this.pnlWkcAndPlan.Margin = new System.Windows.Forms.Padding(1);
            this.pnlWkcAndPlan.Name = "pnlWkcAndPlan";
            this.pnlWkcAndPlan.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.pnlWkcAndPlan.Size = new System.Drawing.Size(764, 120);
            this.pnlWkcAndPlan.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.lblQtyOk1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMoNo1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label20, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblQtySumByDay1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label22, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMoQty1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label24, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblQtyNgSumByDay1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(764, 113);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblQtyOk1
            // 
            this.lblQtyOk1.AutoSize = true;
            this.lblQtyOk1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQtyOk1.Location = new System.Drawing.Point(540, 22);
            this.lblQtyOk1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblQtyOk1.Name = "lblQtyOk1";
            this.lblQtyOk1.Size = new System.Drawing.Size(32, 33);
            this.lblQtyOk1.TabIndex = 9;
            this.lblQtyOk1.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(540, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "已完成:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(6, 0);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 22);
            this.label15.TabIndex = 0;
            this.label15.Text = "订单号:";
            // 
            // lblMoNo1
            // 
            this.lblMoNo1.AutoSize = true;
            this.lblMoNo1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMoNo1.Location = new System.Drawing.Point(6, 22);
            this.lblMoNo1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMoNo1.Name = "lblMoNo1";
            this.lblMoNo1.Size = new System.Drawing.Size(168, 33);
            this.lblMoNo1.TabIndex = 1;
            this.lblMoNo1.Text = "000000001";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(6, 55);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(117, 22);
            this.label20.TabIndex = 2;
            this.label20.Text = "当日总产量:";
            // 
            // lblQtySumByDay1
            // 
            this.lblQtySumByDay1.AutoSize = true;
            this.lblQtySumByDay1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQtySumByDay1.Location = new System.Drawing.Point(6, 77);
            this.lblQtySumByDay1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblQtySumByDay1.Name = "lblQtySumByDay1";
            this.lblQtySumByDay1.Size = new System.Drawing.Size(32, 36);
            this.lblQtySumByDay1.TabIndex = 3;
            this.lblQtySumByDay1.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(311, 0);
            this.label22.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(97, 22);
            this.label22.TabIndex = 4;
            this.label22.Text = "订单数量:";
            // 
            // lblMoQty1
            // 
            this.lblMoQty1.AutoSize = true;
            this.lblMoQty1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMoQty1.Location = new System.Drawing.Point(311, 22);
            this.lblMoQty1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMoQty1.Name = "lblMoQty1";
            this.lblMoQty1.Size = new System.Drawing.Size(32, 33);
            this.lblMoQty1.TabIndex = 5;
            this.lblMoQty1.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(311, 55);
            this.label24.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(117, 22);
            this.label24.TabIndex = 6;
            this.label24.Text = "不良品数量:";
            // 
            // lblQtyNgSumByDay1
            // 
            this.lblQtyNgSumByDay1.AutoSize = true;
            this.lblQtyNgSumByDay1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQtyNgSumByDay1.Location = new System.Drawing.Point(311, 77);
            this.lblQtyNgSumByDay1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblQtyNgSumByDay1.Name = "lblQtyNgSumByDay1";
            this.lblQtyNgSumByDay1.Size = new System.Drawing.Size(32, 36);
            this.lblQtyNgSumByDay1.TabIndex = 7;
            this.lblQtyNgSumByDay1.Text = "0";
            // 
            // pnlOrderPartInfo
            // 
            this.pnlOrderPartInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrderPartInfo.Controls.Add(this.spcProblemAndProduct);
            this.pnlOrderPartInfo.Location = new System.Drawing.Point(1, 128);
            this.pnlOrderPartInfo.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.pnlOrderPartInfo.Name = "pnlOrderPartInfo";
            this.pnlOrderPartInfo.Size = new System.Drawing.Size(764, 361);
            this.pnlOrderPartInfo.TabIndex = 2;
            // 
            // spcProblemAndProduct
            // 
            this.spcProblemAndProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcProblemAndProduct.Location = new System.Drawing.Point(0, 0);
            this.spcProblemAndProduct.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.spcProblemAndProduct.Name = "spcProblemAndProduct";
            // 
            // spcProblemAndProduct.Panel1
            // 
            this.spcProblemAndProduct.Panel1.Controls.Add(this.spcProblem);
            // 
            // spcProblemAndProduct.Panel2
            // 
            this.spcProblemAndProduct.Panel2.Controls.Add(this.spcProduct);
            this.spcProblemAndProduct.Size = new System.Drawing.Size(764, 361);
            this.spcProblemAndProduct.SplitterDistance = 461;
            this.spcProblemAndProduct.SplitterWidth = 8;
            this.spcProblemAndProduct.TabIndex = 2;
            // 
            // spcProblem
            // 
            this.spcProblem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcProblem.Location = new System.Drawing.Point(0, 0);
            this.spcProblem.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.spcProblem.Name = "spcProblem";
            this.spcProblem.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcProblem.Panel1
            // 
            this.spcProblem.Panel1.Controls.Add(this.gpbQcCause);
            // 
            // spcProblem.Panel2
            // 
            this.spcProblem.Panel2.Controls.Add(this.gpbWkcJam);
            this.spcProblem.Size = new System.Drawing.Size(461, 361);
            this.spcProblem.SplitterDistance = 150;
            this.spcProblem.SplitterWidth = 9;
            this.spcProblem.TabIndex = 3;
            // 
            // gpbQcCause
            // 
            this.gpbQcCause.Controls.Add(this.dgvQc);
            this.gpbQcCause.Controls.Add(this.label1);
            this.gpbQcCause.Controls.Add(this.cmbQcCause);
            this.gpbQcCause.Controls.Add(this.btnQcCauseSave);
            this.gpbQcCause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbQcCause.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbQcCause.Location = new System.Drawing.Point(0, 0);
            this.gpbQcCause.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.gpbQcCause.Name = "gpbQcCause";
            this.gpbQcCause.Padding = new System.Windows.Forms.Padding(0);
            this.gpbQcCause.Size = new System.Drawing.Size(461, 150);
            this.gpbQcCause.TabIndex = 0;
            this.gpbQcCause.TabStop = false;
            this.gpbQcCause.Text = "不良原因";
            // 
            // dgvQc
            // 
            this.dgvQc.AllowUserToAddRows = false;
            this.dgvQc.AllowUserToDeleteRows = false;
            this.dgvQc.AllowUserToOrderColumns = true;
            this.dgvQc.AllowUserToResizeRows = false;
            this.dgvQc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQc.BackgroundColor = System.Drawing.Color.White;
            this.dgvQc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvQc.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvQc.ColumnHeadersHeight = 36;
            this.dgvQc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvQc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colQcTypeNo,
            this.colQcSerial,
            this.colQcCause});
            this.dgvQc.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvQc.Location = new System.Drawing.Point(4, 59);
            this.dgvQc.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.dgvQc.Name = "dgvQc";
            this.dgvQc.RowHeadersVisible = false;
            this.dgvQc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvQc.ShowCellErrors = false;
            this.dgvQc.Size = new System.Drawing.Size(451, 87);
            this.dgvQc.TabIndex = 11;
            // 
            // colQcTypeNo
            // 
            this.colQcTypeNo.HeaderText = "型号";
            this.colQcTypeNo.Name = "colQcTypeNo";
            // 
            // colQcSerial
            // 
            this.colQcSerial.HeaderText = "序列号";
            this.colQcSerial.Name = "colQcSerial";
            // 
            // colQcCause
            // 
            this.colQcCause.HeaderText = "不良原因";
            this.colQcCause.Name = "colQcCause";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 27);
            this.label1.TabIndex = 10;
            this.label1.Text = "不良原因录入:";
            // 
            // cmbQcCause
            // 
            this.cmbQcCause.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQcCause.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbQcCause.FormattingEnabled = true;
            this.cmbQcCause.Location = new System.Drawing.Point(143, 18);
            this.cmbQcCause.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cmbQcCause.Name = "cmbQcCause";
            this.cmbQcCause.Size = new System.Drawing.Size(179, 36);
            this.cmbQcCause.TabIndex = 9;
            // 
            // btnQcCauseSave
            // 
            this.btnQcCauseSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQcCauseSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnQcCauseSave.FlatAppearance.BorderSize = 2;
            this.btnQcCauseSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnQcCauseSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnQcCauseSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQcCauseSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQcCauseSave.Location = new System.Drawing.Point(329, 16);
            this.btnQcCauseSave.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnQcCauseSave.Name = "btnQcCauseSave";
            this.btnQcCauseSave.Size = new System.Drawing.Size(120, 40);
            this.btnQcCauseSave.TabIndex = 7;
            this.btnQcCauseSave.Text = "保存";
            this.btnQcCauseSave.UseVisualStyleBackColor = false;
            this.btnQcCauseSave.Click += new System.EventHandler(this.btnQcCauseSave_Click);
            // 
            // gpbWkcJam
            // 
            this.gpbWkcJam.Controls.Add(this.dgvJamCause);
            this.gpbWkcJam.Controls.Add(this.label6);
            this.gpbWkcJam.Controls.Add(this.cmbJamCause);
            this.gpbWkcJam.Controls.Add(this.btnJamSave);
            this.gpbWkcJam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbWkcJam.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbWkcJam.Location = new System.Drawing.Point(0, 0);
            this.gpbWkcJam.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.gpbWkcJam.Name = "gpbWkcJam";
            this.gpbWkcJam.Padding = new System.Windows.Forms.Padding(0);
            this.gpbWkcJam.Size = new System.Drawing.Size(461, 202);
            this.gpbWkcJam.TabIndex = 1;
            this.gpbWkcJam.TabStop = false;
            this.gpbWkcJam.Text = "停机";
            // 
            // dgvJamCause
            // 
            this.dgvJamCause.AllowUserToAddRows = false;
            this.dgvJamCause.AllowUserToDeleteRows = false;
            this.dgvJamCause.AllowUserToOrderColumns = true;
            this.dgvJamCause.AllowUserToResizeRows = false;
            this.dgvJamCause.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvJamCause.BackgroundColor = System.Drawing.Color.White;
            this.dgvJamCause.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvJamCause.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvJamCause.ColumnHeadersHeight = 36;
            this.dgvJamCause.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvJamCause.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColumnJamStartTime,
            this.dgvColumnJamStopTime,
            this.dgvColumnJamCause,
            this.dgvColumnJamTime});
            this.dgvJamCause.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvJamCause.Location = new System.Drawing.Point(6, 60);
            this.dgvJamCause.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.dgvJamCause.Name = "dgvJamCause";
            this.dgvJamCause.RowHeadersVisible = false;
            this.dgvJamCause.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvJamCause.ShowCellErrors = false;
            this.dgvJamCause.Size = new System.Drawing.Size(449, 142);
            this.dgvJamCause.TabIndex = 11;
            // 
            // dgvColumnJamStartTime
            // 
            this.dgvColumnJamStartTime.HeaderText = "开始时间";
            this.dgvColumnJamStartTime.Name = "dgvColumnJamStartTime";
            // 
            // dgvColumnJamStopTime
            // 
            this.dgvColumnJamStopTime.HeaderText = "结束时间";
            this.dgvColumnJamStopTime.Name = "dgvColumnJamStopTime";
            // 
            // dgvColumnJamCause
            // 
            this.dgvColumnJamCause.HeaderText = "停机原因";
            this.dgvColumnJamCause.Name = "dgvColumnJamCause";
            // 
            // dgvColumnJamTime
            // 
            this.dgvColumnJamTime.HeaderText = "停机时间";
            this.dgvColumnJamTime.Name = "dgvColumnJamTime";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 27);
            this.label6.TabIndex = 10;
            this.label6.Text = "停机原因录入:";
            // 
            // cmbJamCause
            // 
            this.cmbJamCause.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbJamCause.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbJamCause.FormattingEnabled = true;
            this.cmbJamCause.Location = new System.Drawing.Point(143, 18);
            this.cmbJamCause.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cmbJamCause.Name = "cmbJamCause";
            this.cmbJamCause.Size = new System.Drawing.Size(179, 36);
            this.cmbJamCause.TabIndex = 9;
            // 
            // btnJamSave
            // 
            this.btnJamSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJamSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnJamSave.FlatAppearance.BorderSize = 2;
            this.btnJamSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnJamSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnJamSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJamSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJamSave.Location = new System.Drawing.Point(331, 17);
            this.btnJamSave.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnJamSave.Name = "btnJamSave";
            this.btnJamSave.Size = new System.Drawing.Size(120, 40);
            this.btnJamSave.TabIndex = 7;
            this.btnJamSave.Text = "保存";
            this.btnJamSave.UseVisualStyleBackColor = false;
            this.btnJamSave.Click += new System.EventHandler(this.btnJamSave_Click);
            // 
            // spcProduct
            // 
            this.spcProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcProduct.Location = new System.Drawing.Point(0, 0);
            this.spcProduct.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.spcProduct.Name = "spcProduct";
            this.spcProduct.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcProduct.Panel1
            // 
            this.spcProduct.Panel1.Controls.Add(this.gpbBom);
            // 
            // spcProduct.Panel2
            // 
            this.spcProduct.Panel2.Controls.Add(this.gpxAndon);
            this.spcProduct.Size = new System.Drawing.Size(295, 361);
            this.spcProduct.SplitterDistance = 97;
            this.spcProduct.SplitterWidth = 9;
            this.spcProduct.TabIndex = 4;
            // 
            // gpbBom
            // 
            this.gpbBom.Controls.Add(this.cmbType);
            this.gpbBom.Controls.Add(this.btnSearch);
            this.gpbBom.Controls.Add(this.label14);
            this.gpbBom.Controls.Add(this.cmbWkc);
            this.gpbBom.Controls.Add(this.label13);
            this.gpbBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbBom.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbBom.Location = new System.Drawing.Point(0, 0);
            this.gpbBom.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.gpbBom.Name = "gpbBom";
            this.gpbBom.Padding = new System.Windows.Forms.Padding(0);
            this.gpbBom.Size = new System.Drawing.Size(295, 97);
            this.gpbBom.TabIndex = 1;
            this.gpbBom.TabStop = false;
            this.gpbBom.Text = "BOM";
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(66, 59);
            this.cmbType.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(115, 29);
            this.cmbType.TabIndex = 14;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.FlatAppearance.BorderSize = 2;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(193, 25);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 58);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "查看";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(7, 61);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 27);
            this.label14.TabIndex = 12;
            this.label14.Text = "型号：";
            // 
            // cmbWkc
            // 
            this.cmbWkc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWkc.Enabled = false;
            this.cmbWkc.FormattingEnabled = true;
            this.cmbWkc.Location = new System.Drawing.Point(66, 16);
            this.cmbWkc.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cmbWkc.Name = "cmbWkc";
            this.cmbWkc.Size = new System.Drawing.Size(115, 29);
            this.cmbWkc.TabIndex = 11;
            this.cmbWkc.SelectedIndexChanged += new System.EventHandler(this.cmbWkc_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(6, 18);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 27);
            this.label13.TabIndex = 10;
            this.label13.Text = "工位：";
            // 
            // gpxAndon
            // 
            this.gpxAndon.Controls.Add(this.tplAndon);
            this.gpxAndon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxAndon.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpxAndon.Location = new System.Drawing.Point(0, 0);
            this.gpxAndon.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.gpxAndon.Name = "gpxAndon";
            this.gpxAndon.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.gpxAndon.Size = new System.Drawing.Size(295, 255);
            this.gpxAndon.TabIndex = 2;
            this.gpxAndon.TabStop = false;
            this.gpxAndon.Text = "Andon";
            // 
            // tplAndon
            // 
            this.tplAndon.ColumnCount = 2;
            this.tplAndon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tplAndon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tplAndon.Controls.Add(this.btnCall, 1, 0);
            this.tplAndon.Controls.Add(this.tlpAndonSelect, 0, 0);
            this.tplAndon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplAndon.Location = new System.Drawing.Point(6, 29);
            this.tplAndon.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.tplAndon.Name = "tplAndon";
            this.tplAndon.RowCount = 1;
            this.tplAndon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplAndon.Size = new System.Drawing.Size(283, 219);
            this.tplAndon.TabIndex = 0;
            // 
            // btnCall
            // 
            this.btnCall.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCall.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCall.FlatAppearance.BorderSize = 2;
            this.btnCall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCall.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCall.Location = new System.Drawing.Point(175, 38);
            this.btnCall.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(102, 142);
            this.btnCall.TabIndex = 23;
            this.btnCall.Text = "呼叫";
            this.btnCall.UseVisualStyleBackColor = false;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // tlpAndonSelect
            // 
            this.tlpAndonSelect.ColumnCount = 1;
            this.tlpAndonSelect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAndonSelect.Controls.Add(this.rdbOther, 0, 4);
            this.tlpAndonSelect.Controls.Add(this.rdbPartSupply, 0, 2);
            this.tlpAndonSelect.Controls.Add(this.rdbPartQc, 0, 3);
            this.tlpAndonSelect.Controls.Add(this.rdbPE, 0, 1);
            this.tlpAndonSelect.Controls.Add(this.rdbEquipment, 0, 0);
            this.tlpAndonSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAndonSelect.Location = new System.Drawing.Point(0, 0);
            this.tlpAndonSelect.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAndonSelect.Name = "tlpAndonSelect";
            this.tlpAndonSelect.RowCount = 5;
            this.tlpAndonSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpAndonSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpAndonSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpAndonSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpAndonSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpAndonSelect.Size = new System.Drawing.Size(169, 219);
            this.tlpAndonSelect.TabIndex = 0;
            // 
            // rdbOther
            // 
            this.rdbOther.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbOther.AutoSize = true;
            this.rdbOther.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbOther.Location = new System.Drawing.Point(6, 179);
            this.rdbOther.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.rdbOther.Name = "rdbOther";
            this.rdbOther.Size = new System.Drawing.Size(73, 33);
            this.rdbOther.TabIndex = 21;
            this.rdbOther.TabStop = true;
            this.rdbOther.Text = "其它";
            this.rdbOther.UseVisualStyleBackColor = true;
            // 
            // rdbPartSupply
            // 
            this.rdbPartSupply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbPartSupply.AutoSize = true;
            this.rdbPartSupply.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbPartSupply.Location = new System.Drawing.Point(6, 93);
            this.rdbPartSupply.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.rdbPartSupply.Name = "rdbPartSupply";
            this.rdbPartSupply.Size = new System.Drawing.Size(113, 29);
            this.rdbPartSupply.TabIndex = 18;
            this.rdbPartSupply.TabStop = true;
            this.rdbPartSupply.Text = "部件供应";
            this.rdbPartSupply.UseVisualStyleBackColor = true;
            // 
            // rdbPartQc
            // 
            this.rdbPartQc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbPartQc.AutoSize = true;
            this.rdbPartQc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbPartQc.Location = new System.Drawing.Point(6, 136);
            this.rdbPartQc.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.rdbPartQc.Name = "rdbPartQc";
            this.rdbPartQc.Size = new System.Drawing.Size(113, 29);
            this.rdbPartQc.TabIndex = 22;
            this.rdbPartQc.TabStop = true;
            this.rdbPartQc.Text = "部件质量";
            this.rdbPartQc.UseVisualStyleBackColor = true;
            // 
            // rdbPE
            // 
            this.rdbPE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbPE.AutoSize = true;
            this.rdbPE.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbPE.Location = new System.Drawing.Point(6, 50);
            this.rdbPE.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.rdbPE.Name = "rdbPE";
            this.rdbPE.Size = new System.Drawing.Size(73, 29);
            this.rdbPE.TabIndex = 19;
            this.rdbPE.TabStop = true;
            this.rdbPE.Text = "工艺";
            this.rdbPE.UseVisualStyleBackColor = true;
            // 
            // rdbEquipment
            // 
            this.rdbEquipment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbEquipment.AutoSize = true;
            this.rdbEquipment.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbEquipment.Location = new System.Drawing.Point(6, 7);
            this.rdbEquipment.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.rdbEquipment.Name = "rdbEquipment";
            this.rdbEquipment.Size = new System.Drawing.Size(73, 29);
            this.rdbEquipment.TabIndex = 20;
            this.rdbEquipment.TabStop = true;
            this.rdbEquipment.Text = "设备";
            this.rdbEquipment.UseVisualStyleBackColor = true;
            // 
            // timSubmit
            // 
            this.timSubmit.Interval = 1000;
            this.timSubmit.Tick += new System.EventHandler(this.timSubmit_Tick);
            // 
            // timDataRefresh
            // 
            this.timDataRefresh.Interval = 600000;
            this.timDataRefresh.Tick += new System.EventHandler(this.timDataRefresh_Tick);
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 489);
            this.Controls.Add(this.pnlOrderPartInfo);
            this.Controls.Add(this.pnlWkcAndPlan);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmProduct";
            this.Text = "生产";
            this.Load += new System.EventHandler(this.frmProduct_Load);
            this.pnlWkcAndPlan.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlOrderPartInfo.ResumeLayout(false);
            this.spcProblemAndProduct.Panel1.ResumeLayout(false);
            this.spcProblemAndProduct.Panel2.ResumeLayout(false);
            this.spcProblemAndProduct.ResumeLayout(false);
            this.spcProblem.Panel1.ResumeLayout(false);
            this.spcProblem.Panel2.ResumeLayout(false);
            this.spcProblem.ResumeLayout(false);
            this.gpbQcCause.ResumeLayout(false);
            this.gpbQcCause.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQc)).EndInit();
            this.gpbWkcJam.ResumeLayout(false);
            this.gpbWkcJam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJamCause)).EndInit();
            this.spcProduct.Panel1.ResumeLayout(false);
            this.spcProduct.Panel2.ResumeLayout(false);
            this.spcProduct.ResumeLayout(false);
            this.gpbBom.ResumeLayout(false);
            this.gpbBom.PerformLayout();
            this.gpxAndon.ResumeLayout(false);
            this.tplAndon.ResumeLayout(false);
            this.tlpAndonSelect.ResumeLayout(false);
            this.tlpAndonSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWkcAndPlan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblQtyOk1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblMoNo1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblQtySumByDay1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblMoQty1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblQtyNgSumByDay1;
        private System.Windows.Forms.Panel pnlOrderPartInfo;
        private System.Windows.Forms.SplitContainer spcProblemAndProduct;
        private System.Windows.Forms.SplitContainer spcProblem;
        private System.Windows.Forms.GroupBox gpbQcCause;
        private System.Windows.Forms.DataGridView dgvQc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQcTypeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQcSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQcCause;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbQcCause;
        private System.Windows.Forms.Button btnQcCauseSave;
        private System.Windows.Forms.GroupBox gpbWkcJam;
        private System.Windows.Forms.DataGridView dgvJamCause;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnJamStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnJamStopTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnJamCause;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnJamTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbJamCause;
        private System.Windows.Forms.Button btnJamSave;
        private System.Windows.Forms.SplitContainer spcProduct;
        private System.Windows.Forms.GroupBox gpbBom;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbWkc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox gpxAndon;
        private System.Windows.Forms.TableLayoutPanel tplAndon;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.TableLayoutPanel tlpAndonSelect;
        private System.Windows.Forms.RadioButton rdbOther;
        private System.Windows.Forms.RadioButton rdbPartSupply;
        private System.Windows.Forms.RadioButton rdbPartQc;
        private System.Windows.Forms.RadioButton rdbPE;
        private System.Windows.Forms.RadioButton rdbEquipment;
        private System.Windows.Forms.Timer timSubmit;
        private System.Windows.Forms.Timer timDataRefresh;


    }
}