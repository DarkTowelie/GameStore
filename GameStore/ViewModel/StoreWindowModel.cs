using GameStore.Commands;
using GameStore.Model;
using GameStore.ModelContext;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GameStore.ViewModel
{
    internal class StoreWindowModel : INotifyPropertyChanged
    {
        public event EventHandler EventCloseWindow;
        public void CloseWindow() => EventCloseWindow?.Invoke(this, EventArgs.Empty);

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        BitmapImage avatar;
        public BitmapImage Avatar
        {
            get { return avatar; }
            set
            {
                avatar = value;
                OnPropertyChanged();
            }
        }


        private BaseCommands loadAvatar;
        public BaseCommands LoadAvatar
        {
            get
            {
                return loadAvatar ??
                    (loadAvatar = new BaseCommands(obj =>
                    {
                        OpenFileDialog opf = new OpenFileDialog();
                        opf.Filter = "Images (*.jpg)|*.jpg";
                        opf.ShowDialog();
                        if(opf.FileName != "")
                        {
                            BitmapImage image = new BitmapImage(new Uri(opf.FileName));
                            using(DBContext db = new DBContext())
                            {
                                foreach (var u in db.User)
                                {
                                    if (u.Id == LoginData.CurrentUser.Id)
                                    {
                                        u.Avatar = DataTransform.JpgToByte(image);
                                        Avatar = image;
                                        break;
                                    }
                                }
                                db.SaveChanges();
                            }
                        }
                    }));
            }
        }

        public StoreWindowModel()
        {
            using (DBContext db = new DBContext())
            {
                User? currentUser = db.User.Where(u => u.Id == LoginData.CurrentUser.Id).FirstOrDefault();
                if (currentUser.Avatar.Length == 0)
                {
                    var image = new BitmapImage();
                    string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    string folderPath = System.IO.Path.GetDirectoryName(exePath);
                    image.BeginInit();
                    image.UriSource = new Uri(folderPath + "\\Images\\" + "defAvatar.jpg");
                    image.EndInit();
                    Avatar = image;
                }
                else
                {
                    Avatar = DataTransform.ByteToImage(currentUser.Avatar);
                }
            }
        }
    }
}
