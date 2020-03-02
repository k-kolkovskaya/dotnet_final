using Stripe;
using System;
using System.Collections.Generic;

namespace SushiBot
{
    class OrderBot
    {
        public void Start()
        {
            //CreateOrder();
            Email email = new Email();
            email.CreateEMail();
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
            User user = new User(GetName(), GetEmail());

            List<OrderItem> orderItems = new List<OrderItem>();
            while (AddNewItem(orderItems))
            {

            }


            return new Order(orderItems, user, "adopted", new DateTime());
        }


        public OrderItem CreateOrderItem(List<MenuItem<int>> menuItems)
        {
            Console.WriteLine("Enter serial number, please");
            int serialNumber = Convert.ToInt32(Console.ReadLine());

            if(serialNumber == 0)
            {
                return null;
            } 
            else
            {
                OrderItem orderItem = new OrderItem();

                for (int i = 0; i < menuItems.Count; i++)
                {
                    if (menuItems[i].Id == serialNumber)
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
