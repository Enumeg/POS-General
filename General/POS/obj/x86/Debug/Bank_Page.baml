   M S B A M L   `   `   `  ����A  =Source, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/$clr-namespace:Source;assembly=SourceSource  5   	    POS   POS.Bank_Page   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6a   3cc$clr-namespace:Source;assembly=Source     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42ex)http://schemas.xceed.com/wpf/xaml/toolkit  69     N� Title$  حسابات البنك��6n   $��RightToLeft=�6�      Page_Background N� 
Background# [  5   	    N� 
FontFamily$ Droid Arabic Naskh)�67    N� FontSize$ 16(�6W   .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��* �6   �� 5      $��35 �6   .+�5
   
   �� 
�������$��0,0,0,2q�6%   ._�5      � $��Center=�6    � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $	��120 �6'   �� 5      $��15 �6'   �� 5      $
��Auto �6'   �� 5      $	��120 �6'   .+�5      �� $��0��6     Label_TextBlock#��[ 6,   $��مـن :��6U   �� 5      $��3��6   #��[ 6,   $��إلى :��6U   &   Xceed.Wpf.Toolkit.DateTimePicker  5      -   5        $��From_DTP��5   �   $��1��6$     Edit_DateTimePicker#��[ 64   6�     5      -   5        $��To_DTP��5   �   $��4��6$   #��[ 64   6�   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��Bank_DG��5   G   $��1��6     View_DataGrid#��[ 6    $��Tahoma)�6V      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ 	Collapsed=�6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� 	 �� Path$	 id�  5      
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6%      
IsReadOnly .    Header$ التاريخ��6D    6U   �� $	 bnk_date� �� StringFormat$ 
yyyy/MM/dd��  5      $

 Auto 6%    . $ 
إيداع��6D    6S   �� $	 value1�  5      $

 Auto 6%    . $ سحب��6D    6Q   �� $	 value2�  5      $

 Auto 6%    . $ البيان��6D      
FontFamily$ Droid Arabic Naskh)�6}    6T   �� $	 bnk_description�6}   5!         Source.EditPanel  5"   
   -   5        $��Bank_EP��5"   $   $��2��6   6Y   5#      5$      