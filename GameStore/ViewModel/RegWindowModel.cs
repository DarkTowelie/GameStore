using GameStore.Commands;
using GameStore.Model;
using GameStore.ModelContext;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        Brush emailColor;
        public Brush EmailColor
        {
            get { return emailColor; }
            set
            {
                emailColor = value;
                OnPropertyChanged("EmailColor");
            }
        }

        Brush loginColor;
        public Brush LoginColor
        {
            get { return loginColor; }
            set
            {
                loginColor = value;
                OnPropertyChanged("LoginColor");
            }
        }

        Brush passwordColor;
        public Brush PasswordColor
        {
            get { return passwordColor; }
            set
            {
                passwordColor = value;
                OnPropertyChanged("PasswordColor");
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

                            LoginColor = LoginData.CheckLogin(newUserLogin) ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
                            EmailColor = LoginData.CheckEmail(newUserEmail) ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
                            PasswordColor = LoginData.CheckPassword(pb.Password) ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);

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

        public RegWindowModel()
        {
            LoginColor = new SolidColorBrush(Colors.Black);
            EmailColor = new SolidColorBrush(Colors.Black);
            PasswordColor = new SolidColorBrush(Colors.Black);
        }
        public void CloseWindow() => EventCloseWindow?.Invoke(this, EventArgs.Empty);
    }
}
