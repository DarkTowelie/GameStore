using GameStore.Model;
using GameStore.ModelContext;
using System.Windows;
using System.Linq;

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
                        Game GGStrive = new Game(1, "Gulty Gear Strive", 0, imagesPath + "GuiltyGear Strive.jpg");
                        db.Game.Add(GGStrive);
                        Game ResidentEvil2 = new Game(1, "Resident Evil 2", 0, imagesPath + "GuiltyGear Strive.jpg");
                        db.Game.Add(GGStrive);

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
            catch
            {
                MessageBox.Show("Ошибка инициализации БД.");
            }
        }
    }
}
