   M S B A M L   `   `   `  ���� L  HHomeAccounting.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:HomeAccounting.UI.ViewModelsHomeAccounting.UI.ViewModels  ,    &HomeAccounting.UI.Views.ExchangeWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     <local*clr-namespace:HomeAccounting.UI.ViewModels     -     � Title$  SaveExchange��$	��225��$	��300�� � 	Resources  �� 
TargetType �� Property �� Value��%�   '��       '�� S     �� " ��.���  � ��$	 125����  � ��$
 Left=���  � ��$	 Top=��� " ��.���  � ��$
 Left=���  � ��$	 Top=���  � ��$	 100����  � ��
 ���F���  � ��$
 Bold"� � DataContext 4   .HomeAccounting.UI.ViewModels.ExchangeViewModel  .��� -   $
��Grd1��
�������.+��� $��	10,10,0,0q�.��Date(  "System.Windows.Controls.DatePicker  $	��Top=�$
��Left=�$��
140,10,0,0q�$	��125��   Text �� *Date+ �� Mode$ TwoWay=� �� StringFormat$ d/M/yy���� $��	10,50,0,0q�.��Dollar Amount�� $��
140,50,0,0q����� *	Dollars+$ F2���� $��	10,90,0,0q�.��SaveExchange Rate�� $��
140,90,0,0q����� *Rate+$ F2���� $��
10,130,0,0q�.��
Grivnyas�� $
��Left=�$	��Top=�$��140,130,0,0q�$	��125������ *	Grivnya+$ F2���� $��Right=�$��Bottom=�$��	0,0,70,10q�$��50��	 �� 	IsDefault	 . ���� *SaveCommand+.��Save�� -   $��Right=�$��Bottom=�$��	0,0,10,10q�$��50��
 �� IsCancel
 . .��Cancel