   M S B A M L   `   `   `  ���� C  ?BIMTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:DropDownButtonSampleDropDownButtonSample  "    Wpf_First_Project.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     CDropDownButtonSample"clr-namespace:DropDownButtonSample     -     � Title$(  "BIM Secretary Tools - TFormatCheck��$	��350��$	��525�� � WindowStartupLocation$ CenterScreen=�{�.  � WindowState$ 	Maximized=� � Icon$ logo_bim_72_7MA_icon.ico��.��� ����  � ColumnDefinitions �� $
��258* ��� $	��96* ��� $
��Auto � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��233* �.+��� -    ��Name$ browser��$��Browser��$
��Left=�$��	20,10,0,0q�$��75��$��0��$��1�� �� 	IsDefault . �� -    ��Name$ textBox��$��	20,10,0,0q�	 �� TextWrapping$	 NoWrap=�$3��-Chọn đường dẫn Folder muốn scan ...��$	��Top=�$��0��$��0��$��20���� -   $ scanbtn��$
��Scan��$��2��$
��Left=�$��	2,10,20,0q�$	��Top=�$��75��$��20���� -   $ 	reportbtn��{�.  $��Report��$��2��$
��Left=�$��
85,10,20,0q�$	��Top=�$��75��$��20���� -   $ 	exportbtn��{�.  $��Export��$��2��$
��Left=�$��170,10,20,0q�$	��Top=�$��75��$��20���� -   
 ��Name$
 label��$-��'Chọn điều kiện cần kiểm tra:��$
��Left=�$��20                ,10,0,0q�$��1��$	��Top=�&   System.Windows.Controls.DataGrid  -     Name$ listView�� �� AlternationCount$ 2��   EnableRowVirtualization . $��
20,1,10,13q�$��3��   
IsReadOnly . $��3��   RowStyle ��  �� 
TargetType)  #System.Windows.Controls.DataGridRow"  .���  �� Property � �� �� Value$ Arial)� �� Triggers P�  P� Property �@��AlternationIndex P� Value$ 1��. ���  � �� �#eaf2ff�� -	    ��Name$ comboBox��$��400px��$��20,1,138,13q�$
��Left=�$��2�� �� SelectedIndex$ 0���� -
   $

 date��$��Kiểm tra từ ngày: ��$��Right=�$��
173,10,0,0q�$��1��$	��Top=�(  "System.Windows.Controls.DatePicker  -     Name$ 
datePicker��$��Right=�$��	173,2,0,0q�$��2��$	��Top=�)   #DropDownButtonSample.DropDownButton  -     Name$ dropDownButton��$	��▼��$��2��$
��Left=�$��	63,10,0,0q�$	��Top=�   Menu �� $��160px��.@�m� -    m�Name$ 
scanWithEx��$��Scan with Exception��