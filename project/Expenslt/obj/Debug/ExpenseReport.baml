   M S B A M L   `   `   `  ����C  ?Expenslt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ExpensltExpenslt  5   	       Expenslt.ExpenseReport   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Expenslt     5   	     � Title$  Expenselt - View Expense��5   	   $	��450��6*   $	��800��67   .��5	      � $��
10,0,10,10q�6   ��5   
   �� 5       �� ImageSource$ watermark.png��6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��1��6    � RowDefinitions 5      �� 5      $��* �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��0��6   $��22(�6!   $��Ariel)�6/   
����  �$
��Bold"�6T   $	��Top=�6f   .��6~   Expense Report For:6�   �� 5      $��1��6   $
��Bold"�6!   $��22(�63   $��
-10,0,10,0q�6A   .��6U   Name:6\   �� 5      $��1��6   $��22(�6?   $
��Bold"�6M   $
��Left=�6_   $��	150,0,0,0q�6z   
���   ���6!   ��  �� Path$
 Name�6�   �� 5      $��2��6   $
��Bold"�6!   $��22(�63   $��-10,0,258,0q�6A   .��6V   Department:6c   �� 5      $��2��6   $��22(�6E   $
��Bold"�6S   $
��Left=�6e   $��	150,0,0,0q�6�   
���   ���6!   �� $ 
Department�6�   � 5!      $��3��6    5"      �� 5#      $
��Auto �6$   �� 5$      $��* �6$    5&      �� 5'      $��* �6'   �� 5(      $��* �6'   .+�5,      �� $��0��6   $��0��6)   $��35��66    �� Padding$ 0q�6B   
���� ��$��Bottom=�6f   ._�5-      �� $��Center=�6   
�������$��16(�6J   $��Center=�6X   .��6u   Expense Type6�   5.      �� 5/      $��1��6   $��0��6)   $��35��66   $ 0q�6B   
���� ��$��Bottom=�6f   ._�50      �� $��Center=�6   
�������$��16(�6J   $��Center=�6X   .��6u   Amount6}   51      &   System.Windows.Controls.DataGrid  52      $��1��6   $��0��6(      AutoGenerateColumns .     RowHeaderWidth$ 0Q�6T   {�.  ��6g   �� $ Expenses�   Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ExpenseType��6.   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6N   �� $ ExpenseType�56        57      $��1��6   $��1��6(    .  $ 0Q�6T   {�.  ��6g   �� $ Expenses� 58        59      $	 Amount��6.   $
 * 6>    6H   �� $ ExpenseAmount�5;      5=      5>      5@      5A      