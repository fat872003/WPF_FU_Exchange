   M S B A M L   `   `   `  ����J  FExchange.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Exchange.WpfApp.UIExchange.WpfApp.UI  5   	   !    Exchange.WpfApp.UI.wProduct   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Exchange.WpfApp.UI     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  wProduct��5	   	   $	��450��6   $
��1000��6'   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� -   5        $��menu1��5      $��42��6   $	��Top=�6(   $��2q�6@   $��16(�6T   $
��Bold"�6b   $��0��6t   .@�5      m� $
��Menu��6    m� IsCheckable$ False��6%   $��16(�69   $��38��6G   .@�5      m� -   5        $��Posted Product��5      $ False��63   $��12(�6G   6U   m� 5      -   5        $��My traded product��5      $ False��66   $��12(�6J   6X   m� 5      -   5        $��My wanted product��5      $ False��66   $��12(�6J   6X   m� 5      -   5        $��My order DetailList��5      $ False��68   $��12(�6L   6Z   m� 5      -   5        $��My wishList��5      $ False��60   $��12(�6D   6R   m� 5      -   5        $��My order��5      $ False��6-   $��12(�6A   6O   5      5      � 5   
   $��1��6   $��10,10,10,25q�6    5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5!      �� .  (MaterialDesignThemes.Wpf.ColorZoneAssist   
Background
 �   �   
Foreground
 �����   Mode$ Custom=�5$      $��Sản phẩm trao đổi��5%      $��
0,-16,0,10q�6,   $��0��6@   5&      �� 5(      -   5         ��Name$ SearchTextBox��5(      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$% Enter product name to search...��5)      $	��300��5*      $��30��5+      $��340,27,340,0q�5,      $��0��5.      $	��Top=�5/      &   System.Windows.Controls.DataGrid  51      -	   5          Name$ 
grdProduct��51      	   AutoGenerateColumns$	 False��52      
   CanUserAddRows$
 False��54      $��1��55      $��0,10,0,0q�6$   ��53      �� *
UserHave+   Columns 56      0  *System.Windows.Controls.DataGridTextColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header$ Product��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6[      
Visibility$ Visible=�6h   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Product.Name+6h     58      $ Price��6)   $
 Auto 6R      
IsReadOnly$
 True��6_    68   �� *Price+6_     59      $ Currency��6)   $
 Auto 6X   $
 True��6e    6;   �� *
Currency+6e     5:      $ Quantity��6)   $
 Auto 6X   $
 True��6e    6;   �� *
Quantity+6e     5;      $ Post Description��6)   $
 Auto 6c   $
 True��6p    6C   �� *Description+6p     5<      $ Product Description��6)   $
 Auto 6n   $
 True��6{    6F   �� *Product.Description+6{     5=      $ Customer��6)   $ * 6i   $
 True��6s    6;   �� *Product.Customer.FullName+6s     5>      $ 	Post Date��6)   $
 0.6* 6z   $
 True��6�    6<   �� *
CreateDate+ �� StringFormat$ {0:dd/MM/yyyy}��6�     5?      $ GapPrice��6)   $
 Auto 6X   $
 True��6e    6;   �� *
GapPrice+6e     5@      $ Status��6)   $
 Auto 6T   $
 True��6a    69   �� *Status+6a     5A      $	 Fax��6)   $
 0.7* 6N   $
 True��6[    66   �� *Fax+6[   4  .System.Windows.Controls.DataGridTemplateColumn  5B      $	 100 6-      CellTemplate 5C      �� 5D      .R�5E   "   ��  ��Name$ ButtonTrade��6L   -
   5        
���   �$��Trade��5E   <   ��6a   �� *ProductUserHaveId+6�   5F      5H      5J      5K      5L      5M      