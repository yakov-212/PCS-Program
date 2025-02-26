using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Metrics;

namespace BattleShip
{
    
    internal class Game
    {
        static Random rand = new Random();
        const int BOARD_SIZE = 11;
        static int[] len= {2,3,3,4,5};
        static char[] LETTERS = { ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        static char[,] board = new char[BOARD_SIZE, BOARD_SIZE];
        static Boats[] ships = MakeBoats();
        
        static void Main(string[] args)
        {

            Play();
            // For Testing Purposes

            //FillBoard();
            //PolpulatBoard();
            //PrintBoard();
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(ships[i].NameBoat);
            //    for (int j = 0; j < ships[i].Len; j++)
            //    {

            //        Console.Write(LETTERS[ships[i].Pos[0][j]]);
            //        Console.Write(ships[i].Pos[1][j] + " ");

            //    }
            //    Console.WriteLine();
            //}


        }

        static void FillBoard()
        {
            char c;
            
            for (int i = 0; i < BOARD_SIZE; i++){
                for (int j = 0; j < BOARD_SIZE; j++){
                    

                    if (i == 0)
                        c = LETTERS[j];
                    else if (i != 0 && j == 0)
                        c = (char)('0'+i);
                    else
                        c = '~';

                    board[i, j] = c;

                }
                
            }
            
        }
        static void PrintBoard()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    Console.Write( $"{board[i, j]} "); 
                }
                Console.WriteLine();
                
            }
            
        }
        static Boats[] MakeBoats()
        {
            Boats aircraft = new Boats();
            Boats battle = new Boats();
            Boats dst = new Boats();
            Boats sub = new Boats();
            Boats pat = new Boats();

            aircraft.NameBoat = "AirCraftCarrier";
            aircraft.Len = len[4];
            battle.NameBoat = "BattleShip";
            battle.Len = len[3];
            dst.NameBoat = "Destroyer";
            dst.Len = len[2];
            sub.NameBoat = "Submarine";
            sub.Len = len[1];
            pat.NameBoat = "PatroleBoat";
            pat.Len = len[0];
            Boats[] ships = { aircraft, battle, dst, sub, pat };
            return ships;
        }
        static void PolpulatBoard()
        {
            
            for (int i = 0; i < ships.Length; i++)
            {
                int dir = rand.Next(4);
                PlaceBoats(i, dir);
            }

            
        }
        // First made four unique placements so I would get a better idea on how to combine them into one
        /*static void Up(int boat)
        {
            int row = rand.Next(1, SIZE);
            int col = rand.Next(ships[boat].Len, SIZE);
            int[][] pos = new int[2][];
            for (int i = 0; i < pos.Length; i++)
            {
                pos[i] = new int[ships[boat].Len];
            }
            for (int i = 0; i < ships[boat].Len; i++)
            {
                pos[0][i] = row;
                pos[1][i] = col - i;
            }
            ships[boat].Pos = pos;

        }

        static void Down(int boat)
        {
            int row = rand.Next(1, SIZE);
            int col = rand.Next(1, SIZE + 1 - ships[boat].Len);
            int[][] pos = new int[2][];
            for (int i = 0; i < pos.Length; i++)
            {
                pos[i] = new int[ships[boat].Len];
            }
            for (int i = 0; i < ships[boat].Len; i++)
            {
                pos[0][i] = row;
                pos[1][i] = col + i;
            }
            ships[boat].Pos = pos;
        }
        static void Right(int boat)
        {
            int row = rand.Next(1, SIZE + 1 - ships[boat].Len);
            int col = rand.Next(1, SIZE);
            int[][] pos = new int[2][];
            for (int i = 0; i < pos.Length; i++)
            {
                pos[i] = new int[ships[boat].Len];
            }
            for (int i = 0; i < ships[boat].Len; i++)
            {
                pos[0][i] = row + i;
                pos[1][i] = col;
            }
            ships[boat].Pos = pos;
        }
        static void Left(int boat)
        {
            int row = rand.Next(ships[boat].Len, SIZE);
            int col = rand.Next(1, SIZE);
            int[][] pos = new int[2][];
            for (int i = 0; i < pos.Length; i++)
            {
                pos[i] = new int[ships[boat].Len];
            }
            for (int i = 0; i < ships[boat].Len; i++)
            {
                pos[0][i] = row - i;
                pos[1][i] = col;
            }
            ships[boat].Pos = pos;
        }*/
        static int[] GetRowCol(int boat, int dir) {
            int row;
            int col;
            int x;
            if (dir>= 2)
            {
                col = rand.Next(1, BOARD_SIZE);

                if (dir%2 == 0)
                {
                    row = rand.Next(ships[boat].Len, BOARD_SIZE);
                    x = -1;
                }
                else
                {
                    row = rand.Next(1, BOARD_SIZE + 1 - ships[boat].Len);
                    x = 1;
                }
            }

            else
            {
                row = rand.Next(1, BOARD_SIZE);

                if (dir % 2 == 0)
                {
                   col = rand.Next(ships[boat].Len, BOARD_SIZE);
                    x = -1;
                }
                else
                {
                    col = rand.Next(1, BOARD_SIZE + 1 - ships[boat].Len);
                    x = 1;
                }
            }
            int[] rowCol = { row, col,x };
            return rowCol;
        }
        static void PlaceBoats(int boat,int dir)
        {
            bool stop = false;
            while (!stop)
            {
                int boatLen = ships[boat].Len;
                int[] rowCol = GetRowCol(boat, dir);
                int row = rowCol[0];
                int col = rowCol[1];
                int x = rowCol[2];
                int[][] pos = new int[2][];
                for (int i = 0; i < pos.Length; i++)
                {
                    pos[i] = new int[boatLen];
                }
                for (int i = 0; i < boatLen; i++)
                {
                    if (dir >= 2)
                    {
                        pos[0][i] = row + (i * x);
                        pos[1][i] = col;
                    }
                    else
                    {
                        pos[0][i] = row;
                        pos[1][i] = col + (i * x);
                    }
                }
                ships[boat].Pos = pos;
                stop = true;
                if (boat != 0)
                    stop = CheckBoat(boat);
            }
            
            
        }
        static bool CheckBoat(int boat)
        {
            for (int k = 0; k < boat; k++)
            {
                for (int i = 0; i < ships[boat].Len - 1; i++)
                {
                    for (int j = 0; j < ships[boat - 1].Len; j++)
                    {
                        int r = ships[boat].Pos[0][i];
                        int c = ships[boat].Pos[1][i];
                        int r1 = ships[boat - 1-k].Pos[0][j];
                        int c1 = ships[boat - 1-k].Pos[1][j];
                        if (r1 == r && c1 == c)
                        {

                            //Console.WriteLine($"{ships[boat].NameBoat} {r} {c}: {ships[boat - 1-k].NameBoat} {r1} {c1}");
                            return false;
                        }

                    }
                }
            }
            return true;
            
        }
        static bool CheckHit(char letter,int num,bool real) {
            int letterNum = -1;
            bool hit = false;
            // Turns letter into an int
            for (int i = 0; i < LETTERS.Length; i++)
            {
                if (LETTERS[i] == letter)
                    letterNum = i;
            }
            //checks if letter was already guessed
            if (!real)
            {
                if (board[num, letterNum] == '~')
                    return true;
                return false;
            }
            // hit is true if same pos as a boat
            for (int i = 0; i < len.Length; i++)
            {
                for (int j = 0; j < ships[i].Len; j++)
                {
                    int shipLetter = ships[i].Pos[0][j];
                    int shipNum = ships[i].Pos[1][j];
                    if (shipLetter == letterNum && shipNum == num)
                    {
                        hit = true;
                        break;
                    }
                }
            }
            if (hit)
                board[num, letterNum] = 'X';
            else
                board[num, letterNum] = '0';
            return hit;

        }
        static int NeedToHit()
        {
            int neededHit = 0;
            for (int i = 0; i < len.Length; i++)
            {
                neededHit += len[i];
            }
            return neededHit;
        }
        static string GetCoordinates(int shellsLeft)
        {
            string guess;
            while (true)
            {
                PrintBoard();
                Console.WriteLine($"{shellsLeft} Shells left");
                Console.WriteLine("Enter the coordinates");
                guess = Console.ReadLine();
                int allowed = (int)Char.ToUpper(guess[0]);
                if (guess.Length > 3 || guess.Length <2)
                {
                    Console.Clear();
                    Console.WriteLine("Only enter one letter and one number");
                    Console.Write("Press Enter to confirm... ");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (allowed < 65 || allowed > 74)
                {
                    Console.Clear();
                    Console.WriteLine("Only enter letters A-J");
                    Console.Write("Press Enter to confirm... ");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    char letter = Char.ToUpper(guess[0]);
                    int num;
                    if (guess.Length > 2)
                        num = 10;
                    else
                        num = Int32.Parse(" " + guess[1]);

                    if (CheckHit(letter, num, false))
                    {
                        CheckHit(letter, num, true);
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("You've already bombed that location");
                    Console.Write("Press Enter to confirm... ");
                    Console.ReadLine();
                    Console.Clear();

                }
            }
            return guess;
        }
        static void Play() {
            Console.WriteLine("We are in the midst of World War III, the Chinease battle fleet are ravaging the Indo-Pacific ocean");
            Console.WriteLine("Luckily for us we have you, the best gosh darn pilot this side of the Mississipi");
            Console.WriteLine("Intel on the Chinease radar systems tells us youll be able to drop 45-55 bombs before they zero in on your possition");
            Console.WriteLine();
            Console.WriteLine("Im sure you remeber but to drop your bombs enter in the coordintas without any spaces; as in A1, B8, or C10");
            Console.WriteLine("The ~ on your display will turn into a 0 for a miss or an X for a hit");
            Console.WriteLine("The entirety of western civilization is counting on you soldier best of luck and G-d bless America");
            Console.WriteLine();
            Console.Write("Press Enter to Continue...");
            Console.ReadLine();
            Console.Clear();

            FillBoard();
            PolpulatBoard();
            int neededHits = NeedToHit();
            int didHit = 0;
            int shells = rand.Next(45, 56);
            int shellsLeft = shells;

            for (int i = 0; i < shells; i++)
            {
                GetCoordinates(shellsLeft);
                shellsLeft--;
                Console.Clear();
              
                if (didHit == neededHits)
                {
                    PrintBoard();
                    Win(shellsLeft);
                    return;
                    
                }     
            }
            PrintBoard();
            Lose();
        }
        static void Win(int shots)
        {
            Console.WriteLine();
            Console.WriteLine("Congradulations on Your Victory!!");
            Console.WriteLine("Your a True American Hero who's saved countless lives");
            Console.WriteLine($"Youve defeated the mighty Chinese Armada and with {shots} shots to spare!! ");
        }
        static void Lose()
        {
            Console.WriteLine();
            Console.WriteLine("We've lost the war and the west has fallen");
            Console.WriteLine();
            Console.WriteLine("Well thats that time to learn some chinease I guess");
            Console.WriteLine("Oh no not you, youll definetly be exucated as a war crimanal for all those ships you sunk");
            Console.WriteLine("Or at least... tried to sink. It was nice knowing you kid");
        }
    }
}
