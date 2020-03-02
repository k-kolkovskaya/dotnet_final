using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SushiBot
{
    class MenuReader
    {
        private const string Path = @"D:\Kristush\Projects\SushiBot\sushi.json";

        public List<MenuItem<int>> WriteDataToMenu()
        {
            try
            {
                List<MenuItem<int>> restoredMenuItems = JsonConvert.DeserializeObject<List<MenuItem<int>>>(File.ReadAllText(Path));
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
