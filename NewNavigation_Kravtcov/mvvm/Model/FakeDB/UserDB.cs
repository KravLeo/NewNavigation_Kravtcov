using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNavigation_Kravtcov.mvvm.Model.FakeDB
{
    public class UserDB
    {
        private List<User> users = new List<User>();

        public async Task<bool> Register(User user)
        {
            if (users.Any(u => u.Username == user.Username))
            {
                return false; // Пользователь уже существует
            }

            users.Add(user);
            await Task.Delay(100);
            return true;
        }

        public async Task<bool> Login(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            await Task.Delay(100);
            return user != null;
        }

        public async Task<bool> LoginAsGuest()
        {
            await Task.Delay(500);
            return true; // Гостевой вход всегда успешен
        }
    }
}
