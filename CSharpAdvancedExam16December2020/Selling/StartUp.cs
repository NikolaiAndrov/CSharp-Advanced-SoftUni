namespace Selling
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] bakery = new char[n, n];

            int myRow = 0;
            int myCol = 0;

            int pillar1Row = 0;
            int pillar1Col = 0;
            int pillar2Row = 0;
            int pillar2Col = 0;
            bool isFirst = true;

            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                char[] items = Console.ReadLine().ToCharArray();

                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    bakery[row, col] = items[col];

                    if (items[col] == 'S')
                    {
                        myRow = row;
                        myCol = col;
                    }

                    if (items[col] == 'O' && isFirst)
                    {
                        pillar1Row = row;
                        pillar1Col = col;
                        isFirst = false;
                    }
                    else if (items[col] == 'O' && !isFirst)
                    {
                        pillar2Row = row;
                        pillar2Col = col;
                    }
                }

            }
               
            int money = 0;

            while (money < 50)
            {
                string direction = Console.ReadLine();
                bakery[myRow, myCol] = '-';

                if (direction == "right")
                {
                    myCol++;
                }
                else if (direction == "left")
                {
                    myCol--;
                }
                else if (direction == "up")
                {
                    myRow--;
                }
                else if (direction == "down")
                {
                    myRow++;
                }

                if (IsOutside(bakery, myRow, myCol))
                {
                    break;
                }

                if (char.IsDigit(bakery[myRow, myCol]))
                {
                    string sumAsStr = bakery[myRow, myCol].ToString();
                    money += int.Parse(sumAsStr);
                    bakery[myRow, myCol] = 'S';
                }
                else if (bakery[myRow, myCol] == '-')
                {
                    bakery[myRow, myCol] = 'S';
                }
                else if (bakery[myRow, myCol] == 'O')
                {
                    if (myRow == pillar1Row && myCol == pillar1Col)
                    {
                        bakery[myRow, myCol] = '-';
                        myRow = pillar2Row;
                        myCol = pillar2Col;
                        bakery[myRow, myCol] = 'S';
                    }
                    else if (myRow == pillar2Row && myCol == pillar2Col)
                    {
                        bakery[myRow, myCol] = '-';
                        myRow = pillar1Row;
                        myCol = pillar1Col;
                        bakery[myRow, myCol] = 'S';
                    }
                }
            }

            if (money < 50)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
                Console.WriteLine($"Money: {money}");
            }
            else if (money >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
                Console.WriteLine($"Money: {money}");
            }

            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    Console.Write(bakery[row, col]);
                }

                Console.WriteLine();
            }
        }

        static bool IsOutside<T>(T[,] matrix, int row, int col)
            => row < 0 || row >= matrix.GetLength(0) ||
               col < 0 || col >= matrix.GetLength(1);
    }
}
