   M S B A M L   `   `   `  ����J  FExchange.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Exchange.WpfApp.SmallUIExchange.WpfApp.SmallUI  5   	   /    )Exchange.WpfApp.SmallUI.wOrderInformation   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Exchange.WpfApp.SmallUI     5   	     � Title$  wOrderInformation��5   	   $	��550��6#   $
��1269��60   
�������.��5	      � $	��522��6   $��Bottom=�6   
�������$
��Left=�6F   $
��1269��6a   $��0,0,0,12q�6n    � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��261* �6   �� 5      $	��73* �6   �� 5      $	��89* �6   .+�5   
   �� $��Traded Product��6   $��Center=�6+   $	��706��6H   $	��229��6T   $	��Top=�6a   $��3��6y   $��0,13,0,0q�6�   .��5      � $	��150��6    5      �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$    5       �� 5!      $	��114 �6'   �� 5"      $��66 �6'   �� 5#      $	��103 �6'   �� 5$      $	��197 �6'   �� 5%      $��84 �6'   �� 5&      $��26 �6'   .+�5*      �� $��0��6   $��Code Wanted��6%   $��Center=�6;   $��Center=�6X   $��94��6z   $��0,0,0,37q�6�   $��2��6�   �� 5+      -   5         ��Name$ txtUserHavetId��5+   8   $��1��6   $��0��6+   $��5,0,5,12q�6P    �� 
IsReadOnly$
 True��6b   �� 5,      $��2��6   $��0��6(   $��Product Name��65   $��Center=�6L   $��0,0,0,37q�6n   $��2��6�   �� 5-      -   5        $ txtUserHaveName��5-   7   $��0��6   $��3��6'   $��5,0,0,12q�6P   $	��180��6b   $
��Left=�6n   $
 True��6�   �� 5.      $��4��6   $��0��6(   $��Quantity��65   $
��Left=�6H   $��Center=�6c   $��56��6�   $��0,0,0,37q�6�   $��2��6�   �� 5/      -   5        $ txtUserHaveQuantity��5/   7   $��5��6   $��0��6*   $��
5,0,-98,12q�6T   �� 51      $��1��6   $��	ProductID��6%   $��Center=�69   $��Center=�6V   $��94��6x   �� 52      -   5        $ txtUseHaveProductID��52   7   $��1��6   $��1��6*   $��5,0,5,12q�6T   $
 True��6f   �� 53      $��2��6   $��1��6(   $��Description��65   $��Center=�6K   �� 54      -   5        $ txtUserHaveDescription��54   *   $��3��6   $��5,0,0,12q�6J   $	��180��6\   $
��Left=�6h   $��1��6�   �� 55      $��4��6   $��1��6(   $��	Gap Price��65   $��Center=�6I   $��Center=�6f   $��84��6�   �� 56      -   5        $ txtHaveGapPrice��56   7   $��5��6   $��1��6*   $��
5,0,-98,12q�6P   $
 True��6d   �� 58      $��2��6   $��Currency��6%   $��Center=�68   $��Center=�6U   $��94��6w   �� 59      -   5        $ txtHavecurrency��59   7   $��1��6   $��2��6*   $��5,0,5,12q�6P   $
 True��6b   �� 5:      $��2��6   $��2��6(   $
��Note��65   $��Center=�6D   �� 5;      -   5        $ txtHaveNote��5;   7   $��2��6   $��3��6'   $��5,0,0,12q�6L   $	��180��6^   $
��Left=�6j   �� 5<      $��4��6   $��2��6(   $��	Post Date��65   $
��Left=�6I   $��Center=�6d   $��74��6�   �� 5=      -	   5        $ txtHaveCreateDate��5=   7   $��5��6   $��1��6*   $��5,36,-92,12q�6R   $
 True��6g    J� RenderTransformOrigin$ 0.5,0.5&�6y   $��2��6�   .��6�   z�5>      V� 5?      .~�5@      �� �� 5A      �� 5B       �� Angle$ -0.076Q�6.   T� 5C      5D      .��5E   /   5F      �� 5H      $��2��6   $	��Fax��6%   $��Center=�63   $��Center=�6P   $��94��6r   $��0,37,0,0q�6}   $��2��6�   �� 5I      -
   5        $ 
txtHaveFax��5I   7   $��1��6   $��2��6*   $��	5,37,5,12q�6K   $
 True��6^   $��2��6p   �� 5J      -   5        $ txtCustomerHave��5J   7   $��3��6   $��3��6'   $��5,6,0,6q�6P   $	��180��6a   $
��Left=�6m   �� 5K      $��2��6   $��2��6(   $��	Custommer��65   $��Center=�6I   $��0,37,0,0q�6k   $��2��6}   �� 5L      -   5        $ txtHaveStatus��5L   7   $��5��6   $��2��6*   $��5,37,-92,12q�6N   $
 True��6c   $ 0.5,0.5&�6u   $��2��6�   .��6�   z�5M      V� 5N      .~�5O      �� �� 5P      �� 5Q      $ -0.076Q�6.   T� 5R      5S      .��5T   /   5U      �� 5V      $��4��6   $��2��6(   $��Status��65   $��Center=�6F   $��Center=�6c   $��74��6�   $��0,32,0,5q�6�   $��2��6�   5W      5X      �� 5[   
   $ ��wanted product information��6   $��Center=�67   $	��706��6T   $	��229��6`   $	��Top=�6m   $��0,57,0,0q�6�   $��2��6�   $��2��6�   .��5\      � $	��150��6    5]      �� 5^      $��* �6$   �� 5_      $��* �6$   �� 5`      $��* �6$   �� 5a      $��* �6$    5c      �� 5d      $	��114 �6'   �� 5e      $��66 �6'   �� 5f      $	��103 �6'   �� 5g      $	��197 �6'   �� 5h      $��84 �6'   �� 5i      $��26 �6'   .+�5m      �� $��0��6   $��Code Wanted��6%   $��Center=�6;   $��Center=�6X   $��94��6z   $��0,0,0,37q�6�   $��2��6�   �� 5n      -   5        $ txtUserWanttId��5n   7   $��1��6   $��0��6*   $��5,0,5,12q�6O   $
 True��6a   �� 5o      $��2��6   $��0��6(   $��Product Name��65   $��Center=�6L   $��0,0,0,37q�6n   $��2��6�   �� 5p      -   5        $ txtUserWantName��5p   7   $��0��6   $��3��6'   $��5,0,0,12q�6P   $	��180��6b   $
��Left=�6n   $
 True��6�   �� 5q      $��4��6   $��0��6(   $��Quantity��65   $
��Left=�6H   $��Center=�6c   $��56��6�   $��0,0,0,37q�6�   $��2��6�   �� 5r      -   5        $ txtUserWantQuantity��5r   7   $��5��6   $��0��6*   $��
5,0,-98,12q�6T   �� 5t      $��1��6   $��	ProductID��6%   $��Center=�69   $��Center=�6V   $��94��6x   �� 5u      -   5        $ txtUseWantProductID��5u   7   $��1��6   $��1��6*   $��5,0,5,12q�6T   $
 True��6f   �� 5v      $��2��6   $��1��6(   $��Description��65   $��Center=�6K   �� 5w      -   5        $ txtUserWantDescription��5w   *   $��3��6   $��5,0,0,12q�6J   $	��180��6\   $
��Left=�6h   $��1��6�   �� 5x      $��4��6   $��1��6(   $��	Gap Price��65   $��Center=�6I   $��Center=�6f   $��84��6�   �� 5y      -   5        $ txtWantGapPrice��5y   7   $��5��6   $��1��6*   $��
5,0,-98,12q�6P   $
 True��6d   �� 5{      $��2��6   $��Currency��6%   $��Center=�68   $��Center=�6U   $��94��6w   �� 5|      -   5        $ txtWantCurrency��5|   7   $��1��6   $��2��6*   $��5,0,5,12q�6P   $
 True��6b   �� 5}      $��2��6   $��2��6(   $
��Note��65   $��Center=�6D   �� 5~      -   5        $ txtWantNote��5~   7   $��2��6   $��3��6'   $��5,0,0,12q�6L   $	��180��6^   $
��Left=�6j   �� 5      $��4��6   $��2��6(   $��	Post Date��65   $
��Left=�6I   $��Center=�6d   $��74��6�   �� 5�      -   5        $ txtWantCreateDate��5�   7   $��5��6   $��1��6*   $��5,36,-92,12q�6R   $
 True��6g   $ 0.5,0.5&�6y   $��2��6�   .��6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ -0.076Q�6.   T� 5�      5�      .��5�   /   5�      �� 5�      $��2��6   $	��Fax��6%   $��Center=�63   $��Center=�6P   $��94��6r   $��0,37,0,0q�6}   $��2��6�   �� 5�      -   5        $ 
txtWantFax��5�   7   $��1��6   $��2��6*   $��	5,37,5,12q�6K   $
 True��6^   $��2��6p   �� 5�      -   5        $ txtCustommerWant��5�   7   $��3��6   $��3��6'   $��5,6,0,6q�6Q   $	��180��6b   $
��Left=�6n   �� 5�      $��2��6   $��2��6(   $��	Custommer��65   $��Center=�6I   $��0,37,0,0q�6k   $��2��6}   �� 5�      -   5        $ txtWantedStatus��5�   7   $��5��6   $��2��6*   $��5,37,-92,12q�6P   $
 True��6e   $ 0.5,0.5&�6w   $��2��6�   .��6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ -0.076Q�6.   T� 5�      5�      .��5�   /   5�      �� 5�      $��4��6   $��2��6(   $��Status��65   $��Center=�6F   $��Center=�6c   $��74��6�   $��0,32,0,5q�6�   $��2��6�   5�      5�      �� 5�   
   $��Order information��6   $
��Left=�6.   $	��449��6I   $	��320��6U   $��Center=�6b   $��2��6}   $��1��6�   $��1��6�   $��2��6�   .��5�      � $	��378��6   $	��Top=�6     5�      �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   $��25��62   �� 5�      $
��Auto �6$   $��0��62    5�      �� 5�      $	��43* �6'   �� 5�      $
��173* �6'   �� 5�      $��8* �6'   �� 5�      $
��208* �6'   .+�5�      �� $��OrderID��6   $
��Left=�6*   $��Center=�6E   $��10,0,0,0q�6`   $��2��6r   $��24��6�   $��50��6�   �� 5�      -   5        $ 
txtOrderID��5�   .   $
 True��6   $
