   M S B A M L   `   `   `  ����J  FExchange.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Exchange.WpfApp.CustomUserControl!Exchange.WpfApp.CustomUserControl  5
   	   #    Exchange.WpfApp.ProductWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   8uc/clr-namespace:Exchange.WpfApp.CustomUserControl  5
   	   -   5          �Name$  window��5   	    � Title$ Product Details��5   	   $	��470��6!   $	��800��6.    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5      4   .Exchange.WpfApp.CustomUserControl.ControlBarUC  
 � Tag 6   �� *Title+ �� ElementName$ window��6J   5      � 5   
   $��1��6   .+�5      #  MaterialDesignThemes.Wpf.Card  $��0��6"      MaterialDesignOutlinedCard#��[  5   "   .��5       �  � ColumnDefinitions 5!      �� 5"      $	��460 �5#      �� 5$      $	��330 �5%      .+�5'      �� $��0��6    �� CornerRadius$ 10��6-   $	��Top=�5(      $	��355��5)      $��35 30 20 10q�5*      ��5,      �� 5-      	 j� Stretch$	 UniformToFill=�5.   !   
 �� ImageSource
 5/   !   �� *Img+54      �� 55      $��1��6!   .+�57      �� $��20 30 10 10q�58      $
��Auto��5:       �� TextAlignment$
 Left=�5;      $
��Wrap=�5<      $
��Bold"�5=      $��28(�5>      ��59      �� *Name+5@      �� 5A      $��20 0 0 5q�6$   �� 5B      $��20(�6`   $
��Bold"�6n   
���  ����6(   ��  �� Path$ Price� �� StringFormat$ {0:#,#} ₫��6�   5C      �� 5D       �� Orientation$ 
Horizontal=�6%   $��	20 5 0 10q�6>   .+�5E      '  !MaterialDesignThemes.Wpf.PackIcon  $��0,2,3,0q�66   ��5F   "   �� 5G   &    �� 
TargetType"  6,   .�5H   *   ��  �� Property �@ Kind �� Value$ Check=�6A   �� 5I   *    � ��
 �2�2�6G    �� Triggers 5J   *   �� 5K   .    �� Binding 6:   �� *Status+ �� Value	 False6U   .a�5L   2   ��  �@ Kind$ Cancel=�6I   �� 5M   2    � ��
 �  ��6O   5N   /   5P   '   5R      �� 5S      $��Center=�6(   $��14(�6C   ��5T   "   �� 5U   &   " ��6,   .�5V   *   ��  � ��$ In stock��6A   �� 5W   *    � ��
 �2�2�6G    5X   *   �� 5Y   .    6:   �� *Status+	 False6U   .a�5Z   2   ��  � ��$ Out of stock��6I   �� 5[   2    � ��
 �  ��6O   5\   /   5^   '   5`      5a      �� 5c      $ 
Horizontal=�6%   $��20 0 0 5q�6>   .+�5d           Kind$ CartPlus=�66   $��0 3 5 0q�6F   �� 5e      $��Center=�6e   $��13(�6�   ��6(   �� $ Quantity�$ Quantity: {0}��6�   5f      �� 5h      $��	20 20 0 0q�6$   $��14(�5i   $   $��Medium"�5j   $   &   System.Windows.Controls.DataGrid  5k      -   5          Name$ Author��5k   '      AutoGenerateColumns$ False��68      HeadersVisibility$
 None=�6T      CanUserAddRows$ False��6m      Columns 5l   "   0  *System.Windows.Controls.DataGridTextColumn  5m   &   ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
FullName+6V   5o      5p      �� 5r      
���iii�$��	20 50 0 5q�5t      $��Product Details��5u      $��15(�5v      $
��Bold"�5w      �� 5y      $
��auto��5z      $��50��5{      $��
20 0 10 10q�5|      $��13(�5~      $
��Wrap=�5      ��5}      �� *Description+5      �� 5�      $ 
Horizontal=�6%   $��	10 10 0 0q�6>   .+�5�      �� -   5         ��Name$ btnTradeName��5�   %   $��	0 0 10 0 q�5�   !   $
��Left=�5�   !   $��	Trade now��5�   !   $��18(�5�   !   $	��142��5�   !   $��47��6-   
�������
���   �5�      �� 5�      -   5        $
��Left=�5�   !   $��Cancel��5�   !   $��15(�5�   !   $	��140��5�   !   $��45��6-   $��10,0,0,0q�5�   !    ! MaterialDesignPaperDarkButton#��[ 5�   !    � ToolTip$3 -Resource name: MaterialDesignPaperLightButton��5�   !   
���   �
�������$��1q�5�   !   5�      5�      5�      5�      5�      5�      5�      5�      