namespace Client
{
    partial class frmPartBackup
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
            this.components = new System.ComponentModel.Container();
            this.btnPartBackupSearch = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpMaintanceStore = new System.Windows.Forms.DateTimePicker();
            this.dgvMaintainceInfo = new System.Windows.Forms.DataGridView();
            this.dgvColumnBackupPartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnBackupPartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnBackupPartDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnBackupPartQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnBackupPartUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnBackupPartManufacter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnBackupPartSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnBackupPartRegistime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnBackupPartRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timPartBackup = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaintainceInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPartBackupSearch
            // 
            this.btnPartBackupSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPartBackupSearch.FlatAppearance.BorderSize = 2;
            this.btnPartBackupSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnPartBackupSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPartBackupSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPartBackupSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPartBackupSearch.Location = new System.Drawing.Point(481, 4);
            this.btnPartBackupSearch.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnPartBackupSearch.Name = "btnPartBackupSearch";
            this.btnPartBackupSearch.Size = new System.Drawing.Size(243, 50);
            this.btnPartBackupSearch.TabIndex = 19;
            this.btnPartBackupSearch.Text = "备件信息查询";
            this.btnPartBackupSearch.UseVisualStyleBackColor = false;
            this.btnPartBackupSearch.Click += new System.EventHandler(this.btnPartBackupSearch_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(6, 15);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 27);
            this.label16.TabIndex = 18;
            this.label16.Text = "操作日期";
            // 
            // dtpMaintanceStore
            // 
            this.dtpMaintanceStore.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpMaintanceStore.Location = new System.Drawing.Point(110, 9);
            this.dtpMaintanceStore.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.dtpMaintanceStore.Name = "dtpMaintanceStore";
            this.dtpMaintanceStore.Size = new System.Drawing.Size(360, 39);
            this.dtpMaintanceStore.TabIndex = 17;
            // 
            // dgvMaintainceInfo
            // 
            this.dgvMaintainceInfo.AllowUserToAddRows = false;
            this.dgvMaintainceInfo.AllowUserToDeleteRows = false;
            this.dgvMaintainceInfo.AllowUserToOrderColumns = true;
            this.dgvMaintainceInfo.AllowUserToResizeRows = false;
            this.dgvMaintainceInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMaintainceInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvMaintainceInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMaintainceInfo.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvMaintainceInfo.ColumnHeadersHeight = 36;
            this.dgvMaintainceInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMaintainceInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColumnBackupPartNo,
            this.dgvColumnBackupPartName,
            this.dgvColumnBackupPartDesc,
            this.dgvColumnBackupPartQty,
            this.dgvColumnBackupPartUnitPrice,
            this.dgvColumnBackupPartManufacter,
            this.dgvColumnBackupPartSize,
            this.dgvColumnBackupPartRegistime,
            this.dgvColumnBackupPartRemark});
            this.dgvMaintainceInfo.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvMaintainceInfo.Location = new System.Drawing.Point(2, 62);
            this.dgvMaintainceInfo.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.dgvMaintainceInfo.Name = "dgvMaintainceInfo";
            this.dgvMaintainceInfo.RowHeadersVisible = false;
            this.dgvMaintainceInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMaintainceInfo.ShowCellErrors = false;
            this.dgvMaintainceInfo.Size = new System.Drawing.Size(763, 426);
            this.dgvMaintainceInfo.TabIndex = 20;
            // 
            // dgvColumnBackupPartNo
            // 
            this.dgvColumnBackupPartNo.HeaderText = "编号";
            this.dgvColumnBackupPartNo.Name = "dgvColumnBackupPartNo";
            // 
            // dgvColumnBackupPartName
            // 
            this.dgvColumnBackupPartName.HeaderText = "名称";
            this.dgvColumnBackupPartName.Name = "dgvColumnBackupPartName";
            // 
            // dgvColumnBackupPartDesc
            // 
            this.dgvColumnBackupPartDesc.HeaderText = "描述";
            this.dgvColumnBackupPartDesc.Name = "dgvColumnBackupPartDesc";
            // 
            // dgvColumnBackupPartQty
            // 
            this.dgvColumnBackupPartQty.HeaderText = "数量";
            this.dgvColumnBackupPartQty.Name = "dgvColumnBackupPartQty";
            // 
            // dgvColumnBackupPartUnitPrice
            // 
            this.dgvColumnBackupPartUnitPrice.HeaderText = "单价";
            this.dgvColumnBackupPartUnitPrice.Name = "dgvColumnBackupPartUnitPrice";
            // 
            // dgvColumnBackupPartManufacter
            // 
            this.dgvColumnBackupPartManufacter.HeaderText = "生产商";
            this.dgvColumnBackupPartManufacter.Name = "dgvColumnBackupPartManufacter";
            // 
            // dgvColumnBackupPartSize
            // 
            this.dgvColumnBackupPartSize.HeaderText = "规格尺寸";
            this.dgvColumnBackupPartSize.Name = "dgvColumnBackupPartSize";
            // 
            // dgvColumnBackupPartRegistime
            // 
            this.dgvColumnBackupPartRegistime.HeaderText = "登记时间";
            this.dgvColumnBackupPartRegistime.Name = "dgvColumnBackupPartRegistime";
            // 
            // dgvColumnBackupPartRemark
            // 
            this.dgvColumnBackupPartRemark.HeaderText = "备注";
            this.dgvColumnBackupPartRemark.Name = "dgvColumnBackupPartRemark";
            // 
            // timPartBackup
            // 
            this.timPartBackup.Interval = 300000;
            this.timPartBackup.Tick += new System.EventHandler(this.timPartBackup_Tick);
            // 
            // frmPartBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 489);
            this.Controls.Add(this.dgvMaintainceInfo);
            this.Controls.Add(this.btnPartBackupSearch);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dtpMaintanceStore);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPartBackup";
            this.Text = "备件信息";
            this.Load += new System.EventHandler(this.frmPartBackup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaintainceInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPartBackupSearch;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpMaintanceStore;
        private System.Windows.Forms.DataGridView dgvMaintainceInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnBackupPartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnBackupPartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnBackupPartDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnBackupPartQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnBackupPartUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnBackupPartManufacter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnBackupPartSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnBackupPartRegistime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnBackupPartRemark;
        private System.Windows.Forms.Timer timPartBackup;

    }
}