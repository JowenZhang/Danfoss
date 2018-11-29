namespace Client
{
    partial class frmApoAct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApoAct));
            this.dgvApoAct = new System.Windows.Forms.DataGridView();
            this.colApoActStep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApoActUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApoActName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApoActTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApoAct)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvApoAct
            // 
            this.dgvApoAct.AllowUserToAddRows = false;
            this.dgvApoAct.AllowUserToDeleteRows = false;
            this.dgvApoAct.AllowUserToOrderColumns = true;
            this.dgvApoAct.AllowUserToResizeRows = false;
            this.dgvApoAct.BackgroundColor = System.Drawing.Color.White;
            this.dgvApoAct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvApoAct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvApoAct.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvApoAct.ColumnHeadersHeight = 36;
            this.dgvApoAct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvApoAct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colApoActStep,
            this.colApoActUser,
            this.colApoActName,
            this.colApoActTime});
            this.dgvApoAct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApoAct.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvApoAct.Location = new System.Drawing.Point(8, 46);
            this.dgvApoAct.Margin = new System.Windows.Forms.Padding(5);
            this.dgvApoAct.Name = "dgvApoAct";
            this.dgvApoAct.RowHeadersVisible = false;
            this.dgvApoAct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvApoAct.ShowCellErrors = false;
            this.dgvApoAct.Size = new System.Drawing.Size(784, 546);
            this.dgvApoAct.TabIndex = 14;
            // 
            // colApoActStep
            // 
            this.colApoActStep.HeaderText = "审批序号";
            this.colApoActStep.Name = "colApoActStep";
            this.colApoActStep.Width = 120;
            // 
            // colApoActUser
            // 
            this.colApoActUser.HeaderText = "处理人";
            this.colApoActUser.Name = "colApoActUser";
            this.colApoActUser.Width = 140;
            // 
            // colApoActName
            // 
            this.colApoActName.HeaderText = "处理名称";
            this.colApoActName.Name = "colApoActName";
            this.colApoActName.Width = 200;
            // 
            // colApoActTime
            // 
            this.colApoActTime.HeaderText = "处理时间";
            this.colApoActTime.Name = "colApoActTime";
            this.colApoActTime.Width = 140;
            // 
            // frmApoAct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(6)))), ((int)(((byte)(9)))));
            this.CaptionBackColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(6)))), ((int)(((byte)(9)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(6)))), ((int)(((byte)(9)))));
            this.CaptionFont = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 42;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.CloseBoxSize = new System.Drawing.Size(32, 32);
            this.Controls.Add(this.dgvApoAct);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MaxSize = new System.Drawing.Size(32, 32);
            this.MiniSize = new System.Drawing.Size(32, 32);
            this.Name = "frmApoAct";
            this.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.Text = "审核流程显示";
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.frmApoAct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApoAct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvApoAct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApoActStep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApoActUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApoActName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApoActTime;





    }
}