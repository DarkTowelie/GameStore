   M S B A M L   `   `   `  ����D  @GameStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GameStore	GameStore  5   	   9!clr-namespace:GameStore.ViewModelGameStore.ViewModel  5   	   E'clr-namespace:GameStore.CustomControllsGameStore.CustomControlls  5	   	        GameStore.Views.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:GameStore     5   	   0vm!clr-namespace:GameStore.ViewModel     5   	   BcustomControls'clr-namespace:GameStore.CustomControlls     5	   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5          �Name$  mw��5   	    � Title$ 
MainWindow��5   	   $	��450��5   	   $	��800��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � -   5         �Name$ MainGrid��5       � RowDefinitions 5   
   �� 5      $	��40* �6   �� 5      $
��415* �6   .+�5   
   � $��1��6   ��5      �� 5         AuthBack �� ImageSource# [  6    5      �� 5      $	��45* �6    �� 5      $	��40* �6    �� 5       $	��15* �6    �� 5!      $	��40* �6    �� 5"      $	��15* �6    �� 5#      $	��40* �6    �� 5$      $
��100* �6     � ColumnDefinitions 5&      �� 5'      $	��25* �6#   �� 5(      $	��85* �6#   �� 5)      $
��100* �6#   .+�5+      �� -   5        	 ��Name$	 tbLogin��5+      $��1��5,      $��1��5-       ! MaterialDesignOutlinedTextBox#��[ 5.      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 
Логин��5/      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush �	#FF8D00D2
�������$��Center=�52       � Cursor$ Arrow��68   $��15(�53      ��54      �� *CurrentUserLogin+ �� UpdateSourceTrigger$ PropertyChanged=���55      ��  �� Path$ 
LoginColor�G� 57      -   5         G�Name$ 
pbPassword��57      $��3��58      $��1��59       % !MaterialDesignOutlinedPasswordBox#��[ 5:      $
 Пароль��5;       �	#FF8D00D2
�������$��Center=�5>      $��15(�5?      $ Arrow��5A      ��5@      �� $ PasswordColor�5A      � 5C      $��5��6   $��1��6     5D      �� 5E      $
��145* �6'   �� 5F      $	��50* �6'   �� 5G      $
��135* �6'   .+�5I      �� -   5         ��Name$ bLogIn��5I      $��0��5J      $��0��5K      ���	#FF484848
�������$
 Hand��5N      $��14(�5O      $��Center=�5P      $��
ВОЙТИ��5Q      ���	#FF484848��5S      �� *	LoginUser+��5T      ��  �� ElementName$ 
pbPassword���� 5V      -   5        $ bOpenReg��5V      $��0��5W      $��2��5X      ���	#FF484848
�������$
 Hand��5[      $��14(�5\      $��Center=�5]      $��РЕГИСТРАЦИЯ��5^      ���	#FF484848��5`      �� *ChangeToRegWindow+5b      5c      5d      5e      