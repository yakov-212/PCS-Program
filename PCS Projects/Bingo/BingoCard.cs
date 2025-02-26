using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    internal class BingoCard
    {
        static Random rand = new Random();
        public static int SIZE = 5;
        static int[,] card = new int[SIZE, SIZE];
        public int[,] Card {  get { return card; } }
        public int Size { get { return SIZE; } }
        

        public void PrintCard()
        {

            int num;
            string lessTen;
            Console.WriteLine("B  I  N  G  O");
            for (int i = 0; i < card.Length; i++)
            {
                num = card[i / SIZE, i % SIZE];
                if (num < 10)
                {
                    lessTen = "0" + num.ToString();
                    if (num == 0)
                        lessTen = "XX";




                    Console.Write($"{lessTen} ");
                }
                else
                    Console.Write($"{num} ");
                if (i % SIZE == SIZE - 1)
                {
                    Console.WriteLine();
                }

            }
        }
        public void FillCard()
        {
            int num;
            for (int i = 0; i < card.Length; i++)
            {
                num = GetNumber(i);

                if (i == card.Length / 2)
                    num = 0;

                card[i / SIZE, i % SIZE] = num;

            }
            
        }
        static int GetNumber(int index)
        {
            bool again;
            int num = -1;
            int randSize = 16 * (index % SIZE);
            do
            {
                again = false;
                num = rand.Next(1 + randSize, 16 + randSize);

                for (int i = 0; i < index; i++)
                {
                    if (num == card[i / SIZE, i % SIZE])
                    {
                        again = true;
                    }
                }
            } while (again);
            return num;

        }

    }
}
