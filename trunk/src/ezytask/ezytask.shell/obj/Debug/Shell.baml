   M S B A M L   `   `   `  ����H  Dezytask.shell, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ezytask.shell.UserControlsezytask.shell.UserControls  5   	       ezytask.shell.Shell   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      k gInfragistics3.Wpf.Ribbon.v9.1, Version=9.1.20091.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb-igRibbonhttp://infragistics.com/Ribbon  5   	   d `Infragistics3.Wpf.v9.1, Version=9.1.20091.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb/	igWindowshttp://infragistics.com/Windows  5   	   p lInfragistics3.Wpf.DockManager.v9.1, Version=9.1.20091.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb0igDock#http://infragistics.com/DockManager  5   	   4local(clr-namespace:ezytask.shell.UserControls  5   	   e aMicrosoft.Practices.Composite.Presentation, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null.cal$http://www.codeplex.com/CompositeWPF  5
   	   -   5          �Name$  Window��5       � Title$ ezytask��6   $	��804��5      $	��637��6    � WindowState$ 	Maximized=�5        � 	Resources 5         ApplicationMenuImage  	ExitImage  SettingsImage  AddUserImage  EditUserImage��%-  &	        &	 E     &	 p     &	 �     &	 �     ��5   
   1-Resources/xamRibbonDefaultApplicationIcon.png��6c   ��5   
   Resources/exit2.png��6=   ��5   
   Resources/settings.png��6D   ��5   
   Resources/add_user.png��6C   ��5   
   Resources/edit_user.png��6E   5      .��5      � $��0,0,0,10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5!   
   +  %Infragistics.Windows.Ribbon.XamRibbon  F  @Microsoft.Practices.Composite.Presentation.Regions.RegionManager   
RegionName$ RibbonBarRegion��6   $��0��5"         ApplicationMenu 5$      1  +Infragistics.Windows.Ribbon.ApplicationMenu  5%      -   5        $��appMenu��5&   +      Image# [  5%   +   $ ApplicationMenuRegion��5'   +   .@�5(      ,  &Infragistics.Windows.Ribbon.ButtonTool  -   5        $��btnSettings��5(   *      
SmallImage# [ 6=   $��Settings��6�   /  )Infragistics.Windows.Ribbon.SeparatorTool  5)        5*      -   5        $��btnExit��5*   *   # [ 69   $
��Exit��6w   5+      	   Tabs.	 5.      /  )Infragistics.Windows.Ribbon.RibbonTabItem  $��ezytask menu��6%   $ RibbonTabItemRegion��6;   5=      5>      5  /Infragistics.Windows.DockManager.XamDockManager  5A   
   
   ThemeH  BInfragistics.Windows.Themes.Internal.DockManagerThemeTypeConverter$

 Aero 6    $��2��5B          Panes 5C      0	  *Infragistics.Windows.DockManager.SplitPane	  5D         InitialLocation$ DockedBottom=�6#    	  Panes. 5E      2
  ,Infragistics.Windows.DockManager.ContentPane
  $��eazytask debug output��6)   .��5F      3   -ezytask.shell.UserControls.DebugOutputControl  69   5G      5H      .��5K      :  4Infragistics.Windows.DockManager.DocumentContentHost     Panes. 5L      	  . 5M      3  -Infragistics.Windows.DockManager.TabGroupPane  $ DocumentRegion��6*   5N      5O      5P      5R      5S      5T      