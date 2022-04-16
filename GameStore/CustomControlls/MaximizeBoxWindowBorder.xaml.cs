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
    /// <summary>
    /// Логика взаимодействия для MaximizeBoxWindowBorder.xaml
    /// </summary>
    public partial class MaximizeBoxWindowBorder : UserControl
    {
        Window parent;
        public MaximizeBoxWindowBorder(Window parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            this.parent.Close();
        }

        private void bMaximize_Click(object sender, RoutedEventArgs e)
        {
            if(parent.WindowState == WindowState.Maximized)
            {
                parent.WindowState = WindowState.Normal;
            }
            else
            {
                parent.WindowState = WindowState.Maximized;
            }
        }

        private void bHide_Click(object sender, RoutedEventArgs e)
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
