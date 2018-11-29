namespace Client
{
    partial class frmBom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBom));
            this.dgvBom = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBom)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBom
            // 
            this.dgvBom.AllowUserToAddRows = false;
            this.dgvBom.AllowUserToDeleteRows = false;
            this.dgvBom.AllowUserToOrderColumns = true;
            this.dgvBom.AllowUserToResizeRows = false;
            this.dgvBom.BackgroundColor = System.Drawing.Color.White;
            this.dgvBom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBom.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvBom.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvBom.ColumnHeadersHeight = 36;
            this.dgvBom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBom.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvBom.Location = new System.Drawing.Point(8, 46);
            this.dgvBom.Margin = new System.Windows.Forms.Padding(5);
            this.dgvBom.Name = "dgvBom";
            this.dgvBom.RowHeadersVisible = false;
            this.dgvBom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvBom.ShowCellErrors = false;
            this.dgvBom.Size = new System.Drawing.Size(784, 546);
            this.dgvBom.TabIndex = 14;
            // 
            // frmBom
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
            this.Controls.Add(this.dgvBom);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MaxSize = new System.Drawing.Size(32, 32);
            this.MiniSize = new System.Drawing.Size(32, 32);
            this.Name = "frmBom";
            this.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.Text = "Bom显示";
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.frmBom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBom;





    }
}