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
            //book.AddGrade(89.1);
            //book.AddGrade(90.5);
            //book.AddGrade(77.5);

            // actual user input
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                // try catch block - trying to add a grade into the gradebook
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    // book.AddGrade('A'); different method than one above
                }
                catch (ArgumentException ex) // exception is thrown within AddGrade method... here we are catching it
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Argument");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Format");
                }
                finally
                {
                    // code that will always happen
                }
            }


            var stats = book.GetStatistics(); // want this method to show lowest, highest, average grades


            Console.WriteLine($"Lowest Grade: {stats.Low}");
            Console.WriteLine($"Highest Grade: {stats.High}");
            Console.WriteLine($"Average Grade: {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

            /* By using abstraction and encapsulation we were able to make the code much cleaner
             * Now, if we were to come back to this code 5 months or years later, we can easily see what we are doing here
             */


        }
    }
}
