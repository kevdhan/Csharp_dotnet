using System;
using System.Collections.Generic;
using System.Linq; // for LINQ queries

/* There are 2 syntax of LINQ
 * 1. Query syntax - familiar with SQL
 * 2. Method syntax - familiar with C#, but some learning
 */
namespace UnderstandingLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            /* var in C# is different from other variables
             * var = let compiler figure out what the correct datatype is
             * useful
             */


            // initalizing a generic collection of cars
            List<Car> myCars = new List<Car>()
            {
                new Car() { VIN="A1", Make="BMW", Model="550i", StickerPrice=55000, Year=2012 },
                new Car() { VIN="B2", Make="Toyota", Model="4Runner", StickerPrice=35000, Year=2013 },
                new Car() { VIN="C3", Make="BMW", Model="745li", StickerPrice=75000, Year=2010 },
                new Car() { VIN="D4", Make="Ford", Model="Escape", StickerPrice=25000, Year=2015 },
                new Car() { VIN="E5", Make="BMW", Model="55i", StickerPrice=57000, Year=2016 }
            };

            // 2 syntax of LINQ:

            //LINQ query (very SQL like)
            Console.WriteLine("LINQ Query");
            var bmws_query = from car in myCars
                       where car.Make == "BMW"
                       && car.Year == 2010 // getting where car make is in 2010
                       select car;

            foreach (var car in bmws_query)
            {
                Console.WriteLine("{0} {1}", car.Model, car.VIN);
            }
            Console.WriteLine();

            //LINQ Query - ordered. Getting cars and ordering them by descending car year
            Console.WriteLine("LINQ Query, ordered");
            var orderedCars_query = from car in myCars
                                    orderby car.Year descending // cars are ordered from newest to oldest
                                    select car;

            foreach (var car in orderedCars_query)
            {
                Console.WriteLine("{0} {1} {2}", car.Year, car.Model, car.VIN);
            }
            Console.WriteLine();


            ////////////////////////////////////////////////////////////////////


            // LINQ method/lambda
            Console.WriteLine("LINQ Method");
            /* p => p.Make == "BMW" is considered a lambda function
             */
            var bmws_method = myCars.Where(p => p.Make == "BMW" && p.Year == 2010);

            foreach (var car in bmws_method)
            {
                Console.WriteLine("{0} {1}", car.Model, car.VIN);
            }
            Console.WriteLine();

            // LINQ Method, ordered. Same way to order by descending as LINQ Query
            Console.WriteLine("LINQ Method, ordered");      
            var orderedCars_lambda = myCars.OrderByDescending(p => p.Year);

            foreach (var car in orderedCars_lambda)
            {
                Console.WriteLine("{0} {1} {2}", car.Year, car.Model, car.VIN);
            }
            Console.WriteLine();

            // another example
            Console.WriteLine("extracting first BMW");
            // ordering the cars by year, then grabbing the first car with Make == BMW
            var firstBMW = myCars.OrderByDescending(p => p.Year).First(p => p.Make == "BMW");
            Console.WriteLine(firstBMW.VIN);
            Console.WriteLine();

            // another example
            Console.WriteLine(myCars.TrueForAll(p => p.Year > 2012)); // are all my car years > 2012
            Console.WriteLine(myCars.TrueForAll(p => p.Year > 2009));

            // reduce the price of each car by 3000 setting the value
            myCars.ForEach(p => p.StickerPrice -= 3000);

            // another example, don't have to separately write out a foreach loop
            myCars.ForEach(p => Console.WriteLine("{0} {1:C}", p.VIN, p.StickerPrice));

            // another example, checking if in data, there exists a car that is a 745li model
            Console.WriteLine(myCars.Exists(p => p.Model == "745li"));

            // another example, aggregate example, sums all the price of each car in the dataset 
            Console.WriteLine(myCars.Sum(p => p.StickerPrice));


            Console.WriteLine("var variable examples");
            // reiterating: var --> let the compiler decide what the data type
            // all data types in .NET has GetType() method. System.Object --> parent of all objects
            Console.WriteLine(myCars.GetType()); // tells us what the type of object
            Console.WriteLine(orderedCars_lambda.GetType());
            Console.WriteLine(bmws_query.GetType());

            var newCars = from car in myCars
                             where car.Make == "BMW"
                             && car.Year == 2010 // getting where car make is in 2010
                             select new { car.Make, car.Model }; // creating new collection
            Console.WriteLine(newCars.GetType());

        }
    }

    // Car class
    class Car
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double StickerPrice { get; set; }
    }

}
