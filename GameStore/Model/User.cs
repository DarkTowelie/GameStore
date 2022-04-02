using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Model
{
    internal class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {
            Id = 0;
            Login = "";
            Email = "";
            Password = "";
        }

        public User(int id, string login, string email, string password)
        {
            Id = id;
            Login = login;
            Email = email;
            Password = password;
        }
    }
}
