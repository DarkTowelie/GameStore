using GameStore.Commands;
using GameStore.Model;
using GameStore.ModelContext;
using GameStore.Views;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace GameStore.ViewModel
{
    internal class MainWindowModel : INotifyPropertyChanged
    {
        public event EventHandler EventCloseWindow;
        string currentUserLogin;

        public string CurrentUserLogin
        {
            get { return currentUserLogin; }
            set
            {
                currentUserLogin = value;
                OnPropertyChanged("CurrentUserLogin");
            }
        }

        private BaseCommands changeToRegWindow;
        public BaseCommands ChangeToRegWindow
        {
            get
            {
                return changeToRegWindow ??
                    (changeToRegWindow = new BaseCommands(obj =>
                    {
                        WindowsBuilder.ShowRegWindow();
                        CloseWindow();
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
                        PasswordBox pb = (PasswordBox)obj;
                        using (DBContext db = new DBContext())
                        {
                            var users = db.User.ToList();
                            var user = users.Where(u => u.Login == currentUserLogin 
                                                    && u.Password == pb.Password).FirstOrDefault();
                            if(user != null)
                            {
                                LoginData.CurrentUser.Id = user.Id;
                                LoginData.CurrentUser.Login = user.Login;
                                LoginData.CurrentUser.UserEmail = user.Email;
                                WindowsBuilder.ShowStoreWindow();
                                CloseWindow();
                            }
                            else
                            {
                                MessageBox.Show("Пользователь не найден!");
                            }
                        }
                        
                    }));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void CloseWindow() => EventCloseWindow?.Invoke(this, EventArgs.Empty);
    }
}
