   M S B A M L   `   `   `  ����J  FExchange.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Exchange.WpfApp.UIExchange.WpfApp.UI  5   	   "    Exchange.WpfApp.UI.wUserWant   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Exchange.WpfApp.UI     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  	wUserWant��5
   	   $	��520��6   $
��1000��6(   .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� .  (MaterialDesignThemes.Wpf.ColorZoneAssist   
Background
 �   �   
Foreground
 �����   Mode$ Custom=�5      $��Your Traded Product��5      $��10q�6.   .��5      � $	��150��6    � RowDefinitions 5      �� 5      $��1* �6(   �� 5      $��1* �6(   �� 5      $��1* �6(   �� 5      $��1* �6(    � ColumnDefinitions 5      �� 5      $	��114 �6+   �� 5      $��66 �6+   �� 5      $	��103 �6+   �� 5      $	��197 �6+   �� 5      $��84 �6+   �� 5      $��26 �6+   .+�5"      �� $��0��6   $��Code Wanted��6)   $��Center=�6?   $��Center=�6\   $��94��6~   $��0,0,0,37q�6�   $��2��6�   �� 5#      -   5         ��Name$ txtUserWanttId��5#   ;   $��1��6   $��0��6.   $��5,0,5,12q�6S    �� 
IsReadOnly$
 True��6e   �� 5$      $��2��6   $��0��6,   $��Product Name��69   $��Center=�6P   $��0,0,0,37q�6r   $��2��6�   �� 5%      -   5        $ txtUserWantName��5%   ;   $��0��6   $��3��6+   $��5,0,0,12q�6T   $	��180��6f   $
��Left=�6r   $
 True��6�   �� 5&      $��4��6   $��0��6,   $��Quantity��69   $
��Left=�6L   $��Center=�6g   $��56��6�   $��0,0,0,37q�6�   $��2��6�   �� 5'      -   5        $ txtUserWantQuantity��5'   ;   $��5��6   $��0��6.   $��
5,0,-98,12q�6X   �� 5*      $��1��6   $��Price��6)   $��Center=�69   $��Center=�6V   $��94��6x   �� 5+      -   5        $ txtUseWantPrice��5+   ;   $��1��6   $��1��6.   $��5,0,5,12q�6T   $
 True��6f   �� 5,      $��2��6   $��1��6,   $��Description��69   $��Center=�6O   �� 5-      -   5        $ txtUserWantDescription��5-   .   $��3��6   $��5,0,0,12q�6N   $	��180��6`   $
