using GameStore.Model;
using GameStore.ModelContext;
using System.Windows;
using System.Linq;
using System;

namespace GameStore
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            WindowsBuilder.ShowMainWindow();
            InitDB();
            base.OnStartup(e);
        }

        void InitDB()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    db.Database.Initialize(false);

                    if (db.User.Count() == 0 && db.Game.Count() == 0)
                    {
                        string imagesPath = @"Images\Games\";

                        Game GGStrive = new Game(1, "Gulty Gear Strive", 2000, imagesPath + "GuiltyGear Strive.jpg");
                        db.Game.Add(GGStrive);

                        Game ResidentEvil2 = new Game(1, "Resident Evil 2", 2000, imagesPath + "ResidentEvil2.jpg");
                        db.Game.Add(ResidentEvil2);

                        Game DevilMayCry5 = new Game(1, "Devil May Cry 5", 2000, imagesPath + "DMC5.jpg");
                        db.Game.Add(DevilMayCry5);

                        Game HalfLife2 = new Game(1, "Half-Life 2", 500, imagesPath + "HL2.jpg");
                        db.Game.Add(HalfLife2);

                        Game TheWitcher3 = new Game(1, "The Witcher 3", 2000, imagesPath + "TheWitcher3.jpg");
                        db.Game.Add(TheWitcher3);

                        Game HuntShowdown = new Game(1, "Hunt Showdown", 2000, imagesPath + "HuntShowdown.jpg");
                        db.Game.Add(HuntShowdown);

                        Game SpaceRangers2 = new Game(1, "Space Rangers 2", 500, imagesPath + "SpaceRangers2.jpg");
                        db.Game.Add(SpaceRangers2);

                        Game DarkestDungeon2 = new Game(1, "Darkest Dungeon 2", 500, imagesPath + "DarkestDungeon2.jpg");
                        db.Game.Add(DarkestDungeon2);

                        User VVS = new User(1, "VVS", "VVS@mail.ru", "Oz23101992!");
                        db.User.Add(VVS);
                        User AAN = new User(2, "AAN", "AAN@mail.ru", "Oz23101992!");
                        db.User.Add(AAN);
                        VVS.Games.Add(GGStrive);
                        VVS.Games.Add(ResidentEvil2);
                        AAN.Games.Add(GGStrive);
                        db.SaveChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации БД: {ex.Message}");
            }
        }
    }
}
