using System;

namespace UnderstandingArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Documentation over Arrays in C#
             * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/
             * 
             * Multi-Dimensional Arrays v.s. Jagged Arrays
             * https://stackoverflow.com/questions/4648914/why-we-have-both-jagged-array-and-multidimensional-array
             * Multi-Dimensional Arrays - single block of memory, matrix
             * Jagged Arrays - An array of int[]... each int[] can be different lengths/size
             * 
             * 
             * Arrays v.s. Collection
             * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections 
             * Collection - more dynamic and non-fixed
            */

            // 1D Array 
            Console.WriteLine("1D Array");
            int[] array1 = new int[5]; // creating an array of 5 integers, auto filled w/ 0's?
            array1[3] = 20;

            for (int i = 0; i < array1.Length; i++)
            {
                Console.WriteLine(array1[i]);
            }

            // 1D Array - instantiating with values
            int[] numberArray = new int[] { 4, 5, 6, 7, 10 };
            Console.WriteLine(numberArray[3]);
            foreach (int num in numberArray)
            {
                Console.WriteLine(num);
            }

            // Array of Strings
            string[] names = new string[] { "bobby", "joey", "kevin"};
            Console.WriteLine(names[1]);

            // Another way of looping through an array without a for loop instantiation
            foreach (string name in names) // foreach
            {
                Console.WriteLine(name);
            }

            // Reverse name by splitting string into an array
            string zig = "YOU CAN GET WHAT YOU WANT OUT OF LIFE"
                + "IF YOU HELP ENOUGH OTHER PEOPLE GET WHAT THEY WANT";

            char[] charArray = zig.ToCharArray(); //ToCharArray --> helper method pre-built for use
            Array.Reverse(charArray);

            foreach (char zigChar in charArray)
            {
                Console.Write(zigChar);
            }


            Console.WriteLine();
            // Jagged Array --> im assuming this is more memory efficient
            Console.WriteLine("Jagged Array");
            int[][] array2 = new int[5][];
            // you have to instantiate each array in the Jagged Array
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = new int[i+1];
            }
            Console.WriteLine(array2[0][0]);
            Console.WriteLine(array2[1].Length); // output should be 2
            Console.WriteLine();

            // Multi-dimensional array
            Console.WriteLine("Multi-Dimensional Array");
            int[,] array3 = new int[3, 2]; // designating 3 arrays (rows), each with 2 columns
            array3[0, 1] = 30;
            Console.WriteLine(array3[0,1]);
        }
    }
}
