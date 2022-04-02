using GameStore.Commands;
using GameStore.Model;
using GameStore.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace GameStore.ViewModel
{
    internal class MainWindowModel : INotifyPropertyChanged
    {
        User currentUser;
        string currentUserLogin;
        string currentUserPassword;
        public User CurrentUser
        {
            get { return currentUser; }
            set 
            {
                currentUser = value;
                OnPropertyChanged("NewUser");
            }
        }

        public string CurrentUserLogin
        {
            get { return currentUserLogin; }
            set
            {
                currentUserLogin = value;
                OnPropertyChanged("CurrentUserLogin");
            }
        }

        public string CurrentUserPassword
        {
            get { return currentUserPassword; }
            set
            {
                currentUserPassword = value;
                OnPropertyChanged("CurrentUserPassword");
            }
        }

        private BaseCommands createRegWindow;
        public BaseCommands CreateRegWindow
        {
            get
            {
                return createRegWindow ??
                    (createRegWindow = new BaseCommands(obj =>
                    {
                        RegWindow regWindow = new RegWindow();
                        regWindow.Show();
                        Window window = (Window)obj;
                        window.Close();
                    }));
            }
        }

        private BaseCommands loginUser;
        public BaseCommands LoginUser
        {
            get
            {
                return loginUser ??
                    (loginUser = new BaseCommands(obj =>
                    {
                        currentUser = new User(0, "", "", "");
                    }));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
