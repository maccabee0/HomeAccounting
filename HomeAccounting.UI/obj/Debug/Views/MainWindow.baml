   M S B A M L   `   `   `  ����L  HHomeAccounting.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:HomeAccounting.UI.ViewModelsHomeAccounting.UI.ViewModels  5   @   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel 5   	   (    "HomeAccounting.UI.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <local*clr-namespace:HomeAccounting.UI.ViewModels     6@   Hscm8clr-namespace:System.ComponentModel;assembly=WindowsBase     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��969��6)    � 	Resources 5      &   System.Windows.Controls.DataGrid �� 
TargetType �� Property �� Value   CategoryTemplate �� DataType4   .HomeAccounting.UI.ViewModels.CategoryViewModel   AutoGenerateColumns   CanUserAddRows �� UpdateSourceTrigger	   RowStyle)  #System.Windows.Controls.DataGridRow
   Columns0  *System.Windows.Controls.DataGridTextColumn,  &System.Windows.Controls.DataGridColumn   Header   Width5  /System.Windows.Controls.DataGridLengthConverter1  +System.Windows.Controls.DataGridBoundColumn   Binding �� StringFormat��%�  '        &	  s     �� 5   
   "  6   .�5      ��  � ��$
 Left=�64   �� 5	       � ��$ Stretch=�62   5
      �� 5   
   "  60   .R�5      � $��0q�6   $��Stretch=�6   $	��140��6:   $	��270��6F   .+�5      �� $��Stretch=�6   $��Center=�66   $	��Top=�6Z   
�����F�$
��Bold"�6�   $��	10,5,10,0q�6�   ��6�   �� *
Category+  5      $��Stretch=�6   $��10,35,10,35q�69    .   .  ��5      �� *FilteredTransactions+$ PropertyChanged=�	 5      �� 5      "  6    .�5      -   5        5      
 5        5      $
 Date��6-   $ 50 6;    6F   �� *Date+$ d/M/yy��6w     5      $ Amount��6-   $ 55 6i    6=   �� *Amount+$ F2��6v   5      �� 5      $��Stretch=�6   $��Bottom=�6:   
������$��
10,0,10,10q�6m   $��20��6�   ��5      �� *Total+$ PropertyChanged=�$ F2��5      5      5       � DataContext 5       0   *HomeAccounting.UI.ViewModels.MainViewModel  5!   
   .��5#      � 
������� J� RenderTransformOrigin$ 0.5,0.5&�6   .+�5$   
   (	  "System.Windows.Controls.DatePicker	  $
��Left=�6   $��	10,10,0,0q�60   $	��Top=�6C   $��30��6[    	  Text 6g   �� *Month+ �� Mode$ TwoWay=��� 5%   
   $��Right=�6   $��Center=�6,   $	��Top=�6P   
�����F�$
��Bold"�6   $��
0,10,100,0q�6�   .��6�   Amount Available This Month6�   �� 5&   
   $��Right=�6   $	��Top=�60   $��	0,10,10,0q�6H   $��20��6[   $��60��6g   ��6r   �� *	Dollars+$ PropertyChanged=�$ C��6�   �� 5'   
   $��Right=�6   $	��Top=�60   $��	0,30,10,0q�6H   $��20��6[   $��60��6g   ��6r   �� *
Grivnyas+$ PropertyChanged=�$ F2��6�   �� 5(   
   $��10,50,140,70q�6   #���   6S   ��6(   �� *CategoryViewModels+��5)      �� 5*      .R�5+      ��  �� Orientation$ 
Horizontal=�6!   5,      5<      �� 5?   
   $��First week Total��6   $��Right=�6+   $��	0,70,10,0q�6G   $	��Top=�6Z   $	��120��6r   
���Gc��6~   �� 5@   
   $��Right=�6   $��20��60   $��
0,100,10,0q�6<   $
��Wrap=�6P   $	��Top=�6�   $	��120��6�   ��6d   �� *FirstWeekTotal+$ PropertyChanged=�$ F2��6�   �� 5A   
   $��Second week total��6   $��Right=�6,   $��
0,120,10,0q�6H   $	��Top=�6\   $	��120��6t   
���Gc��6�   �� 5B   
   $��Right=�6   $��20��60   $��
0,150,10,0q�6<   $
��Wrap=�6P   $	��Top=�6�   $	��120��6�   ��6d   �� *SecondWeekTotal+$ PropertyChanged=�$ F2��6�   �� 5C   
   $��Third week total��6   $��Right=�6+   $��
0,170,10,0q�6G   $	��Top=�6[   $	��120��6s   
���Gc��6   �� 5D   
   $��Right=�6   $��20��60   $��
0,200,10,0q�6<   $
��Wrap=�6P   $	��Top=�6�   $	��120��6�   ��6d   �� *ThirdWeekTotal+$ PropertyChanged=�$ F2��6�   �� 5E   
   $��Fourth week total��6   $��Right=�6,   $��
0,220,10,0q�6H   $	��Top=�6\   $	��120��6t   
���Gc��6�   �� 5F   
   $��Right=�6   $��20��60   $��
0,250,10,0q�6<   $
��Wrap=�6P   $	��Top=�6�   $	��120��6�   ��6d   �� *FourthWeekTotal+$ PropertyChanged=�$ F2��6�   �� 5G   
   $��Total Spent��6   $��Right=�6&   $��
0,270,10,0q�6B   $	��Top=�6V   $	��120��6n   
���Gc��6z   �� 5H   
   $��Right=�6   $��20��60   $��
0,300,10,0q�6<   $
��Wrap=�6P   $	��Top=�6�   $	��120��6�   ��6d   �� *MonthlyTotal+$ PropertyChanged=�$ F2��6�   �� 5I   
   -   5        $��Right=�5I      $��Bottom=�6-   $��	0,0,95,10q�6H   $��75��6[   $��25��6f   .��6�   Graph6�   �� 5J   
   $��Right=�6   $��Bottom=�6-   $��
0,0,180,10q�6H   $��75��6\   $��25��6g   ��6s   �� *NewExchangeCommand+.��6�   
Exchange6�   �� 5K   
   -   5        $��
ExpenseBtn��5K      $��Right=�6#   $��	0,0,10,10q�6?   $��Bottom=�6R   $��75��6m   $��25��6x   ��6�   �� *NewTransactionCommand+.��6�   	Expense6�   5L      5M      