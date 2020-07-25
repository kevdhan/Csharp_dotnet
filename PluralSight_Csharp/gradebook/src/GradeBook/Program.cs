using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        // input of Main is an array of strings
        static void Main(string[] args) 
        {

            // var data type has to equal something
            // var - still strongly defined. Can't define a var variable as a double and a string

            // var numbers = new double[3]; | creating a double array
            // var numbers = new double[] {12.7, 11.3, 15.4};
            // var numbers = new[] {12.7, 11.3, 15.8}; | here, creating an array of doubles, without officially declaring double


            // Array - specific size
            // Collections - fluid size



            // utilizing the new class Book
            var book = new Book("Kevin's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            var stats = book.GetStatistics(); // want this method to show lowest, highest, average grades


            Console.WriteLine($"Lowest Grade: {stats.Low}");
            Console.WriteLine($"Highest Grade: {stats.High}");
            Console.WriteLine($"Average Grade: {stats.Average:N1}");

            /* By using abstraction and encapsulation we were able to make the code much cleaner
             * Now, if we were to come back to this code 5 months or years later, we can easily see what we are doing here
             */


    }
    }
}