��Left=�6l   $��1��6�   �� 5.      $��4��6   $��1��6,   $��	Gap Price��69   $��Center=�6M   $��Center=�6j   $��84��6�   �� 5/      -   5        $ txtGapPrice��5/   ;   $��5��6   $��1��6.   $��
5,0,-98,12q�6P   $
 True��6d   �� 52      $��2��6   $��Currency��6)   $��Center=�6<   $��Center=�6Y   $��94��6{   �� 53      -   5        $ txtcurrency��53   ;   $��1��6   $��2��6.   $��5,0,5,12q�6P   $
 True��6b   �� 54      $��2��6   $��2��6,   $
��Note��69   $��Center=�6H   �� 55      -	   5        $ txtNote��55   ;   $��2��6   $��3��6+   $��5,0,0,12q�6L   $	��180��6^   $
��Left=�6j   �� 56      $��4��6   $��2��6,   $��	Post Date��69   $
��Left=�6M   $��Center=�6h   $��74��6�   �� 57      -
   5        $ txtCreateDate��57   ;   $��5��6   $��1��6.   $��5,36,-225,12q�6R   $
 True��6h   	 J� RenderTransformOrigin$	 0.5,0.5&�6z   $��2��6�   .��6�   z�58      V� 59      .~�5:   "   �� �� 5;   "   �� 5<   "   
 �� Angle$
 -0.076Q�62   T� 5=   "   5>      .��5?   3   5@      �� 5C      $��2��6   $	��Fax��6)   $��Center=�67   $��Center=�6T   $��94��6v   $��0,37,0,0q�6�   $��2��6�   �� 5D      -   5        $ txtFax��5D   ;   $��1��6   $��2��6.   $��	5,37,5,12q�6K   $
 True��6^   $��2��6p   �� 5E      -   5        $ 	txtStatus��5E   ;   $��3��6   $��3��6+   $��5,6,0,6q�6N   $	��180��6_   $
��Left=�6k   �� 5F      $��2��6   $��2��6,   $��Status��69   $��Center=�6J   $��0,37,0,0q�6l   $��2��6~   5H      5I      �� 5K      $��40��6   $ 
Horizontal=�6%   $��Right=�6>   .+�5L      �� -   5        $ SearchTextBox��5L       �� TextWrapping$
 Wrap=�61   $	��182��6E   $��	0,0,270,0q�6R   6e   �� 5M      -   5         ��Name$ 
ButtonSave��5M      
���   �$
��Save��6A   $��35��6Q   $	��110��6]   $��0,0,10,0q�6�   �� 5N      -   5        $ ButtonCancel��5N      
�������
���   �
���iii�$��Cancel��6k   $��0 0 10 0q�6|   $��35��6�   $��80��6�   6�   5P      �� 5Q      $��Center=�6   .+�5T      &   System.Windows.Controls.DataGrid  -   5          Name$ grdUserWant��5T         AutoGenerateColumns$ False��60      CanUserAddRows$ False��5U   <   $	��200��6S   $��10q�6`   $��Stretch=�5V      $	��600��5W      ��5U      �� *
UserWant+   Columns 5Y      0  *System.Windows.Controls.DataGridTextColumn  5Z      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Wanted ID��6-      
Visibility$ Visible=�6k      
IsReadOnly$
 True��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   ��  �� Path$ ProductUserWantId�6�     5[      $ 
Product ID��6-   $ Visible=�6d   $
 True��6y    6A   �� $ 	ProductId�6y     5\      $ Product Name��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6i   $
 True��6w    6C   �� $ Product.Name�6w     5]      $ Description��6-   $
 Auto 6g   $
 True��6u    6B   �� $ Description�6u     5^      $ Price��6-   $
 Auto 6[   $
 True��6i    6<   �� $ Price�6i     5_      $ 
Wanted Qty��6-   $
 Auto 6c   $
 True��6q    6A   �� $ Quantity�6q     5`      $ 	Total Qty��6-   $
 Auto 6j    6@   �� $ Product.Quantity�6j     5a      $ 	Gap Price��6-   $
 Auto 6b   $
 True��6p    6@   �� $ GapPrice�6p     5b      $	 Fax��6-   $
 Auto 6W   $
 True��6e    6:   �� $	 Fax�6e     5c      $
 Note��6-   $
 Auto 6Y   $
 True��6g    6;   �� $
 Note�6g     5d      $ Create Date��6-   $
 Auto 6f   $
 True��6t    6B   �� $ 
CreateDate�6t     5e      $ Currency��6-   $
 Auto 6a   $
 True��6o    6?   �� $ Currency�6o     5f      $ Status��6-   $
 Auto 6]   $
 True��6k    6=   �� $ Status�6k   4  .System.Windows.Controls.DataGridTemplateColumn  5g      $	 120 61      CellTemplate 5h      �� 5i   "   .R�5j   &   �� $ ButtonSelect��6m   -   5        $��Select��5j   -   
����  ����	#FFF3F1F1��6�   �� $ ProductUserWantId�6�   5k   #   5m        5n      $	 120 61    5o      �� 5p   "   .R�5q   &   �� $ ButtonDelete��6j   -   5        $��Delete��5q   -   
���  �����	#FFF3F1F1��6�   �� $ ProductUserWantId�6�   5r   #   5t      5v      5w      5x      5y      5z      