   M S B A M L   `   `   `  ����I  EStudentGestion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:StudentGestion.ViewStudentGestion.View  5   	   %    StudentGestion.View.AverageView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:StudentGestion.View     5   	     � Title$  AverageView��5   	   $	��450��6   $	��800��6*    � DataContext 66   �� *	Average+   Locator �� Source# [  .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��Nom et Prenom��6   $��0��6,   �� 5      $��1��6   $��Center=�6'   $��20,0,0,0q�6B   .��6T   ��5      `� 5       �� StringFormat$ {0} {1}��6+   .1�5   "   ��  �� Path$ 	FirstName�6+   �� 5   "   $ LastName�6*   5      .��5      5      5      � 5   
   $��1��6    5      �� 5       $
��Auto �6#   .+�5"   
   �� ��6   �� *sheets+��5#      �� 5$      .R�5%      ��  �� Orientation$ 
Horizontal=�6!   .+�5&      �� ��6!   �� *
ModuleName+�� 5'      ��6    �� *Note+5(      5)      5+      5,      � 5-   
   $��2��6    5.      �� 5/      $
��Auto �6#   �� 50      $
��Auto �6#   .+�52      �� $��Moyenne��6   $��0��6&   �� 53      $��1��62   $��Center=�6B   $��20,0,0,0q�6]   ��6   �� *	Average+6]   54      55      56      