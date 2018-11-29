namespace Client
{
    partial class frmBaseMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseMaster));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.tclMaster = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(484, 8);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(130, 36);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // tclMaster
            // 
            this.tclMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tclMaster.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.tclMaster.Location = new System.Drawing.Point(6, 46);
            this.tclMaster.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tclMaster.Name = "tclMaster";
            this.tclMaster.SelectedIndex = 0;
            this.tclMaster.Size = new System.Drawing.Size(788, 548);
            this.tclMaster.TabIndex = 1;
            // 
            // frmBaseMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CaptionBackColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(6)))), ((int)(((byte)(9)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(6)))), ((int)(((byte)(9)))));
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 40;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.CloseBoxSize = new System.Drawing.Size(32, 32);
            this.ControlBoxOffset = new System.Drawing.Point(4, 4);
            this.Controls.Add(this.tclMaster);
            this.Controls.Add(this.picLogo);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ICoOffset = new System.Drawing.Point(1, 0);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MaxSize = new System.Drawing.Size(32, 32);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.MiniSize = new System.Drawing.Size(32, 32);
            this.Name = "frmBaseMaster";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Radius = 8;
            this.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.Text = "Danfoss CNCC MES-";
            this.TitleColor = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBaseMaster_FormClosing);
            this.Load += new System.EventHandler(this.frmBaseMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.TabControl tclMaster;


    }
}