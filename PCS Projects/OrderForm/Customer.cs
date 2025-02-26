using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderForm
{
    internal class Customer
    {
        private string name;
        private string add;
        private double discount;

        public string Name { get { return name; }}
        public double Discount { get { return discount; } }
        
        public Customer() {
            name = "John Doe";
            discount = 0;
        }
        public Customer(string name,double discount) { 
            this.name = name;
            this.discount = discount;

        }

    }
}
