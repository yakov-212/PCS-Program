using System.ComponentModel.DataAnnotations;

namespace Bingo
{
    internal class Bingo
    {
        static Random rand = new Random();
        static int[] calledNums = new int[76];
        static void Main(string[] args)
        {
            BingoCard card = new BingoCard();
            int num;
            string[] letters = { "B", "I", "N", "G", "O" };
            card.FillCard();
            for (int i = 0; i < 75; i++)
            {
                num = GetNum(i);
                card.PrintCard();
                Console.WriteLine($"{letters[(num-1) / 15]}{num}");
                Console.ReadLine();
                CheckNum(card, num);
                if (CheckBingo(card))
                {
                    Console.Clear();
                    card.PrintCard();
                    Console.WriteLine("Bingo!!");
                    break;
                }
                Console.Clear();

            }










        }

        static int GetNum(int index)
        {
            
            int num = -1;
            bool again;
            
            do
            {
                again = false;
                num = rand.Next(1, 76);
                calledNums[index] = num;
                for (int i = 0; i < index; i++)
                {
                    if (num == calledNums[i])
                        again = true;

                }
                
            }
            while (again);
            
            return num;
        }

        static void CheckNum(BingoCard card,int num)
        {
            for (int i = 0; i < card.Card.Length; i++)
            {
                int row = i / card.Size;
                int col = i % card.Size;
                
                if (card.Card[row, col] == num)
                {
                    card.Card[row,col] = 0;
                    return;
                }
            }

        }

        static bool CheckBingo(BingoCard card) {
            int bingoRow = 0;
            int bingoCol = 0;
            int bingoDiagRight= 0;
            int bingoDiagLeft= 0;
            for (int i = 0; i < card.Card.Length; i++)
            {

                int row = i / card.Size;
                int col = i % card.Size;


                if (col == 0)
                    bingoCol = 0;
                if (row == 0)
                    bingoRow = 0;


                if (card.Card[row, col] == 0)
                    bingoRow += 1;
                else
                    bingoRow = 0;
                if (card.Card[col, row] == 0)
                    bingoCol += 1;
                else
                    bingoCol = 0;

                if (row == col)
                {
                    if (card.Card[row, col] == 0)
                        bingoDiagLeft += 1;
                }
                if (row + col == card.Size - 1)
                {
                    if (card.Card[row, col] == 0)
                        bingoDiagRight += 1;
                }


                if (bingoRow == card.Size || bingoCol == card.Size || bingoDiagLeft == card.Size || bingoDiagRight == card.Size)
                    return true;
            }
            return false;
        }


    }
}