��Left=�6B   $��Center=�6]   $	��120��6x   $��3��6�   $��2,0,0,0q�6�   $��25��6�   �� 5�      $��Ordered Date��6   $
��Left=�6/   $��Center=�6J   $��1��6e   $��10,0,0,0q�6r   $��2��6�   $��24��6�   $��80��6�   �� 5�      -   5        $ txtOrderedDate��5�      $
 True��63   $
��Left=�6F   $��Center=�6a   $	��149��6|   $��1��6�   $��3��6�   $��2,0,0,0q�6�   $��25��6�   �� 5�      $��Complete Date��6   $
��Left=�60   $��Center=�6K   $��2��6f   $��10,0,0,0q�6s   $��2��6�   $��24��6�   $��88��6�   �� 5�      -   5        $ txtCompleteDate��5�      $
��Left=�63   $
 True��6O   $��Center=�6b   $	��149��6}   $��2��6�   $��3��6�   $��2,0,0,0q�6�   $��25��6�   �� 5�      $��
Order Type��6   $
��Left=�6-   $��Center=�6H   $��3��6c   $��10,0,0,0q�6p   $��2��6�   $��24��6�   $��67��6�   �� 5�      -   5        $ txtOrderType��5�      $
��Left=�60   $��Center=�6K   $
 True��6g   $	��120��6z   $��3��6�   $��3��6�   $��2,0,0,0q�6�   $��25��6�   �� 5�      $
