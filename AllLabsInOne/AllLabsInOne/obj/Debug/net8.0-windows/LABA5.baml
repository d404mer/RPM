   M S B A M L   `   `   `  ����G  CAllLabsInOne, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:AllLabsInOneAllLabsInOne  5   	       AllLabsInOne.LABA5   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:AllLabsInOne     5   	     � Title$  LABA5��5   	   $	��450��6   $	��800��6$    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5
         GradientBrush �� 
StartPoint �� EndPoint � Color � Offset  LargeTextBoxStyle �� 
TargetType	 �� Property
 �� Value �� Triggers P� Property P� Value  SmallTextBoxStyle��%a  &	        &	 �     7   &	 �    7   �� 5   
   $	 0,0&�64   $	 1,1&�6E   .��5      � $ Yellow��6   $ 0Q�6*   � 5      $	 Red��6   $ 1Q�6'   5      �� 5   
   " ��6*   .�5      �� 	 � ��$
 16(�6)   �� 5      	 � ��$	
 150��6'   �� 5      	 � ��$
 5q�6'   �� 5      	 � ��8
   6+    5      P� 5       �@J�	IsFocused$
 True��6/   . �5      �� 	 � ��$
 20(�61   �� 5      	 � ��$	
 200��6/   5      5      �� 5   
   " ��6*   .�5       �� 	 � ��$
 Bottom=�62   �� 5!      	 � ��$
 12(�6)   �� 5"      	 � ��$	
 100��6'   �� 5#      	 � ��$
 5q�6'   �� 5%      	 � ��8
   6+    5&      P� 5'       �@J�	IsFocused$
 True��6/   . �5(      �� 	 � ��$
 16(�61   �� 5)      	 � ��$	
 150��6/   5*      5,      5-      .��5.      �  � ColumnDefinitions 5/   
   �� 50      $��* �6   �� 51      $��* �6   .+�54   
   � #��[  6   $��0��6;   .+�55      �� .+�56      �� #��[ 6   �� 57      #��[ 6   58      59      � 5;   
   #��[  6   $��1��6;   .+�5<      �� .+�5>      �� #��[ 6   �� 5?      #��[ 6   5@      5A      5B      5C      