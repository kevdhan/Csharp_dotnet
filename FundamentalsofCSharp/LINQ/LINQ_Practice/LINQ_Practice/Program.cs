using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var grades = new List<int>{ 10, 20, 100, 50, 70 };

            // grabbing first 3 elements in enumerable
            var gradeLINQTake = grades.Take(3);

            foreach (var grade in gradeLINQTake)
            {
                Console.WriteLine(grade);
            }


            // printing in descending order and taking first 4 elements
            foreach (var grade in grades.OrderByDescending(x=>x).Take(4))
            {
                Console.WriteLine(grade);
            }

        }
    }
}
