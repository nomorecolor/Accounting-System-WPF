   M S B A M L   `   `   `  ����O  KAccountingProjectWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:AccountingProjectWPFAccountingProjectWPF  5   	   %    AccountingProjectWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:AccountingProjectWPF     5   	   -   5        $��HomePage��5   	     � Title$  
MainWindow��5	   	   $	��500��6   $	��600��6)    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�6Z   .��5
      � $��10,10,10,10q�6    � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $
��8.5* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��0��6   $	��100��6"   61   �� 5      -   5        $��	BtnIncome��5      $��1��6&   
 � Tag$ Income��63   $��0,5,20,5q�6@   
���   �$��0q�6g   
�������.��5      �� $��Income��6   6,   5      �� 5      -   5        $��
BtnExpense��5      $��2��6'   $ Expense��64   $��0,5,20,5q�6B   
���   �$��0q�6i   
�������.��5      �� $��Expense��6   6-   5      �� 5       -   5        $��	BtnReport��5       $��3��6&   $��0,5,20,5q�63   
���   �$��0q�6Z   
�������.��5!      �� $��Reports��6   6-   5"      �� 5#      -   5        $��BtnExit��5#      $��4��6$   $��0,5,20,5q�62   
���   �$��0q�6Y   
�������.��5$      �� $
��Exit��6   6*   5%      5&      � 5(   
   -   5        $��	stackMain��5(      $��1��6   $��0,0,0,5q�60    5)      �� 5*      $
��Auto �6    �� 5+      $��8* �6    �� 5,      $
��Auto �6    .+�5.      �� -   5        $��	cmbMonths��5.   $   $��0��6   $
��Left=�65   � 50      $��2��6    51      �� 52      $��7* �6'   �� 53      $��3* �6'   .+�56      �� -   5        $��txtEntry��56   *   $��0��6   $��0,2,5,0q�6:   �� 57      -	   5        $��	txtAmount��57   *   $��1��6   $��0,2,0,0q�6;   58      59      5:      5;      