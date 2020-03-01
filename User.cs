using System;

namespace SushiBot
{
    class User
    {
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public String Name { get; set; }
        public String Email { get; set; }
    }
}
