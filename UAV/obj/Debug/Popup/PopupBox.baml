   M S B A M L   `   `   `  ����  UAV    UAV.PopupBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�6@    � 
ResizeMode$ NoResize=�6e   $	��500��5   	    � ShowInTaskbar .  $	��150��6+    � Topmost . $
��Auto=�6G    � AllowsTransparency .  � WindowStyle$
 None=�6�   $��Microsoft Sans Serif)�6�   $��11 pt(�6�   .��5      �� $��0��6   $��1��6    �� CornerRadius$ 5��6+   $��1q�6<   
�������
������� J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 2Q�6   	   
BlurRadius$	 7Q�6/   
   Color$
 Black��6>      	Direction$	 270Q�6L      Opacity$	 0.5Q�6\   ._�5	   
   � $
��auto��6    � ColumnDefinitions 5
      �� 5      $��80 �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� -   5        $��imgIcon��5   I   $��0��6   $��1��6%   $��60��62   $��60��6>   $��5q�6X   6e   �� 5      -   5        $��txtTitle��5   5   $��0��6   $��0��6(   $��3��6E    �� TextAlignment$
 Left=�6Y      MainHeaderTextBlockStyle#���   6o   $��0,0,0,1q�6�   6�   �� 5      -   5        $��
txtMessage��5   U   $��WrapWithOverflow=�6   $��1��68   $��1��6H   $��5q�6g   $��52��6r     HeaderTextBlockStyle#���  6~   $��2��6�   6�   �� 5      -   5        $
��btns��5      $��0��6%   $��2��65   $��2��6B   $��Center=�6V    �� Orientation$ 
Horizontal=�6s   .+�5      �� -   5        $��btnOk��5      $��80��6&   $��Ok��61   
 � Tag$ ok��6>   $y�	Collapsed=�6Y   6s   �� 5      -   5        $��	btnCancel��5      $��80��6*   $y�	Collapsed=�65   $��Cancel��6L   $ cancel��6]   6�   �� 5      -   5        $��btnYes��5      $��80��6*   $y�	Collapsed=�65   $	��Yes��6L   $	 yes��6Z   6y   �� 5      -   5        $��btnNo��5      $��80��6*   $y�	Collapsed=�65   $��No��6L   $ no��6Y   6w   �� 5      -	   5        $��btnNone��5      $��80��6*   $y�	Collapsed=�65   $
��None��6L   $
 none��6[   6|   5      5      5      5      