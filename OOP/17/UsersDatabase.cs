using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace _17
{
    internal class UsersDatabase
    {
        public static Dictionary<string, string> UsersPasswords { get; set; } = new Dictionary<string, string>() {
            { "user", "123" },
        };
        public static Dictionary<string, string> AdminsPasswords { get; set; } = new Dictionary<string, string>() {
            { "admin", "admin"},
        };

        public static Dictionary<string, User> UsersObjects => new()
        {
            {"user", new User("user", "123") },
        };
        public static Dictionary<string, Admin> AdminObjects => new()
        {
            {"admin", new Admin("user", "admin") },
        };

        public static List<User> AllUsers => new()
        {

        };


        public static User? getUserByUsername(string username)
        {
            UsersObjects.TryGetValue(username, out var user);
            return user;
        }

        public static Admin? getAdminByUsername(string username)
        {
            AdminObjects.TryGetValue(username, out var user);
            return user;
        }


    }

}
