   M S B A M L   `   `   `  ����  Exchange.WpfApp     Exchange.WpfApp.UI.wMyOder   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localExchange.WpfApp.UI.wMyOder     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  My Order Detail List��5	   	   $	��650��6&   $
��1300��63   .��5      �  � ColumnDefinitions 5   
   �� 5      .+�5   
   o� -   5        $��menu1��5      $��60��6   $	��Top=�6(   $��2q�6@   $��16(�6T   $
��Bold"�6b   .@�5      m� $
��Menu��6    m� IsCheckable$ False��6%   $��16(�69   .@�5      m� -   5        $��Post Product��5      $ False��61   $��12(�6E   6S   m� 5      -   5        $��My trade product��5      $ False��65   $��12(�6I   6W   5      5      �� 5   
    �� Orientation$ Vertical=�6    J� RenderTransformOrigin$ 	0.5,0.519&�6,   .+�5      �� .  (MaterialDesignThemes.Wpf.ColorZoneAssist   
Background
 �   �   
Foreground
 �����   Mode$ Custom=�5      $��My Order Information��5      $��35 45 35 35q�6/   $	��212��6D   .��5      � $	��150��6    � RowDefinitions 5      �� 5      $��1* �6(   �� 5      $��1* �6(   �� 5       $��1* �6(    5"      �� 5#      $	��125 �6+   �� 5$      $
��89.4 �6+   �� 5%      $��110.6 �6+   �� 5&      $
��Auto �6+   $	��115��68   �� 5'      $	��171 �6+   �� 5(      $	��150 �6+   �� 5)      $	��200 �6+   �� 5*      $��75 �6+   .+�5.      �� $��0��6   $��0��6,   $��Your product name��69   $
��Left=�6U   $��Center=�6p   $	��111��6�   �� 5/      -   5        	 ��Name$	 txt_haveProductName��5/   ;   $��1��6   $��0��6.   $��5,0,0,12q�6X   $	��180��6j   $
��Left=�6v   
 �� 
IsReadOnly$

 True��6�   $��2��6�   �� 50      $��3��6   $��0��6,   $��Quantity��69   $��Center=�6L   $��Center=�6i   $	��115��6�   �� 51      -   5        $	 txt_havequantityProduct��51   ;   $��0��6   $��4��6+   $��	5,0,10,12q�6\   $

 True��6o   �� 52      $��5��6   $��0��6,   $��Message��69   $��Center=�6K   $��Center=�6h   $	��130��6�   �� 53      -   5        $	 txt_Message��53   ;   $��6��6   $��0��6.   $��	5,0,10,12q�6P   �� 54      -   5         ��Name$ ButtonUserHaveSelect��54   M   $��7��6   
���   �$��0��6@   $��Select��6k   $��10,10,-20,8q�6�   �� 57      $��1��6   $��WantedProduct Name��6)   $��Center=�6F   $��Center=�6c   $	��125��6�   �� 58      -	   5        $	 txt_wantProductName��58      $��1��6;   $��1��6K   $��5,0,0,12q�6X   $	��180��6j   $
��Left=�6v   $

 True��6�   $��2��6�   �� 59      $��3��6   $��1��6,   $��Wanted Quantity��69   $
��Left=�6S   $��Center=�6n   $	��105��6�   �� 5:      -
   5        $	 txt_wantQuantityProduct��5:   ;   $��1��6   $��4��6+   $��	5,0,10,12q�6\   $

 True��6o   �� 5;      $��5��6   $��1��6,   $��Address��69   $��Center=�6K   $��Center=�6h   $	��130��6�   �� 5<      -   5        $	 txt_Address��5<   ;   $��6��6   $��1��6.   $��	5,0,10,12q�6P   �� 5=      -   5        $ ButtonUserHaveSelect2��5=   M   $��7��6   
���   �$��1��6@   $��Select��6l   $��
10,9,-20,9q�6�   �� 5@      -   5         ��Name$ 	txtStatus��5@      $��0��6/   $��2��6?   $��Status��6L   $
��Left=�6]   $��Center=�6x   $��57��6�   �� 5A      -   5        $	 
txt_Status��5A   ;   $��1��6   $��2��6.   $��5,0,0,12q�6O   $	��180��6a   $
��Left=�6m   $��2��6�   �� 5B      $��3��6   $��2��6,   $��
Created by��69   $��Center=�6N   $��Center=�6k   $	��114��6�   �� 5C      -   5        $	 txt_createCustommer��5C   ;   $��2��6   $��4��6+   $��	5,0,10,12q�6X   $

 True��6k   �� 5D      $��5��6   $��1��6,   $��Order Detail ID��69   $��Center=�6S   $��Center=�6p   $	��132��6�   $��0,46,0,4q�6�   $��2��6�   �� 5E      -   5        $	 txt_orderDetailID��5E   ;   $��2��6   $��6��6+   $��	5,0,10,12q�6V   $

 True��6i   5F      5G      �� 5H      -   5        $	 SearchTextBox��5H       �� TextWrapping$
 Wrap=�6-   $	��332��6A   6M   �� 5I      $��40��6   $ 
Horizontal=�6%   $��Right=�6>   $	��368��6Z   .+�5J      �� -   5        $ 
ButtonSave��5J      
���   �$
��Save��6@   $��35��6O   $��80��6[   $��0,0,20,0q�6   �� 5K      -   5        $ ButtonCancel��5K      
�������
���   �
���iii�$��Cancel��6l   $��35��6}   $��80��6�   $��0,0,30,0q�6�   �� 5L      -   5        $ ButtonGoToOrder��5L      ���#4CAF50$��	Order Now��6G   $
��Bold"�6[   $��35��6m   $	��115��6y   6�   5M      �� 5N      $
��Auto=�6   $
��Auto=�6A   $��0,10,0,5q�6d   $	��225��6v   $
��1208��6�   .��5O      &   System.Windows.Controls.DataGrid  -   5          Name$ grdOrderView��5O         AutoGenerateColumns$ False��61      CanUserAddRows$ False��6M   ��6e   �� *OrderDetail+   Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Header$ Order Detail ID��6-      
Visibility$ Visible=�6h      
IsReadOnly$
 True��6}   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *OrderDetailId+6}     5S      $ having Product ID��6-   $ Visible=�6n   $
 True��6�    6H   �� *ProductUserHaveId+6�     5T      $ Wanted Product ID��6-   $ Visible=�6n   $
 True��6�    6H   �� *ProductUserWantId+6�     5V      $ GapPrice��6-   $ Visible=�6\   $
 True��6q    6?   �� *
GapPrice+6q     5W      $ Proposer��6-   $ Visible=�6\   $
 True��6q    6?   �� *
Proposer+6q     5X      $ Discount��6-   $ Visible=�6\   $
 True��6q    6?   �� *
Discount+6q     5Y      $ Order Message��6-   $ Visible=�6`   $
 True��6u    6D   �� *	Message+6u     5Z      $ Address��6-   $ Visible=�6Z   $
 True��6o    6>   �� *	Address+6o     5\      $ Order Detail Status��6-   $ Visible=�6e   $
 True��6z    6J   �� *Status+6z   4  .System.Windows.Controls.DataGridTemplateColumn  5]      $ Select��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6A      CellTemplate 5^      �� 5_   "   .R�5`   &   �� -   5        $��Select��5`   -   ��6>   �� *OrderDetailId+6i   5a   #   5c        5f      $ Delete��61   $	 120 6A    5g      �� 5h   "   .R�5i   &   �� -   5        $��Delete��5i   -   
�������
���������6c   �� *OrderDetailId+6�   5j   #   5l      5p      5q      5r      5s      5t      