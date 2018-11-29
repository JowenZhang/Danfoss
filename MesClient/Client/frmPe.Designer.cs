namespace Client
{
    partial class frmPe
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
            this.spcBasePe = new System.Windows.Forms.SplitContainer();
            this.cmbPeWkc = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.pnlPeBase = new System.Windows.Forms.Panel();
            this.spcPeBase = new System.Windows.Forms.SplitContainer();
            this.gbxPeFile = new System.Windows.Forms.GroupBox();
            this.dgvFileFlow = new System.Windows.Forms.DataGridView();
            this.colPeFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeFileDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeFileCreater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPeFileFlow = new System.Windows.Forms.Button();
            this.btnPeFileWatch = new System.Windows.Forms.Button();
            this.rdbPeSaf = new System.Windows.Forms.RadioButton();
            this.rdbPeJsa = new System.Windows.Forms.RadioButton();
            this.rdbPeFi = new System.Windows.Forms.RadioButton();
            this.rdbPeVi = new System.Windows.Forms.RadioButton();
            this.rdbPeSi = new System.Windows.Forms.RadioButton();
            this.rdbPeCi = new System.Windows.Forms.RadioButton();
            this.rdbPeSop = new System.Windows.Forms.RadioButton();
            this.gpxOpt = new System.Windows.Forms.GroupBox();
            this.btnLocalDataUpload = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPeDataDownload = new System.Windows.Forms.Button();
            this.spcBasePe.Panel1.SuspendLayout();
            this.spcBasePe.Panel2.SuspendLayout();
            this.spcBasePe.SuspendLayout();
            this.pnlPeBase.SuspendLayout();
            this.spcPeBase.Panel1.SuspendLayout();
            this.spcPeBase.Panel2.SuspendLayout();
            this.spcPeBase.SuspendLayout();
            this.gbxPeFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileFlow)).BeginInit();
            this.gpxOpt.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcBasePe
            // 
            this.spcBasePe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcBasePe.Location = new System.Drawing.Point(0, 0);
            this.spcBasePe.Margin = new System.Windows.Forms.Padding(1);
            this.spcBasePe.Name = "spcBasePe";
            this.spcBasePe.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcBasePe.Panel1
            // 
            this.spcBasePe.Panel1.Controls.Add(this.cmbPeWkc);
            this.spcBasePe.Panel1.Controls.Add(this.label17);
            // 
            // spcBasePe.Panel2
            // 
            this.spcBasePe.Panel2.Controls.Add(this.pnlPeBase);
            this.spcBasePe.Size = new System.Drawing.Size(766, 489);
            this.spcBasePe.SplitterDistance = 45;
            this.spcBasePe.SplitterWidth = 2;
            this.spcBasePe.TabIndex = 0;
            // 
            // cmbPeWkc
            // 
            this.cmbPeWkc.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPeWkc.FormattingEnabled = true;
            this.cmbPeWkc.Location = new System.Drawing.Point(82, 1);
            this.cmbPeWkc.Margin = new System.Windows.Forms.Padding(1);
            this.cmbPeWkc.Name = "cmbPeWkc";
            this.cmbPeWkc.Size = new System.Drawing.Size(498, 43);
            this.cmbPeWkc.TabIndex = 12;
            this.cmbPeWkc.SelectedIndexChanged += new System.EventHandler(this.cmbPeWkc_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(6, 4);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 27);
            this.label17.TabIndex = 11;
            this.label17.Text = "工位：";
            // 
            // pnlPeBase
            // 
            this.pnlPeBase.Controls.Add(this.spcPeBase);
            this.pnlPeBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPeBase.Location = new System.Drawing.Point(0, 0);
            this.pnlPeBase.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPeBase.Name = "pnlPeBase";
            this.pnlPeBase.Size = new System.Drawing.Size(766, 442);
            this.pnlPeBase.TabIndex = 12;
            // 
            // spcPeBase
            // 
            this.spcPeBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcPeBase.Location = new System.Drawing.Point(0, 0);
            this.spcPeBase.Margin = new System.Windows.Forms.Padding(1);
            this.spcPeBase.Name = "spcPeBase";
            // 
            // spcPeBase.Panel1
            // 
            this.spcPeBase.Panel1.Controls.Add(this.gbxPeFile);
            this.spcPeBase.Panel1MinSize = 580;
            // 
            // spcPeBase.Panel2
            // 
            this.spcPeBase.Panel2.Controls.Add(this.gpxOpt);
            this.spcPeBase.Panel2MinSize = 100;
            this.spcPeBase.Size = new System.Drawing.Size(766, 442);
            this.spcPeBase.SplitterDistance = 620;
            this.spcPeBase.SplitterWidth = 2;
            this.spcPeBase.TabIndex = 0;
            // 
            // gbxPeFile
            // 
            this.gbxPeFile.Controls.Add(this.dgvFileFlow);
            this.gbxPeFile.Controls.Add(this.btnPeFileFlow);
            this.gbxPeFile.Controls.Add(this.btnPeFileWatch);
            this.gbxPeFile.Controls.Add(this.rdbPeSaf);
            this.gbxPeFile.Controls.Add(this.rdbPeJsa);
            this.gbxPeFile.Controls.Add(this.rdbPeFi);
            this.gbxPeFile.Controls.Add(this.rdbPeVi);
            this.gbxPeFile.Controls.Add(this.rdbPeSi);
            this.gbxPeFile.Controls.Add(this.rdbPeCi);
            this.gbxPeFile.Controls.Add(this.rdbPeSop);
            this.gbxPeFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxPeFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbxPeFile.Location = new System.Drawing.Point(0, 0);
            this.gbxPeFile.Margin = new System.Windows.Forms.Padding(4);
            this.gbxPeFile.Name = "gbxPeFile";
            this.gbxPeFile.Padding = new System.Windows.Forms.Padding(4);
            this.gbxPeFile.Size = new System.Drawing.Size(620, 442);
            this.gbxPeFile.TabIndex = 0;
            this.gbxPeFile.TabStop = false;
            this.gbxPeFile.Text = "工艺文件类型";
            // 
            // dgvFileFlow
            // 
            this.dgvFileFlow.AllowUserToAddRows = false;
            this.dgvFileFlow.AllowUserToDeleteRows = false;
            this.dgvFileFlow.AllowUserToOrderColumns = true;
            this.dgvFileFlow.AllowUserToResizeRows = false;
            this.dgvFileFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFileFlow.BackgroundColor = System.Drawing.Color.White;
            this.dgvFileFlow.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvFileFlow.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvFileFlow.ColumnHeadersHeight = 36;
            this.dgvFileFlow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFileFlow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPeFileName,
            this.colPeFileDateTime,
            this.colPeFileCreater});
            this.dgvFileFlow.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvFileFlow.Location = new System.Drawing.Point(4, 76);
            this.dgvFileFlow.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFileFlow.Name = "dgvFileFlow";
            this.dgvFileFlow.RowHeadersVisible = false;
            this.dgvFileFlow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFileFlow.ShowCellErrors = false;
            this.dgvFileFlow.Size = new System.Drawing.Size(613, 366);
            this.dgvFileFlow.TabIndex = 24;
            // 
            // colPeFileName
            // 
            this.colPeFileName.HeaderText = "文件名";
            this.colPeFileName.Name = "colPeFileName";
            this.colPeFileName.Width = 200;
            // 
            // colPeFileDateTime
            // 
            this.colPeFileDateTime.HeaderText = "日期";
            this.colPeFileDateTime.Name = "colPeFileDateTime";
            this.colPeFileDateTime.Width = 180;
            // 
            // colPeFileCreater
            // 
            this.colPeFileCreater.HeaderText = "编制";
            this.colPeFileCreater.Name = "colPeFileCreater";
            this.colPeFileCreater.Width = 140;
            // 
            // btnPeFileFlow
            // 
            this.btnPeFileFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPeFileFlow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPeFileFlow.FlatAppearance.BorderSize = 2;
            this.btnPeFileFlow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnPeFileFlow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPeFileFlow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPeFileFlow.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPeFileFlow.Location = new System.Drawing.Point(435, 12);
            this.btnPeFileFlow.Margin = new System.Windows.Forms.Padding(0);
            this.btnPeFileFlow.Name = "btnPeFileFlow";
            this.btnPeFileFlow.Size = new System.Drawing.Size(90, 60);
            this.btnPeFileFlow.TabIndex = 23;
            this.btnPeFileFlow.Text = "流程";
            this.btnPeFileFlow.UseVisualStyleBackColor = false;
            this.btnPeFileFlow.Click += new System.EventHandler(this.btnPeFileFlow_Click);
            // 
            // btnPeFileWatch
            // 
            this.btnPeFileWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPeFileWatch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPeFileWatch.FlatAppearance.BorderSize = 2;
            this.btnPeFileWatch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnPeFileWatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPeFileWatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPeFileWatch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPeFileWatch.Location = new System.Drawing.Point(527, 12);
            this.btnPeFileWatch.Margin = new System.Windows.Forms.Padding(0);
            this.btnPeFileWatch.Name = "btnPeFileWatch";
            this.btnPeFileWatch.Size = new System.Drawing.Size(90, 60);
            this.btnPeFileWatch.TabIndex = 23;
            this.btnPeFileWatch.Text = "打开";
            this.btnPeFileWatch.UseVisualStyleBackColor = false;
            this.btnPeFileWatch.Click += new System.EventHandler(this.btnPeFileWatch_Click);
            // 
            // rdbPeSaf
            // 
            this.rdbPeSaf.AutoSize = true;
            this.rdbPeSaf.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbPeSaf.Location = new System.Drawing.Point(343, 30);
            this.rdbPeSaf.Margin = new System.Windows.Forms.Padding(4);
            this.rdbPeSaf.Name = "rdbPeSaf";
            this.rdbPeSaf.Size = new System.Drawing.Size(62, 27);
            this.rdbPeSaf.TabIndex = 16;
            this.rdbPeSaf.TabStop = true;
            this.rdbPeSaf.Text = "SAF";
            this.rdbPeSaf.UseVisualStyleBackColor = true;
            this.rdbPeSaf.CheckedChanged += new System.EventHandler(this.rdbPeSaf_CheckedChanged);
            // 
            // rdbPeJsa
            // 
            this.rdbPeJsa.AutoSize = true;
            this.rdbPeJsa.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbPeJsa.Location = new System.Drawing.Point(278, 30);
            this.rdbPeJsa.Margin = new System.Windows.Forms.Padding(4);
            this.rdbPeJsa.Name = "rdbPeJsa";
            this.rdbPeJsa.Size = new System.Drawing.Size(60, 27);
            this.rdbPeJsa.TabIndex = 17;
            this.rdbPeJsa.TabStop = true;
            this.rdbPeJsa.Text = "JSA";
            this.rdbPeJsa.UseVisualStyleBackColor = true;
            this.rdbPeJsa.CheckedChanged += new System.EventHandler(this.rdbPeJsa_CheckedChanged);
            // 
            // rdbPeFi
            // 
            this.rdbPeFi.AutoSize = true;
            this.rdbPeFi.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbPeFi.Location = new System.Drawing.Point(228, 30);
            this.rdbPeFi.Margin = new System.Windows.Forms.Padding(4);
            this.rdbPeFi.Name = "rdbPeFi";
            this.rdbPeFi.Size = new System.Drawing.Size(45, 27);
            this.rdbPeFi.TabIndex = 18;
            this.rdbPeFi.TabStop = true;
            this.rdbPeFi.Text = "FI";
            this.rdbPeFi.UseVisualStyleBackColor = true;
            this.rdbPeFi.CheckedChanged += new System.EventHandler(this.rdbPeFi_CheckedChanged);
            // 
            // rdbPeVi
            // 
            this.rdbPeVi.AutoSize = true;
            this.rdbPeVi.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbPeVi.Location = new System.Drawing.Point(175, 30);
            this.rdbPeVi.Margin = new System.Windows.Forms.Padding(4);
            this.rdbPeVi.Name = "rdbPeVi";
            this.rdbPeVi.Size = new System.Drawing.Size(48, 27);
            this.rdbPeVi.TabIndex = 19;
            this.rdbPeVi.TabStop = true;
            this.rdbPeVi.Text = "VI";
            this.rdbPeVi.UseVisualStyleBackColor = true;
            this.rdbPeVi.CheckedChanged += new System.EventHandler(this.rdbPeVi_CheckedChanged);
            // 
            // rdbPeSi
            // 
            this.rdbPeSi.AutoSize = true;
            this.rdbPeSi.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbPeSi.Location = new System.Drawing.Point(124, 30);
            this.rdbPeSi.Margin = new System.Windows.Forms.Padding(4);
            this.rdbPeSi.Name = "rdbPeSi";
            this.rdbPeSi.Size = new System.Drawing.Size(46, 27);
            this.rdbPeSi.TabIndex = 20;
            this.rdbPeSi.TabStop = true;
            this.rdbPeSi.Text = "SI";
            this.rdbPeSi.UseVisualStyleBackColor = true;
            this.rdbPeSi.CheckedChanged += new System.EventHandler(this.rdbPeSi_CheckedChanged);
            // 
            // rdbPeCi
            // 
            this.rdbPeCi.AutoSize = true;
            this.rdbPeCi.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbPeCi.Location = new System.Drawing.Point(72, 30);
            this.rdbPeCi.Margin = new System.Windows.Forms.Padding(4);
            this.rdbPeCi.Name = "rdbPeCi";
            this.rdbPeCi.Size = new System.Drawing.Size(47, 27);
            this.rdbPeCi.TabIndex = 21;
            this.rdbPeCi.TabStop = true;
            this.rdbPeCi.Text = "CI";
            this.rdbPeCi.UseVisualStyleBackColor = true;
            this.rdbPeCi.CheckedChanged += new System.EventHandler(this.rdbPeCi_CheckedChanged);
            // 
            // rdbPeSop
            // 
            this.rdbPeSop.AutoSize = true;
            this.rdbPeSop.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbPeSop.Location = new System.Drawing.Point(4, 30);
            this.rdbPeSop.Margin = new System.Windows.Forms.Padding(4);
            this.rdbPeSop.Name = "rdbPeSop";
            this.rdbPeSop.Size = new System.Drawing.Size(63, 27);
            this.rdbPeSop.TabIndex = 22;
            this.rdbPeSop.TabStop = true;
            this.rdbPeSop.Text = "Sop";
            this.rdbPeSop.UseVisualStyleBackColor = true;
            this.rdbPeSop.CheckedChanged += new System.EventHandler(this.rdbPeSop_CheckedChanged);
            // 
            // gpxOpt
            // 
            this.gpxOpt.Controls.Add(this.btnLocalDataUpload);
            this.gpxOpt.Controls.Add(this.button1);
            this.gpxOpt.Controls.Add(this.btnPeDataDownload);
            this.gpxOpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxOpt.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpxOpt.Location = new System.Drawing.Point(0, 0);
            this.gpxOpt.Margin = new System.Windows.Forms.Padding(4);
            this.gpxOpt.Name = "gpxOpt";
            this.gpxOpt.Padding = new System.Windows.Forms.Padding(4);
            this.gpxOpt.Size = new System.Drawing.Size(144, 442);
            this.gpxOpt.TabIndex = 0;
            this.gpxOpt.TabStop = false;
            // 
            // btnLocalDataUpload
            // 
            this.btnLocalDataUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocalDataUpload.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLocalDataUpload.FlatAppearance.BorderSize = 2;
            this.btnLocalDataUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnLocalDataUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLocalDataUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalDataUpload.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLocalDataUpload.Location = new System.Drawing.Point(0, 382);
            this.btnLocalDataUpload.Margin = new System.Windows.Forms.Padding(4);
            this.btnLocalDataUpload.Name = "btnLocalDataUpload";
            this.btnLocalDataUpload.Size = new System.Drawing.Size(144, 60);
            this.btnLocalDataUpload.TabIndex = 8;
            this.btnLocalDataUpload.Text = "数据上传";
            this.btnLocalDataUpload.UseVisualStyleBackColor = false;
            this.btnLocalDataUpload.Click += new System.EventHandler(this.btnLocalDataUpload_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(0, 246);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 60);
            this.button1.TabIndex = 9;
            this.button1.Text = "手动报工";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // btnPeDataDownload
            // 
            this.btnPeDataDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPeDataDownload.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPeDataDownload.FlatAppearance.BorderSize = 2;
            this.btnPeDataDownload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnPeDataDownload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPeDataDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPeDataDownload.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPeDataDownload.Location = new System.Drawing.Point(0, 314);
            this.btnPeDataDownload.Margin = new System.Windows.Forms.Padding(4);
            this.btnPeDataDownload.Name = "btnPeDataDownload";
            this.btnPeDataDownload.Size = new System.Drawing.Size(144, 60);
            this.btnPeDataDownload.TabIndex = 9;
            this.btnPeDataDownload.Text = "工艺参数下载";
            this.btnPeDataDownload.UseVisualStyleBackColor = false;
            this.btnPeDataDownload.Click += new System.EventHandler(this.btnPeDataDownload_Click);
            // 
            // frmPe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 489);
            this.Controls.Add(this.spcBasePe);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPe";
            this.Text = "工艺";
            this.Load += new System.EventHandler(this.frmPe_Load);
            this.spcBasePe.Panel1.ResumeLayout(false);
            this.spcBasePe.Panel1.PerformLayout();
            this.spcBasePe.Panel2.ResumeLayout(false);
            this.spcBasePe.ResumeLayout(false);
            this.pnlPeBase.ResumeLayout(false);
            this.spcPeBase.Panel1.ResumeLayout(false);
            this.spcPeBase.Panel2.ResumeLayout(false);
            this.spcPeBase.ResumeLayout(false);
            this.gbxPeFile.ResumeLayout(false);
            this.gbxPeFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileFlow)).EndInit();
            this.gpxOpt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcBasePe;
        private System.Windows.Forms.ComboBox cmbPeWkc;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel pnlPeBase;
        private System.Windows.Forms.SplitContainer spcPeBase;
        private System.Windows.Forms.GroupBox gbxPeFile;
        private System.Windows.Forms.DataGridView dgvFileFlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeFileDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeFileCreater;
        private System.Windows.Forms.Button btnPeFileFlow;
        private System.Windows.Forms.Button btnPeFileWatch;
        private System.Windows.Forms.RadioButton rdbPeSaf;
        private System.Windows.Forms.RadioButton rdbPeJsa;
        private System.Windows.Forms.RadioButton rdbPeFi;
        private System.Windows.Forms.RadioButton rdbPeVi;
        private System.Windows.Forms.RadioButton rdbPeSi;
        private System.Windows.Forms.RadioButton rdbPeCi;
        private System.Windows.Forms.RadioButton rdbPeSop;
        private System.Windows.Forms.GroupBox gpxOpt;
        private System.Windows.Forms.Button btnLocalDataUpload;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPeDataDownload;

    }
}