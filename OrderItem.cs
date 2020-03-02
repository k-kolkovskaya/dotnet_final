using System;
using System.Collections.Generic;
using System.Text;

namespace SushiBot
{
    class OrderItem : MenuItem<int>
    {
        public int Count { get; set; }
    }
}
