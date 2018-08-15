using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wpf_First_Project
{
    public delegate void ShowMainWindow(object sender);
    //public delegate void PassListExcept(object sender);
    public partial class ExceptFolder : Form
    {
        public event ShowMainWindow showMainWindow;
        //public PassListExcept passListExcept;
        public string selectedpath { get; set; } 
        public ExceptFolder(string selectedpath)
        {
            InitializeComponent();
            explorerTree1.SelectedPath = selectedpath;
        }

        private void btnScanEx_Click(object sender, EventArgs e)
        {
            //foreach(string node in explorerTree1.CheckedList)
            //{
            //    MessageBox.Show(node);
            //}
            MainWindow mainWindow = new MainWindow();
            showMainWindow(explorerTree1.CheckedList);
            //passListExcept(explorerTree1.CheckedList);
            this.Close();
        }
    }
}
