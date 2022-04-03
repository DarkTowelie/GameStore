using GameStore.Commands;
using GameStore.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameStore.ViewModel
{
    internal class RegWindowModel : INotifyPropertyChanged
    {
        public event EventHandler EventCloseWindow;
        
        string newUserLogin;
        string newUserEmail;

        public string NewUserLogin
        {
            get { return newUserLogin; }
            set
            {
                newUserLogin = value;
                OnPropertyChanged("NewUserLogin");
            }
        }

        public string NewUserEmail
        {
            get { return newUserEmail; }
            set
            {
                newUserEmail = value;
                OnPropertyChanged("NewUserEmail");
            }
        }

        private BaseCommands changeToMainWindow;
        public BaseCommands ChangeToMainWindow
        {
            get
            {
                return changeToMainWindow ??
                    (changeToMainWindow = new BaseCommands(obj =>
                    {
                        WindowsBuilder.ShowMainWindow();
                        CloseWindow();
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
