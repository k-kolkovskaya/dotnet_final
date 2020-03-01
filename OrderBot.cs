using System;
using System.Collections.Generic;

namespace SushiBot
{
    class OrderBot
    {
        public void Start()
        {
            CreateOrder();
        }

        public string GetName()
        {
            Console.WriteLine("Hi, what's your name?");
            string name = Console.ReadLine();
            return name;
        }

        public string GetEmail()
        {
            Console.WriteLine("Enter your email, please");
            string email = Console.ReadLine();
            return email;  
        }

        public List<MenuItem> ShowMenu()
        {
            Console.WriteLine("Choose serial number of the sushi that you want");
            MenuReader menuReader = new MenuReader();
            var menuItems = menuReader.WriteDataToMenu();
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"Serial number: {menuItems[i].Id}, item: {menuItems[i].Name}, description: {menuItems[i].Description}, price: {menuItems[i].Price}");
            }

            return menuItems;
        }

        public Order CreateOrder()
        {
            User user = new User(GetName(), GetEmail());
            List<OrderItem> orderItems = new List<OrderItem>();
            OrderItem newOrderItem = CreateOrderItem(ShowMenu());

            for (int i = 0; i < newOrderItem.Count; i++)
            {
                orderItems.Add(newOrderItem);
            }

            Console.WriteLine("If you want to continue type Y, else type N");
            string answer = Console.ReadLine();

            if (answer == "Y")
            {
                OrderItem anotherOrderItem = CreateOrderItem(ShowMenu());

                for (int i = 0; i < anotherOrderItem.Count; i++)
                {
                    orderItems.Add(anotherOrderItem);
                }
            }
            else
            {
                return new Order(orderItems, user, "adopted", new DateTime());
            }
        }


        public OrderItem CreateOrderItem(List<MenuItem> menuItems)
        {
            Console.WriteLine("Enter serial number, please");
            int serialNumber = Convert.ToInt32(Console.ReadLine());

            MenuItem menuItem = new MenuItem();

            for (int i = 0; i < menuItems.Count; i++)
            {
                if (menuItems[i].Id == serialNumber)
                {
                    menuItem = menuItems[i];
                }
            }

            Console.WriteLine("Enter count from 1 to 10, please");
            int count = Convert.ToInt32(Console.ReadLine());

            return new OrderItem(count, menuItem);
        }
    }
}
