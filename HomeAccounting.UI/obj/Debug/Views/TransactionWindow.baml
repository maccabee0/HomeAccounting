   M S B A M L   `   `   `  ����L  HHomeAccounting.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:HomeAccounting.UI.ViewModelsHomeAccounting.UI.ViewModels  5   	   /    )HomeAccounting.UI.Views.TransactionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <local*clr-namespace:HomeAccounting.UI.ViewModels     5   	   -   5          � Title$  TransactionWindow��5   	   $	��200��6#   $	��300��60    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$
 Left=�64   �� 5	       � ��$	 Top=�62   �� 5
       � ��$	 100��6&   �� 5       � ��
 ���F�6+   �� 5       � ��$
 Bold"�6+   5      5       � DataContext 5      7   1HomeAccounting.UI.ViewModels.TransactionViewModel  5   
   .��5      � 
�������.+�5   
   �� $
��Date��6   $��	10,10,0,0q�6   (  "System.Windows.Controls.DatePicker  5   
   $��
140,10,0,0q�67   $
��Left=�6K   $	��Top=�6f   $	��125��6~      Text 6   �� *Date+ �� Mode$ TwoWay=�6~   �� 5   
   $��Amount��6   $��	10,50,0,0q�6!   �� 5   
   $
��Left=�6   $	��Top=�6-   $��
140,50,0,0q�6E   $	��125��6Y   ��6e   �� *Amount+$ TwoWay=� �� StringFormat$ F2��	 �� UpdateSourceTrigger$	 PropertyChanged=��� 5   
   $��Category��6   $��	10,90,0,0q�6#   �� 5   
   $
��Left=�6   $	��Top=�6.   $��
140,90,0,0q�6F   $	��125��6Z   
 �� DisplayMemberPath$
 CategoryString��5       �� SelectedValuePath$ 
CategoryID��5      ��5      ��  �� Path$ 
Categories� �� SelectedValue 5      �� *SelectedCategoryId+$ TwoWay=��� 5   
   $
��Save��6   $��Right=�6    $��Bottom=�6<   $��25��6W   $��50��6c   $��	0,0,70,10q�6n   ��6�   �� *SaveCommand+�� 5   
   -   5        $��Cancel��5      $��Right=�6"   $��Bottom=�6>   $��25��6Y   $��50��6e   $��	0,0,10,10q�6p   6�   5      5       