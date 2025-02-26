
namespace Orders
{
    internal class OrderForm
    {
        static void Main(string[] args)
        {
            string[] a = new string[4];



            ItemDatabase db = new ItemDatabase();
            Order order3 = new Order(db.GetById(100), db.GetById(102), db.GetById(103));
            order3.Print();

            Console.WriteLine("-----------------------------");
            Order order = new Order();
            Item item = new Item();
            item.SetDetails("Lenova", "Laptop", 450.99);
            item.SetDetails("Lenova", "Laptop", 450.99m);
            Item item2 = new Item("HP", "Desktop", 599.99m);
            Item item3 = new Item()
            {
                Name = "Samsung",
                Desc = "Tablet",
                Price = 150.99
            };
            Item item4 = new Item("Kokkosh", "Cake", 13.99m)
            {
                Taxable = false
            };
            item.Print();
            Order order1 = new Order(item, item2, new Item("Micro", "Mouse", 5.99m));
            //order1.SetAddress("617 6th", "Lakewood", "NJ", "08701");

            Order order2 = new Order("yakov", 20, 2);
            //order2.SetAddress("500 6th", "Lakewood", "NJ", "08701");
            order2.AddItem(item);
            order2.AddItem(item2);
            order2.Print();
            Order order4 = new Order(2);
            //order2.SetAddress("500 6th", "Lakewood", "NJ", "08701");
            order4.AddItem(item);
            order4.AddItem(item2);
            order4.Print();

            Item[] items = order2.Items;
            items[0] = item4; //this will change order2 (not anymore because we gave you a copy)
            items[0].Price = .50; //will damage item in order (not anymore he has a copy of an item)
            items = null; //no damage to order2
            items = new Item[0]; //no damage to order2

            order2.Print();
            Item[]? foundByName;
            Item[]? foundByDesc;
            foundByName = db.GetByName("kokkosh");
            foundByDesc = db.GetByDescription("cake");
            Console.WriteLine();
            Console.WriteLine("Found By Name");
            Console.WriteLine();
            for (int i = 0; i < foundByName.Length ; i++)
            {
                Console.WriteLine($"{foundByName[i].Name}, {foundByName[i].Desc}");
            }
            Console.WriteLine();
            Console.WriteLine("Found By Description");
            Console.WriteLine();
            for (int i = 0; i < foundByDesc.Length ; i++)
            {
                Console.WriteLine($"{foundByDesc[i].Name}, {foundByDesc[i].Desc}");
            }

        }
    }
}
