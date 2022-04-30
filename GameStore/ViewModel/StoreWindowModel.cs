using GameStore.Commands;
using GameStore.ModelContext;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GameStore.ViewModel
{
    internal class StoreWindowModel
    {
        public event EventHandler EventCloseWindow;
        public void CloseWindow() => EventCloseWindow?.Invoke(this, EventArgs.Empty);

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
                                        break;
                                    }
                                }
                                db.SaveChanges();
                            }
                        }
                    }));
            }
        }
    }
}
