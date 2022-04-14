using GameStore.CustomControlls;
using GameStore.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GameStore.Views
{
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
            WindowBorder windowBorder = new WindowBorder(this);
            MainGrid.SetValue(Grid.RowProperty, 0);
            MainGrid.Children.Add(windowBorder);
        }

        private void tbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbLogin.Foreground = LoginData.CheckLogin(tbLogin.Text) ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }
        private void tbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbEmail.Foreground = LoginData.CheckEmail(tbEmail.Text) ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }
        private void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pbPassword.Foreground = LoginData.CheckPassword(pbPassword.Password) ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }
        private void pbRepPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pbRepPassword.Foreground = LoginData.CheckPassword(pbRepPassword.Password) ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }
    }
}
