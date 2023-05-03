namespace RallyRacing
{
    public class StartUp
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string carNumber = Console.ReadLine();
            string[,] circuit = new string[size, size];

            bool isFirstTunel = true;
            int firstTunelRow = 0;
            int firstTunelCol = 0;
            int secondTunelRow = 0;
            int secondTunelCol = 0;

            for (int row = 0; row < circuit.GetLength(0); row++)
            {
                string[] circuitItems = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < circuit.GetLength(1); col++)
                {
                    circuit[row, col] = circuitItems[col];

                    if (circuitItems[col] == "T" && isFirstTunel)
                    {
                        firstTunelRow = row;
                        firstTunelCol = col;
                        isFirstTunel = false; 
                    }
                    else if (circuitItems[col] == "T" && !isFirstTunel)
                    {
                        secondTunelRow = row;
                        secondTunelCol = col;
                    }
                }
            }

            int carRow = 0;
            int carCol = 0;
            circuit[carRow, carCol] = "C";
            int kilometresPassed = 0;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                circuit[carRow, carCol] = ".";

                if (command == "up")
                {
                    carRow -= 1;
                }
                else if (command == "down")
                {
                    carRow += 1;
                }
                else if (command == "right")
                {
                    carCol += 1;
                }
                else if (command == "left")
                {
                    carCol -= 1;
                }

                if (circuit[carRow, carCol] == ".")
                {
                    kilometresPassed += 10;
                }
                else if (circuit[carRow, carCol] == "T")
                {
                    kilometresPassed += 30;
                    circuit[carRow, carCol] = ".";

                    if (carRow == firstTunelRow && carCol == firstTunelCol)
                    {
                        carRow = secondTunelRow;
                        carCol = secondTunelCol;
                    }
                    else if (carRow == secondTunelRow && carCol == secondTunelCol)
                    {
                        carRow = firstTunelRow;
                        carCol = firstTunelCol;
                    }
                }
                else if (circuit[carRow, carCol] == "F")
                {
                    kilometresPassed += 10;
                    circuit[carRow, carCol] = "C";
                    break;
                }

                circuit[carRow, carCol] = "C";
            }

            if (command == "End")
            {
                Console.WriteLine($"Racing car {carNumber} DNF.");
            }
            else
            {
                Console.WriteLine($"Racing car {carNumber} finished the stage!");
            }
            Console.WriteLine($"Distance covered {kilometresPassed} km.");
            PrintMatrix(circuit);
        }

        static void PrintMatrix<T>(T[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}