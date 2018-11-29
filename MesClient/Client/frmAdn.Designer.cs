namespace Client
{
    partial class frmAdn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdn));
            this.label3 = new System.Windows.Forms.Label();
            this.lblAdnTypeName = new System.Windows.Forms.Label();
            this.lblCallTip = new System.Windows.Forms.Label();
            this.lblEqmName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCall = new System.Windows.Forms.Button();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCurrentDept = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(58, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "类型名称：";
            // 
            // lblAdnTypeName
            // 
            this.lblAdnTypeName.AutoSize = true;
            this.lblAdnTypeName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAdnTypeName.Location = new System.Drawing.Point(281, 64);
            this.lblAdnTypeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdnTypeName.Name = "lblAdnTypeName";
            this.lblAdnTypeName.Size = new System.Drawing.Size(69, 27);
            this.lblAdnTypeName.TabIndex = 0;
            this.lblAdnTypeName.Text = "label1";
            // 
            // lblCallTip
            // 
            this.lblCallTip.AutoSize = true;
            this.lblCallTip.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCallTip.Location = new System.Drawing.Point(58, 190);
            this.lblCallTip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCallTip.Name = "lblCallTip";
            this.lblCallTip.Size = new System.Drawing.Size(172, 27);
            this.lblCallTip.TabIndex = 0;
            this.lblCallTip.Text = "请选择呼叫部门：";
            // 
            // lblEqmName
            // 
            this.lblEqmName.AutoSize = true;
            this.lblEqmName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEqmName.Location = new System.Drawing.Point(281, 106);
            this.lblEqmName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEqmName.Name = "lblEqmName";
            this.lblEqmName.Size = new System.Drawing.Size(69, 27);
            this.lblEqmName.TabIndex = 2;
            this.lblEqmName.Text = "label1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(58, 106);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 27);
            this.label5.TabIndex = 3;
            this.label5.Text = "来源工位：";
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
            this.btnCall.Location = new System.Drawing.Point(63, 250);
            this.btnCall.Margin = new System.Windows.Forms.Padding(4);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(383, 79);
            this.btnCall.TabIndex = 24;
            this.btnCall.Text = "确认";
            this.btnCall.UseVisualStyleBackColor = false;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentStatus.Location = new System.Drawing.Point(281, 148);
            this.lblCurrentStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(69, 27);
            this.lblCurrentStatus.TabIndex = 25;
            this.lblCurrentStatus.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(58, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 27);
            this.label2.TabIndex = 26;
            this.label2.Text = "目前进度：";
            // 
            // lblCurrentDept
            // 
            this.lblCurrentDept.AutoSize = true;
            this.lblCurrentDept.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentDept.Location = new System.Drawing.Point(281, 190);
            this.lblCurrentDept.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentDept.Name = "lblCurrentDept";
            this.lblCurrentDept.Size = new System.Drawing.Size(69, 27);
            this.lblCurrentDept.TabIndex = 27;
            this.lblCurrentDept.Text = "label1";
            // 
            // frmAdn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(6)))), ((int)(((byte)(9)))));
            this.CaptionBackColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(6)))), ((int)(((byte)(9)))));
            this.CaptionBackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(6)))), ((int)(((byte)(9)))));
            this.CaptionFont = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 42;
            this.ClientSize = new System.Drawing.Size(533, 375);
            this.CloseBoxSize = new System.Drawing.Size(32, 32);
            this.Controls.Add(this.lblCurrentDept);
            this.Controls.Add(this.lblCurrentStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.lblEqmName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAdnTypeName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCallTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdn";
            this.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.Text = "安灯响应";
            this.TitleColor = System.Drawing.Color.White;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAdnTypeName;
        private System.Windows.Forms.Label lblCallTip;
        private System.Windows.Forms.Label lblEqmName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrentDept;




    }
}