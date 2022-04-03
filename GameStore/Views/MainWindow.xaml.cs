using GameStore.CustomControlls;
using System.Windows;
using System.Windows.Controls;
using GameStore.Model;
using System.Windows.Media;

namespace GameStore.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowBorder windowBorder = new WindowBorder(this);
            MainGrid.SetValue(Grid.RowProperty, 0);
            MainGrid.Children.Add(windowBorder);
        }

        private void tbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(LoginData.CheckLogin(tbLogin.Text))
            {
                tbLogin.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbLogin.Foreground = new SolidColorBrush(Colors.Red);
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
    }
}
