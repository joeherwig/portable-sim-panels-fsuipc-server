   M S B A M L   `   `   `  ����\  Xportable-sim-panels-fsuipc-server, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:portableSimPanelsFsuipcServerportableSimPanelsFsuipcServer  5   	   .    (portableSimPanelsFsuipcServer.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:portableSimPanelsFsuipcServer     5   	   -   5          � Title$'  !portable-sim-panels-FSUIPC-server��5   	   $	��250��5	   	   $	��400��6      BackgroundColor#���   5
   	    � WindowStyle$
 None=�68   $	��400��5   &   $	��250��65     WindowChromeKey'  !System.Windows.Shell.WindowChrome   WindowChrome# �  5   	    � 	Resources 5       �� Color  	TextColor �� 
TargetType �� Property �� Value   ResizeBorderThickness	   CaptionHeight��%W  &	        &	 !     '� D     7   '�� �     &	 �     �� 5   
   $ #000000��62   �� 5   
   $ 	#F2FFFFFF��6,   �� 5   
   " �6   .�5      ��  � ��8   6+   5      �� 5   
   " ��6   .�5      ��  � ��# �   6+   6W   5        5   
    5      u�5      5q�6   $	 0Q�5   G   5      5      .��5      � $��	0,0,-8,-8q�6   
 � ColumnDefinitions
 5   
   �� 5       $	��200��6   .+�5#   
   ]� ��.  $��
10,10,0,11q�6*    J� RenderTransformOrigin$ -0.723,-0.896&�6>   $
��Left=�6d   $��75��6   z�5$      V� 5%      .~�5&      �� �� 5'      �� 5(       �� Angle$ -0.008Q�6&   T� 5)      5*      5.      � 5/   
   $��
100,0,10,0q�6   $��32��6#   $	��Top=�6/   .+�50      ��  �� Orientation$ 
Horizontal=�6   $��Right=�51      $��Center=�52      .+�54      �� -   5         ��Name$ MinimizeButton��54      -  'System.Windows.Input.KeyboardNavigation   	IsTabStop .    iconMinimize#��[ 56   (   $��32��6X   ��6c   Z� �� 58      -   5        $ MaximizeButton��58       .    iconMaximize#��[ 5:   (   ��6X   Z� �� 5<      -   5        $ CloseButton��5<       .    	iconClose#��[ 5>   ,   ��6Y   Z� 5?      5A      �� 5B   
    K� ZIndex$ -1��6   $*��$airplane-airline-aircraft-travel.jpg��6"   $��UniformToFill=�6P   �� 5C   
   -   5         ��Name$
 Tabs��5C      $��
0,32,10,10q�6#    �� TabStripPlacement$
 Left=�6M   ��67   Z� ��6f   Z� .@�5E      �� $	��Sim��6   #���   6#   #���  6R   $��
-2,-2,0,-2q�6{   .��5F      � .+�5G      �� -   5         ��Name$ SimulatorInfo��5G      $�� ��63   $��	0,0,1,158q�6>   �� 5H      -   5        $ QrCodeLabel��5H      $�� ��61   $��
0,47,1,123q�6<   #���  6P   �� 5I      -   5        $ QrCodeButton��5I      $��100,87,100,10q�63   
���   �#���  6t   ��6]   Z� .��5J      �� -	   5         ��Name$ QrCode��5J       5K      5L      5N      �� 5O      $��FSUIPC��6   .��5P      � $��	16,24,0,0q�6   .+�5Q      �� -
   5         ��Name$ JsonFilterField��5Q      $��18��67    �� TextWrapping$
 Wrap=�6C   $�� ��6W   #���   6_   #���  6�   $��	0,-23,0,0q�6�   $	��Top=�6�   $ 	0.5,1.018&�6�   �� 5R      -   5        $ JsonTextField��5R      $��
0,28,10,10q�65   $
 Wrap=�6I   #���  6]    �� AcceptsReturn . #���   6�    J� OpacityMask �	#7F2A2A2A��6�   Z� 6�   5S      5T      5W      5Y      5Z      