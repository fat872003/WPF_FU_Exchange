   M S B A M L   `   `   `  ����J  FExchange.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Exchange.WpfApp.UIExchange.WpfApp.UI  5   	       Exchange.WpfApp.UI.wOrder   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Exchange.WpfApp.UI     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  wOrder��5
   	   $	��750��6   $
��1300��6%   .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6    J� RenderTransformOrigin$ 	0.5,0.519&�6,   .+�5      �� .  (MaterialDesignThemes.Wpf.ColorZoneAssist   
Background
 �   �   
Foreground
 �����   Mode$ Custom=�5      $��My Oder Information��5      $��35q�6.   $	��335��6:   $
��1216��6G   .��5      � $	��250��6   $��	0,17,0,16q�6$   $
��1067��67    � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      $��50 �6(   �� 5      $��50 �6(    � ColumnDefinitions 5      �� 5      $	��125 �6+   �� 5       $
��89.4 �6+   �� 5!      $��110.6 �6+   �� 5"      $
��Auto �6+   $	��115��68   �� 5#      $	��171 �6+   �� 5$      $	��150 �6+   �� 5%      $	��200 �6+   �� 5&      $��75 �6+   .+�5*      �� $��0��6   $��0��6,   $��OrderID��69   $
��Left=�6K   $��Center=�6f   $	��111��6�   �� 5+      -   5         ��Name$ txt_orderID��5+   ;   $��1��6   $��0��6.   $��5,0,0,12q�6P   $	��180��6b   $
��Left=�6n   	 �� 
IsReadOnly$
	 True��6�   $��2��6�   �� 5,      $��3��6   $��0��6,   $��Order Detail ID��69   $
��Left=�6S   $��Center=�6n   $	��105��6�   �� 5-      -   5        $ txt_orderDetailID��5-   ;   $��0��6   $��4��6+   $��	5,0,10,12q�6V   $
	 True��6i   �� 5.      $��5��6   $��0��6,   $��
Order date��69   $��Center=�6N   $��Center=�6k   $	��130��6�   �� 5/      -   5        $ txt_orderDate��5/   ;   $��6��6   $��0��6.   $��	5,0,10,12q�6R   $��38��6e   $��Bottom=�6q   $
	 True��6�   �� 52      $��1��6   $��Complete Date��6)   $��Center=�6A   $��Center=�6^   $	��125��6�   �� 53      -   5        $ txt_completeDate��53      $��1��68   $��1��6H   $��5,0,0,12q�6U   $	��180��6g   $
��Left=�6s   $
	 True��6�   $��2��6�   �� 54      $��3��6   $��1��6,   $��Total Discount��69   $
��Left=�6R   $��Center=�6m   $	��105��6�   �� 55      -   5        $ txt_totalDiscount��55   ;   $��1��6   $��4��6+   $��	5,0,10,12q�6V   $
	 True��6i   �� 56      $��5��6   $��1��6,   $��Total Quantity��69   $��Center=�6R   $��Center=�6o   $	��130��6�   �� 57      -   5        $ txt_totalOrderQuantity��57   ;   $��6��6   $��1��6.   $��	5,0,10,12q�6[   $
	 True��6n   �� 5:      -   5        
 ��Name$
 	txtStatus��5:      $��0��6/   $��2��6?   $��Description��6L   $
��Left=�6b   $��Center=�6}   $	��111��6�   �� 5;      -	   5        $ txt_Des��5;   ;   $��1��6   $��2��6.   $��5,0,0,12q�6L   $	��180��6^   $
��Left=�6j   $��2��6�   �� 5<      $��3��6   $��2��6,   $��Order Status��69   $��Center=�6P   $��Center=�6m   $	��114��6�   �� 5=      -
   5        $ OrderStatus��5=   ;   $��2��6   $��4��6+   $��	5,0,10,12q�6P   �� 5>      $��5��6   $��1��6,   $
��Note��69   $��Center=�6H   $��Center=�6e   $	��132��6�   $��0,46,0,4q�6�   $��2��6�   �� 5?      -   5        $ txt_note��5?   ;   $��2��6   $��6��6+   $��	5,0,10,12q�6M   �� 5B      -   5        $
 UserHaveStatus��5B      $��0��64   $��3��6D   $��Trad status��6Q   $
��Left=�6g   $��Center=�6�   $	��111��6�   �� 5C      -   5        $ txtUserHaveStatus��5C   ;   $��1��6   $��3��6.   $
	 True��6V   $��5,0,0,12q�6h   $	��180��6z   $
��Left=�6�   $��2��6�   �� 5D      $��3��6   $��3��6,   $��Wanted status��69   $��Center=�6Q   $��Center=�6n   $	��105��6�   �� 5E      -   5        $ txtUserWantStatus��5E   ;   $��3��6   $��4��6+   $��	5,0,10,12q�6V   $
	 True��6i   �� 5F      $��5��6   $��3��6,   $��
Order type��69   $��Center=�6N   $��Center=�6k   $	��130��6�   �� 5G      -   5         ��Name$ txtOrderType��5G   <   $��6��6   $��3��6/   $��
5,13,10,12q�6R    �� DisplayMemberPath$ OrderTypeName��6f    �� SelectedItem 6�   �� *SelectedOrderType+ �� Mode$ TwoWay=��� 5K      -   5        $
 Customer_Order��5K      $��4��64   $��Ordered customer��6A   $��Center=�6\   $��Center=�6y   $	��125��6�   �� 5L      -   5        $ txtCustommerOrder��5L   ;   $��1��6   $��4��6.   $��5,0,0,12q�6V   $	��180��6h   $
��Left=�6t   $��2��6�   $
	 True��6�   5M      5P      �� 5Q      -   5        $ SearchTextBox��5Q      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Type here to search...��6-    �� TextWrapping$
 Wrap=�6e   $	��241��6y   6�   �� 5R      $��40��6   $ 
Horizontal=�6%   $��Right=�6>   $	��368��6Z   .+�5S      �� -   5         ��Name$ ButtonUpdate��5S      
���   �$��Update��6B   $��35��6S   $��80��6_   $��0,0,20,0q�6�   �� 5T      -   5        $ ButtonCancel��5T      
�������
���iii�
���   �$��Cancel��6k   $��35��6|   $��80��6�   $��0,0,30,0q�6�   5U      �� 5V      $
��Auto=�6   $
��Auto=�6A   $��0,10,0,5q�6d   $	��225��6v   $
��1208��6�   .��5W      &   System.Windows.Controls.DataGrid  -   5          Name$ grdOrderView��5W         AutoGenerateColumns$ False��61      CanUserAddRows$ False��6M   ��6e   �� *OrderDetail+   Columns 5X      0  *System.Windows.Controls.DataGridTextColumn  5Y      ,  &System.Windows.Controls.DataGridColumn   Header$ Order ID��6-      
Visibility$ Visible=�6[      
IsReadOnly$
 True��6p   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *	OrderId+6p     5Z      $ Order detail ID��6-   $ Visible=�6h   $
 True��6}    6F   �� *OrderDetailId+6}     5[      $ 
Order Date��6-   $ Visible=�6e   $
 True��6z    6A   �� *Order.OrderDate+6z     5\      $ Complete Date��6-   $ Visible=�6i   $
 True��6~    6D   �� *Order.CompleDate+6~     5]      $ Total Quantity��6-   $ Visible=�6r   $
 True��6�    6E   �� *Order.TotalOrderQuantity+6�     5^      $ Order Description��6-   $ Visible=�6n   $
 True��6�    6H   �� *Order.Description+6�     5_      $ UserHaveStatus��6-   $ Visible=�6n   $
 True��6�    6E   �� *Order.UserHaveStatus+6�     5`      $ UserWantStatus��6-   $ Visible=�6n   $
 True��6�    6E   �� *Order.UserWantStatus+6�     5a      $
 Note��6-   $ Visible=�6Z   $
 True��6o    6;   �� *
