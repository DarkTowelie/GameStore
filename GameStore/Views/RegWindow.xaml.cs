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
            if (LoginData.CheckLogin(tbLogin.Text))
            {
                tbLogin.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbLogin.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
        private void tbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LoginData.CheckEmail(tbEmail.Text))
            {
                tbEmail.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbEmail.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
        private void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (LoginData.CheckPassword(pbPassword.Password))
            {
                pbPassword.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                pbPassword.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
        private void pbRepPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (LoginData.CheckPassword(pbRepPassword.Password))
            {
                pbRepPassword.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                pbRepPassword.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
