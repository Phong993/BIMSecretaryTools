using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf_First_Project
{
    /// <summary>
    /// Interaction logic for ReportForm.xaml
    /// </summary>
    public partial class ReportForm : Window
    {
        //public int spacetv { get; set; }
        //public int giaidoan3 { get; set; }
        //public int block4_2_3 { get; set; }
        //public int block4_invalid { get; set; }
        //public int filetype5 { get; set; }
        //public int desc6_isnumber { get; set; }
        //public int desc6_isyymm { get; set; }
        //public int desc6_is3_ { get; set; }
        //public List<int> listSche { get; set; }
        public Dictionary<string, int> dicSche { get; set; }
        public ReportForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dtReport = new DataTable();
            dtReport.Columns.Add("Reason");
            dtReport.Columns.Add("Times");
            int tong = 0;
            foreach(KeyValuePair<string,int> k in dicSche)
            {
                if (k.Value == 0)
                    continue;
                string[] array = new string[2];
                array[0] = k.Key;
                array[1] = k.Value.ToString();
                tong += k.Value;
                dtReport.Rows.Add(array);
            }

            //string[] tongarr = new string[2];
            //tongarr[0] = "Tổng";
            //tongarr[1] = tong.ToString();
            //dtReport.Rows.Add(tongarr);
            charTong.Content = tong;
            gridReport.ItemsSource = dtReport.DefaultView;

            //DataGridRow row = (DataGridRow)gridReport.ItemContainerGenerator.ContainerFromIndex(6);
            //if (row == null)
            //{
            //    var item = gridReport.Items[6];
            //    /* bring the data item (Product object) into view
            //     * in case it has been virtualized away */
            //    gridReport.ScrollIntoView(item);
            //    row = gridReport.ItemContainerGenerator.ContainerFromIndex(6) as DataGridRow;
            //}
            //Setter bold = new Setter(TextBlock.FontWeightProperty, FontWeights.Bold, null);
            //Style newStyle = new Style(row.GetType());
            //newStyle.Setters.Add(bold);
            //row.Style = newStyle;
        }
    }
}