��Note��6   $
��Left=�6'   $��Center=�6B   $��4��6]   $��10,0,0,0q�6j   $��2��6|   $��24��6�   $��34��6�   �� 5�      -   5        $ txtOrderNote��5�      $
��Left=�60   $��Center=�6K   $	��120��6f   $
 True��6s   $��4��6�   $��3��6�   $��2,0,0,0q�6�   $��25��6�   �� 5�      $��Description��6   $
��Left=�6.   $��Center=�6I   $��5��6d   $��10,0,0,0q�6q   $��2��6�   $��24��6�   $��68��6�   �� 5�      -   5        $ txtOrderDes��5�      $
��Left=�6/   $��Center=�6J   $	��120��6e   $
 True��6r   $��5��6�   $��3��6�   $��2,0,0,0q�6�   $��25��6�   �� 5�      $��Order detail ID��6   $
��Left=�62   $��Center=�6M   $��6��6h   $��10,0,0,0q�6u   $��2��6�   $��24��6�   $��86��6�   �� 5�      -   5        $ txtOrderDetailID��5�      $
��Left=�64   $��Center=�6O   $	��120��6j   $��6��6v   $
 True��6�   $��3��6�   $��2,0,0,0q�6�   $��25��6�   �� 5�      $��Message��6   $
��Left=�6*   $��Center=�6E   $��7��6`   $��10,0,0,0q�6m   $��2��6   $��24��6�   $��55��6�   �� 5�      -    5        $ 
txtMessage��5�      $
��Left=�6.   $��Center=�6I   $	��135��6d   $��7��6p   $��3��6}   $
 True��6�   $��2,0,0,0q�6�   $��25��6�   �� 5�      $��Address��6   $
��Left=�6*   $��Center=�6E   $��8��6`   $��10,0,0,0q�6m   $��2��6   $��24��6�   $��51��6�   �� 5�      -!   5        $ 
txtAddress��5�      $
��Left=�6.   $��Center=�6I   $	��120��6d   $��8��6p   $��3��6}   $��2,0,0,0q�6�   $
 True��6�   $��25��6�   �� 5�      $��Status��6   $
��Left=�6)   $��Center=�6D   $��9��6_   $��10,0,0,0q�6l   $��2��6~   $��24��6�   $��40��6�   �� 5�      -"   5        $ txtOrderdetailStatus��5�      $
��Left=�68   $��Center=�6S   $	��120��6n   $��9��6z   $��3��6�   $��2,0,0,0q�6�   $
 True��6�   $��25��6�   5�      5�      5�      5�      