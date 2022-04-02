using GameStore.CustomControlls;
using System.Windows;
using System.Windows.Controls;
using GameStore.ViewModel;
using GameStore.ModelContext;
using GameStore.Model;
using System.Configuration;

namespace GameStore.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowModel();
            WindowBorder windowBorder = new WindowBorder(this);
            MainGrid.SetValue(Grid.RowProperty, 0);
            MainGrid.Children.Add(windowBorder);
        }

        private void mw_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                UserContext db = new UserContext();
                db.Database.Initialize(false);
            }
            catch
            {
                MessageBox.Show("Ошибка инициализации БД.");
            }
        }
    }
}
