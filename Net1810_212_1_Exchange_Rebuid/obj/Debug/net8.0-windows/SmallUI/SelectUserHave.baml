   M S B A M L   `   `   `  ����J  FExchange.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Exchange.WpfApp.SmallUIExchange.WpfApp.SmallUI  5   	   ,    &Exchange.WpfApp.SmallUI.SelectUserHave   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Exchange.WpfApp.SmallUI     5   	   -   5          � Title$  SelectUserHaveSmallUI��5   	   $	��580��6'   $	��800��64   .��5	      � .+�5
   
   �� -   5         �� Orientation$ Vertical=�5
      .+�5      �� $+��%Thông tin sản phẩm trao đỏi
��6   $��10q�6F   .��5      � $	��100��6    � RowDefinitions 5      �� 5      $��1* �6(   �� 5      $��1* �6(    � ColumnDefinitions 5      �� 5      $��80 �6+   �� 5      $	��150 �6+   �� 5      $��80 �6+   �� 5      $	��150 �6+   �� 5      $��80 �6+   �� 5      $	��200 �6+   �� 5      $��* �6+   .+�5      �� $��0��6   $��0��6,   $��
UserWantID��69   $
��Left=�6N   $��Center=�6i   �� 5      -   5         ��Name$ txt_userWantID��5   ;   $��1��6   $��0��6.   $��25��6S   $��	0,13,0,12q�6_   $	��140��6r   $��Center=�6~    �� 
IsReadOnly$
 True��6�   �� 5      $��2��6   $��0��6,   $
��Name��69   $
��Left=�6H   $��Center=�6c   �� 5      -   5        $ ProductName��5   ;   $��0��6   $��3��6+   $��25��6P   $��	5,13,0,12q�6\   $	��145��6o   $
��Left=�6{   $
 True��6�   �� 5       $��4��6   $��0��6,   $��Quantity��69   $
��Left=�6L   $��Center=�6g   �� 5!      -   5        $ txtQuantity��5!   ;   $��5��6   $��0��6.   $��25��6P   $��	5,13,0,12q�6\   $	��159��6o   $
��Left=�6{   $
 True��6�   �� 5%      $��0��6   $��1��6,   $��Description��69   $
��Left=�6O   $��Center=�6j   �� 5&      -   5        $ txtDes��5&   ;   $��1��6   $��1��6.   $��25��6K   $��	0,13,0,12q�6W   $	��140��6j   $��Center=�6v   $
 True��6�   �� 5'      $��2��6   $��1��6,   $
��Note��69   $
��Left=�6H   $��Center=�6c   �� 5(      -   5        $ txtNote��5(   ;   $��1��6   $��3��6+   $��25��6L   $��	5,13,0,12q�6X   $	��145��6k   $
��Left=�6w   $
 True��6�   �� 5)      -   5         ��Name$ 
CreateDate��5)      $��4��60   $��1��6@   $��Create Date��6M   $
��Left=�6c   $��Center=�6~   �� 5*      -	   5        $ txtCreateDate��5*   ;   $��5��6   $��1��6.   $��25��6R   $��	5,13,0,12q�6^   $	��159��6q   $
��Left=�6}   $
 True��6�   5+      5,      �� 5-      -
   5        $ SearchTextBox��5-      $	��300��6-   $��30��69   6E   �� 5.      $��40��6   $ 
Horizontal=�6%   $	��799��6>   .+�5/      �� -   5         ��Name$ submit��5/      $��submit��6)   $��30��6:   $��84��6F   $��	10,0,20,0q�6Q   6d   �� 50      -   5        $ Cancel��50      $��Cancel��6)   $��30��6:   $��77��6F   6Q   51      �� 52      $	��278��6   $	��736��6&   .+�53      &   System.Windows.Controls.DataGrid  -   5          Name$ 
grdProduct��53      	   AutoGenerateColumns$	 False��6/   $	��169��6l   
   CanUserAddRows$
 False��6y   ��6K   �� *
UserHave+   Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$ your Wanted ID��6-      
Visibility$ Visible=�6k      
IsReadOnly$
 True��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *ProductUserHaveId+6�     56      $ Wanted Product ID��6-   $ Visible=�6f   $
 True��6{    6H   �� *	ProductId+6{     57      $ Wanted Product Name��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6k   $
 True��6x    6J   �� *Product.Name+6x     58      $ Description��6-   $	 150 6b   $
 True��6o    6B   �� *Description+6o     59      $
 Note��6-   $	 150 6T   $
 True��6a    6;   �� *Note+6a     5:      $ Price��6-   $	 150 6V   $
 True��6c    6<   �� *Price+6c     5;      $ Wanted Quantity��6-   $	 150 6c   $
 True��6p    6F   �� *
Quantity+6p     5<      $ Total Quantity��6-   $	 150 6j    6E   �� *Product.Quantity+6j     5=      $ GapPrice��6-   $	 150 6\   $
 True��6i    6?   �� *
GapPrice+6i     5>      $	 Fax��6-   $	 150 6R   $
 True��6_    6:   �� *Fax+6_     5?      $ Create Date��6-   $	 150 6a   $
 True��6n    6B   �� *
CreateDate+6n     5@      $ Currency��6-   $	 150 6\   $
 True��6i    6?   �� *
Currency+6i     5A      $ Status��6-   $	 150 6X   $
 True��6e    6=   �� *Status+6e   4  .System.Windows.Controls.DataGridTemplateColumn  5C      $ option��61   $	 100 6B      CellTemplate 5D      �� 5E   "   .R�5F   &   �� $ ButtonSelect��6>   -   5        $��Select��5F   -   ��6T   �� *ProductUserHaveId+6�   5G   #   5I      5L      5M      5N      5O      5Q      