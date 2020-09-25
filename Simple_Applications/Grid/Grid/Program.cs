using System;
using System.IO;

namespace Grid
{
    class Program
    {
        static void Main(string[] args)
        {
            //using var reader = File.OpenText("grid.txt");
            using var reader = File.OpenText("grid.txt");

            var dimension = int.Parse(reader.ReadLine());

            // multi-dimensional array, dimension by dimension
            int[,] grid = new int[dimension, dimension];

            // populating the grid
            for (int i = 0; i < dimension; i++)
            {
                string[] nums = reader.ReadLine().Split();
                for (int j = 0; j < dimension; j++)
                {
                    grid[i, j] = int.Parse(nums[j]);
                }
            }
            var diag_prod = find_maxDiagProd(grid, dimension);

            var linear_prod = find_maxLinearProd(grid, dimension);

            if (diag_prod > linear_prod)
            {
                Console.WriteLine($"Diagonal Product: {diag_prod}");
            }
            else
            {
                Console.WriteLine($"Linear Product: {linear_prod}");
            }

            
        }

        /// <summary>
        /// determine highest diagonal product, Left to Right, given a grid
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="dimension"></param>
        /// <returns> highest product value, diagonal </returns>
        public static int find_maxDiagProd(int[,] grid, int dimension)
        {
            var max_product = 0;

            for (int row = 0; row < dimension-3; row++)
            {
                for (int col = 0; col < dimension-3; col++)
                {
                    int lr_prod = 1, rl_prod = 1;
                    for (int prod_ctr = 0; prod_ctr < 4; prod_ctr++)
                    {
                        lr_prod *= grid[row + prod_ctr, col + prod_ctr];
                        rl_prod *= grid[row + prod_ctr, (dimension-1)-(col+prod_ctr)];
                    }

                    if (lr_prod > max_product)
                    {
                        max_product = lr_prod; 
                    }
                    if (rl_prod > max_product)
                    {
                        max_product = rl_prod;
                    }
                }
            }

            return max_product;
        }

        //public static int diagRL_product(int[,] grid, int dimension)
        //{
        //    var max_product = 0;

        //    for (int row = 0; row < dimension-3; row++)
        //    {
        //        for (int i = 0; i < max; i++)
        //        {

        //        }
        //    }

        //    return max_product;
        //}

        /// <summary>
        /// determine highest row/column product given the grid
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="dimension"></param>
        /// <returns> highest product value, linear </returns>
        public static int find_maxLinearProd(int[,] grid, int dimension)
        {
            // finding the max product value
            var max_product = 0;

            // counter for iteration dimension amt of times
            for (int outer_ctr = 0; outer_ctr < dimension; outer_ctr++)
            {
                // checking row and column
                for (int idx = 0; idx < dimension - 3; idx++)
                {
                    int row_product = 1, col_product = 1;
                    // getting product of 4 numbers
                    for (int product_ctr = 0; product_ctr < 4; product_ctr++)
                    {
                        // calculating prod. along row
                        row_product *= grid[outer_ctr, idx + product_ctr];
                        // calculating prod. along column
                        col_product *= grid[idx + product_ctr, outer_ctr];
                    }

                    // if row product is greater than max, replace
                    if (row_product > max_product)
                    {
                        max_product = row_product;
                    }
                    // if col product is greater than max, replace
                    if (col_product > max_product)
                    {
                        max_product = col_product;
                    }
                }
            }
            return max_product;
        }
    }
}
