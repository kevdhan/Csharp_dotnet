using System;

namespace MagicSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            // prompt user to enter an odd number 1 or greater
            var input = 0;
            do
            {
                Console.Write("Please enter an odd number, >= 1: ");
                input = int.Parse(Console.ReadLine());

            } while (input % 2 == 0 || input < 1);

            // create magic square
            int[,] magic_square = Make_square(input);

            // print magic square
            Print_square(magic_square);

            // verify if it is a magic square
            int canonical_sum = input * ((input*input) + 1) / 2;

            if (Check_square(magic_square, canonical_sum))
            {
                Console.WriteLine("This is a magic square and the canonical sum is {0}", canonical_sum);
            }
            else
            {
                Console.WriteLine("This is not a magic square");
            }
        }

        /// <summary>
        /// Populate 2D Array with numbers from 1 to num^2. 
        /// </summary>
        /// <param name="num"> Safely assume num>=1 and odd </param>
        /// <returns> returns a populated a 2D Array that represents a magic square </returns>
        public static int[,] Make_square(int num)
        {
            int[,] magic_square = new int[num, num];
            /* 1 placed in middle bottom row
             * next numbers: right and down, wrapping around
             * if right and down spot is taken, then place number 1 space above original spot
             */
            // starting point
            int row = num - 1, col = num / 2;

            for (int magic_num = 1; magic_num < (num*num)+1; magic_num++)
            {
                magic_square[row, col] = magic_num;

                // update column
                int updated_col = col+1;
                if (updated_col == num)
                {
                    updated_col = 0;
                }

                // update row
                int updated_row = row+1;
                if (updated_row == num)
                {
                    updated_row = 0;
                }

                // check if spot already has a number
                if (magic_square[updated_row,updated_col] == 0) // free spot
                {
                    row = updated_row;
                    col = updated_col;
                }
                else // taken
                {
                    updated_row = row - 1;
                    if (updated_row < 0)
                    {
                        updated_row = num - 1;
                    }
                    row = updated_row;
                }
                
            }

            return magic_square;
        }

        /// <summary>
        /// Print the magic square 
        /// </summary>
        /// <param name="magic_square"> Takes in a 2D Array, that represents a magic square </param>
        public static void Print_square(int[,] magic_square)
        {
            var greatestNum_length = Convert.ToString(magic_square.GetLength(0) * magic_square.GetLength(0));
            var rightalignment_format = greatestNum_length.Length;

            for (int row = 0; row < magic_square.GetLength(0); row++)
            {
                for (int col = 0; col < magic_square.GetLength(1); col++)
                {
                    Console.Write($"{magic_square[row,col], 10} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Check that the 2D Array generated is indeed a magic square
        /// </summary>
        /// <param name="magic_square"></param>
        /// <returns> return true if array is a magic square, otherwise false </returns>
        public static bool Check_square(int[,] magic_square, int canonical_sum)
        {
            // returns true if both conditions are met
            return (checksquare_rowcol(magic_square, canonical_sum)
                && checksquare_diag(magic_square, canonical_sum));
        }

        /// <summary>
        /// helper function for Check_square, checks sum of row and columns
        /// </summary>
        /// <param name="magic_square"></param>
        /// <param name="canonical_sum"></param>
        /// <returns> true if sums equal to canonical sum, otherwise false </returns>
        private static bool checksquare_rowcol(int[,] magic_square, int canonical_sum)
        {
            int dimension = magic_square.GetLength(0);

            for (int outer_idx = 0; outer_idx < dimension; outer_idx++)
            {
                int horizontal_sum = 0;
                int vertical_sum = 0;
                for (int inner_idx = 0; inner_idx < dimension; inner_idx++)
                {
                    horizontal_sum += magic_square[outer_idx, inner_idx];
                    vertical_sum += magic_square[inner_idx, outer_idx];
                }

                // if sum does not equal the canonical sum, return false
                if (horizontal_sum != canonical_sum || vertical_sum != canonical_sum)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// helper function for Check_square, checks sum of diagonals
        /// </summary>
        /// <param name="magic_square"></param>
        /// <param name="canonical_sum"></param>
        /// <returns> return true if sums equals canonical sum, otherwise return false </returns>
        private static bool checksquare_diag(int[,] magic_square, int canonical_sum)
        {
            int dimension = magic_square.GetLength(0);

            int diagLR_sum = 0;
            int diagRL_sum = 0;

            for (int idx = 0; idx < dimension; idx++)
            {
                diagLR_sum += magic_square[idx, idx];
                diagRL_sum += magic_square[idx, dimension - 1 - idx];
            }

            if (diagLR_sum != canonical_sum || diagRL_sum != canonical_sum)
            {
                return false;
            }

            return true; 
        }
    }
}
