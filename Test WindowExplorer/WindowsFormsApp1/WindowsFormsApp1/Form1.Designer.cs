namespace WindowsFormsApp1
{
    partial class Form1
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
            this.explorerTree1 = new WindowsExplorer.ExplorerTree();
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
            this.explorerTree1.Size = new System.Drawing.Size(446, 436);
            this.explorerTree1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 460);
            this.Controls.Add(this.explorerTree1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsExplorer.ExplorerTree explorerTree1;
    }
}

