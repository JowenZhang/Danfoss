namespace Client
{
    partial class frmPwdBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPwdBox));
            this.label1 = new System.Windows.Forms.Label();
            this.btnPeDataDownLoad = new System.Windows.Forms.Button();
            this.txtType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入员工编号：";
            // 
            // btnPeDataDownLoad
            // 
            this.btnPeDataDownLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPeDataDownLoad.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPeDataDownLoad.FlatAppearance.BorderSize = 2;
            this.btnPeDataDownLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnPeDataDownLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPeDataDownLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPeDataDownLoad.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPeDataDownLoad.Location = new System.Drawing.Point(107, 182);
            this.btnPeDataDownLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnPeDataDownLoad.Name = "btnPeDataDownLoad";
            this.btnPeDataDownLoad.Size = new System.Drawing.Size(252, 75);
            this.btnPeDataDownLoad.TabIndex = 24;
            this.btnPeDataDownLoad.Text = "确定下载";
            this.btnPeDataDownLoad.UseVisualStyleBackColor = false;
            this.btnPeDataDownLoad.Click += new System.EventHandler(this.btnPeDataDownLoad_Click);
            // 
            // txtType
            // 
            this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtType.Location = new System.Drawing.Point(117, 127);
            this.txtType.Margin = new System.Windows.Forms.Padding(4);
            this.txtType.Multiline = true;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(234, 33);
            this.txtType.TabIndex = 25;
            // 
            // frmPwdBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(6)))), ((int)(((byte)(9)))));
            this.CaptionBackColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(6)))), ((int)(((byte)(9)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(6)))), ((int)(((byte)(9)))));
            this.CaptionFont = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 42;
            this.ClientSize = new System.Drawing.Size(469, 286);
            this.CloseBoxSize = new System.Drawing.Size(32, 32);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.btnPeDataDownLoad);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPwdBox";
            this.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.Text = "请输入密码";
            this.TitleColor = System.Drawing.Color.White;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPeDataDownLoad;
        private System.Windows.Forms.TextBox txtType;




    }
}