   M S B A M L   `   `   `  ����I  ESzachy_Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Szachy_ProjektSzachy_Projekt  5          Szachy_Projekt.startMenu   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Szachy_Projekt     5        N� Title$  	startMenu��5	       � 	Resources 5         NoMouseOverButtonTemplate �� 
TargetType �� Triggers P� Property P� Value �� Value �� Property��%2  &	        �� 5   
   " ��5      .R�5      �� #��z��6   #��z��5      #��z��5      ._�5      �� #��z��6#   #��z��5      5       5      P� 5       � {�$ False��5   
   . �5      �� # Z�5       � ���� 5      # Z
�5       � ��5      5      5      .��5!      �  � ColumnDefinitions 5"   
   �� 5#      $
��0.3* �6   �� 5$      $
��0.4* �6   �� 5%      $
��0.3* �6   	 � RowDefinitions	 5'   
   �� 5(      $
��0.1* �6   �� 5)      $
��0.1* �6   �� 5*      $
��0.1* �6   �� 5+      $
��0.1* �6   �� 5,      $
��0.1* �6   �� 5-      $
��0.1* �6   �� 5.      $
��0.1* �6   �� 5/      $
��0.1* �6   �� 50      $
��0.1* �6   .+�54   
   �� -   5        
 ��Name$
 mainMenuBtn��54      $$��Naciśnij aby rozpocząć grę��6&   $��4��6K   $��1��6X   
������ $��0q�6�   $��24(�6�   #��[  6�    � FocusVisualStyle 6�   Z�  � Triggers 57      :� 58       :� RoutedEvent$ Button.Loaded��6   [�59      �� 5:      .��5;      ��  g� 	BeginTime 00:00:006)    g� RepeatBehavior$ Forever��6>    �� 
TargetName$ mainMenuBtn��6W    �� TargetProperty$* $(Foreground).(SolidColorBrush.Color)�6{   .��5<   "   ��  �� From	 Black61   	 �� To	 White6>    g� Duration$ 0:0:2D�6I   �� 5=   "   	 White61   	 Black6>   $ 0:0:2D�6I   	 0:0:26Z   5>      5@      5B      5D      5G      5H      