   M S B A M L   `   `   `  ����J  FExchange.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Exchange.WpfApp.UIExchange.WpfApp.UI  5   	   "    Exchange.WpfApp.UI.wWishList   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Exchange.WpfApp.UI     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  	wWishList��5   	   $	��676��6   $
��1300��6(   .��5      � $��Center=�6   $
��1300��6(   $	��666��65   $	��Top=�6B    � RowDefinitions 5   
   �� 5      $��0* �6   �� 5      $
��523* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ grdWishList��5         AutoGenerateColumns$ False��6(      CanUserAddRows$ False��6D   $��
38,76,28,0q�6�   $��1��6�   $	��233��6�   $	��Top=�6�   ��6\   �� *OrderDetail+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Order Detail ID��6%      
Visibility$ Visible=�6`      
IsReadOnly$
 True��6u   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6>   �� *OrderDetailId+6u     5      $ having Product ID��6%   $ Visible=�6f   $
 True��6{   	 6@   �� *ProductUserHaveId+6{     5      $ Wanted Product ID��6%   $ Visible=�6f   $
 True��6{   	 6@   �� *ProductUserWantId+6{     5      $ GapPrice��6%   $ Visible=�6T   $
 True��6i   	 67   �� *
GapPrice+6i     5      $ Proposer��6%   $ Visible=�6T   $
 True��6i   	 67   �� *
Proposer+6i     5      $ Discount��6%   $ Visible=�6T   $
 True��6i   	 67   �� *
Discount+6i     5      $ Order Message��6%   $ Visible=�6X   $
 True��6m   	 6<   �� *	Message+6m     5      $ Address��6%   $ Visible=�6R   $
 True��6g   	 66   �� *	Address+6g     5!      $ Order Detail Status��6%   $ Visible=�6]   $
 True��6r   	 6B   �� *Status+6r   4  .System.Windows.Controls.DataGridTemplateColumn  5"      
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 130 6*      CellTemplate 5#      �� 5$      .R�5%      �� -   5        $	��Add��5%   %   
����  �
���������6^   �� *OrderDetailId+6�   5&      5(        5+      $	
 120 6)    5,      �� 5-      .R�5.      �� -   5        $��Delete��5.   %   
���  ��
���������6^   �� *OrderDetailId+6�   5/      51      55        56   
   -   5        $ grdWantOrder��56      $ False��6)   $ False��6E   $��
0,377,39,0q�6�   $��1��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $	��218��6�   $	��Top=�6�   $��Right=�6�   $
��1178��6  ��6\   �� *orderDetailsToOrderMemory+z�57      V� 58      .~�59      �� �� 5:       �� AngleX$ 0.574Q�6$   �� 5;      T� 5<       T� X$
 1.19Q�6)   5=       5?        5@      $ Order Detail ID��6%   $ Visible=�6`   $
 True��6u   	 6>   �� *OrderDetailId+6u     5B      $ having Product ID��6%   $ Visible=�6f   $
 True��6{   	 6@   �� *ProductUserHaveId+6{     5C      $ Wanted Product ID��6%   $ Visible=�6f   $
 True��6{   	 6@   �� *ProductUserWantId+6{     5E      $ GapPrice��6%   $ Visible=�6T   $
 True��6i   	 67   �� *
GapPrice+6i     5F      $ Proposer��6%   $ Visible=�6T   $
 True��6i   	 67   �� *
Proposer+6i     5G      $ Discount��6%   $ Visible=�6T   $
 True��6i   	 67   �� *
Discount+6i     5H      $ Order Message��6%   $ Visible=�6X   $
 True��6m   	 6<   �� *	Message+6m     5I      $ Address��6%   $ Visible=�6R   $
 True��6g   	 66   �� *	Address+6g     5K      $ Order Detail Status��6%   $ Visible=�6]   $
 True��6r   	 6B   �� *Status+6r     5N      $	
 120 6)    5O      �� 5P      .R�5Q      �� -   5        $��Remove��5Q   %   
�������
���������6[   �� *OrderDetailId+6�   5R      5T      5V      �� 5X   
   $��My trade orders i wanted��6   $
��Left=�63   $��
60,333,0,0q�6N   $��20(�6b   $
��Bold"�6p   $	��Top=�6�   $��41��6�   $	��278��6�   $��1��6�   �� 5Y   
   $��My wish list��6   $
��Left=�6'   $��	56,18,0,0q�6B   $��20(�6U   $
��Bold"�6c   $	��Top=�6u   $��34��6�   $	��254��6�   $ 0.479,2.675&�6�   $��1��6�   �� 5Z   
   -   5         ��Name$ SearchTextBox��5Z   J   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Type here to filter...��6   $��500,25,500,0q�6a   $��1��6�   $��27��6�   $	��Top=�6�   �� 5[   
   -   5        
���   �$��Order��5[   $   $
��Left=�64   $��1197,336,0,0q�6O   $��2��6e   $	��Top=�6v   6�   �� 5\   
   -	   5        
���   �$��View My order��5\   $   $
��Left=�6<   $��1147,39,0,0q�6W   $��2��6l   $	��Top=�6}   6�   5^      5_      