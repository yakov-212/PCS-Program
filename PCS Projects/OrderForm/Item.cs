﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Orders
{
    internal class Item
    {
        private decimal price;
        private static int idGen = 100;

        public Item()
        {
            id += idGen++;
        }

        //public Item(Item another)  {
        //    Name = another.Name;
        //    Desc = another.Desc;
        //    this.price = another.price;
        //    Taxable = another.Taxable;
        //}
        public Item(Item another) : this(another.Name, another.Desc, another.price, another.Taxable)
        {
            this.id = another.id;
            idGen--;
        }

        public Item(string name, string desc, decimal price, bool taxable = true) : this()
        {
            Name = name;
            Desc = desc;
            this.price = price;
            Taxable = taxable;
        }
        private string id = "ID#";
        public string Id
        {
            get { return id; }
        }


        public double Price
        {
            get { return (double)price; }
            set { price = (decimal)value; }
        }

        public string Name { get; set; }
        public string Desc { get; set; }
        //public bool Taxable { get; init; } //init allows to be set in initializer list only
        public bool Taxable { get; set; }
        public void Print()
        {
            Console.WriteLine($"{Name}- {Desc} price: {price:C}");
        }
        [Obsolete("SetDetails is deprecated that uses a double for price use the setDetails that uses a decimal")]
        public void SetDetails(string name, string desc, double price)
        {
            this.Name = name;
            this.Desc = desc;
            this.price = (decimal)price;
        }
        public void SetDetails(string name, string desc, decimal price, bool taxable = true)
        {
            this.Name = name;
            this.Desc = desc;
            this.price = price;
            this.Taxable = taxable;
        }

    }
}