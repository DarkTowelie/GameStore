   M S B A M L   `   `   `  ����D  @GameStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GameStore	GameStore  5   	   E'clr-namespace:GameStore.CustomControllsGameStore.CustomControlls  5   	       GameStore.Views.RegWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:GameStore     5   	   BcustomControls'clr-namespace:GameStore.CustomControlls     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5
   	   $	��450��5   	   $	��800��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � -   5         �Name$ MainGrid��5       � RowDefinitions 5   
   �� 5      $	��40* �6   �� 5      $
��415* �6   .+�5   
   � $��1��6   ��5      �� 5         RegBack �� ImageSource# [  6    5      �� 5      $	��45* �6    �� 5      $	��40* �6    �� 5      $	��15* �6    �� 5       $	��40* �6    �� 5!      $	��15* �6    �� 5"      $	��40* �6    �� 5#      $	��15* �6    �� 5$      $	��40* �6    �� 5%      $	��15* �6    �� 5&      $	��40* �6    �� 5'      $	��10* �6     � ColumnDefinitions 5)      �� 5*      $	��25* �6#   �� 5+      $	��85* �6#   �� 5,      $
��100* �6#   .+�5.      �� -   5         ��Name$ tbLogin��5.      $��1��5/      $��1��50       ! MaterialDesignOutlinedTextBox#��[ 51      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 
Логин��52      .  (MaterialDesignThemes.Wpf.TextFieldAssist
   UnderlineBrush
 �	#FF8D00D2
�������$��Center=�56       � Cursor$ Arrow��68   $��15(�57      ��55      �� *
LoginColor+��58      �� *NewUserLogin+�� 5:      -   5        $ tbEmail��5:      $��3��5;      $��1��5<      #��[ 5=      $	 
Почта��5>      
 �	#FF8D00D2
�������$��Center=�5B      $ Arrow��68   $��15(�5C      ��5A      �� *
EmailColor+��5D      �� *NewUserEmail+G� 5F      -   5         G�Name$ 
pbPassword��5F      $��5��5G      $��1��5H       % !MaterialDesignOutlinedPasswordBox#��[ 5I      $	 Пароль��5J      
 �	#FF8D00D2
�������$��Center=�5N      $��15(�5O      $ Arrow��6$   ��5M      �� *PasswordColor+5O   $   � 5Q      $��9��6   $��1��6     5R      �� 5S      $
��145* �6'   �� 5T      $	��50* �6'   �� 5U      $
��135* �6'   .+�5W      �� -   5         ��Name$ bLogin��5W      $��0��5X      $��0��5Y      ���	#FF484848
�������$
 Hand��5\      $��14(�5]      $��Center=�5^      $��
НАЗАД��5_      ���	#FF484848��5a      �� *ChangeToMainWindow+�� 5c      -   5        $ bAddUser��5c      $��0��5d      $��2��5e      ���	#FF484848
�������$
 Hand��5h      $��14(�5i      $��Center=�5j      $��РЕГИСТРАЦИЯ��5k      ���	#FF484848��5m      �� *
AddNewUser+��5n      ��  �� ElementName$ 
pbPassword��5p      5q      5r      5s      5t      