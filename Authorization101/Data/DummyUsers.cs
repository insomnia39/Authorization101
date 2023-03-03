using Authorization101.Model;
using System.Collections.Generic;
using System.Linq;

namespace Authorization101.Data
{
    public class DummyUsers
    {
        public static List<User> Users = new List<User>()
        {
            new User("1", "Udin", "udin123"),
            new User("2", "Junet", "junet123"),
            new User("3", "Bambang", "bambang123")
        };

        public static User FindUser(string Name, string Password)
        {
            return Users.FirstOrDefault(p => p.Name == Name && p.Password == Password); 
        }
    }
}
