   M S B A M L   `   `   `  ����A  =Source, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/$clr-namespace:Source;assembly=SourceSource  5   >    POS   POS.Products   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6`   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42ex)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -cc$clr-namespace:Source;assembly=Source  6>   :d2http://schemas.microsoft.com/expression/blend/2008  5   H   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   $��RightToLeft=�5   n      Page_Background  N� 
Background#  [  5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   $��35��6*   �� 5      $��* �6   �� 5	      $��35 �6   .+�5   
   � -   5        $��Properties_WP��5      $��2��6)   .+�5      � -   5        $��	Search_DG��5      $	��0,3q�6$    � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $	��120 �6'   �� 5      $
��Auto �6'   �� 5      $	��120 �6'   �� 5      $
��Auto �6'   �� 5      $	��120 �6'   .+�5      �� $��0��6     Label_TextBlock#��[ 6,   $��الصنف :��6U   �� 5      $��2��6   #��[ 6,   $��السريال :��6U   �� 5      $��4��6   #��[ 6,   $��الفئة :��6U   �� 5      -   5        $��
Product_TB��5   t   $��1��6     Search_TextBox#��[ 6*   6t   �� 5      -   5        $��	Serial_TB��5   t   $��3��6   #��[ 6*   6t   �� 5      -   5        $��Categories_CB��5   �   $��5��6     Search_ComboBox#��[ 6+   6�   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��Products_DG��5   G   $��1��6     View_DataGrid#��[ 6       
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6%      Header$ 
الفئة��6T      
FontFamily$ Droid Arabic Naskh)�6c   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� 	 �� Path$	 cat_name�6c     5       $
 Auto 6%   $ السريال��6V    62   �� $	 
pro_serial�6V     5!      $
 100* 6%   $ الصنف ��6T   $ Droid Arabic Naskh)�6d    62   �� $	 pro_name�6d     5"      $
 Auto 6%   $ سعر البيع��6T    62   �� $	 pro_sell�6T     5#      $
 Auto 6%   $ حد الشراء��6U    62   �� $	 	pro_limit�6U     5$      $
 Auto 6%   $ الرصيد��6V    62   �� $	 
pro_amount�6V   
   RowStyle
 5&      �� 5'       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    �� Triggers 5(      �� 5)       �� Binding 6&   �� *
pro_status+ �� Value 06E   .a�5*      ��  �� Property � �� �� Value
 � ���6;   5+      �� 5,       6&   �� *
pro_status+ 16E   .a�5-      ��  � ��
 � � �6;   �� 5.       � ��
 �����6;   5/      �� 50       6&   �� *
pro_status+ -16E   .a�51      ��  � ��
 �  ��6;   �� 52       � ��
 �����6;   53      55      57      � 58   
   $��2��6    59      �� 5:      $��3* �6#   �� 5;      $��* �6#   �� 5<      $��* �6#   �� 5=      $��* �6#   .+�5?         Source.EditPanel  -   5        5?   E   �� 5@      -   5        $��1��5@        Panel_Button#��[ 6%   $��الفئات��6K   
 � Tag$% /POS;component/Images/Theme.ico��6s   �� 5A      -	   5        $��2��5A      #��[ 6%   $��الصفات��6K   $' !/POS;component/Images/catalog.ico��6s   �� 5B      -
   5        $��3��5B      #��[ 6%   $��الطباعة��6K   $' !/POS;component/Images/catalog.ico��6t   5C      5D      5E      