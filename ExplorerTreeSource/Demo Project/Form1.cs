using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TestExplorer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private WindowsExplorer.ExplorerTree explorerTree1;
		private Microsoft.VisualBasic.Compatibility.VB6.FileListBox fileListBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.explorerTree1 = new WindowsExplorer.ExplorerTree();
			this.fileListBox1 = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
			this.SuspendLayout();
			// 
			// explorerTree1
			// 
			this.explorerTree1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.explorerTree1.BackColor = System.Drawing.Color.White;
			this.explorerTree1.ImageCount = 0;
			this.explorerTree1.Location = new System.Drawing.Point(0, 0);
			this.explorerTree1.Name = "explorerTree1";
			this.explorerTree1.SelectedImage = "";
			this.explorerTree1.SelectedPath = "home";
			this.explorerTree1.ShowMyComputer = true;
			this.explorerTree1.ShowMyDocuments = true;
			this.explorerTree1.ShowMyFavorites = true;
			this.explorerTree1.ShowMyNetwork = true;
			this.explorerTree1.Size = new System.Drawing.Size(416, 512);
			this.explorerTree1.TabIndex = 0;
			// 
			// fileListBox1
			// 
			this.fileListBox1.Location = new System.Drawing.Point(424, 8);
			this.fileListBox1.Name = "fileListBox1";
			this.fileListBox1.Pattern = "*.*";
			this.fileListBox1.Size = new System.Drawing.Size(200, 498);
			this.fileListBox1.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(640, 534);
			this.Controls.Add(this.fileListBox1);
			this.Controls.Add(this.explorerTree1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void explorerTree1_ImageChanged(object sender, System.EventArgs e)
		{
		
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.explorerTree1.ShowMyFavorites = true;
			
		}
	}
}
