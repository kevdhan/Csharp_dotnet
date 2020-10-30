using System;

namespace CollectionPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // array - fixed size and order
            string[] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            // foreach loop, go through every item in the array
            foreach (var day in daysOfWeek)
            {
                Console.WriteLine(day);
            }
        }
    }
}
