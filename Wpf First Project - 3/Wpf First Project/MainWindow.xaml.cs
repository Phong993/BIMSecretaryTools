using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Text.RegularExpressions;
using System.Data;
//using Delimon.Win32.IO;
using System.IO;
using System.Net;

namespace Wpf_First_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime datePicked;
        DataTable dataTable;
        int spacetv, giaidoan3, block4_2_3, block4_invalid, filetype5, desc6_isnum, desc6_isyymm, desc6_is3_, wrongformat;
        List<string> Discipline = new List<string> { "A", "S", "M" };
        List<string> Phase = new List<string> { "PG", "CD", "DD", "AL", "CT", "FB", "CO", "CL", "OM", "DM", "RV", "NA" };
        List<string> FileType = new List<string> { "AF", "CM", "CR", "DR", "M2", "M3", "MR", "VS", "BQ", "CA", "CO", "CP", "DB", "FN", "HS", "IE", "MI", "MS", "PP", "PR", "RD", "RI", "RP", "SA", "SH", "SN", "SP", "SU" };

        List<string> listException = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            Conditionals();
        }
        private void Conditionals()
        {
            comboBox.Items.Add("Điều kiện ưu tiên số 1 (Rule mới áp dụng từ ngày 31/10)");
            comboBox.Items.Add("Điều kiện ưu tiên số 2");
            comboBox.Items.Add("Tất cả điều kiện");
        }
        private void browser_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog choofdlog = new System.Windows.Forms.FolderBrowserDialog(); 
            if(choofdlog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox.Text = choofdlog.SelectedPath;
                MySettings.Default.path = choofdlog.SelectedPath;
                MySettings.Default.Save();
            }
        }
        private void scanbtn_Click(object sender, RoutedEventArgs e)
        {
            dataTable.Rows.Clear();
            spacetv = 0; giaidoan3 = 0; block4_2_3 = 0; block4_invalid = 0; filetype5 = 0; desc6_isnum = 0; desc6_isyymm = 0; desc6_is3_ = 0; wrongformat = 0;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    ConsoleManager.Show();
                    //Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, new Action(() => DieuKien1(textBox.Text, "*"))); 
                    listException = new List<string>();
                    DieuKien1(textBox.Text, "*");
                    listView.ItemsSource = dataTable.DefaultView;
                    ConsoleManager.Hide();
                    reportbtn.IsEnabled = true;
                    exportbtn.IsEnabled = true;
                    break;
                case 1:
                    System.Windows.MessageBox.Show("Điều kiện chưa hỗ trợ");
                    break;
                case 2:
                    System.Windows.MessageBox.Show("Điều kiện chưa hỗ trợ");
                    break;
            }
        }

        private void scanwithException(object sender)
        {
            listException = new List<string>();
            listException = (List<string>)sender;
            dataTable.Rows.Clear();
            spacetv = 0; giaidoan3 = 0; block4_2_3 = 0; block4_invalid = 0; filetype5 = 0; desc6_isnum = 0; desc6_isyymm = 0; desc6_is3_ = 0; wrongformat = 0;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    ConsoleManager.Show();
                    //Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, new Action(() => DieuKien1(textBox.Text, "*"))); 
                    DieuKien1(textBox.Text, "*");
                    listView.ItemsSource = dataTable.DefaultView;
                    ConsoleManager.Hide();
                    reportbtn.IsEnabled = true;
                    exportbtn.IsEnabled = true;
                    break;
                case 1:
                    System.Windows.MessageBox.Show("Điều kiện chưa hỗ trợ");
                    break;
                case 2:
                    System.Windows.MessageBox.Show("Điều kiện chưa hỗ trợ");
                    break;
            }
        }

        public void DieuKien1(string path, string searchPattern)
        {

            //try
            //{
            //if (!Directory.Exists(path))
            //    return;
            //NetworkCredential theNetworkCredential = new NetworkCredential("", "", "");
            //theNetworkCredential.UserName = "phongnh57738";
            //theNetworkCredential.Password = "12345";
            //theNetworkCredential.Domain = @"\\192.168.1.100\doc_center\";
            //CredentialCache theNetcache = new CredentialCache();
            //theNetcache.Add(new Uri(@"\\192.168.1.100\"), "Basic", theNetworkCredential);
            //path = @"\\?\" + path;//Sửa ngày 30/05/2018 để tránh lỗi longer path >=259 character
            if(path.Length >= 258)
            {
                path = @"\\?\" + path;
            }
            if (listException.Count != 0)
                if (listException.Contains(path))
                    return;
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path, searchPattern, SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    try
                    {
                        ConsoleWriteline(file);
                        if (DateTime.Compare(Directory.GetCreationTime(file), datePicked) >= 0)
                        {

                            if (IsHasSpace(file) || IsTiengVietCoDau(file))
                            {
                                print2Table(file, "Do có khoảng trắng hoặc là Tiếng Việt có dấu");
                                spacetv++;
                                continue;
                            }
                            string nameNonExt = System.IO.Path.GetFileNameWithoutExtension(file);
                            string[] fileArray = nameNonExt.Split('-');
                            if (fileArray.Length == 6)//Là File Dự Án
                            {
                                //if(fileArray[1].Contains("_"))
                                //{
                                //    string[] boMonArray = fileArray[1].Split('_');
                                //    if(!Discipline.Any(x => x == boMonArray[1]))
                                //    {
                                //        print2Table(file,"Do không chứa ký tự Bộ Môn theo quy định tại trường 2");
                                //        continue;
                                //    }
                                //}
                                //else
                                //{
                                //    print2Table(file,"Do không đúng cấu trúc quy định tại trường 2 Bộ Môn");
                                //    continue;
                                //}
                                if (!Phase.Any(x => x == fileArray[2]))//Phải chứa ký tự trong List Phase
                                {
                                    print2Table(file, "Do không chứa ký tự Giai Đoạn quy định tại trường 3");
                                    giaidoan3++;
                                    continue;
                                }
                                if (fileArray[3].Count(x => x == '_') == 3)//A_2F_Z1_1A Block/ Level/ Zone
                                {
                                    string[] array3 = fileArray[3].Split('_');
                                    if (array3[1].Length > 3 || array3[1].Length < 2)//Mã cho tầng có từ 2 - 3 ký tự
                                    {
                                        print2Table(file, "Do độ dài ký tự quy định tầng khác 2 hoặc 3");
                                        block4_2_3++;
                                        continue;
                                    }
                                }
                                else
                                {
                                    print2Table(file, "Do không đúng cấu trúc quy định tầng");
                                    block4_invalid++;
                                    continue;
                                }
                                if (!FileType.Any(x => x == fileArray[4]))
                                {
                                    print2Table(file, "Do không chứa ký tự quy định File Type");
                                    filetype5++;
                                    continue;
                                }
                                if (fileArray[5].Split('_').Length == 3)
                                {
                                    string[] fileDescArray = fileArray[5].Split('_');
                                    int x = 0;
                                    DateTime date;
                                    if (!Int32.TryParse(fileDescArray[1], out x))
                                    {
                                        print2Table(file, "Do không chứa đúng ký tự quy định phiên bản của file. Phải là số");
                                        desc6_isnum++;
                                        continue;
                                    }

                                    if (!DateTime.TryParseExact(fileDescArray[2], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
                                    {
                                        print2Table(file, "Do không chứa đúng ký tự quy định ngày tháng của file. Phải là kiểu YYYYMMDD");
                                        desc6_isyymm++;
                                        continue;
                                    }
                                }
                                else
                                {
                                    print2Table(file, "Do không chứa đúng cấu trúc quy định Description. Phải đủ 3 vùng _");
                                    desc6_is3_++;
                                    continue;
                                }

                            }
                            else if (fileArray.Length == 1)//Là File không thuộc Dự Án
                            {
                                if (nameNonExt.Split('_').Length == 3)
                                {
                                    string[] fileDescArray = nameNonExt.Split('_');
                                    int x = 0;
                                    DateTime date;
                                    if (!Int32.TryParse(fileDescArray[1], out x))
                                    {
                                        print2Table(file, "Do không chứa đúng ký tự quy định phiên bản của file. Phải là số");
                                        desc6_isnum++;
                                        continue;
                                    }

                                    if (!DateTime.TryParseExact(fileDescArray[2], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
                                    {
                                        print2Table(file, "Do không chứa đúng ký tự quy định ngày tháng của file. Phải là kiểu YYYYMMDD");
                                        desc6_isyymm++;
                                        continue;
                                    }
                                }
                                else
                                {
                                    print2Table(file, "Do không chứa đúng cấu trúc quy định Description. Phải đủ 3 vùng _ dành cho file không thuộc dự án");
                                    desc6_is3_++;
                                    continue;
                                }
                            }
                            else
                            {
                                print2Table(file, "Sai cấu trúc đã quy định 6 trường nếu là file dự án");
                                wrongformat++;
                                continue;
                            }

                        }
                    }
                    catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.ToString()); print2Table(file, "File bị lỗi"); }

                }

                foreach (string folder in Directory.GetDirectories(path, searchPattern, SearchOption.TopDirectoryOnly))
                {
                    DieuKien1(folder, searchPattern);
                }
            }
            //}
            //catch {  }
        }

        //private void DieuKien1()
        //{
        //    //listView.Items.Clear();
        //    DataTable dataTable = new DataTable();
        //    dataTable.Columns.Add("Path");
        //    dataTable.Columns.Add("Modified Date", typeof(DateTime));
        //    dataTable.Columns.Add("CreatedDate",typeof(DateTime));
        //    dataTable.Columns.Add("Owner");           

        //    ConsoleManager.Show();
        //    try
        //    {           
        //        var directories = Directory.GetDirectories(textBox.Text, "*", SearchOption.TopDirectoryOnly);
        //        var files = Directory.GetFiles(textBox.Text, "*", SearchOption.TopDirectoryOnly);

        //        foreach (string directory in directories)
        //        {
        //            var subdirectories1 = Directory.GetDirectories(directory, "*", SearchOption.TopDirectoryOnly);
        //            var files1 = Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly);
        //            foreach (string subdir1 in subdirectories1)
        //            {
        //                var subdirectory2 = Directory.GetDirectories(subdir1, "*", SearchOption.TopDirectoryOnly);
        //                foreach (string subdir2 in subdirectory2)
        //                {
        //                    var subdirectory3 = Directory.GetDirectories(subdir2, "*", SearchOption.TopDirectoryOnly); 
        //                    foreach (string subdir3 in subdirectory3)
        //                    {
        //                        var files3 = Directory.GetFiles(subdir3, "*", SearchOption.TopDirectoryOnly);
        //                        foreach (string subFile1 in files3)
        //                        {
        //                            //if (!CheckforSegment5_FileNameYYMMDDv1(subFile1))
        //                            //{
        //                            //    listView.Items.Add(subFile1);
        //                            //}
        //                            //if (IsTiengVietCoDau(subFile1))
        //                            //{
        //                            //    listView.Items.Add(subFile1); Debug.WriteLine(subFile1);
        //                            //}
        //                            if (IsHasSpace(subFile1) || IsTiengVietCoDau(subFile1))
        //                            {
        //                                if(datePicked != null )
        //                                {
        //                                    if(DateTime.Compare(Directory.GetCreationTime(subFile1),datePicked) >=0)
        //                                    {
        //                                        string[] array = new string[4];
        //                                        array[0] = subFile1;
        //                                        //array[1] = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:dd/MM/yyyy hh:mm:ss}", Directory.GetLastWriteTime(subFile1));
        //                                        //array[2] = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:dd/MM/yyyy hh:mm:ss}", Directory.GetCreationTime(subFile1));
        //                                        array[1] = Directory.GetLastWriteTime(subFile1).ToString();
        //                                        array[2] = Directory.GetCreationTime(subFile1).ToString();
        //                                        array[3] = Directory.GetAccessControl(subFile1).GetOwner(typeof(System.Security.Principal.SecurityIdentifier)).ToString();

        //                                        dataTable.Rows.Add(array);
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    string[] array = new string[4];
        //                                    array[0] = subFile1;
        //                                    array[1] = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:dd/MM/yyyy hh:mm:ss}", Directory.GetLastWriteTime(subFile1));
        //                                    array[2] = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:dd/MM/yyyy hh:mm:ss}", Directory.GetCreationTime(subFile1));
        //                                    array[3] = Directory.GetAccessControl(subFile1).GetOwner(typeof(System.Security.Principal.SecurityIdentifier)).ToString();

        //                                    dataTable.Rows.Add(array);
        //                                }
        //                                Debug.WriteLine(subFile1);
        //                            }
        //                            Console.WriteLine(subFile1);
        //                            //Debug.WriteLine(subFile1);
        //                        }
        //                        //listView.Items.Add(subdir3);
        //                    }
        //                    //listView.Items.Add(subdir2);
        //                }
        //                // listView.Items.Add(subdir1);
        //            }
        //            // Debug.WriteLine(directory);
        //            //foreach(string file1 in files1)
        //            //{
        //            //    listView.Items.Add(file1);
        //            //}
        //            //listView.Items.Add(directory);
        //        }

        //        //foreach (string file in files)
        //        //{               
        //        //    listView.Items.Add(file);
        //        //}
        //    }
        //    catch(Exception ex) { System.Windows.Forms.MessageBox.Show(ex.ToString()); }

        //    listView.ItemsSource = dataTable.DefaultView;
        //    //listView.Columns[2].HeaderStringFormat = "dd/MM/yyyy";

        //    ConsoleManager.Hide();
        //}

        public void ConsoleWriteline(string file)
        {
            Debug.WriteLine(file);
            Console.WriteLine(file);
        }
        public static bool FilePathHasInvalidChars(string path)
        {

            return (!string.IsNullOrEmpty(path) && path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0);
        }

        private void print2Table(string file,string reason)
        {
            if(file.Length >= 258)
            {
               file = file.Remove(0,4);
            }
            string[] array = new string[5];
            array[0] = file;            
            array[1] = Directory.GetLastWriteTime(file).ToString();
            array[2] = Directory.GetCreationTime(file).ToString();
            try
            {
                array[3] = Directory.GetAccessControl(file).GetOwner(typeof(System.Security.Principal.SecurityIdentifier)).ToString();
            }
            catch { array[3] = null; }
            array[4] = reason;
            dataTable.Rows.Add(array);
        }
        private bool IsHasSpace(string fname)
        {
            string nameNonExt = System.IO.Path.GetFileNameWithoutExtension(fname);
            string pat = @"(\s)";
            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(nameNonExt);
            while (m.Success)
            {
                return true;
            }
            return false;
        }
        private bool IsTiengVietCoDau(string fname)
        {
            string nameNonExt = System.IO.Path.GetFileNameWithoutExtension(fname);
            string pat = @"[ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]";
            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(nameNonExt);
            
            while (m.Success)
            {
                return true;
            }
            return false;
           
        }


        private bool CheckforSegment5_FileNameYYMMDDv1(string fname)
        {
            string nameNonExt = System.IO.Path.GetFileNameWithoutExtension(fname);
            int charLocation = nameNonExt.IndexOf("_", StringComparison.Ordinal);
            if(charLocation > 0)
            {
                int seccharLocation = charLocation + 6;
                // string isUnderstroke = nameNonExt.Substring(seccharLocation, seccharLocation);
                if (seccharLocation > nameNonExt.Length)
                    return false;
                if (nameNonExt.Substring(seccharLocation) == "_")
                    return true;
                
            }
                return false;
        }

        private bool CheckforSegment1_IsNumberBeforeUnderstroke(string fname)
        {
            string nameNonExt = System.IO.Path.GetFileNameWithoutExtension(fname);
            int charLocation = nameNonExt.IndexOf("_", StringComparison.Ordinal);
            string isNumber = null;
            if (charLocation > 0)
            {
                 isNumber = nameNonExt.Substring(0, charLocation);
            }
            int n;
            bool isNumeric = int.TryParse(isNumber, out n);
            return isNumeric;
        }

        private void scanWithEx_Click(object sender, RoutedEventArgs e)
        {
            ////System.Windows.Forms.MessageBox.Show("Ex");
            //FolderCheckBoxView folderCheckBoxView = new FolderCheckBoxView(textBox.Text);
            ////folderCheckBoxView.path = textBox.Text;
            //folderCheckBoxView.ShowDialog();

            ExceptFolder windowsExplorer = new ExceptFolder(textBox.Text);
            //windowsExplorer.passListExcept = new PassListExcept(GetListExcept);
            windowsExplorer.showMainWindow += new ShowMainWindow(scanwithException);            
            windowsExplorer.ShowDialog();
        }
        //private void GetListExcept(object sender)
        //{
        //    listException = new List<string>();
        //    listException = (List<string>)sender;
        //}

        private bool IsLenghtOver20Char(string fname)
        {
            int lenght = System.IO.Path.GetFileNameWithoutExtension(fname).Length;
            if (lenght <= 20)
                return false;
            else
                return true;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
     
        }

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //System.Windows.MessageBox.Show(listView.SelectedItem.ToString());
            Object o = listView.SelectedItem;
            DataRowView dataRowView = o as DataRowView;
            Process.Start("explorer.exe", "/select, " + dataRowView[0].ToString());
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var pickerDate = sender as DatePicker;
            if(pickerDate.SelectedDate != null)
            {
                DateTime? date = pickerDate.SelectedDate;
                datePicked = (DateTime)date;
                MySettings.Default.date = (DateTime)datePicker.SelectedDate;
                MySettings.Default.Save();
            }
            else
            {
                MySettings.Default.date = DateTime.Now;
                MySettings.Default.Save();
            }
            
            //System.Windows.Forms.MessageBox.Show(String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:dd/MM/yyyy}", date));
        }

        private void listView_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
            {
                Style styleCenter = new Style(typeof(System.Windows.Controls.DataGridCell));        
              
                //styleCenter.Setters.Add(new Setter(HorizontalAlignmentProperty, HorizontalConte));
                //styleCenter.Setters.Add(new Setter(FontWeightProperty, FontWeights.Bold));
                //styleCenter.Setters.Add(new Setter(ForegroundProperty, Brushes.Red));

                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy H:mm:ss";
                (e.Column as DataGridTextColumn).CellStyle = styleCenter;
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(MySettings.Default.path != null)
                textBox.Text = MySettings.Default.path;
            if (MySettings.Default.date != null)
                datePicker.SelectedDate = MySettings.Default.date;

            dataTable = new DataTable();
            dataTable.Columns.Add("Path");
            dataTable.Columns.Add("Modified Date", typeof(DateTime));
            dataTable.Columns.Add("CreatedDate", typeof(DateTime));
            dataTable.Columns.Add("Owner");
            dataTable.Columns.Add("Reason");
        }

        private void reportbtn_Click(object sender, RoutedEventArgs e)
        {
            ReportForm rf = new ReportForm();
            Dictionary<string, int> dicSche = new Dictionary<string, int> { };
            dicSche.Add("Do có khoảng trắng hoặc là Tiếng Việt có dấu",spacetv);
            dicSche.Add("Do không chứa ký tự Giai Đoạn quy định tại trường 3", giaidoan3);
            dicSche.Add("Do độ dài ký tự quy định tầng khác 2 hoặc 3",block4_2_3);
            dicSche.Add("Do không đúng cấu trúc quy định tầng",block4_invalid);
            dicSche.Add("Do không chứa ký tự quy định File Type",filetype5);
            dicSche.Add("Do không chứa đúng ký tự quy định phiên bản của file. Phải là số", desc6_isnum);
            dicSche.Add("Do không chứa đúng ký tự quy định ngày tháng của file. Phải là kiểu YYYYMMDD",desc6_isyymm);
            dicSche.Add("Do không chứa đúng cấu trúc quy định Description. Phải đủ 3 vùng _ dành cho file không thuộc dự án", desc6_is3_);
            dicSche.Add("Sai cấu trúc đã quy định 6 trường nếu là file dự án", wrongformat);

            //List<int> listSche = new List<int> { spacetv, giaidoan3, block4_2_3, block4_invalid, filetype5, desc6_isnum, desc6_isyymm, desc6_is3_, wrongformat };
            //rf.listSche = listSche;
            rf.dicSche = dicSche;
            rf.ShowDialog();
        }

        private void exportbtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            //xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            
            for (int i = 0; i <= listView.Items.Count - 1; i++)
            {
                for (int j = 0; j <= listView.Columns.Count - 1; j++)
                {
                    xlWorkSheet.Cells[i + 1, j + 1] =
                    ((DataRowView)listView.Items[i]).Row.ItemArray[j].ToString();
                }
                
                Console.Write(i * 100 / listView.Items.Count - 1);
            }
            
            System.Windows.Forms.SaveFileDialog saveDlg = new System.Windows.Forms.SaveFileDialog();
            saveDlg.InitialDirectory = @"C:\";
            saveDlg.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveDlg.FilterIndex = 0;
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = "Scan_Export";
            saveDlg.Title = "Export Excel File To";
            if (saveDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = saveDlg.FileName;
                xlWorkBook.SaveCopyAs(path);
                xlWorkBook.Saved = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
            }
        }
    }

    [SuppressUnmanagedCodeSecurity]
    public static class ConsoleManager
    {
        private const string Kernel32_DllName = "kernel32.dll";

        [DllImport(Kernel32_DllName)]
        private static extern bool AllocConsole();

        [DllImport(Kernel32_DllName)]
        private static extern bool FreeConsole();

        [DllImport(Kernel32_DllName)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport(Kernel32_DllName)]
        private static extern int GetConsoleOutputCP();

        public static bool HasConsole
        {
            get { return GetConsoleWindow() != IntPtr.Zero; }
        }

        /// <summary>
        /// Creates a new console instance if the process is not attached to a console already.
        /// </summary>
        public static void Show()
        {
            //#if DEBUG
            if (!HasConsole)
            {
                AllocConsole();
                InvalidateOutAndError();
            }
            //#endif
        }

        /// <summary>
        /// If the process has a console attached to it, it will be detached and no longer visible. Writing to the System.Console is still possible, but no output will be shown.
        /// </summary>
        public static void Hide()
        {
            //#if DEBUG
            if (HasConsole)
            {
                SetOutAndErrorNull();
                FreeConsole();
            }
            //#endif
        }

        public static void Toggle()
        {
            if (HasConsole)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        static void InvalidateOutAndError()
        {
            Type type = typeof(System.Console);

            System.Reflection.FieldInfo _out = type.GetField("_out",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            System.Reflection.FieldInfo _error = type.GetField("_error",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            System.Reflection.MethodInfo _InitializeStdOutError = type.GetMethod("InitializeStdOutError",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            Debug.Assert(_out != null);
            Debug.Assert(_error != null);

            Debug.Assert(_InitializeStdOutError != null);

            _out.SetValue(null, null);
            _error.SetValue(null, null);

            _InitializeStdOutError.Invoke(null, new object[] { true });
        }

        static void SetOutAndErrorNull()
        {
            Console.SetOut(System.IO.TextWriter.Null);
            Console.SetError(System.IO.TextWriter.Null);
        }
    }
}
