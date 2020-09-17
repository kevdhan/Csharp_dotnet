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
            // var book = new InMemoryBook("Kevin's InMemory Grade Book");
            var book = new DiskBook("Kevin's Disk Grade Book");


            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            // you get error because it is an event
            //book.GradeAdded = null;

            // actual user input
            EnterGrades(book);

            // returns a Statistics Object
            var stats = book.GetStatistics(); // want this method to show lowest, highest, average grades


            Console.WriteLine($"Lowest Grade: {stats.Low}");
            Console.WriteLine($"Highest Grade: {stats.High}");
            Console.WriteLine($"Average Grade: {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

            /* By using abstraction and encapsulation we were able to make the code much cleaner
             * Now, if we were to come back to this code 5 months or years later, we can easily see what we are doing here
             */


        }

        private static void EnterGrades(IBook book) // taking in the abstract class Book
        {
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
                    var grade = double.Parse(input); // converts str to double-precision floating point #

                    // same method name, but different signature because different input param
                    book.AddGrade(grade);
                    // book.AddGrade('A'); different method than one above
                }
                // important to try and be specific when catching exceptions/errors
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
                    Console.WriteLine("In the finally block");
                }
            }
        }

        /* a method that meets the requirement of delegate GradeAdded
         * Reason why OnGradeAdded is static is because main is static (static to static)
        */
        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
