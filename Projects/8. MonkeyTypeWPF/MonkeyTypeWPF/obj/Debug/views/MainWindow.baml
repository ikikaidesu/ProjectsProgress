   M S B A M L   `   `   `  ����H  DMonkeyTypeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MonkeyTypeWPF.modelviewsMonkeyTypeWPF.modelviews  5   	   A%clr-namespace:MonkeyTypeWPF.utilitiesMonkeyTypeWPF.utilities  5   	       MonkeyTypeWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5vm&clr-namespace:MonkeyTypeWPF.modelviews     5   	   6Menu%clr-namespace:MonkeyTypeWPF.utilities     5   	   $	��600��5	   	   $	��920��6     � 
ResizeMode$  NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $��0q�5   	   
������  � AllowsTransparency . .��5      �� ���#323437 �� CornerRadius$ 10��5   	   $��0q�5   	   ._�5   
   �  � Cursor$  ��6    � RowDefinitions 5      �� 5      $��75 �6    �� 5       � ColumnDefinitions 5      �� 5      .+�5"      �� $��0��6   $��0��5#      .+�5%      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�5&      $��Center=�5'      $��0,10,0,0q�5(      .+�5)      �� $��/images/icon.png��6   $��50��5*      $��50��5+      $��Center=�5,      �� 5.      $ Vertical=�6!   $��Center=�5/   !   $��0,0,0,0q�50   !   .+�51      �� $��
monkey see��52      $��12(�53      $
��Left=�54         defaultstyle#��[  55      �� 56      $��
monkeytype��57      $��0,-5,0,0q�58        LogoName#��[ 59      5:      5;      5<      �� 5>      $��0��6   $
��Left=�5?      $ 
Horizontal=�5@      $��	175,0,0,0q�5A      .+�5C      ��   nagivationoperations#��[ 5D      ��5E      �� *TypingCommand+.��5F      �� $��/images/typing_icon.png��6   5G      �� 5I      #��[ 5J      $��10,0,0,0q�5L      ��5K      �� *AccountCommand+.��5M      �� $��/images/account_icon.png��6   5N      5P      �� 5R      $��0��6   $��1��5S      $��Right=�5T      $ 
Horizontal=�5U      $��
0,-20,10,0q�5V      .+�5W      ��   windowoperations#��[ 5Z      ��5X      �� *CollapseWindowCommand+��5Y      �� 	 �� RelativeSource	 �� 
 �� AncestorType"
 �.��5[      �� $��/images/minus_icon.png��6   5\      �� 5]      #��[ 5_      ��5^      �� *CloseWindowCommand+.��5a      �� $��/images/close_icon.png��6   5b      5c      �� 5e      $��1��6   ��5f      �� *CurrentView+5g      5h      5i      5j      