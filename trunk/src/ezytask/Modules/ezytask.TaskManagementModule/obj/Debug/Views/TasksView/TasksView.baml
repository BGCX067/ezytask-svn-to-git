   M S B A M L   `   `   `  ����L  Hezytask.utilities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:ezytask.utilities;assembly=ezytask.utilitiesezytask.utilities  5        ezytask.TaskManagementModule<   6ezytask.TaskManagementModule.Views.TasksView.TasksView   5      I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=null\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      r nInfragistics3.Wpf.DataPresenter.v9.1, Version=9.1.20091.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb0igDP%http://infragistics.com/DataPresenter  5      p lInfragistics3.Wpf.DockManager.v9.1, Version=9.1.20091.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb0igDock#http://infragistics.com/DockManager  5      ;toolKit-http://schemas.microsoft.com/wpf/2008/toolkit  5      Futils:clr-namespace:ezytask.utilities;assembly=ezytask.utilities  5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      $	��504��6<   .��5      2  ,Infragistics.Windows.DockManager.ContentPane  -   5        $��ContentPane��5      $��Manage tasks��6,      WindowGradient#���   6B   .��5	   
   �� -   5        $��	mainStack��5	       $��5q�6   .+�5
      �� $��18(�6   Task Management67   �� 5      � 5        � ColumnDefinitions  5      �� 5      $	��100 �6'   �� 5      �� 5       � RowDefinitions 5      �� 5      $��30 �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      �� $��0��5      $��0��5      $
��Left=�5       $��Center=�5!      
Project:66   ]� 5$      $��0��6   $��1��6*   $��0q�6:   .+�5%      �� -   5        $��
btnNewTask��5%   ?   $��Right=�6   $��2q�64    � ToolTip$ New Task��6Q   .��5&      ��  �� Orientation$ 
Horizontal=�6%   .+�5'      �� $��16��6$   $��16��6/   $E��?/ezytask.TaskManagementModule;component/Resources/newtask16.png��5(   $   �� 5*      
New Task62   5+      5,      �� 5-      -   5        $��
cmbProject��5/        TheCombo#���  5-      $
��Auto��5.       �� DisplayMemberPath$
 Name��51       �� SelectedValuePath$ 	IdProject��52      ��50      ��  �� Path$ ProjectList�53   "   54      �� 56      $��1��57      $��0��58      $
��Left=�59      Tasks:64   �� 5<      $��1��6   $��1��6*   .+�5=      4  .Infragistics.Windows.DataPresenter.XamDataGrid  -   5        $��	gridTasks��5C      :  4Infragistics.Windows.DataPresenter.DataPresenterBase   ThemeJ  DInfragistics.Windows.Themes.Internal.DataPresenterThemeTypeConverter$ Royale 5>         GroupByAreaLocation$
 None=�5?      $	��200��5A      $	��200��5B      $��5q�5D      	   
DataSource	 5@      �� $ TaskList�
 J� Effect
 5F      3  -System.Windows.Media.Effects.DropShadowEffect  5G         
BlurRadius$ 7Q�6/      Opacity$	 0.3Q�6>      FieldLayoutSettings 5I      <  6Infragistics.Windows.DataPresenter.FieldLayoutSettings  5J         RecordSelectorLocation$
 None=�5K   !      SelectionTypeRecord$ Single=�5L   !      SelectionTypeCell$
 None=�5M   !      SelectionTypeField$
 None=�5N   !       HighlightAlternateRecords$
 TrueY�5O   !      FieldLayouts 5Q      4  .Infragistics.Windows.DataPresenter.FieldLayout  5R         Fields 5S   "   .  (Infragistics.Windows.DataPresenter.Field  5T   &      Name$ IdTask��61      
Visibility$ 	Collapsed=�6?     5V   &   $
 Name��61      Label$ 	Task name��6=      Settings 5W   *   6	  0Infragistics.Windows.DataPresenter.FieldSettings	  5X   .    	  CellMinWidth$	 200Q�6A   5Z   '     5\   &   $ 	StartDate��61   $ 
Start Date��6B    5]   *   	  5^   .   $	 100Q�6A   5`   '     5b   &   $ EndDate��61   $ End Date��6@    5c   *   	  5d   .   $	 100Q�6A   5f   '   5h      5j      5k      � 5n      $��2��6   $��0��6'   $��2��64     5o      �� 5p      $	��100 �6+   �� 5q      $��* �6+    5s      �� 5t      $��30 �6(   �� 5u      $��30 �6(   �� 5v      $��30 �6(   �� 5w      $��30 �6(   �� 5x      $��30 �6(   .+�5{      �� $��0��6    $��0��6-     TheLabel#���  6=   $
��Left=�6`   $��Center=�6{   
Task name:6�   �� 5|      -   5        $��txtTaskName��5|   ;   $��0��6   $��1��6+     
TheTextBox#���  6N   6u   �� 5~      $��1��6    $��0��6-   #���  6=   $
��Left=�6`   $��Center=�6{   Task description:6�   �� 5      -   5        $��txtTaskDescription��5   ;   $��1��6   $��1��6+   #���  6U   6|   �� 5�      $��2��6    $��0��6-   #���  6=   $
��Left=�6`   $��Center=�6{   Start date:6�   +
  %Microsoft.Windows.Controls.DatePicker
  5�      -   5        $��dtpStartDate��5�   F   $��2��6)   $��1��66   $��3q�6Z     GenericDropShadow#
 �  6e   �� 5�      $��3��6    $��0��6-   #���  6=   $
��Left=�6`   $��Center=�6{   	End date:6�   
  5�      -	   5        $��
dtpEndDate��5�   F   $��3��6)   $��1��66   $��3q�6Y   #
 �  6d   �� 5�      -
   5        $��btnSaveTask��5�   m   $��4��6   $��1��6*   $	��100��6:   $��5q�6F   $��Right=�6Q   .��6�   Save6�   5�      �� 5�      $��0��6   $��2��6,   Assignments:6G   �� 5�      $��3��6   $��1��6*   .+�5�        -   5        $��gridAssignments��5�      $ Royale 5�      $
 None=�5�      $	��200��5�      $	��200��5�      $��5q�5�      	 5�      �� $ AssignmentList�
 5�        5�      $ 7Q�6/   $	 0.3Q�6>    5�        5�      $
 None=�5�   !   $ Single=�5�   !   $
 None=�5�   !   $
 None=�5�   !   $
 TrueY�5�   !    5�        5�       5�   "     5�   &   $ 	IdProject��61   $ 	Collapsed=�6B     5�   &   $
 Name��61   $ Project name��6=    5�   *   	  5�   .   $	 100Q�6A   5�   '     5�   &   $ Description��61   $ Project description��6D    5�   *   	  5�   .   $	 280Q�6A   5�   '   5�      5�      5�      � 5�      $��4��6   $��2��6'     5�      �� 5�      $	��100 �6+   �� 5�      $��* �6+    5�      �� 5�      $��30 �6(   �� 5�      $��30 �6(   �� 5�      $��30 �6(   �� 5�      $��30 �6(   �� 5�      $��30 �6(   �� 5�      $��30 �6(   .+�5�      �� $��0��6    $��0��6-   #���  6=   $
��Left=�6`   $��Center=�6{   	Resource:6�   �� 5�      -   5        $��cmbAssignmentResource��5�   _   $��0��6   $��1��6,   #���  6<   6_   �� 5�      $��1��6    $��0��6-   #���  6=   $
��Left=�6`   $��Center=�6{   Name:6�   �� 5�      -   5        $��txtAssignmentName��5�   ;   $��1��6   $��1��6+   #���  6T   6{   �� 5�      $��2��6    $��0��6-   #���  6=   $
��Left=�6`   $��Center=�6{   Description:6�   �� 5�      -   5        $��txtAssignmentDescription��5�   ;   $��2��6   $��1��6+   #���  6[   6�   �� 5�      $��3��6    $��0��6-   #���  6=   $
��Left=�6`   $��Center=�6{   Start date:6�   
  5�      -   5        $��dtpAssignmentStartDate��5�   F   $��3��6)   $��1��66   $��3q�6d   #
 �  6o   �� 5�      $��4��6    $��0��6-   #���  6=   $
��Left=�6`   $��Center=�6{   	End date:6�   
  5�      -   5        $��dtpAssignmentEndDate��5�   F   $��4��6)   $��1��66   $��3q�6c   #
 �  6n   �� 5�      -   5        $��btnSaveAssignment��5�   m   $��5��6   $��1��6*   $	��100��6:   $��5q�6F   $��Right=�6Q   .��6�   Save6�   5�      5�      � 5�        5�      �� 5�      $	��100 �6'   �� 5�      $	��260 �6'   �� 5�      $	��100 �6'   �� 5�      $	��260 �6'    5�      �� 5�      $��30 �6$   �� 5�      $
��Auto �6$   �� 5�      $��* �6$   .+�5�      �� #���  6   $��0��6?   $��0��6L   Assignments:6j   5�      5     5     5     