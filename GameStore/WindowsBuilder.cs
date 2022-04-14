using GameStore.ViewModel;
using GameStore.Views;


namespace GameStore
{
    public static class WindowsBuilder
    {
        public static void ShowMainWindow()
        {
            var window = new MainWindow();
            var viewModel = new MainWindowModel();
            window.DataContext = viewModel;
            viewModel.EventCloseWindow += (sender, args) => { window.Close(); };
            window.Show();
        }

        public static void ShowRegWindow()
        {
            RegWindow regWindow = new RegWindow();
            var viewModel = new RegWindowModel();
            regWindow.DataContext = viewModel;
            viewModel.EventCloseWindow += (sender, args) => { regWindow.Close(); };
            regWindow.Show();
        }

        public static void ShowStoreWindow()
        {
            StoreWindow storeWindow = new StoreWindow();
            var viewModel = new StoreWindowModel();
            storeWindow.DataContext = viewModel;
            viewModel.EventCloseWindow += (sender, args) => { storeWindow.Close(); };
            storeWindow.Show();
        }
    }
}
