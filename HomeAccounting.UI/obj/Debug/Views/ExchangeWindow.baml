   M S B A M L   `   `   `  ����L  HHomeAccounting.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:HomeAccounting.UI.ViewModelsHomeAccounting.UI.ViewModels  5   	   ,    &HomeAccounting.UI.Views.ExchangeWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <local*clr-namespace:HomeAccounting.UI.ViewModels     5   	   -   5          � Title$  SaveExchange��5   	   $	��225��6   $	��300��6+    � 	Resources 5       �� 
TargetType �� Property �� Value��%�  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$	 125��6&   �� 5	       � ��$
 Left=�64   �� 5
       � ��$	 Top=�62   5      �� 5   
   " ��6   .�5      ��  � ��$
 Left=�64   �� 5       � ��$	 Top=�62   �� 5       � ��$	 100��6&   �� 5       � ��
 ���F�6+   �� 5       � ��$
 Bold"�6+   5      5       � DataContext 5      4   .HomeAccounting.UI.ViewModels.ExchangeViewModel  5   
   .��5      � -   5        $
��Grd1��5      
�������.+�5   
   �� $��	10,10,0,0q�6   .��6#   Date6)   (  "System.Windows.Controls.DatePicker  5   
   $	��Top=�6M   $
��Left=�6e   $��
140,10,0,0q�6�   $	��125��6�      Text 6   �� *Date+ �� Mode$ TwoWay=� �� StringFormat$ d/M/yy��6�   �� 5   
   $��	10,50,0,0q�6   .��6#   Dollar Amount62   �� 5   
   $��
140,50,0,0q�6<   ��6   �� *	Dollars+$ F2��6R   �� 5   
   $��	10,90,0,0q�6   .��6#   SaveExchange Rate66   �� 5   
   $��
140,90,0,0q�69   ��6   �� *Rate+$ F2��69   �� 5   
   $��
10,130,0,0q�6   .��6$   
Grivnyas6.   �� 5   
   $
��Left=�6>   $	��Top=�6Y   $��140,130,0,0q�6q   $	��125��6�   ��6   �� *	Grivnya+$ F2��6�   �� 5    
   $��Right=�6   $��Bottom=�6-   $��	0,0,70,10q�6H   $��50��6[   	 �� 	IsDefault	 . ��6f   �� *SaveCommand+.��6�   Save6�   �� 5!   
   -   5        $��Right=�5!      $��Bottom=�6-   $��	0,0,10,10q�6H   $��50��6[   
 �� IsCancel
 . .��6�   Cancel6�   5"      5#      