Order.Note+6o     5b      $ 
Order Type��6-   $ Visible=�6s   $
 True��6�    6A   �� *Order.OrderType.OrderTypeName+6�     5d      $ Total Discount��6-   $ Visible=�6m   $
 True��6�    6E   �� *Order.TotalDiscount+6�     5e      $ Total Price��6-   $ Visible=�6g   $
 True��6|    6B   �� *Order.TotalPrice+6|     5f      $ Order Status��6-   $ Visible=�6^   $
 True��6s    6C   �� *Status+6s   4  .System.Windows.Controls.DataGridTemplateColumn  5h      $  ��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6;      CellTemplate 5i      �� 5j   "   .R�5k   &   �� -   5        $��Select��5k   -   ��6>   �� *OrderDetailId+6i   5l   #   5n        5q      $  ��61   $	 120 6;    5r      �� 5s   "   .R�5t   &   �� -   5        $��Delete��5t   -   
���  ��
���������6f   �� *OrderDetailId+6�   5u   #   5w        5x      $  ��61   $	 130 6;    5y      �� 5z   "   .R�5{   &   �� -   5        $��Accept��5{   -   ���#4CAF50
���������6f   �� *OrderDetailId+6�   5|   #   5~        5      $  ��61   $	 130 6;    5�      �� 5�   "   .R�5�   &   �� -   5        $��denied��5�   -   
�������
���������6c   �� *OrderDetailId+6�   5�   #   5�        5�      $
 More��61   $	 130 6?    5�      �� 5�   "   .R�5�   &   �� -   5        $��Detail��5�   -   
�������
���   ���6d   �� *OrderDetailId+6�   5�   #   5�      5�      5�      5�      5�      5�      