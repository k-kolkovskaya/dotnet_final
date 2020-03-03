using System;

namespace SushiBot
{
    class User
    {
        private string _name;
        public String Name {
            get { return _name; }
            set
            {
                if(value.Length < 3)
                {
                    throw new Exception($"{nameof(Name)} must contain more than 3 letters");
                }
                else
                    _name = value;
            }
        }
        public String Email { get; set; }
    }
}
