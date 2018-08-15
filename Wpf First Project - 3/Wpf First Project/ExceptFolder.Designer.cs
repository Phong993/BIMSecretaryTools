namespace Wpf_First_Project
{
    partial class ExceptFolder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptFolder));
            this.explorerTree1 = new WindowsExplorer.ExplorerTree();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScanEx = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // explorerTree1
            // 
            this.explorerTree1.BackColor = System.Drawing.Color.White;
            this.explorerTree1.Location = new System.Drawing.Point(12, 12);
            this.explorerTree1.Name = "explorerTree1";
            this.explorerTree1.SelectedPath = "D:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Professional\\Common7\\IDE";
            this.explorerTree1.ShowAddressbar = true;
            this.explorerTree1.ShowMyDocuments = true;
            this.explorerTree1.ShowMyFavorites = true;
            this.explorerTree1.ShowMyNetwork = true;
            this.explorerTree1.ShowToolbar = true;
            this.explorerTree1.Size = new System.Drawing.Size(338, 393);
            this.explorerTree1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "* Scan tất cả thư mục ngoài trừ các thư mục đã đánh dấu";
            // 
            // btnScanEx
            // 
            this.btnScanEx.Location = new System.Drawing.Point(233, 441);
            this.btnScanEx.Name = "btnScanEx";
            this.btnScanEx.Size = new System.Drawing.Size(117, 23);
            this.btnScanEx.TabIndex = 2;
            this.btnScanEx.Text = "Scan with Exception";
            this.btnScanEx.UseVisualStyleBackColor = true;
            this.btnScanEx.Click += new System.EventHandler(this.btnScanEx_Click);
            // 
            // ExceptFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(362, 476);
            this.Controls.Add(this.btnScanEx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.explorerTree1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptFolder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Except Explorer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsExplorer.ExplorerTree explorerTree1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScanEx;
    }
}