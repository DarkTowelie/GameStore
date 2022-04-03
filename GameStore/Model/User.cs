using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Model
{

    internal class User
    {
        public int Id { get; private set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Avatar { get; set; }
        public List<Game> Games { get; set; } = new();

        public User()
        {
            Id = 0;
            Login = "";
            Email = "";
            Password = "";
            Avatar = new byte[0];
        }
        public User(int id, string login, string email, string password)
        {
            Id = id;
            Login = login;
            Email = email;
            Password = password;
            Avatar = new byte[0];
        }
    }
}
