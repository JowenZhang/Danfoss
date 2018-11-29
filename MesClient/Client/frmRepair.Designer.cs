namespace Client
{
    partial class frmRepair
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
            this.label4 = new System.Windows.Forms.Label();
            this.lblEqmStatus = new System.Windows.Forms.Label();
            this.pnlRepaire = new System.Windows.Forms.Panel();
            this.spcRepair = new System.Windows.Forms.SplitContainer();
            this.dgvEqmRepair = new System.Windows.Forms.DataGridView();
            this.colRepairEqmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRepairContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRepairDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRepairRecord = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpRepair = new System.Windows.Forms.DateTimePicker();
            this.dgvEqmMaintaince = new System.Windows.Forms.DataGridView();
            this.colMaintainWorkshop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintainSubLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintainDeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintainDeviceXh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintainPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintainItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintainPartCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintainTaskInformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintainBasicrequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintainNotice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintainDetectcondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintainBeginMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintainPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintainAftermaintain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintaincompel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintainmake_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaintainw_man_hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnWaitingMaintenceRecord = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpMaintence = new System.Windows.Forms.DateTimePicker();
            this.pnlRepaire.SuspendLayout();
            this.spcRepair.Panel1.SuspendLayout();
            this.spcRepair.Panel2.SuspendLayout();
            this.spcRepair.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEqmRepair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEqmMaintaince)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(4, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 27);
            this.label4.TabIndex = 5;
            this.label4.Text = "设备当前状态:";
            // 
            // lblEqmStatus
            // 
            this.lblEqmStatus.AutoSize = true;
            this.lblEqmStatus.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEqmStatus.Location = new System.Drawing.Point(150, 4);
            this.lblEqmStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEqmStatus.Name = "lblEqmStatus";
            this.lblEqmStatus.Size = new System.Drawing.Size(69, 36);
            this.lblEqmStatus.TabIndex = 6;
            this.lblEqmStatus.Text = "正常";
            // 
            // pnlRepaire
            // 
            this.pnlRepaire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRepaire.Controls.Add(this.spcRepair);
            this.pnlRepaire.Location = new System.Drawing.Point(-1, 49);
            this.pnlRepaire.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.pnlRepaire.Name = "pnlRepaire";
            this.pnlRepaire.Size = new System.Drawing.Size(767, 440);
            this.pnlRepaire.TabIndex = 7;
            // 
            // spcRepair
            // 
            this.spcRepair.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcRepair.Location = new System.Drawing.Point(0, 0);
            this.spcRepair.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.spcRepair.Name = "spcRepair";
            this.spcRepair.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcRepair.Panel1
            // 
            this.spcRepair.Panel1.Controls.Add(this.dgvEqmRepair);
            this.spcRepair.Panel1.Controls.Add(this.btnRepairRecord);
            this.spcRepair.Panel1.Controls.Add(this.label10);
            this.spcRepair.Panel1.Controls.Add(this.dtpRepair);
            // 
            // spcRepair.Panel2
            // 
            this.spcRepair.Panel2.Controls.Add(this.dgvEqmMaintaince);
            this.spcRepair.Panel2.Controls.Add(this.btnWaitingMaintenceRecord);
            this.spcRepair.Panel2.Controls.Add(this.label12);
            this.spcRepair.Panel2.Controls.Add(this.dtpMaintence);
            this.spcRepair.Size = new System.Drawing.Size(767, 440);
            this.spcRepair.SplitterDistance = 215;
            this.spcRepair.SplitterWidth = 9;
            this.spcRepair.TabIndex = 0;
            // 
            // dgvEqmRepair
            // 
            this.dgvEqmRepair.AllowUserToAddRows = false;
            this.dgvEqmRepair.AllowUserToDeleteRows = false;
            this.dgvEqmRepair.AllowUserToOrderColumns = true;
            this.dgvEqmRepair.AllowUserToResizeRows = false;
            this.dgvEqmRepair.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEqmRepair.BackgroundColor = System.Drawing.Color.White;
            this.dgvEqmRepair.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvEqmRepair.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvEqmRepair.ColumnHeadersHeight = 36;
            this.dgvEqmRepair.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEqmRepair.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRepairEqmName,
            this.colRepairContent,
            this.colRepairDateTime});
            this.dgvEqmRepair.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvEqmRepair.Location = new System.Drawing.Point(0, 60);
            this.dgvEqmRepair.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.dgvEqmRepair.Name = "dgvEqmRepair";
            this.dgvEqmRepair.RowHeadersVisible = false;
            this.dgvEqmRepair.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvEqmRepair.ShowCellErrors = false;
            this.dgvEqmRepair.Size = new System.Drawing.Size(767, 157);
            this.dgvEqmRepair.TabIndex = 12;
            // 
            // colRepairEqmName
            // 
            this.colRepairEqmName.HeaderText = "设备名称";
            this.colRepairEqmName.Name = "colRepairEqmName";
            this.colRepairEqmName.Width = 120;
            // 
            // colRepairContent
            // 
            this.colRepairContent.HeaderText = "事件/内容";
            this.colRepairContent.Name = "colRepairContent";
            this.colRepairContent.Width = 320;
            // 
            // colRepairDateTime
            // 
            this.colRepairDateTime.HeaderText = "日期";
            this.colRepairDateTime.Name = "colRepairDateTime";
            this.colRepairDateTime.Width = 140;
            // 
            // btnRepairRecord
            // 
            this.btnRepairRecord.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRepairRecord.FlatAppearance.BorderSize = 2;
            this.btnRepairRecord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRepairRecord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRepairRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepairRecord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRepairRecord.Location = new System.Drawing.Point(470, 5);
            this.btnRepairRecord.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnRepairRecord.Name = "btnRepairRecord";
            this.btnRepairRecord.Size = new System.Drawing.Size(280, 50);
            this.btnRepairRecord.TabIndex = 8;
            this.btnRepairRecord.Text = "停机记录查询";
            this.btnRepairRecord.UseVisualStyleBackColor = false;
            this.btnRepairRecord.Click += new System.EventHandler(this.btnRepairRecord_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(6, 18);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 27);
            this.label10.TabIndex = 4;
            this.label10.Text = "操作日期";
            // 
            // dtpRepair
            // 
            this.dtpRepair.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpRepair.Location = new System.Drawing.Point(104, 11);
            this.dtpRepair.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.dtpRepair.Name = "dtpRepair";
            this.dtpRepair.Size = new System.Drawing.Size(360, 39);
            this.dtpRepair.TabIndex = 0;
            // 
            // dgvEqmMaintaince
            // 
            this.dgvEqmMaintaince.AllowUserToAddRows = false;
            this.dgvEqmMaintaince.AllowUserToDeleteRows = false;
            this.dgvEqmMaintaince.AllowUserToOrderColumns = true;
            this.dgvEqmMaintaince.AllowUserToResizeRows = false;
            this.dgvEqmMaintaince.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEqmMaintaince.BackgroundColor = System.Drawing.Color.White;
            this.dgvEqmMaintaince.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvEqmMaintaince.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvEqmMaintaince.ColumnHeadersHeight = 36;
            this.dgvEqmMaintaince.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEqmMaintaince.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaintainWorkshop,
            this.colMaintainSubLine,
            this.colMaintainDeviceName,
            this.colMaintainDeviceXh,
            this.colMaintainPart,
            this.colMaintainItem,
            this.colMaintainPartCode,
            this.colMaintainTaskInformation,
            this.colMaintainBasicrequest,
            this.colMaintainNotice,
            this.colMaintainDetectcondition,
            this.colMaintainBeginMonth,
            this.colMaintainPeriod,
            this.colMaintainAftermaintain,
            this.colMaintaincompel,
            this.colMaintainmake_date,
            this.colMaintainw_man_hour});
            this.dgvEqmMaintaince.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvEqmMaintaince.Location = new System.Drawing.Point(0, 63);
            this.dgvEqmMaintaince.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.dgvEqmMaintaince.Name = "dgvEqmMaintaince";
            this.dgvEqmMaintaince.RowHeadersVisible = false;
            this.dgvEqmMaintaince.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvEqmMaintaince.ShowCellErrors = false;
            this.dgvEqmMaintaince.Size = new System.Drawing.Size(767, 148);
            this.dgvEqmMaintaince.TabIndex = 13;
            // 
            // colMaintainWorkshop
            // 
            this.colMaintainWorkshop.HeaderText = "加工中心";
            this.colMaintainWorkshop.Name = "colMaintainWorkshop";
            this.colMaintainWorkshop.Width = 120;
            // 
            // colMaintainSubLine
            // 
            this.colMaintainSubLine.HeaderText = "子级线体";
            this.colMaintainSubLine.Name = "colMaintainSubLine";
            // 
            // colMaintainDeviceName
            // 
            this.colMaintainDeviceName.HeaderText = "设备名称";
            this.colMaintainDeviceName.Name = "colMaintainDeviceName";
            this.colMaintainDeviceName.Width = 120;
            // 
            // colMaintainDeviceXh
            // 
            this.colMaintainDeviceXh.HeaderText = "设备序号";
            this.colMaintainDeviceXh.Name = "colMaintainDeviceXh";
            // 
            // colMaintainPart
            // 
            this.colMaintainPart.HeaderText = "系统分组";
            this.colMaintainPart.Name = "colMaintainPart";
            this.colMaintainPart.Width = 160;
            // 
            // colMaintainItem
            // 
            this.colMaintainItem.HeaderText = "保养对象";
            this.colMaintainItem.Name = "colMaintainItem";
            this.colMaintainItem.Width = 160;
            // 
            // colMaintainPartCode
            // 
            this.colMaintainPartCode.HeaderText = "对象编号";
            this.colMaintainPartCode.Name = "colMaintainPartCode";
            this.colMaintainPartCode.Width = 120;
            // 
            // colMaintainTaskInformation
            // 
            this.colMaintainTaskInformation.HeaderText = "任务信息";
            this.colMaintainTaskInformation.Name = "colMaintainTaskInformation";
            // 
            // colMaintainBasicrequest
            // 
            this.colMaintainBasicrequest.HeaderText = "基本要求";
            this.colMaintainBasicrequest.Name = "colMaintainBasicrequest";
            // 
            // colMaintainNotice
            // 
            this.colMaintainNotice.HeaderText = "注意事项";
            this.colMaintainNotice.Name = "colMaintainNotice";
            // 
            // colMaintainDetectcondition
            // 
            this.colMaintainDetectcondition.HeaderText = "检验条件";
            this.colMaintainDetectcondition.Name = "colMaintainDetectcondition";
            // 
            // colMaintainBeginMonth
            // 
            this.colMaintainBeginMonth.HeaderText = "起始月份";
            this.colMaintainBeginMonth.Name = "colMaintainBeginMonth";
            this.colMaintainBeginMonth.Width = 120;
            // 
            // colMaintainPeriod
            // 
            this.colMaintainPeriod.HeaderText = "周期";
            this.colMaintainPeriod.Name = "colMaintainPeriod";
            // 
            // colMaintainAftermaintain
            // 
            this.colMaintainAftermaintain.HeaderText = "维保完毕";
            this.colMaintainAftermaintain.Name = "colMaintainAftermaintain";
            // 
            // colMaintaincompel
            // 
            this.colMaintaincompel.HeaderText = "强制隔离";
            this.colMaintaincompel.Name = "colMaintaincompel";
            // 
            // colMaintainmake_date
            // 
            this.colMaintainmake_date.HeaderText = "执行日期";
            this.colMaintainmake_date.Name = "colMaintainmake_date";
            this.colMaintainmake_date.Width = 120;
            // 
            // colMaintainw_man_hour
            // 
            this.colMaintainw_man_hour.HeaderText = "人工工时";
            this.colMaintainw_man_hour.Name = "colMaintainw_man_hour";
            // 
            // btnWaitingMaintenceRecord
            // 
            this.btnWaitingMaintenceRecord.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnWaitingMaintenceRecord.FlatAppearance.BorderSize = 2;
            this.btnWaitingMaintenceRecord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnWaitingMaintenceRecord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnWaitingMaintenceRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaitingMaintenceRecord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWaitingMaintenceRecord.Location = new System.Drawing.Point(470, 6);
            this.btnWaitingMaintenceRecord.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnWaitingMaintenceRecord.Name = "btnWaitingMaintenceRecord";
            this.btnWaitingMaintenceRecord.Size = new System.Drawing.Size(280, 50);
            this.btnWaitingMaintenceRecord.TabIndex = 12;
            this.btnWaitingMaintenceRecord.Text = "待保养设备查询";
            this.btnWaitingMaintenceRecord.UseVisualStyleBackColor = false;
            this.btnWaitingMaintenceRecord.Click += new System.EventHandler(this.btnWaitingMaintenceRecord_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(6, 18);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 27);
            this.label12.TabIndex = 11;
            this.label12.Text = "操作日期";
            // 
            // dtpMaintence
            // 
            this.dtpMaintence.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpMaintence.Location = new System.Drawing.Point(104, 11);
            this.dtpMaintence.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.dtpMaintence.Name = "dtpMaintence";
            this.dtpMaintence.Size = new System.Drawing.Size(360, 39);
            this.dtpMaintence.TabIndex = 10;
            // 
            // frmRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 489);
            this.Controls.Add(this.pnlRepaire);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEqmStatus);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.Name = "frmRepair";
            this.Text = "维修";
            this.Load += new System.EventHandler(this.frmRepair_Load);
            this.pnlRepaire.ResumeLayout(false);
            this.spcRepair.Panel1.ResumeLayout(false);
            this.spcRepair.Panel1.PerformLayout();
            this.spcRepair.Panel2.ResumeLayout(false);
            this.spcRepair.Panel2.PerformLayout();
            this.spcRepair.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEqmRepair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEqmMaintaince)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEqmStatus;
        private System.Windows.Forms.Panel pnlRepaire;
        private System.Windows.Forms.SplitContainer spcRepair;
        private System.Windows.Forms.DataGridView dgvEqmRepair;
        private System.Windows.Forms.Button btnRepairRecord;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpRepair;
        private System.Windows.Forms.DataGridView dgvEqmMaintaince;
        private System.Windows.Forms.Button btnWaitingMaintenceRecord;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpMaintence;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRepairEqmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRepairContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRepairDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainWorkshop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainSubLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainDeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainDeviceXh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainPartCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainTaskInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainBasicrequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainNotice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainDetectcondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainBeginMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainAftermaintain;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintaincompel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainmake_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaintainw_man_hour;


    }
}