using System;

namespace SushiBot
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderBot orderBot = new OrderBot();
            orderBot.Notify += DisplayMessage;
            orderBot.Start();
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
