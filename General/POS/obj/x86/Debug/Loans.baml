   M S B A M L   `   `   `  ����A  =Source, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/$clr-namespace:Source;assembly=SourceSource  5   	    POS   	POS.Loans   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6]   3cc$clr-namespace:Source;assembly=Source     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42ex)http://schemas.xceed.com/wpf/xaml/toolkit  69     N� Title$  الحسابات��6n   $��RightToLeft=�6      Page_Background N� 
Background# [  5   	    N� 
FontFamily$ Arial)�67    N� FontSize$ 18(�6J   .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��* �6   .+�5	   
   � $��Center=�6    � ColumnDefinitions 5
      �� 5      $
��Auto �6#   �� 5      $	��120 �6#   �� 5      $��15 �6#   �� 5      $
��Auto �6#   �� 5      $	��120 �6#   .+�5      �� $��0��6     Label_TextBlock#��[ 6(   $��مـن :��6Q   �� 5      $��3��6   #��[ 6(   $��إلى :��6Q   &   Xceed.Wpf.Toolkit.DateTimePicker  5      -   5        $��From_DTP��5   �   $��1��6      Edit_DateTimePicker#��[ 60   6�     5      -   5        $��To_DTP��5   �   $��4��6    #��[ 60   6�   5      � 5   
   $��1��6    5      �� 5      $��* �6#   �� 5      $��2 �6#   �� 5      $��* �6#    5      �� 5      $��30 �6    �� 5      $��* �6    �� 5      $��35 �6    .+�5!      �� $��0��6   $��0,2,0,0q�6$   $��أقساط العملاء��6>   �� 5"      $��2��6   $��0,2,0,0q�6$   $#��أقساط المورديين��6>   &   System.Windows.Controls.DataGrid  5#      -   5        $��	Income_DG��5#   [   $��0��6   $��1��6'     View_DataGrid#��[ 64      Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6)      Header$ 
الرقم��6V   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   �� 
 �� Path$
 trs_no�6V     5&      $
 Auto 6)   $ التاريخ��6p   	 66   �� $
 trs_date� �� StringFormat$ 
yyyy/MM/dd��6p     5'      $
 Auto 6)   $ العميل��6X      
FontFamily$ Droid Arabic Naskh)�6h   	 66   �� $
 per_name�6h     5(      $
 Auto 6)   $ المدفوع��6X   	 66   �� $
 trs_paid�6X   5*        5+      -   5        $��
Outcome_DG��5+   [   $��2��6   $��1��6'   #��[ 64    5,        5-      $
 Auto 6)   $ 
الرقم��6V   	 66   �� $
 trs_no�6V     5.      $
 Auto 6)   $ التاريخ��6p   	 66   �� $
 trs_date�$ 
yyyy/MM/dd��6p     5/      $
 Auto 6)   $ المورد��6X   $ Droid Arabic Naskh)�6h   	 66   �� $
 per_name�6h     50      $
 Auto 6)   $ المدفوع��6X   	 66   �� $
 trs_paid�6X   52         Source.EditPanel  53      -   5        $��	Income_EP��53   8   $��0��6   $��2��6+   6s     54      -   5        $��
Outcome_EP��54   8   $��2��6   $��2��6+   6v   �� 55      $��1��6   $��3��6%   $	��1,0q�66    
 Border#��[ 6L   56      57      58      