using Stripe;
using System;
using System.Collections.Generic;

namespace SushiBot
{
    class OrderBot
    {
        public delegate void OrderHandler(string message);
        public event OrderHandler Notify;
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

        public List<MenuItem<int>> ShowMenu()
        {
            Console.WriteLine("Choose serial number of the sushi that you want");
            MenuReader menuReader = new MenuReader();
            var menuItems = menuReader.WriteDataToMenu();
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"Serial number: {menuItems[i].Id}, item: {menuItems[i].Name}, description: {menuItems[i].Description}, price: {menuItems[i].Price}");
            }
            Console.WriteLine("Enter 0 to stop choosing and to add order");

            return menuItems;
        }

        public Order CreateOrder()
        {
            User user = new User();
            user.Name = GetName();
            user.Email = GetEmail();

            List<OrderItem> orderItems = new List<OrderItem>();
            while (AddNewItem(orderItems))
            {

            }

            double sum = 0;

            for (int i = 0; i < orderItems.Count; i++)
            {
                sum += (orderItems[i].Price * orderItems[i].Count);
            }

            Notify?.Invoke($"Total price is {sum}. The confirmation was sent to {user.Email}");

            Email email = new Email(user.Email);
            email.CreateEMail();
            return new Order(orderItems, user, "adopted", new DateTime());            
        }


        public OrderItem CreateOrderItem(List<MenuItem<int>> menuItems)
        {
            Console.WriteLine("Enter serial number, please");
            string serialNumberString = Console.ReadLine();
            int serialNumberInt;
            if (!Int32.TryParse(serialNumberString, out serialNumberInt))
            {
                Console.WriteLine("That's not integer!!! Enter integer, please!");
            }

            if (serialNumberInt == 0)
            {
                return null;
            } 
            else
            {
                OrderItem orderItem = new OrderItem();

                for (int i = 0; i < menuItems.Count; i++)
                {
                    if (menuItems[i].Id == serialNumberInt)
                    {
                        orderItem.Id = menuItems[i].Id;
                        orderItem.Name = menuItems[i].Name;
                        orderItem.Description = menuItems[i].Description;
                        orderItem.Price = menuItems[i].Price;
                    }
                }

                Console.WriteLine("Enter count from 1 to 10, please");
                int count = Convert.ToInt32(Console.ReadLine());

                orderItem.Count = count;

                return orderItem;
            }
            
        }

        public Boolean AddNewItem(List<OrderItem> orderItems)
        {
            OrderItem newOrderItem = CreateOrderItem(ShowMenu());
            if(newOrderItem != null)
            {
                orderItems.Add(newOrderItem);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
