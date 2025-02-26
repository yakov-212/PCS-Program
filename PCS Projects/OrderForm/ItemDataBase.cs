using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    internal class ItemDatabase
    {
        static Item[] items;
        public ItemDatabase()
        {
            items = new Item[] {
                new Item("Kokkosh", "Cake", 13.99m, false),
                new Item("Kokkosh Cinamon", "Cookie", 3.99m, false),
                new Item("Kokkosh Chocolate","Cake",15.99m, false),
                new Item("HP", "Desktop", 599.99m),
                new Item("Lenova", "Laptop", 450.99m),
                new Item("Hat", "Tophat", 50.99m),
                new Item("Micro", "Mouse", 5.99m),
            };
        }
        public Item? GetById(int id)
        {
            Console.WriteLine("In GetById id: " + id);
            foreach (var item in items)
            {
                Console.WriteLine("In foreach item id: " + item.Id);
                string numId = item.Id.Substring(3);
                Console.WriteLine("In foreach item id substring: " + numId);
                if (numId.Equals(id.ToString()))
                {
                    Console.WriteLine("Found match");
                    return item;
                }
            }
            return null;
        }
        public Item[]? GetByName(string name)
        {
            Item[] found = new Item[items.Length];
            int itemsFound = 0;
            if (string.IsNullOrEmpty(name)) return null;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Name.ToLower().StartsWith(name.ToLower()))
                {
                    found[itemsFound] = items[i];
                    itemsFound++;
                }
            }
            if (itemsFound > 0)
            {
                Array.Resize(ref found, itemsFound);
                return found;
            }
            return null;

        }public Item[]? GetByDescription(string desc)
        {
            Item[] found = new Item[items.Length];
            int itemsFound = 0;
            if (string.IsNullOrEmpty(desc)) 
                return null;

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Desc.ToLower().Contains(desc.ToLower()))
                {
                    found[itemsFound] = items[i];
                    itemsFound++;
                }
            }
            if (itemsFound > 0)
            {
                Array.Resize(ref found, itemsFound);
                return found;
            }
            return null;

        }
    }
}