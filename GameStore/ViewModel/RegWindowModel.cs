using GameStore.Commands;
using GameStore.Model;
using GameStore.ModelContext;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

        private BaseCommands addNewUser;
        public BaseCommands AddNewUser
        {
            get
            {
                return addNewUser ??
                    (addNewUser = new BaseCommands(obj =>
                    {
                        using (DBContext db = new DBContext())
                        {
                            PasswordBox pb = (PasswordBox)obj;
                            string? password = pb.Password;
                            User? user = db.User.Where(u => u.Login == newUserLogin).FirstOrDefault();

                            if(user == null && LoginData.CheckLogin(newUserLogin) &&
                            LoginData.CheckEmail(newUserEmail) && LoginData.CheckPassword(pb.Password))
                            {
                                if(password != null)
                                {
                                    int maxId = db.User.Max(u => u.Id);
                                    User newUser = new User(maxId + 1, newUserLogin, newUserEmail, password);
                                    db.User.Add(newUser);
                                    db.SaveChanges();
                                    MessageBox.Show("Польователь создан!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пользователь уже существует или данные неверны!");
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
