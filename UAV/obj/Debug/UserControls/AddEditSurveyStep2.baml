   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      d `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF 5       UAV)   #UAV.UserControls.AddEditSurveyStep2   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      bmapRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5      -   5        .��5	      �� ��. $
��Auto=�68   $
��Auto=�6h   .��5
   
   �   � ColumnDefinitions  5      �� 5      $	��200 �6#   �� 5      $	��250 �6#   �� 5      $��10 �6#   �� 5      $	��200 �6#   �� 5      $	��250 �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��15 �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $��10 �6    �� 5      $
��auto �6    �� 5      $��10 �6    �� 5       $
��auto �6    �� 5!      $��* �6    .+�5#      � $��1��6   $��0��6    $��6��60   .+�5$      �� $��20(�6   $
��Left=�6+   $
��Left=�6A   Create Survey6l   �� 5%      $��20(�6   $��Center=�6*   Step 2: Basic Details6_   �� 5&      -   5        $	��100��5&      $��Right=�6%   $��Right=�6<   $��Survey List��6u   5'      �� 5(      $��1��6   $��0��6!   $
��Bold"�61   $
��Left=�6D   5+      �� 5,      $��1��6   $��1��6!   $
��Bold"�61   $��4��6C   $��Center=�6X   5.      �� 50      $��3��6   $��0��6"   $��6��62   $	��1px��6F    �� Stretch$
 Fill=�6\   
�������	 �� X2$ 1��6y   �� 52      $��4��6   $��0��6%   $��Survey title��65   $��8q�6I   6V   �� 53      -   5        $��txtTitle��53   r   $��4��6   $��1��6$   $	��200��64   $��25��6@   $��8q�6L   $
��Left=�6W   6�   �� 55      $��4��6   $��3��6'   $��8q�67   $
��Site��6B   6P   �� 56      -   5         ��Name$ cmbSites��56   �   $��4��6   $��4��6&   $��8q�67   $	��200��6B   $��30��6N   $
��Left=�6Z   6�   �� 58      $��5��6   $��0��6%   $��8q�65   $��Customer��6@   6S   �� 59      -   5        $ cmbCustomers��59   W   $��5��6   $��1��6$   $��8q�64   $	��200��6?   $��30��6K   $
��Left=�6m   6�   �� 5;      $��6��6   $��0��6&   $��8q�66   $
��Date��6A   6P   (  "System.Windows.Controls.DatePicker  5=      -   5        $��txtDate��5=   A   $��6��6   $��1��6&   $��8q�66   $	��200��6P   $��25��6\   $
��Left=�6h   {�.    DisplayDateStart$ 1/1/2010X�6�    � 	Resources 5>      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property	 �� Value��%�   '        �� 5?      "  6   .�5@      ��  �@��
IsReadOnly	 . 67   �� 5A       � ��$	 Center=�6>   5C      5D      5E      �� 5F      $��7��6   $��0��6'   $��8q�67   $
��Time��6B   6R   �� 5G      -   5        $��txtTime��5G   A   $��7��6   $��1��6&   $��8q�66   $	��200��6P   $��25��6\   $
��Left=�6h   6�   � 5I      $��5��6   $��3��6    $��5��60   $��2��6A   $	��300��6U   .+�5J      '  !Microsoft.Maps.MapControl.WPF.Map  -   5        $��CustomerSiteMap��5J   �   +  %Microsoft.Maps.MapControl.WPF.MapCore
   CredentialsProviderT  NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$r
 l2la58yVQb81cKW4Qi0QT~QaDGpQQrcR4_XWGRACtl-Q~AhUsJEBtNJlbU1Y9b8jCgQaterD1Xhp5gksn3d4UFk3ZEKcxcyUjMjyi3khI-Y5i 6   6�   5K      �� 5M      -	   5        $��11��5M      $��4��6%   $��8q�65   $
��Next��6@   $	��150��6P   $��Center=�6\   6�   5O      5P      5Q      