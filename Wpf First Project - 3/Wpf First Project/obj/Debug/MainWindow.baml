   M S B A M L   `   `   `  ����C  ?BIMTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:DropDownButtonSampleDropDownButtonSample  5   	   "    Wpf_First_Project.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   CDropDownButtonSample"clr-namespace:DropDownButtonSample     5   	   -   5          � Title$(  "BIM Secretary Tools - TFormatCheck��5   	   $	��350��64   $	��525��6A    � WindowStartupLocation$ CenterScreen=�6M   {�.  � WindowState$ 	Maximized=�6�    � Icon$ logo_bim_72_7MA_icon.ico��6�   .��5      � ��5   
   �� 5       � ColumnDefinitions 5
   
   �� 5      $
��258* �6   �� 5      $	��96* �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��233* �6   .+�5   
   �� -   5         ��Name$ browser��5      $��Browser��6"   $
��Left=�64   $��	20,10,0,0q�6O   $��75��6b   $��0��6m   $��1��6z    �� 	IsDefault . 6�   �� 5   
   -   5         ��Name$ textBox��5      $��	20,10,0,0q�6#   	 �� TextWrapping$	 NoWrap=�66   $3��-Chọn đường dẫn Folder muốn scan ...��6L   $	��Top=�6w   $��0��6�   $��0��6�   $��20��6�   �� 5   
   -   5        $ scanbtn��5      $
��Scan��6"   $��2��61   $
��Left=�6A   $��	2,10,20,0q�6\   $	��Top=�6o   $��75��6�   $��20��6�   6�   �� 5   
   -   5        $ 	reportbtn��5      {�.  $��Report��66   $��2��6G   $
��Left=�6W   $��
85,10,20,0q�6r   $	��Top=�6�   $��75��6�   $��20��6�   6�   �� 5   
   -   5        $ 	exportbtn��5      {�.  $��Export��66   $��2��6G   $
��Left=�6W   $��170,10,20,0q�6r   $	��Top=�6�   $��75��6�   $��20��6�   6�   �� 5   
   -   5        
 ��Name$
 label��5      $-��'Chọn điều kiện cần kiểm tra:��6   $
��Left=�6F   $��20                ,10,0,0q�6a   $��1��6�   $	��Top=�6�   &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ listView��5$   (    �� AlternationCount$ 2��6      EnableRowVirtualization . $��
20,1,10,13q�6Y   $��3��6m      
IsReadOnly . $��3��6�      RowStyle 5%      �� 5&       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5(      ��  �� Property � �� �� Value$ Arial)�63    �� Triggers 5)      P� 5*       P� Property �@��AlternationIndex P� Value$ 1��6K   . �5+      ��  � �� �#eaf2ff6;   5,      51      53      �� 54   
   -	   5         ��Name$ comboBox��54      $��400px��6%   $��20,1,138,13q�63   $
��Left=�6H   $��2��6c    �� SelectedIndex$ 0��6p   �� 55   
   -
   5        $

 date��55      $��Kiểm tra từ ngày: ��6   $��Right=�6;   $��
173,10,0,0q�6W   $��1��6k   $	��Top=�6x   (  "System.Windows.Controls.DatePicker  56   
   -   5          Name$ 
datePicker��56      $��Right=�6)   $��	173,2,0,0q�6E   $��2��6X   $	��Top=�6e   6}   )   #DropDownButtonSample.DropDownButton  58   
   -   5          Name$ dropDownButton��58   .   $	��▼��6F   $��2��6Y   $
��Left=�6i   $��	63,10,0,0q�6�   $	��Top=�6�      Menu 59      �� 5:      $��160px��6   .@�5;      m� -   5         m�Name$ 
scanWithEx��5;      $��Scan with Exception��5=      5>      5@      5B      5C      