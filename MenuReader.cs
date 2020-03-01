using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SushiBot
{
    class MenuReader
    {
        private const string Path = @"D:\Kristush\Projects\SushiBot\sushi.json";

        public List<MenuItem> WriteDataToMenu()
        {
            try
            {
                List<MenuItem> restoredMenuItems = JsonConvert.DeserializeObject<List<MenuItem>>(File.ReadAllText(Path));
                return restoredMenuItems;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }
    }
}
