   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5       UAV!   UAV.UserControls.SurveyList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      -   5        ���#F3F7FA.��5      �� ��. $
��Auto=�68   $
��Auto=�6h   .��5   
   � -   5          �Name$  
LayoutRoot��5       � ColumnDefinitions 5      �� 5	      $��* �6$    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $��* �6    .+�5      �� -   5        $��0��5      $��0��6#   $	��100��63   $��Right=�6B   $��
Add Survey��6z   &   System.Windows.Controls.DataGrid  5      -   5          Name$ dgSurvey��5   @   $��1��5      $��0��6$    %� IsVirtualizing .  %� VirtualizationMode$ Standard=�6c      SelectionMode$ Single=�5         
IsReadOnly .    AutoGenerateColumns .     	GridStyle#���   6o     GridCellStyle	   	CellStyle#	 �  5        
GridHeader
   ColumnHeaderStyle#
 �  6C      HorizontalGridLinesBrush
 �����  RowStyleWithAlternation   RowStyle# �  5         RowHeaderWidth$ 0Q�6L      VerticalGridLinesBrush
 ����    GridLinesVisibility$
 None=�6�      HeadersVisibility$	 All=�5      $	��Top=�5      $��Center=�66      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	  # ��6*      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 69     	TitleCell1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 6i     DynamicColumnLabel   HeaderStyle# [ 5   )      Binding 5   F   ��  �� Path$ 	RowNumber�5        5      -   5        
SurveyName��$ Survey Title��5   >   $
 auto 6V   # [ 6}   # [ 6�    6c   �� *Title+5        5      $
 auto 6*   $ Customer Name��67   # [ 6w   # [ 6�    6Q   �� $ CustomerName�5        5      $
 auto 6*   $ Create Date��68   # [ 6�   # [ 6�    6M   �� *	CreatedOn+ �� StringFormat$ {0:dd-MMM-yyyy}��5        � ContextMenu 5#      �� 5$      -   5        $��
cmstripRow��5$   "   .@�5%      m� -   5        $��ViewMenuItem��5%   #   $
��View��67    m� Icon 5&      �� 5'   "   $��16��6(   $��16��63   $!��../Resource/Images/view.png��6?   5)      5/      51      52      53      54      