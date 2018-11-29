namespace MesServiceFrm
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnSetupAndUnist = new System.Windows.Forms.Button();
            this.txtLogs = new System.Windows.Forms.RichTextBox();
            this.btnStartAndStop = new System.Windows.Forms.Button();
            this.btnManuPlan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(365, -1);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(130, 40);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // btnSetupAndUnist
            // 
            this.btnSetupAndUnist.Location = new System.Drawing.Point(9, 343);
            this.btnSetupAndUnist.Name = "btnSetupAndUnist";
            this.btnSetupAndUnist.Size = new System.Drawing.Size(100, 40);
            this.btnSetupAndUnist.TabIndex = 1;
            this.btnSetupAndUnist.Text = "安装服务";
            this.btnSetupAndUnist.UseVisualStyleBackColor = true;
            this.btnSetupAndUnist.Click += new System.EventHandler(this.btnStartAndUnist_Click);
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(9, 68);
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.Size = new System.Drawing.Size(582, 262);
            this.txtLogs.TabIndex = 2;
            this.txtLogs.Text = "";
            // 
            // btnStartAndStop
            // 
            this.btnStartAndStop.Location = new System.Drawing.Point(249, 343);
            this.btnStartAndStop.Name = "btnStartAndStop";
            this.btnStartAndStop.Size = new System.Drawing.Size(100, 40);
            this.btnStartAndStop.TabIndex = 1;
            this.btnStartAndStop.Text = "启动服务";
            this.btnStartAndStop.UseVisualStyleBackColor = true;
            this.btnStartAndStop.Click += new System.EventHandler(this.btnStartAndStop_Click);
            // 
            // btnManuPlan
            // 
            this.btnManuPlan.Location = new System.Drawing.Point(489, 343);
            this.btnManuPlan.Name = "btnManuPlan";
            this.btnManuPlan.Size = new System.Drawing.Size(100, 40);
            this.btnManuPlan.TabIndex = 1;
            this.btnManuPlan.Text = "手动计划";
            this.btnManuPlan.UseVisualStyleBackColor = true;
            this.btnManuPlan.Click += new System.EventHandler(this.btnManuPlan_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CaptionBackColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(6)))), ((int)(((byte)(9)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(6)))), ((int)(((byte)(9)))));
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 40;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.CloseBoxSize = new System.Drawing.Size(32, 32);
            this.ControlBoxOffset = new System.Drawing.Point(4, 8);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.btnManuPlan);
            this.Controls.Add(this.btnStartAndStop);
            this.Controls.Add(this.btnSetupAndUnist);
            this.Controls.Add(this.picLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ICoOffset = new System.Drawing.Point(1, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MaxSize = new System.Drawing.Size(32, 32);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.MiniSize = new System.Drawing.Size(32, 32);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Radius = 8;
            this.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.Text = "数据服务管理器";
            this.TitleColor = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMusic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnSetupAndUnist;
        private System.Windows.Forms.RichTextBox txtLogs;
        private System.Windows.Forms.Button btnStartAndStop;
        private System.Windows.Forms.Button btnManuPlan;
    }
}