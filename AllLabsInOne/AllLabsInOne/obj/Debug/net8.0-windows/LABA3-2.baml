   M S B A M L   `   `   `  ����G  CAllLabsInOne, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:AllLabsInOneAllLabsInOne  5   	       AllLabsInOne.LABA3_2   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:AllLabsInOne     5   	     � Title$  LABA3_2��5   	   $	��450��6   $	��800��6&    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � .+�5   
   �� -   5         ��Name$ 	inkCanvas��5      $��10,47,10,10q�6'   �� 5   
    �� Orientation$ 
Horizontal=�6   $��10q�6.   $	��Top=�6:   .+�5      �� $��	Цвет:��6   $��Center=�6$   �� 5      -   5         ��Name$ colorComboBox��5       �� SelectedIndex$ 0��6.   $��10q�6@   .@�5      �� $��Чёрный��6   
 � Tag$ Black��60   �� 5      $��Красный��6   $	 Red��61   �� 5      $��Зелёный��6   $ Green��61   �� 5      $��
Синий��6   $
 Blue��6/   5      �� 5      $��Размер пера:��6   $��Center=�6+   �� 5       -   5         ��Name$ 
sizeSlider��5       $	��100��6)   	 � Minimum$	 1Q�65   
 � Maximum$
 50Q�6A    � Value$ 10Q�6N   $��5q�6Y   $��Center=�6d   �� 5"      $��Режим:��6   $��Center=�6%   �� 5$      $ 
Horizontal=�6   $��Center=�62   $��10q�6M   .+�5&      	� -   5         	�Name$ drawRadioButton��5&      $
��Draw��67    	� 	GroupName$
 Mode��6F    d� 	IsChecked$
 TrueY�6W   $��5q�6h   	� 5(      -   5        $ editRadioButton��5(      $
��Edit��67   $
 Mode��6F   $��5q�6W   	� 5*      -   5        $ deleteRadioButton��5*      $��Delete by Point��69   $
 Mode��6S   $��5q�6d   	� 5,      -   5        $ deletemodelRadioButton��5,      $��Delete Figure��6>   $
 Mode��6V   $��5q�6�   5.      50      51      52      