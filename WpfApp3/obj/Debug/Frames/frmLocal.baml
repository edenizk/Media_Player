   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfApp3.FramesWpfApp3.Frames  5          WpfApp3.Frames.FrmLocal   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WpfApp3.Frames     5      Lcontrols9http://schemas.microsoft.com/netfx/2009/xaml/presentation    5        N� Title$  frmLocal��5
      .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dtPlayList��5      $��16(�6,    	  data1#���   6i      CanUserAddRows .     CanUserResizeColumns .    CanUserResizeRows .     VerticalGridLinesBrush
 ���� $��0,-3,0,3q�6(  ��6�   Z� ��6�   Z�    Columns 5   
   4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6%      CanUserResize .  	   CellTemplate	 5      �� 5      .R�5      �� $��btnPlay��6!   -   5        ��5   F   Z� ��6]   Z� ��5      �� 5   "   
imgBtnView��
 �� ImageSource$'
 !/WpfApp3;component/Icons/play.png��6A   5      5      5        5      $ 24 6%    .  	 5      �� 5      .R�5      �� $��btnAdd��6!   -   5        ��5   D   Z� ��6[   Z� ��5       �� 5!   "   
imgBtnView��$&
  /WpfApp3;component/Icons/add.png��6A   5#      5$      5&      0  *System.Windows.Controls.DataGridTextColumn  5'      -   5        
dgtextPath��   
Foreground
 �����   Header$ 	FILE NAME��5*         
IsReadOnly . $ 4* 5,       . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5-      �� *FullFileName+5.        50      $ TITLE��51      
 ����� . $ 2* 54       .  55      ��  �� Path$ Title�57        58      $ ARTIST��59      
 �����$ 2* 5;       .  .  5=      �� $ Artist�5?        5@      $ ALBUM��5A      
 �����$ 2* 5C       .  5E      �� *Album+5F        5G      $ 1* 5H      
 ����� 5J      �� *Time+   HeaderTemplate 5K      �� 5L      .R�5M      �� $-��'/WpfApp3;component/Icons/alarm_icon.png��6    $��20��6Q   $��20��6^   5N      5O      5Q      5S      5T      