   M S B A M L   `   `   `  ����J  FExchange.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Exchange.WpfAppExchange.WpfApp  5   	   U/clr-namespace:Exchange.WpfApp.CustomUserControl!Exchange.WpfApp.CustomUserControl  5   	   .    (Exchange.WpfApp.SelectTradeProductWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   /localclr-namespace:Exchange.WpfApp     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   8uc/clr-namespace:Exchange.WpfApp.CustomUserControl  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5          �Name$  window��5   	    � Title$ Your Product��5   	   $	��450��6   $	��800��6+    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5      4   .Exchange.WpfApp.CustomUserControl.ControlBarUC  
 � Tag 6   �� *Title+ �� ElementName$ window��6J   5      � 5   
   $��1��6    5      �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      6"   .+�5*      #  MaterialDesignThemes.Wpf.Card  .��5+      �� $��Center=�6   $��	5 5 5 10 q�5,      $��Medium"�5.       $   MaterialDesignHeadline4TextBlock#��[  5/      ��5-      ��  �� Path$ Buyer.FullName� �� StringFormat$  {0}'s Inventory��50      51        54      $��1��6"   $��5q�6/   .��55      � $��0 0 0 10q�6   	 � ColumnDefinitions	 56      �� 57      $	��200 �6+   �� 58      $	��400 �6+   �� 59      $��* �6+   .+�5<      �� -   5        $��	txtFilter��5>      $��Center=�5=      $��1��5@      $��
10 5 10 10q�5A      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$)
 #Enter product name for filtering...��5B       % !MaterialDesignFloatingHintTextBox#��[ 5C      .��6T   5D      5E      5F        5I      $��2��6"   $��5q�6/   .��5J      � .+�5K      &   System.Windows.Controls.DataGrid  -   5          Name$ ProductListGrid��5K         AutoGenerateColumns$ False��5L         CanUserAddRows$ False��5N      $��Center=�5O      $��Center=�5P      $	��800��5Q      ��5M      �� *
Products+   Columns 5R      0  *System.Windows.Controls.DataGridTextColumn  5S      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��61      
IsReadOnly$
 True��6[      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.7* 6m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *	ProductId+6m     5T      $
 Name��61   $
 True��6X   $
 1.5* 6j    6?   �� *Name+6j     5U      $ Quantity��61   $
 True��6`   $
 0.7* 5V   1    5U   C   �� *
Quantity+5V   1     5W      $ Description��61   $
 True��6f   $ 2* 5X   1    5W   F   �� *Description+   ElementStyle 5Y   "   �� 5Z   &    �� 
TargetType" ��6,   .�5[   *   ��  �� Property � �� �� Value$
 Wrap=�6I   5\   '   5^      4	  .System.Windows.Controls.DataGridTemplateColumn	  5_      $ Status��65   $
 0.7* 6E   $
 True��5`   5    	  CellTemplate 5a   "   �� 5b   &   .R�5c   *   �� $��Center=�64   $��Center=�6Q   ��5d   .   �� 5e   2   " ��68   .�5f   6   ��  � ��$ Unavailable��6M    �� Triggers 5g   6   �� 5h   :    �� Binding 6F   �� *Status+ �� Value True6a   .a�5i   >   ��  � ��$ 	Available��6U   5j   ;   5l   3   5n   +   5o   '   5q      	  5r      $ Actions��65   $ * 6F    5s   "   �� 5t   &   .R�5v   *   ��  ��Name$ 	btnSelect��61   -   5        $��Select��5v   D   $��15(�5z   1   
�������
���   �$��0q�5}   1   
������  5x   1   �� 5�   +   5�   '   5�         ColumnHeaderStyle 5�      �� 5�      =
  7System.Windows.Controls.Primitives.DataGridColumnHeader" 
 6$    & "MaterialDesignDataGridColumnHeader �� BasedOn# [ 6F   .�5�   "   ��  � ��$ Center=�6O   5�      5�      5�      5�      5�      5�      5�      