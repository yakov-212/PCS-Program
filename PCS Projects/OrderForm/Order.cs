using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OrderForm;


namespace Orders
{
    internal class Order
    {
        Customer customer;
        Item[] items; //= new Item[100];
        private int myVar;
        //Address add;
        int counter = 0;
        static double taxRate = .0775;

        public Item[] Items
        {
            get
            {
                return getItems();
            }
        }
        private Item[] getItems2()
        {
            Item[] itemArr = new Item[counter];
            Array.Copy(items, itemArr, counter);
            //items.CopyTo(itemArr, 0);
            //itemArr = (Item[])items.Clone();
            return itemArr;
        }
        private Item[] getItems()
        {
            Item[] itemArr = new Item[counter];
            for (int i = 0; i < counter; i++)
                itemArr[i] = new Item(items[i]);
            return itemArr;
        }


        public Order()
        {
            items = new Item[100];
            //add = new Address();
            customer = new Customer();
        }
        public Order(int numItems) : this()
        {
            //this();
            items = new Item[numItems];
            
        }
        public Order(string name,double discount, int numItems = 100) : this(numItems)
        {
            customer = new Customer(name, discount);
        }
        //public Order(string addr, string city, string st, string zip, int numItems = 100) : this(numItems)
        //{
        //    if (this.add != null)
        //    {
        //        add.City = city;
        //        add.Add = addr;
        //        add.State = st;
        //        add.Zip = zip;
        //    }
        //}

        public Order(params Item[] items) : this()
        {
            this.items = items;
            counter = items.Length;
        }
        public void AddItem2(Item item)
        {
            if (item != null)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] == null)
                    {
                        items[i] = item;
                        break;
                    }
                }
            }
        }
        public void AddItem(Item item)
        {
            if (counter == items.Length)
                return;
            if (item != null)
            {
                items[counter++] = item;
            }
        }
        //public void SetAddress(string addr, string city, string st, string zip)
        //{
        //    if (this.add != null)
        //    {
        //        add.City = city;
        //        add.Add = addr;
        //        add.State = st;
        //        add.Zip = zip;
        //    }
        //}
        public decimal GetSubtotal()
        {
            decimal total = 0;
            for (int i = 0; i < counter; i++)
            {
                if (items[i] != null)
                    total += (decimal)(items[i].Price - (items[i].Price*(customer.Discount/100)) );
            }
            return total;
        }

        public decimal GetTax()
        {
            decimal total = 0;
            for (int i = 0; i < counter; i++)
            {
                if (items[i] != null)
                    total += (items[i].Taxable ? (decimal)(items[i].Price * taxRate) : 0);
            }
            return total;
        }
        

       
        public void Print()
        {
            //add.Print();
            Console.WriteLine($"Customer is  {customer.Name}");
            Console.WriteLine($"There {(counter > 1 ? "are" : "is")} {counter} item{(counter > 1 ? "s" : "")}");
            foreach (var item in items)
            {
                if (item != null)
                    item.Print();
            }
            if (customer.Discount > 0)
            {
                Console.WriteLine($"Appling customers discount of {customer.Discount}% off all products");
            }
            decimal subt = GetSubtotal();
            Console.WriteLine($"{"Subtotal:",-14} {subt:C}");
            decimal tax = GetTax();
            Console.WriteLine($"{"Tax:",-14} {tax:C}");
            Console.WriteLine($"{"Total:",-14} {tax + subt:C}");
        }
    }
}
