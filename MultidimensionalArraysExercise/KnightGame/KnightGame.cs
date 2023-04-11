public class KnightGame
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        char[,] board = new char[size, size];
        FillBoard(board);
        int knightsRemoved = 0;

        while (true)
        {
            int maxAttacks = 0;
            int attackingKnightRow = 0;
            int attackingKnightCol = 0;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] != 'K')
                    {
                        continue;
                    }

                    int attacks = 0;

                    //top left
                    if (IsValid(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
                    {
                        attacks++;
                    }

                    //top right
                    if (IsValid(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                    {
                        attacks++;
                    }

                    //left top
                    if (IsValid(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                    {
                        attacks++;
                    }

                    // left down
                    if (IsValid(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                    {
                        attacks++;
                    }

                    // right top
                    if (IsValid(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                    {
                        attacks++;
                    }

                    //right down
                    if (IsValid(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                    {
                        attacks++;
                    }

                    // bottom left
                    if (IsValid(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                    {
                        attacks++;
                    }

                    // bottom right
                    if (IsValid(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                    {
                        attacks++;
                    }

                    if (attacks > maxAttacks)
                    {
                        maxAttacks = attacks;
                        attackingKnightRow = row;
                        attackingKnightCol = col;
                    }
                }   
            }

            if (maxAttacks > 0)
            {
                board[attackingKnightRow, attackingKnightCol] = '0';
                knightsRemoved++;
            }
            else if (maxAttacks == 0)
            {
                break;
            }
        }

        Console.WriteLine(knightsRemoved);
    }

    static bool IsValid(char[,] board, int row, int col)
    {
        return row >= 0 && row < board.GetLength(0) &&
            col >= 0 && col < board.GetLength(1);
    }
    static void FillBoard(char[,] board)
    {
        for (int row = 0; row < board.GetLength(0); row++)
        {
            string figures = Console.ReadLine();

            for (int col = 0; col < board.GetLength(1); col++)
            {
                board[row, col] = figures[col];
            }
        }
    }
}