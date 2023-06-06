namespace PawnWars
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            char[,] board = new char[8, 8];

            int whitePawnRow = 0;
            int whitePawnCol = 0;

            int blackPawnRow = 0;
            int blackPawnCol = 0;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = elements[col];

                    if (elements[col] == 'w')
                    {
                        whitePawnRow = row;
                        whitePawnCol = col;
                    }
                    else if (elements[col] == 'b')
                    {
                        blackPawnRow = row;
                        blackPawnCol = col;
                    }
                }
            }

            int iteration = 0;

            while (true)
            {
                if (iteration % 2 == 0)
                {
                    board[whitePawnRow, whitePawnCol] = '-';
                    whitePawnRow--;

                    if (whitePawnRow == 0)
                    {
                        break;
                    }

                    if (IsStepOnPawn(board, whitePawnRow, whitePawnCol - 1))
                    {
                        whitePawnCol--;
                        board[whitePawnRow, whitePawnCol] = 'w';
                        Console.WriteLine($"Game over! White capture on {(char)(97 + whitePawnCol)}{board.GetLength(0) - whitePawnRow}.");
                        Environment.Exit(0);
                    }
                    else if (IsStepOnPawn(board, whitePawnRow, whitePawnCol + 1))
                    {
                        whitePawnCol++;
                        board[whitePawnRow, whitePawnCol] = 'w';
                        Console.WriteLine($"Game over! White capture on {(char)(97 + whitePawnCol)}{board.GetLength(0) - whitePawnRow}.");
                        Environment.Exit(0);
                    }
                    else
                    {
                        board[whitePawnRow, whitePawnCol] = 'w';
                    }
                }
                else if (iteration % 2 != 0)
                {
                    board[blackPawnRow, blackPawnCol] = '-';
                    blackPawnRow++;

                    if (blackPawnRow == board.GetLength(0) - 1)
                    {
                        break;
                    }

                    if (IsStepOnPawn(board, blackPawnRow, blackPawnCol - 1))
                    {
                        blackPawnCol--;
                        board[blackPawnRow, blackPawnCol] = 'b';
                        Console.WriteLine($"Game over! Black capture on {(char)(97 + blackPawnCol)}{board.GetLength(0) - blackPawnRow}.");
                        Environment.Exit(0);
                    }
                    else if (IsStepOnPawn(board, blackPawnRow, blackPawnCol + 1))
                    {
                        blackPawnCol++;
                        board[blackPawnRow, blackPawnCol] = 'b';
                        Console.WriteLine($"Game over! Black capture on {(char)(97 + blackPawnCol)}{board.GetLength(0) - blackPawnRow}.");
                        Environment.Exit(0);
                    }
                    else
                    {
                        board[blackPawnRow, blackPawnCol] = 'b';
                    }
                }

                iteration++;
            }

            if (whitePawnRow == 0)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(97 + whitePawnCol)}{board.GetLength(0) - whitePawnRow}.");
            }
            else if (blackPawnRow == board.GetLength(0) - 1)
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(97 + blackPawnCol)}{board.GetLength(0) - blackPawnRow}.");
            }
        }

        static bool IsStepOnPawn(char[,] board, int row, int col)
            => row >= 0 && row < board.GetLength(0) &&
               col >= 0 && col < board.GetLength(1) &&
               char.IsLetter(board[row, col]);
    }
}