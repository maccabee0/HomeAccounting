   M S B A M L   `   `   `  ���� L  HHomeAccounting.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:HomeAccounting.UI.ViewModelsHomeAccounting.UI.ViewModels  /    )HomeAccounting.UI.Views.TransactionWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     <local*clr-namespace:HomeAccounting.UI.ViewModels     -     � Title$  TransactionWindow��$	��200��$	��300�� � 	Resources  �� 
TargetType �� Property �� Value��%�   '��       �� " ��.���  � ��$
 Left=���  � ��$	 Top=���  � ��$	 100����  � ��
 ���F���  � ��$
 Bold"� � DataContext 7   1HomeAccounting.UI.ViewModels.TransactionViewModel  .��� 
�������.+��� $
��Date��$��	10,10,0,0q�(  "System.Windows.Controls.DatePicker  $��
140,10,0,0q�$
��Left=�$	��Top=�$	��125��   Text �� *Date+ �� Mode$ TwoWay=��� $��Amount��$��	10,50,0,0q��� $
��Left=�$	��Top=�$��
140,50,0,0q�$	��125������ *Amount+$ TwoWay=� �� StringFormat$ F2��	 �� UpdateSourceTrigger$	 PropertyChanged=��� $��Category��$��	10,90,0,0q��� $
��Left=�$	��Top=�$��
140,90,0,0q�$	��125��
 �� DisplayMemberPath$
 CategoryString�� �� SelectedValuePath$ 
CategoryID������  �� Path$ 
Categories� �� SelectedValue �� *SelectedCategoryId+$ TwoWay=��� $
��Save��$��Right=�$��Bottom=�$��25��$��50��$��	0,0,70,10q����� *SaveCommand+�� -   $��Cancel��$��Right=�$��Bottom=�$��25��$��50��$��	0,0,10,10q