   M S B A M L   `   `   `  ���� U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  B >projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:projekt.Propertiesprojekt.Properties O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem !clr-namespace:projektprojekt    projekt.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    Blvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7
properties clr-namespace:projekt.Properties     6sys&clr-namespace:System;assembly=mscorlib     'localclr-namespace:projekt     -     � Title$  
MainWindow��$	��800��$
��1280�� � 
ResizeMode$ NoResize=� � 	Resources  �� 
TargetType �� Property �� Value!  projekt.Properties.Settings   Default �� Source �� Path	 �� 
TargetType
 �� CornerRadius �� Triggers P� Property P� Value   TransparentWhiteSmoke �� Color �� Opacity  cityEntryViewSource  cityEntitiesViewSource % !cityEntitiesCityEntriesViewSource �� Source  cityViewSource��%#  '��       '��     '�� �    '�� c    &	  s    &	 �    &	 �    &	 �    7  &	 �    �� " ��.���  � ��$	 180����  � ��$ 50����  � �� �� # Z $ userBtnColor���  � ��$ 5q���  � �� �� # Z $ userFont���  � �� �� # Z $ userBtnFontSize���  � ��$ Medium"���  � ��
 ������  � �� �� "	 ��.R��� #��z��$
 10��$��3q����� # Z $ userBtnBorderColor�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �� # Z $ userActiveBtnColor���  � ��
 ������� " ��.���  � �� �� # Z $ userFont���  � ��
 �������  � ��$ 22(���  � ��$ Regular"��� " ��.���  � ��$ 3q���  � ��
 ������  � ��$	 356����  � ��$ 50����  � ��$
 Left=���  � ��$ 22(���  � ��$ 5q���  � �� �� # Z $ userFont��� " ��.���  � ��$ 3q���  � ��
 ������  � ��$	 356����  � ��$ 50����  � ��$
 Left=���  � ��
 �������  � ��$ 22(���  � �� �� # Z $ userFont���  � ��$ 15,15,15,10q���  � ��
 ������ $ 
WhiteSmoke��$	 0.5Q��� �� ��  �� *CityEntries+8   �� .��� ����  �� ImageSource$ /Resources/background.jpg�� j� Stretch$ UniformToFill=�.+��� -   $��MenuBar��$��3��$��70��$��
10,10,10,0q�$	��Top=�.+��  � ColumnDefinitions �� $	��200 ��� $	��200 ��� $	��200 �.+��� -   $��
HomeButton��$
��Home��$��0���� -   $��SettingsButton��$��Settings��$��1���� -   $��DiagramsButton��$��Diagrams��$��2��� -   $
��Home��$y�Visible=�.+��� -   $��	Container��$	��675��$��
10,85,10,0q�$	��Top=�$��2�� �� Orientation$ 
Horizontal=�.+��� $��1��$��0��$��0q�$
��Left=�$	��640��$	��675��.+��� $��Information about places��$��Center=�$��Center=�&   System.Windows.Controls.DataGrid  -     Name$ citiesDataEntry��   AutoGenerateColumns .  $
��Left=�$	��250��$��	10,5,0,10q�$��Center=�$	��620��   RowDetailsVisibilityMode$ VisibleWhenSelected=����� # [    Columns 0  *System.Windows.Controls.DataGridTextColumn  -	   idColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Id��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  -
   
cityColumn��$
 City��$	 100  �� *
CityName+  -   countryColumn��$ Country��$	 100  �� *CountryName+  -   latitudeColumn��$ Latitude��$	 100  �� *
Latitude+  -   longitudeColumn��$ 	Longitude��$	 100  �� *	Longitude+�� $��Places waiting to save��$��Center=�$��Center=�$��	0,0,0,-10q��  �� $	��155 ��� $	��155 ��� $	��155 ��� $	��164 �.+��� $
��City��$��Stretch=�$��12(�$��0q�$��	10,10,0,0q�
�������
���   �$��0���� $��Country��$��Stretch=�$��12(�$��0q�$��0,10,0,0q�
�������
���   �$��1���� $��Latitude��$��Stretch=�$��12(�$��0q�$��0,10,0,0q�
�������
���   �$��2���� $��	Longitude��$��Stretch=�$��12(�$��0q�$��0,10,0,0q�
�������
���   �$��3���� $��	0,-1,0,16q�$	��250��$	��620������ $ Items����� .R��� $��Stretch=�$ 
Horizontal=�.+��� $	��155������ $ CityName��� $	��155������ $ CountryName��� $	��155������ $ Latitude��� $	��130������ $ 	Longitude��� $��Bottom=�$��0q�.+�� $��Bottom=�.+��� -    ��Name$ saveToDatabaseButton��$��Save to database��$	��300���� $��Right=�$��0q�$	��640��.+��� $��Add new place��$��Center=�$��0,0,0,15q��  � DataContext# [  �� $	��250 ���  � RowDefinitions �� �� �� �� .+��� $��Country��$��0��$��0��$��Center=�$��Center=��� -    ��Name$ inputCountry��$��1��$��0���� $
��City��$��0��$��1��$��Center=�$��Center=��� -   $ 	inputCity��$��1��$��1��$��0,15,0,0q��� $��Latitude��$��0��$��2��$��Center=�$��Center=��� -   $ inputLatitude��$��1��$��2��$��0,15,0,0q��� $��	Longitude��$��0��$��3��$��Center=�$��Center=��� -   $ inputLongitude��$��1��$��3��$��0,15,0,0q�� $��0,15,0,0q�.+��� $��0��$��0��.+��� -   $ addPlaceButton��$��	Add place��$��0��$��	0,20,0,40q�$	��300���� -   $ addLocalXMLFile��$��Add local XML file��$��0��$��0,0,0,10q�$	��300���� $��City from API��$��Center=�$��0,10,0,0q��  �� $	��250 ��� .+��� $
��City��$��0��$��Center=�$��Center=��� -   $ inputCityApi��$��1��� $��0,39,0,0q� �� $	��300 ��� .+��� -   $ loadFromApiButton��$��Load from API��$��0��$	��300���� -   $ autoGenerateButton��$��Auto generate every 10s��$��1��$	��300��$��0,0,30,0q�� -   $��Settings��$y�Hidden=�.+��� -   $��ContainerSettings��$��
-2,100,2,0q�.+�� $	��600��$
��1000�� �� ��  �� $��70 ��� $��70 ��� $��70 ��� $��70 ��� $��70 ��� .+��� $
��Font��$��0��$��0��$��Center=�$��Center=�$��
260,10,0,0q��� -     ��Name$  fontComboBox��$��1��$��0��$��Center=�$��Center=�$��	0,0,100,0q��� $��Button font size��$��0��$��1��$��Center=�$��Center=�$��	260,0,0,0q��� -   $  btnFontSizeComboBox��$��1��$��1��$��Center=�$��	0,0,100,0q��� $��Button color��$��0��$��2��$��Center=�$��Center=�$��	260,0,0,0q��� -   $  btnColorComboBox��$��1��$��2��$��Center=�$��	0,0,100,0q��� $��Active button color��$��0��$��3��$��Center=�$��Center=�$��	260,0,0,0q��� -   $  activeBtnColorComboBox��$��1��$��3��$��Center=�$��	0,0,100,0q��� $��Button border color��$��0��$��4��$��Center=�$��Center=�$��	260,0,0,0q��� -   $  btnBorderColorComboBox��$��1��$��4��$��Center=�$��	0,0,100,0q��� -   $��Default��$��0��$��5��$	��300��$��	120,0,0,0q��� -    $
��Save��$��1��$��5��$	��300��$��	0,0,120,0q�� -!   $��Diagrams��$y�Hidden=�.+��� -"   $��Charts��$	��500��$��2��$��Center=�$��Center=�#��[  .+��  �� $	��550 ��� $	��550 �.+��� $,��&Number of cities depending on latitude��$��20q�$��0��$��Center=�$	��Top=�   LiveCharts.Wpf.PieChart  -#   $	��400��$��50, 75q�$��0��&    LiveCharts.Wpf.Charts.Base.Chart!   LegendLocation$! Bottom=�"   	Hoverable" . #   DataTooltip# Z� $   Series$ 	   LiveCharts.Wpf.PieSeries	  -$   $��Lat9060��
   LiveCharts.Wpf.Series% 
  Title$% 	-90 : -60��& 
  Values;   5LiveCharts.Wpf.Converters.NumericChartValuesConverter$& 31 ' 
  
DataLabels' . ( 
  
LabelPoint( �� *
PointLabel+	  -%   $��Lat6030��$% 	-60 : -30��$& 14 ' . ( �� *
PointLabel+	  -&   $��Lat300��$% -30 : 0��$& 90 ' . ( �� *
PointLabel+	  -'   $��Lat030��$% 0 : 30��$& 21 ' . ( �� *
PointLabel+	  -(   $��Lat3060��$% 30 : 60��$& 25 ' . ( �� *
PointLabel+	  -)   $��Lat6090��$% 60 : 90��$& 22 ' . ( �� *
PointLabel+�� $&�� Number of cities in each country��$��20q�$��1��$��Center=�$	��Top=�#   LiveCharts.Wpf.CartesianChart  $	��400��$��50, 25q�$��1��$
! Left=�$ �� *SeriesCollection+)   AxisX)    LiveCharts.Wpf.Axis  *   Title$* Country��+   Labels+ �� *Labels+,   AxisY,   $* Number��-   LabelFormatter- �� *	Formatter+