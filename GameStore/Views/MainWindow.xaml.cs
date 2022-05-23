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
    }
}
