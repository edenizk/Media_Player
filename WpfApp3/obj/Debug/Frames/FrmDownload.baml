   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfApp3.FramesWpfApp3.Frames  5           WpfApp3.Frames.FrmDownload   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WpfApp3.Frames     5      Lcontrols9http://schemas.microsoft.com/netfx/2009/xaml/presentation    5        N� Title$  FrmDownload��5
      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
dtPlayList��5      $��16(�60    	  data1#���   6m      CanUserAddRows .     CanUserResizeColumns .    CanUserResizeRows .     VerticalGridLinesBrush
 ���� $��0,-3,0,3q�6,  ��6�   Z� ��6�   Z�  � ContextMenu 5      �� 5      .@�5      m� -   5        $��Delete��5      6O   5         Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6)   	   CanUserResize	 .  
   CellTemplate
 5      �� 5      .R�5      �� $��btnPlay��6%   -   5        ��5   J   Z� ��6a   Z� ��5   "   �� 5   &   
imgBtnView�� �� ImageSource$' !/WpfApp3;component/Icons/play.png��6E   5      5      5        5      $ 24 6)   	 .  
 5       �� 5!      .R�5"      �� $��btnAdd��6%   -   5        ��5"   H   Z� ��6_   Z� ��5#   "   �� 5$   &   
imgBtnView��$&  /WpfApp3;component/Icons/add.png��6E   5&      5'      5)      0  *System.Windows.Controls.DataGridTextColumn  5*      -   5        
dgtextPath��   
Foreground
 �����   Header$ 	FILE NAME��5-         
IsReadOnly . $ 4* 5/      	 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 50      �� *FullFileName+51        53      $
 0.5* 54      
 ����� 56      �� *Time+   HeaderTemplate 57      �� 58      .R�59      �� $-��'/WpfApp3;component/Icons/alarm_icon.png��6$   $��20��6U   $��20��6b   5:      5;      5=      5?      5@      5A      