namespace FrmHardware
{
    partial class frmOp040
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOp040));
            this.panel1 = new System.Windows.Forms.Panel();
            this.axUserControl11 = new AxOP040.AxUserControl1();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axUserControl11)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.axUserControl11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 457);
            this.panel1.TabIndex = 0;
            // 
            // axUserControl11
            // 
            this.axUserControl11.Enabled = true;
            this.axUserControl11.Location = new System.Drawing.Point(1, 1);
            this.axUserControl11.Margin = new System.Windows.Forms.Padding(1);
            this.axUserControl11.Name = "axUserControl11";
            this.axUserControl11.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axUserControl11.OcxState")));
            this.axUserControl11.Size = new System.Drawing.Size(1010, 608);
            this.axUserControl11.TabIndex = 0;
            // 
            // frmOp040
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 457);
            this.Controls.Add(this.panel1);
            this.Name = "frmOp040";
            this.Text = "主界面";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axUserControl11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private AxOP040.AxUserControl1 axUserControl11;
    }
}