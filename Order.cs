using System;
using System.Collections.Generic;
using System.Text;

namespace SushiBot
{
    class Order
    {
        public Order(List<OrderItem> orderItems, User user, string status, DateTime time)
        {
            OrderItems = orderItems;
            User = user;
            Status = status;
            Time = time;
        }

        public List<OrderItem> OrderItems { get; set; }
        public User User { get; set; }
        public string Status { get; set; }
        public DateTime Time { get; set; }
    }
}
