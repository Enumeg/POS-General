   M S B A M L   `   `   `  ����A  =Source, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/$clr-namespace:Source;assembly=SourceSource  5   	    POS   
POS.Income   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6^   3cc$clr-namespace:Source;assembly=Source     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42ex)http://schemas.xceed.com/wpf/xaml/toolkit  69   $��RightToLeft=�6n      Page_Background  N� 
Background#  [  5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��* �6   .+�5	   
   � $��Center=�6    � ColumnDefinitions 5
      �� 5      $
��Auto �6#   �� 5      $	��120 �6#   �� 5      $��15 �6#   �� 5      $
��Auto �6#   �� 5      $	��120 �6#   .+�5      �� $��0��6     Label_TextBlock#��[ 6(   $��مـن :��6Q   �� 5      $��3��6   #��[ 6(   $��إلى :��6Q   &   Xceed.Wpf.Toolkit.DateTimePicker  5      -   5        $��From_DTP��5   �   $��1��6      Edit_DateTimePicker#��[ 60   6�     5      -   5        $��To_DTP��5   �   $��4��6    #��[ 60   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��	Income_DG��5   G   $��1��6     View_DataGrid#��[ 6       Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6%      Header$ 
الرقم��6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   ��  �� Path$ trs_no�6R     5      $
 Auto 6%   $ التاريخ��6m    62   �� $ trs_date� �� StringFormat$ 
yyyy/MM/dd��6m     5      $
 Auto 6%   $ 
الشخص��6T   	   
FontFamily$	 Droid Arabic Naskh)�6c    62   �� $ per_naem�6c     5      $
 Auto 6%   $ المدفوع��6T    62   �� $ trs_paid�6T     5      $
 Auto 6%   $ نوع العملية��6T   $	 Droid Arabic Naskh)�6i    62   �� $ trn_name�6i   5      5      5       