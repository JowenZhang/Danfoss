namespace MesMusicPlayer
{
    partial class frmMusic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMusic));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.timCycle = new System.Windows.Forms.Timer(this.components);
            this.ckbEqm = new System.Windows.Forms.CheckBox();
            this.ckbPe = new System.Windows.Forms.CheckBox();
            this.ckbProduct = new System.Windows.Forms.CheckBox();
            this.ckbQc = new System.Windows.Forms.CheckBox();
            this.ckbOther = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(165, -1);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(130, 40);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // timCycle
            // 
            this.timCycle.Interval = 5000;
            this.timCycle.Tick += new System.EventHandler(this.timCycle_Tick);
            // 
            // ckbEqm
            // 
            this.ckbEqm.AutoSize = true;
            this.ckbEqm.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbEqm.Location = new System.Drawing.Point(85, 65);
            this.ckbEqm.Name = "ckbEqm";
            this.ckbEqm.Size = new System.Drawing.Size(84, 35);
            this.ckbEqm.TabIndex = 1;
            this.ckbEqm.Text = "设备";
            this.ckbEqm.UseVisualStyleBackColor = true;
            this.ckbEqm.CheckedChanged += new System.EventHandler(this.ckbCheckbox_CheckedChanged);
            // 
            // ckbPe
            // 
            this.ckbPe.AutoSize = true;
            this.ckbPe.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbPe.Location = new System.Drawing.Point(85, 107);
            this.ckbPe.Name = "ckbPe";
            this.ckbPe.Size = new System.Drawing.Size(84, 35);
            this.ckbPe.TabIndex = 1;
            this.ckbPe.Text = "工艺";
            this.ckbPe.UseVisualStyleBackColor = true;
            this.ckbPe.CheckedChanged += new System.EventHandler(this.ckbCheckbox_CheckedChanged);
            // 
            // ckbProduct
            // 
            this.ckbProduct.AutoSize = true;
            this.ckbProduct.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbProduct.Location = new System.Drawing.Point(85, 149);
            this.ckbProduct.Name = "ckbProduct";
            this.ckbProduct.Size = new System.Drawing.Size(132, 35);
            this.ckbProduct.TabIndex = 1;
            this.ckbProduct.Text = "部件供应";
            this.ckbProduct.UseVisualStyleBackColor = true;
            this.ckbProduct.CheckedChanged += new System.EventHandler(this.ckbCheckbox_CheckedChanged);
            // 
            // ckbQc
            // 
            this.ckbQc.AutoSize = true;
            this.ckbQc.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbQc.Location = new System.Drawing.Point(85, 191);
            this.ckbQc.Name = "ckbQc";
            this.ckbQc.Size = new System.Drawing.Size(132, 35);
            this.ckbQc.TabIndex = 1;
            this.ckbQc.Text = "部件质量";
            this.ckbQc.UseVisualStyleBackColor = true;
            this.ckbQc.CheckedChanged += new System.EventHandler(this.ckbCheckbox_CheckedChanged);
            // 
            // ckbOther
            // 
            this.ckbOther.AutoSize = true;
            this.ckbOther.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbOther.Location = new System.Drawing.Point(85, 233);
            this.ckbOther.Name = "ckbOther";
            this.ckbOther.Size = new System.Drawing.Size(84, 35);
            this.ckbOther.TabIndex = 1;
            this.ckbOther.Text = "其它";
            this.ckbOther.UseVisualStyleBackColor = true;
            this.ckbOther.CheckedChanged += new System.EventHandler(this.ckbCheckbox_CheckedChanged);
            // 
            // frmMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CaptionBackColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(6)))), ((int)(((byte)(9)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(6)))), ((int)(((byte)(9)))));
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 40;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.CloseBoxSize = new System.Drawing.Size(32, 32);
            this.ControlBoxOffset = new System.Drawing.Point(4, 8);
            this.Controls.Add(this.ckbOther);
            this.Controls.Add(this.ckbQc);
            this.Controls.Add(this.ckbProduct);
            this.Controls.Add(this.ckbPe);
            this.Controls.Add(this.ckbEqm);
            this.Controls.Add(this.picLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ICoOffset = new System.Drawing.Point(1, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 300);
            this.MaxSize = new System.Drawing.Size(32, 32);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.MiniSize = new System.Drawing.Size(32, 32);
            this.Name = "frmMusic";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Radius = 8;
            this.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.Text = "安灯播放器";
            this.TitleColor = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMusic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Timer timCycle;
        private System.Windows.Forms.CheckBox ckbEqm;
        private System.Windows.Forms.CheckBox ckbPe;
        private System.Windows.Forms.CheckBox ckbProduct;
        private System.Windows.Forms.CheckBox ckbQc;
        private System.Windows.Forms.CheckBox ckbOther;


    }
}