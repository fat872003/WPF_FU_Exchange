   M S B A M L   `   `   `  ����J  FExchange.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Exchange.WpfApp.CustomUserControl!Exchange.WpfApp.CustomUserControl  5      4    .Exchange.WpfApp.CustomUserControl.ControlBarUC   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Exchange.WpfApp.CustomUserControl     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $��ucControlBar��5      .  (System.Windows.Interactivity.Interaction    Triggers  5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ MouseLeftButtonDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 5      �� *MouseMoveWindowCommand+   CommandParameter 5      ��  �� ElementName$ ucControlBar��5      .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ Inverted=�6#   .��5      ]� .+�5      �� $��Right=�6   
������  �� Orientation$ 
Horizontal=�6M    � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%�   '��       �� 5      "	 ��6    .�5      �� 
 � ��$ 2 4 2 4q�67   6I   �� 5      
 � ��$ 40��66   6C   5      5      .+�5       ��  � ToolTip$ Đóng��5"       c� OverflowMode$ AsNeeded=�6-   
������ 
���������5       �� *MinimizeWindowCommand+��5!      �� $ ucControlBar��.��5%      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�62    5&      ��%^   '��       �� 5'      "	 ��6$   .�5(   "   �� 
 �@��CornerRadius$ 3��6A   5)      5*      5+      �� 5,      $ Đóng��5.      $ AsNeeded=�6-   
������ 
���������5,      �� *MaximizeWindowCommand+��5-      �� $ ucControlBar��.��51        $ WindowMaximize=�62    52      ��%^   '��       �� 53      "	 ��6$   .�54   "   �� 
 �@��CornerRadius$ 3��6A   55      56      57      �� 5:      $ Đóng��5<      $ AsNeeded=�6-   
������ 
���������5:      �� *CloseWindowCommand+��5;      �� $ ucControlBar��.��5?        $ WindowClose=�62    5@      ��%^   '��       �� 5A      "	 ��6$   .�5B   "   �� 
 �@��CornerRadius$ 3��6A   5C      5D      5E      5F      �� 5H      $
��Left=�6   $ 
Horizontal=�63   .+�5I      d�  '  #MaterialDesignHamburgerToggleButton#���   6#   �� 5J      $��Center=�6    $��16 0 0 0q�6;   ��5K       �� *Tag+$ ucControlBar��5L      5M      5N      5O      5P      5Q      