   M S B A M L   `   `   `  ����G  CRomanProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RomanProject.ViewRomanProject.View  5      (    "RomanProject.View.UsersListControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:RomanProject.View     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid     
IsReadOnly . $��0��6y   $��2��6�      AutoGenerateColumns .     CanUserSortColumns .  ��. $	��200��6!   �� SelectedItem 6   �� *
Selected+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *Users+$ OneWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   �� *Name+6N     5      $	 Surname��6%   
 66   �� *	Surname+6T     5      $	 E-mail��6%   
 65   �� *EMail+6Q     5      $	 Birthday Date��6%   
 6<   �� *BirthdayDate+6_     5      $	 Adult��6%   
 64   �� *	IsAdult+6R     5      $	 Sun Sign��6%   
 67   �� *	SunSign+6U     5      $	 Chinease Sign��6%   
 6<   �� *ChineaseSign+6_     5      $	 Birthday Today��6%   
 6=   �� *
IsBirthday+6^   5      � 5    
   $��1��6   $��0��6     5!      �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    �� 5&      $
��Auto �6    �� 5'      $
��Auto �6    �� 5(      $
��Auto �6    �� 5)      $
��Auto �6    �� 5*      $
��Auto �6     5,      �� 5-      $��* �6"   6.   �� 5.      $��* �6#   6/   .+�50      �� $��0��6   $��0��6!   $
��Left=�62   $
��Name��6N   �� 51      $��1��6   $��0��6#   $��5,5,5,5q�63   $��25��6D   ��6P   �� *
NameFilter+$ OneWayToSource=�$ PropertyChanged=�6�   �� 52      $��2��6   $��0��6!   $
��Left=�62   $��Surname��6N   �� 53      $��3��6   $��0��6#   $��5,5,5,5q�63   $��25��6D   ��6P   �� *SurnameFilter+$ OneWayToSource=�$ PropertyChanged=�6�   �� 54      $��4��6   $��0��6!   $
��Left=�62   $��E-mail��6N   �� 55      $��5��6   $��0��6#   $��5,5,5,5q�63   $��25��6D   ��6P   �� *EMailFilter+$ OneWayToSource=�$ PropertyChanged=�6�   �� 56      $��6��6   $��0��6!   $
��Left=�62   $��Birthday date��6N   (  "System.Windows.Controls.DatePicker  57      $��7��6   $��0��6&   $��5,5,5,5q�66      SelectedDate 6H   �� *DateTimeFilter+$ OneWayToSource=�$ PropertyChanged=��� 59      $��0��6   $��1��6!   $
��Left=�62   $��Is Adult��6N   �� 5:      $��1��6   $��1��6#   $��5,5,5,5q�63   $��25��6D   ��6P   �� *IsAdultFilter+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5;      $��2��6   $��1��6!   $
��Left=�62   $��Sun Sign��6N   �� 5<      $��3��6   $��1��6#   $��5,5,5,5q�63   $��25��6D   ��6P   �� *SunSignFilter+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5=      $��4��6   $��1��6!   $
��Left=�62   $��Chinease Sign��6N   �� 5>      $��5��6   $��1��6#   $��5,5,5,5q�63   $��25��6D   ��6P   �� *ChineaseSignFilter+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5?      $��6��6   $��1��6!   $
��Left=�62   $��Birthday today��6N   �� 5@      $��7��6   $��1��6#   $��5,5,5,5q�63   $��25��6D   ��6P   �� *IsBirthdayTodayFilter+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5A      $��2��6   $��8��6)   $��Filter��66   $��5,5,5,5q�6G   ��6X   �� *FilterCommand+6|   5B      � 5C   
   $��1��6   $��1��6     5D      �� 5E      $
��Auto �6    �� 5F      $
��Auto �6    �� 5G      $
��Auto �6    �� 5H      $
��Auto �6    �� 5I      $
��Auto �6    �� 5J      $
��Auto �6    �� 5K      $
��Auto �6     5M      �� 5N      $��* �6#   �� 5O      $��* �6#   .+�5Q      	� $��0��6s   $��0��6�   $��5,30,5,5q�6�   $��By Name��6�    d� 	IsChecked 6   �� *
NameSort+$ OneWayToSource=�$ PropertyChanged=�6�   	� 5R      $��0��6v   $��1��6�   $��5,5,5,5q�6�   $��
By Surname��6�    6   �� *SurnameSort+$ OneWayToSource=�$ PropertyChanged=�6�   	� 5S      $��0��6t   $��2��6�   $��5,5,5,5q�6�   $��	By e-mail��6�    6   �� *	EMailSort+$ OneWayToSource=�$ PropertyChanged=�6�   	� 5T      $��0��6{   $��3��6�   $��5,5,5,5q�6�   $��By birthdaty date��6�    6   �� *BirthdayDateSort+$ OneWayToSource=�$ PropertyChanged=�6�   	� 5U      $��1��6v   $��0��6�   $��5,30,5,5q�6�   $��By Is Adult��6�    6   �� *IsAdultSort+$ OneWayToSource=�$ PropertyChanged=�6�   	� 5V      $��1��6v   $��1��6�   $��5,5,5,5q�6�   $��By Sun Sign��6�    6   �� *SunSignSort+$ OneWayToSource=�$ PropertyChanged=�6�   	� 5W      $��1��6{   $��2��6�   $��5,5,5,5q�6�   $��By Chinease Sign��6�    6   �� *ChineaseSignSort+$ OneWayToSource=�$ PropertyChanged=�6�   	� 5X      $��1��6|   $��3��6�   $��5,5,5,5q�6�   $��By Is Birthday today��6�    6   �� *BirthdayTodaySort+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5Y      $��2��6   $��4��6*   $��5,5,5,5q�68   $
��Sort��6I   ��6X   �� *SortCommand+6z   �� 5Z      $��2��6   $��5��6*   $��5,63,5,5q�68   $	��Add��6J   ��6X   �� *
AddCommand+6y   �� 5[      $��6��6   $��0��6#   $��5,5,5,5q�63   $
��Edit��6D   ��6S   �� *EditCommand+6u   �� 5\      $��6��6   $��1��6#   $��5,5,5,5q�63   $��Remove��6D   ��6U   �� *RemoveCommand+6y   5]      �� 5^   
   $��10q�6   $��2��6   $��2��6*   $��Reset��6>   ��6N   �� *ResetCommand+6q   5_      5`      