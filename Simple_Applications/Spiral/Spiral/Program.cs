using System;

namespace Spiral
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter dimension: ");
            var dimension = int.Parse(Console.ReadLine());
            if (dimension%2 == 0)
            {
                dimension++;
            }

            int num;
            do
            {
                Console.Write("Enter number in spiral: ");
                num = int.Parse(Console.ReadLine());
            } while (num > dimension*dimension);

            if (num > (dimension-2)*(dimension-2))
            {
                Console.WriteLine("Number not in Range, it is a corner number");
            }
            else
            {
                // populating the grid
                var grid = PopulateGrid(dimension);

                // find user input spiral
                var spiral = GetUserSpiral(grid, num);
                for (int i = 0; i < spiral.GetLength(0); i++)
                {
                    for (int j = 0; j < spiral.GetLength(1); j++)
                    {
                        Console.Write(spiral[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        // find user input spiral within bigger grid
        public static int[,] GetUserSpiral(int[,] grid, int num)
        {
            int spiral_row = 0, spiral_col = 0;
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] == num)
                    {
                        spiral_row = row;
                        spiral_col = col;
                    }
                }
            }

            spiral_row--;
            spiral_col--;

            int[,] spiral = new int[3, 3];
            for (int i = 0; i < spiral.GetLength(0); i++)
            {
                for (int j = 0; j < spiral.GetLength(1); j++)
                {
                    spiral[i, j] = grid[spiral_row+i, spiral_col+j];
                }
            }

            return spiral;
        }

        // Populate grid, given dimension
        public static int[,] PopulateGrid(int dimension)
        {
            // starting point
            int row = dimension/2 , col = dimension/2;

            // new grid
            int[,] grid = new int[dimension, dimension];

            // populate first num
            int num = 1;
            grid[row, col] = num;
            num++;

            // intial params
            int down = 1, left = 2, up = 2, right = 2;
            while (num <= dimension*dimension)
            {
                // go right 1
                col++;
                grid[row, col] = num;
                num++;

                // go down
                for (int i = 0; i < down; i++)
                {
                    row++;
                    grid[row, col] = num;
                    num++;
                }
                down += 2;

                // go left
                for (int i = 0; i < left; i++)
                {
                    col--;
                    grid[row, col] = num;
                    num++;
                }
                left += 2;

                // go up
                for (int i = 0; i < up; i++)
                {
                    row--;
                    grid[row, col] = num;
                    num++;
                }
                up += 2;

                // go right
                for (int i = 0; i < right; i++)
                {
                    col++;
                    grid[row, col] = num;
                    num++;
                }
                right += 2;
            }

            return grid;
        }
    }
}
