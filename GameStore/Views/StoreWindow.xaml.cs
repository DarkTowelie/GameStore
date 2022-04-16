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
        }

        void FillGrid()
        {
            using(DBContext db = new DBContext())
            {
                List<RowDefinition> rows = new List<RowDefinition>();
                int gamesCount = db.Game.Count();
                for (int i = 0; i < gamesCount; i++)
                {
                    rows.Add(new RowDefinition());
                    rows[i * 2].Height = new GridLength(30);
                    rows.Add(new RowDefinition());
                    rows[i * 2 + 1].Height = new GridLength(130, GridUnitType.Star);
                }

                for (int i = 0; i < rows.Count; i++)
                {
                    GamesGrid.RowDefinitions.Add(rows[i]);
                }

                int columnNum = 1;
                int rowNum = 1;
                int index = 0;
                foreach(Game game in db.Game)
                {
                    Image currentImage = new Image();
                    BitmapImage logo = DataTransform.ByteToImage(game.Image);
                    currentImage.Source = logo;
                    currentImage.SetValue(Grid.RowProperty, rowNum);
                    currentImage.SetValue(Grid.ColumnProperty, columnNum);
                    columnNum = (columnNum == 1) ? 3 : 1;
                    GamesGrid.Children.Add(currentImage);
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
