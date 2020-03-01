using System;
using System.Collections.Generic;
using System.Text;

namespace SushiBot
{
    class OrderItem : MenuItem
    {
        public OrderItem(int count, MenuItem menuItem)
        {
            Count = count;
            MenuItem = menuItem;
        }

        public int Count { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
