using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameStore.CustomControlls
{
    public partial class WindowBorder : UserControl
    {
        Window parent;

        public WindowBorder(Window parent)
        {
            this.parent = parent;
            InitializeComponent();

            Button closeButton = new Button();
            closeButton.Name = "bClose";
            closeButton.SetValue(Grid.ColumnProperty, 2);
            closeButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8D00D2"));
            closeButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            closeButton.Content = "X";
            closeButton.VerticalContentAlignment = VerticalAlignment.Center;
            closeButton.HorizontalAlignment = HorizontalAlignment.Center;
            closeButton.Click += Close_Click;
            MainGrid.Children.Add(closeButton);


            Button hideButton = new Button();
            hideButton.Name = "bHide";
            hideButton.SetValue(Grid.ColumnProperty, 1);
            hideButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF005047"));
            hideButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            hideButton.Content = "_";
            hideButton.VerticalContentAlignment = VerticalAlignment.Center;
            hideButton.HorizontalAlignment = HorizontalAlignment.Center;
            hideButton.Click += Hide_Click;
            MainGrid.Children.Add(hideButton);
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.parent.Close();
        }

        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            this.parent.WindowState = WindowState.Minimized;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                parent.DragMove();
        }
    }
}
