   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApp3.WindowsWpfApp3.Windows  5   	   $    WpfApp3.Windows.PlayListWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApp3.Windows     5   	     � Title$  Add Remove Create��5   	   $	��200��6#   $	��400��60   ���	#FF1E1E1E � 
ResizeMode$ NoResize=�6S   .��5	      � .+�5
   
   �� $��PlayList Name: ��6   $��0q�6*   $
��Left=�66   $��10, 100, 0, 0q�6Q   $	��Top=�6h   
�������6�   �� 5   
   -   5        $��txtPlayListName��5      $��0q�6)   $��20��65   $	��140��6A   $
��Left=�6M   $	��Top=�6h   $��100, 100, 0, 0q�6�   ���	#FF1E1E1E
�������
�������6�   �� 5   
   -   5        $��btnCreateAndAdd��5      $��Create and Add��6F   $��30��6_   $	��100��6k   $
��Left=�6w   $	��Top=�6�   $��250, 95, 0, 0q�6�   6�   �� 5   
   -   5        $��btnAdd��5      $	��Add��64   $��30��6B   $��40��6N   $
��Left=�6Y   $	��Top=�6t   $��310, 130, 0, 0q�6�   6�   �� 5   
   -   5        $��btnRemovePlaylist��5      $��Remove PlayList��6K   $��30��6e   $	��100��6q   $
��Left=�6}   $	��Top=�6�   $��10, 130, 0, 0q�6�   6�   �� 5   
   -   5         ��Name$ lbPlayLists��5      $y�Visible=�5      ���	#FF1E1E1E$��2��5      $��90��5      $	��400��5      $	��Top=�5      
�������5      5      5      