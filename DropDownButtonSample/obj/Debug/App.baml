   M S B A M L   `   `   `  ����O  KDropDownButtonSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:DropDownButtonSampleDropDownButtonSample  5          DropDownButtonSample.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      4local"clr-namespace:DropDownButtonSample     5        �� 	Resources  5         EllipseToggleButtonStyle �� 
TargetType �� Property  ButtonBackground �� Value  ButtonBorder  
ButtonText �� 
TargetType J� SnapsToDevicePixels �� Triggers P� Property P� Value  ButtonTextDisabled  ButtonBackgroundHover  ButtonBorderHover  ButtonTextHover  ButtonBackgroundPressed 	 ButtonBorderPressed	 �� 
TargetName 

 Accent  PlusIcon

 �� Top �� RelativeSource �� AncestorType �� Left  
DeleteIcon � Points��%�  &	        &	 p    &	     �� 5   
   " d�5      .�5	      ��  � ��# �  6+   �� 5
       � ��# �  6,   �� 5       � ��$ 1q�60   �� 5       �@�FocusVisualStyle 61   Z� �� 5       � ��# �  6+   �� 5       � ��$ 20��6'   �� 5       � ��$ Center=�6;   �� 5       � ��$ 3q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      � .+�5      A� $��Chrome��6&   #��z��5   "   #��z��5   "   #��z��5   "   #��z��5   "   #��z��5   "   �� 5      $��	Presenter��6/   #��z��5   +   #��z��5   +   #��z��5   +   ��. # z 5    +   5!       5#      P� 5$       � {� .  . �5%   "   �� # �  6?    � ��5&      P� 5'       �@J�IsMouseOver . . �5(   "   �� # �  6?    � ���� 5)   "   # �  6@    � ���� 5*   "   # �  6?    � ��5+      P� 5,       � �� . . �5-   "   �� # �  6?    � ���� 5.   "   # �  6@    � ���� 5/   "   # �  6?    � ��50      P� 51       �@d�	IsChecked$
 TrueY�6H   . �52   "   �� # �  6?    � ���� 53   "   # � 	 6@    � ���� 54   "   # �  6?    � ��55      P� 56       �@J�	IsFocused . . �57   "   �� $	 Chrome��6)   # � 
 6O    � ��58      5:      5<      �� 5=       � ��$ Center=�69   �� 5>       � ��$ 20��6&   5?      �� 5A   
   .R�5B      (� $��Stretch=�6   $��Stretch=�5C      .��5D      �� $	��100��6   $	��100��5E      .+�5F      �� $

 37.5��6    $	��100��5G      $��25��5H      ��5I      �� *
Foreground+ �� $ ContentControlL��� 5J      $
 37.5��6    $��25��5K      $	��100��5L      ��5M      �� *
Foreground+ �� $ ContentControlL�5N      5O      5P      �� 5Q   
   .R�5R      (� $��Stretch=�6   $��Stretch=�5S      .��5T      �� $	��100��6   $	��100��5U      .+�5V      �� $	��100��6   $	��100��5W      .+�5X      � q �    -1������ �� �� -1�,��� ���, �� ������, -1 �� �������� -1��6"   �� *
Foreground+ �� $ ContentControlL�5Y      5Z      5[      5\      5]      5^      5_      