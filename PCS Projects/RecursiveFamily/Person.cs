using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveFamily
{
    internal class Person
    {
        Person[] children;
        static Random rand = new Random();
        static int numChildren;
        static int numLeaves;
        static int branch;

        public Person(int num) {
            children = new Person[num];
            if (num > 0)
                Console.WriteLine($"Branch {branch} Congrats on {num} children");
            else
                Console.WriteLine($"No children this is the leaf for branch {branch++}");
                

            for (int i = 0; i < num; i++)
            {
                
                
                children[i] = new Person(rand.Next(0,3));
                numChildren++;
            }
            
            
        }
        public override string? ToString()
        {
            if (numLeaves == 0)
                return $"You have {numChildren} children";

            string plural = numLeaves == 1 ? "leaf" : "leaves"; 
            return $"You have {numChildren} children and {numLeaves} {plural}";
        }
        public void FindLeaves(Person child)
        {
            if (child.children.Length == 0)
            {
                numLeaves++;
                return;
            }
            for (int i = 0; i < child.children.Length; i++)
            {
                FindLeaves(child.children[i]);
            }

        }
        
    }
}
