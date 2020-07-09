using System;

namespace ObjectLifetime
{
    /* General Notes
     * One good thing about C# and .NET (similar to other languages like Java), you have Garbage Collection.
     * You don't have to worry about memory leaks or having to remember to erase memory etc.
     * 
     * With langauges like C or C++, which aren't as managed, Garbage collection is not a feature
     */
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();

            myCar.Make = "Oldmobile";
            myCar.Model = "Cutlas Supreme";
            myCar.Year = 1986;
            myCar.Color = "Silver";

            Car myOtherCar; // creating a car object
            myOtherCar = myCar; // referencing same address

            Console.WriteLine("{0} {1} {2} {3}", myOtherCar.Make, myOtherCar.Model, myOtherCar.Year, myOtherCar.Color);

        }
    }

    class Car
    {

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

    }
}
