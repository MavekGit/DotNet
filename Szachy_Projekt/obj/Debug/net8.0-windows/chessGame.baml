   M S B A M L   `   `   `  ����I  ESzachy_Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Szachy_ProjektSzachy_Projekt  5          Szachy_Projekt.chessGame   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Szachy_Projekt     5        N� Title$  	chessGame��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��0.5625* �6   �� 5      $��0.4375* �6    � RowDefinitions 5   
   .+�5   
   A� -   5         A�Name$ UGrid��5       A� Rows$ 8��6%    A� Columns$ 8��6.   $��0��6:   5      � 5   
   -   5         �Name$ MGrid��5      $��1��6    5      �� 5       $
��0.1* �6    �� 5!      $
��0.1* �6    �� 5"      $
��0.1* �6    �� 5#      $
��0.1* �6    �� 5$      $
��0.1* �6    �� 5%      $
��0.1* �6    �� 5&      $
��0.1* �6    �� 5'      $
��0.1* �6    �� 5(      $
��0.1* �6    �� 5)      $
��0.1* �6     5,      �� 5-      $��0.25* �6#   �� 5.      $
��0.5* �6#   �� 5/      $��0.25* �6#   .+�52      �� -   5         ��Name$	 PTM��52      $��0��6%   $��1��62   $��White to move��6B   $��Center=�6W   $��Center=�6r   $��24(�6�   �� 54      $��3��6   $��1��6%   $��	Time Left��65   $��Center=�6F   $��Center=�6a   $��24(�6~   �� 56      $��2��6   $��0��6%   $��Black��65   $��Center=�6B   $��Center=�6]   $��24(�6z   �� 58      $��2��6   $��3��6%   $��White��65   $��Center=�6B   $��Center=�6]   $��24(�6z   �� 5:      $��3��6   $��0��6%   $��X��65   $��Center=�6>   $��Center=�6Y   $��24(�6v   �� 5<      $��3��6   $��2��6%   $��X��65   $��Center=�6>   $��Center=�6Y   $��24(�6v   �� 5>      $��1��6   $��1��6%   �� 5@      $��6��6   $��1��6"   $��Undo the move��62   6L   �� 5B      -   5        $��8��5B      $��1��6"   $��
Reset Game��62   6^   5D      5F      5I      