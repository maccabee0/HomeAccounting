   M S B A M L   `   `   `  ���� L  HHomeAccounting.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:HomeAccounting.UI.ViewModelsHomeAccounting.UI.ViewModels  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel (    "HomeAccounting.UI.Views.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     <local*clr-namespace:HomeAccounting.UI.ViewModels     Hscm8clr-namespace:System.ComponentModel;assembly=WindowsBase       � Title$  
MainWindow��$	��450��$	��969�� � 	Resources &   System.Windows.Controls.DataGrid �� 
TargetType �� Property �� Value   CategoryTemplate �� DataType4   .HomeAccounting.UI.ViewModels.CategoryViewModel   AutoGenerateColumns   CanUserAddRows �� UpdateSourceTrigger	   RowStyle)  #System.Windows.Controls.DataGridRow
   Columns0  *System.Windows.Controls.DataGridTextColumn,  &System.Windows.Controls.DataGridColumn   Header   Width5  /System.Windows.Controls.DataGridLengthConverter1  +System.Windows.Controls.DataGridBoundColumn   Binding �� StringFormat��%e  '        &	  @     �� "  .���  � ��$
 Left=���  � ��$ Stretch=��� "  .R�� $��0q�$��Stretch=�$	��140��$	��270��.+��� $��Stretch=�$��Center=�$	��Top=�
�����F�$
��Bold"�$��	10,5,10,0q����� *
Category+  $��Stretch=�$��10,35,10,35q� .   .  ���� *FilteredTransactions+$ PropertyChanged=�	 �� "  .�-   
   $
 Date��$ 50  �� *Date+$ d/M/yy��  $ Amount��$ 55  �� *Amount+$ F2���� $��Stretch=�$��Bottom=�
������$��
10,0,10,10q�$��20������ *Total+$ PropertyChanged=�$ F2�� � DataContext 0   *HomeAccounting.UI.ViewModels.MainViewModel  .��� 
������� J� RenderTransformOrigin$ 0.5,0.5&�.+�(	  "System.Windows.Controls.DatePicker	  $
��Left=�$��	10,10,0,0q�$	��Top=�$��30�� 	  Text �� *Month+ �� Mode$ TwoWay=��� $��Right=�$��Center=�$	��Top=�
�����F�$
��Bold"�$��
0,10,100,0q�.��Amount Available This Month�� $��Right=�$	��Top=�$��	0,10,10,0q�$��20��$��60������ *	Dollars+$ PropertyChanged=�$ C���� $��Right=�$	��Top=�$��	0,30,10,0q�$��20��$��60������ *
Grivnyas+$ PropertyChanged=�$ F2���� $��10,50,140,70q�#���   ���� *CategoryViewModels+���� .R���  �� Orientation$ 
Horizontal=��� $��First week Total��$��Right=�$��	0,70,10,0q�$	��Top=�$	��120��
���Gc���� $��Right=�$��20��$��
0,100,10,0q�$
��Wrap=�$	��Top=�$	��120������ *FirstWeekTotal+$ PropertyChanged=�$ F2���� $��Second week total��$��Right=�$��
0,120,10,0q�$	��Top=�$	��120��
���Gc���� $��Right=�$��20��$��
0,150,10,0q�$
��Wrap=�$	��Top=�$	��120������ *SecondWeekTotal+$ PropertyChanged=�$ F2���� $��Third week total��$��Right=�$��
0,170,10,0q�$	��Top=�$	��120��
���Gc���� $��Right=�$��20��$��
0,200,10,0q�$
��Wrap=�$	��Top=�$	��120������ *ThirdWeekTotal+$ PropertyChanged=�$ F2���� $��Fourth week total��$��Right=�$��
0,220,10,0q�$	��Top=�$	��120��
���Gc���� $��Right=�$��20��$��
0,250,10,0q�$
��Wrap=�$	��Top=�$	��120������ *FourthWeekTotal+$ PropertyChanged=�$ F2���� $��Total Spent��$��Right=�$��
0,270,10,0q�$	��Top=�$	��120��
���Gc���� $��Right=�$��20��$��
0,300,10,0q�$
��Wrap=�$	��Top=�$	��120������ *MonthlyTotal+$ PropertyChanged=�$ F2���� -   $��Right=�$��Bottom=�$��	0,0,95,10q�$��75��$��25��.��Graph�� $��Right=�$��Bottom=�$��
0,0,180,10q�$��75��$��25������ *NewExchangeCommand+.��
Exchange�� -   $��
ExpenseBtn��$��Right=�$��	0,0,10,10q�$��Bottom=�$��75��$��25������ *NewTransactionCommand+.��	Expense