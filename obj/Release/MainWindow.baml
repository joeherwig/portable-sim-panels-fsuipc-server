   M S B A M L   `   `   `  ���� \  Xportable-sim-panels-fsuipc-server, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:portableSimPanelsFsuipcServerportableSimPanelsFsuipcServer  .    (portableSimPanelsFsuipcServer.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     =local+clr-namespace:portableSimPanelsFsuipcServer     -     � Title$'  !portable-sim-panels-FSUIPC-server��$��266.333��$��401.333��   BackgroundColor#���    � WindowStyle$
 None=�$	��400��$	��250��  WindowChromeKey'  !System.Windows.Shell.WindowChrome   WindowChrome# �   � 	Resources  �� Color  	TextColor �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius
 ��Name �� Triggers P� Property P� Value �� 
TargetName   ResizeBorderThickness   CaptionHeight��%�  &	        &	      '�� (     '� >    7   '�� ]    &	 ~    �� $ #000000���� $ 	#F2FFFFFF���� " ��.���  � �� �� " ��.R�� .+��� $��Border��$��0,0,0,0q����	#18424242
���   �$��1,1,1,1q�$	 4��._��� $
 ContentSite��$��Center=�$��Center=�$��Header��$��10,10,10,10q���.  P�  � {� . . ��� $ Border�� � �� �	#66353535�� $ Border�� � ��$ 1,1,1,0q���  � �� �	#FF969696P�  �@��
IsSelected . . ���  �@K�ZIndex$	 100���� $ Border�� � �� �	#FF424242�� $ Border�� � ��$ 1,1,1,0q���  � ��
 ������� " �.���  � ��8   �� " ��.���  � ��# �      u�5q�$ 0Q�.��� $��	0,0,-8,-8q� � ColumnDefinitions �� $	��200��.+�]� ��.  $��
10,10,0,11q� J� RenderTransformOrigin$ -0.723,-0.896&�$
��Left=�$��75��z�V� .~��� �� ��  �� Angle$ -0.008Q�T� � $��
100,0,10,0q�$��32��$	��Top=�.+���  �� Orientation$ 
Horizontal=�$��Right=�$��Center=�.+��� -    ��Name$ MinimizeButton��-  'System.Windows.Input.KeyboardNavigation   	IsTabStop .    iconMinimize#��[ $��32����Z� �� -   $ MaximizeButton�� .    iconMaximize#��[ ��Z� �� -   $ CloseButton�� .    	iconClose#��[ ��Z� ��  K� ZIndex$ -1��$*��$airplane-airline-aircraft-travel.jpg��$��UniformToFill=��� -    ��Name$
 Tabs��$��0,32,10.5,9.5q����	#331D1D1D �� TabStripPlacement$
 Left=�#���  ��Z� .@��� $	��Sim��.��� ���	#66424242.+��� -    ��Name$ SimulatorInfo��$�� ��$��0,0,0.5,174.5q��� -    ��Name$ QrCodeLabel��$
��Left=�$��	10,52,0,0q�$
��Wrap=�$�� ��$	��Top=�$	��306��$��34���� -   $ QrCodeButton��$��100,91,100,10q� � Cursor$
 Hand������ " ��.���  � ��
 ���� ��  � �� �� " ��.R��� #��z��._��� $��Center=�$��Center=� �� Triggers P�  �@J�IsMouseOver . . ���  � ��
 ���� .���� -	    ��Name$ QrCode���� $��FSUIPC��.��� ���	#66424242.+��� -
    ��Name$ JsonFilterField��$��24��  �� TextWrapping$
  Wrap=�$�� ��#���   #���  $	��Top=�$ 	0.5,1.018&��� -   $ JsonTextField��$��0,29,0,0q�$
  Wrap=�#���  ! �� AcceptsReturn! . " �� 
IsReadOnly" . $
��Auto=���Z� ��Z� 