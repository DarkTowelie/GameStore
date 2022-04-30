using GameStore.CustomControlls;
using GameStore.Model;
using GameStore.ModelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GameStore.Views
{
    public partial class StoreWindow : Window
    {
        public StoreWindow()
        {
            InitializeComponent();
            MaximizeBoxWindowBorder windowBorder = new MaximizeBoxWindowBorder(this);
            MainGrid.SetValue(Grid.RowProperty, 0);
            MainGrid.Children.Add(windowBorder);
            FillGrid();
            LoadAvatar();
        }

        void LoadAvatar()
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
                    iAvatar.Source = image;
                }
                else
                {
                    iAvatar.Source = DataTransform.ByteToImage(currentUser.Avatar);
                }
            }
        }

        void FillGrid()
        {
            using (DBContext db = new DBContext())
            {
                List<RowDefinition> rows = new List<RowDefinition>();
                int gamesCount = db.Game.Count();
                int rowsCount = (gamesCount + 1) / 2;
                for (int i = 0; i < rowsCount; i++)
                {
                    rows.Add(new RowDefinition());
                    rows[i * 2].Height = new GridLength(30);
                    rows.Add(new RowDefinition());
                    rows[i * 2 + 1].Height = new GridLength(130, GridUnitType.Star);
                }
                rows.Add(new RowDefinition());
                rows[rows.Count - 1].Height = new GridLength(30);

                for (int i = 0; i < rows.Count; i++)
                {
                    GamesGrid.RowDefinitions.Add(rows[i]);
                }

                int columnNum = 1;
                int rowNum = 1;
                int index = 0;
                foreach (Game game in db.Game)
                {
                    StackPanel sp = new StackPanel();
                    sp.SetValue(Grid.RowProperty, rowNum);
                    sp.SetValue(Grid.ColumnProperty, columnNum);

                    Label price = new Label();
                    price.HorizontalAlignment = HorizontalAlignment.Center;
                    price.Content = game.Price + " $";

                    Label Name = new Label();
                    Name.HorizontalAlignment = HorizontalAlignment.Center;
                    Name.Content = game.Name;

                    Image currentImage = new Image();
                    BitmapImage logo = DataTransform.ByteToImage(game.Image);
                    currentImage.Source = logo;
                    columnNum = (columnNum == 1) ? 3 : 1;

                    sp.Children.Add(currentImage);
                    sp.Children.Add(Name);
                    sp.Children.Add(price);
                    GamesGrid.Children.Add(sp);

                    if ((index + 1) % 2 == 0)
                    {
                        rowNum += 2;
                    }
                    index++;
                }
            }
        }
    }
}
