   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    UAV   UAV.Controls.Login   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5        $��Arial)�5   
   $��12 pt(�6   (   "MahApps.Metro.Controls.MetroWindow    	GlowBrush
  �   � � Icon$&  /Resource/Images/taskbarlogo.ico��6A      WindowTitleBrush �#F3F7FA���#F3F7FA � WindowState$ 	Maximized=�5   A   .��5	      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��1��6   $��1��6!   $	��300��6.   $	��100��6:   $y�Visible=�6G   $%��/Resource/Images/headerlogo.png��6\   �� 5   
   $��1��6   $��3��6"    �� CornerRadius$ 2��6/   $��1q�6@   
������ ���#FDFDFD$��10q�6�    �� Padding$ 10q�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   ShadowDepth$	 2Q�6#   
   
BlurRadius$
 7Q�63      Color$ Black��6B      	Direction$	 270Q�6P      Opacity$	 0.5Q�6`   ._�5      �  5      �� 5      $��* �6'    5!      �� 5"      $��40 �6$   �� 5#      $
��auto �6$   �� 5$      $
��auto �6$   �� 5%      $
��auto �6$   �� 5&      $
��auto �6$   �� 5'      $
��auto �6$   �� 5(      $
��auto �6$   �� 5)      $
��auto �6$   �� 5*      $
��auto �6$   �� 5+      $
��auto �6$   �� 5,      $
��auto �6$   �� 5-      $
��auto �6$   �� 5.      $��30 �6$   .+�51      �� $��0��6   $��0��6-   $��Login��6:      MainHeaderTextBlockStyle#���   6I   6   �� 53      $��0��6   $��1��6,     HeaderTextBlockStyle#���  69   	User name�� 6s   $
��Left=�6}   $��Center=�6�   
���  ��*6�   6�   �� 54      -   5        $��txtEmail��54   w   $��0��6   $��2��6*   $��30��67   $��Center=�6D    �� 	MaxLength$ 60��6f   6w   �� 55      $��0��6   $��3��6,   #���  6:   
Password�� 6s   $
��Left=�6}   $��Center=�6�   
���  ��*6�   6�   G� 56      -   5        $��txtPin��56   �   $��0��6   $��4��6.   $��30��6;   $��2��6G   $��Center=�6\    G� 	MaxLength$ 50��6~   $	��320��6�    � UseLayoutRounding .  G� Password$  ��6�   �� 57      -   5        $��lblMsg��57   5   $��0��6   $��5��6(     ErrorMsg#���  6C   �� 58      -   5        $��btnEnterAdmin��58   6   $��6��6   $��0��6&   $��Center=�6L   $��Sign In��6i    �� 	IsDefault . $��10q�59      $��5q�6&   $	��300��62   $��2��6Z   6p   �� 5;      -   5        $��btnCreateAccount��5;   )   $��1��6   $��7��6A   $��Right=�6O   $��Create an account��6k   $��10q�6�   $��5q�6�   5<      �� 5=      -   5        $��btnforgotpwd��5=   )   $��0��6   $��7��6=   $
��Left=�6L   $��Forgot Password?��6h   $��10q�6�   $��5q�6�   5>      5?      5@      5A      5B      