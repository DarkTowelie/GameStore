using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace GameStore.Model
{
    public class Game
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public virtual List<User> Users { get; set; } = new();

        public Game()
        {
            Id = 0;
            Name = "";
            Price = 0;
            Image = new byte[0];
        }

        public Game(int id, string name, decimal price, string imagePath)
        {
            Id = id;
            Name = name;
            Price = price;
            BitmapImage image = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            Image = DataTransform.JpgToByte(image);
        }
    }
}
