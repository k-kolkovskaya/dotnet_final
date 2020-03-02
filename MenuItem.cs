using System;
using System.Collections.Generic;
using System.Text;

namespace SushiBot
{
    class MenuItem<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
