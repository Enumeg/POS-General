   M S B A M L   `   `   `  ����  POS    POS.Add_Update_Attendence   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42ex)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   $	��350��5   	     � WindowStartupLocation$  CenterScreen=�6      Default_Window#��[  5   	   .��5      �  � ColumnDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6    � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   .+�5   
   �� $��0��6   $��0��6$     Label_TextBlock#��[ 61   $��المــوظـــف :��6Z   �� 5   
   $��0��6   $��1��6$   #��[ 61   $&�� التــــاريــــخ :��6Z   �� 5   
   $��0��6   $��2��6$   #��[ 61   $��الحضـــــور :��6Z   �� 5   
   $��0��6   $��3��6$   #��[ 61   $��الإنصراف :��6Z   �� 5   
   -   5        $��Employees_CB��5   X   $��1��6   $��0��6#     Edit_ComboBox#��[ 60   6X   &   Xceed.Wpf.Toolkit.DateTimePicker  5   
   -   5        $��Date_DTP��5   g   $��1��6   $��1��6,     Edit_DateTimePicker#��[ 69   6g   "  Xceed.Wpf.Toolkit.TimePicker  5   
   -   5        $��
Attend_DTP��5   w   $��1��6   $��2��6(      FormatString$ hh:mm tt��65     Edit_TimePicker#��[ 6M   6w     5   
   -   5        $��	Leave_DTP��5   w   $��1��6   $��3��6(   $ hh:mm tt��65   #��[ 6M   6w   �� 5   
   -   5        $	��New��5   e   $��0��6   $��4��6#     New_CheckBox#��[ 60   $��جديد��6V   6e   �� 5   
   -   5        $��1��5      $��4��6!   $��حفظ��6.   6<   5      5      