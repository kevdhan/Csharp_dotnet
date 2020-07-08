using System;

namespace SimpleClasses
{
    // classes -> container for related methods
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.Make = "Oldsmobile";
            myCar.Model = "Cutlas Supreme";
            myCar.Year = 1986;
            myCar.Color = "Silver";

            Console.WriteLine("{0} {1} {2} {3}", myCar.Make, myCar.Model, myCar.Year, myCar.Color);

            // decimal value = DetermineMarketValue(myCar);
            // Console.WriteLine("{0:C}", value);

            Console.WriteLine("{0:C}",myCar.DetermineMarketValue());
            
        }

        // takes in an object of class Car
        // Car - class
        // car - name of object
        private static decimal DetermineMarketValue(Car car)
        {
            decimal carValue = 100.0M;

            // Someday I might look up the car online webservice to get more accurate value

            return carValue;
        }
    }

    // creating a new class
    // class --> blueprint
    // object --> an instantiation of the class
    class Car
    {
        // short to creating methods: "prop", tab, tab
        /* C#: Get and Set: https://www.w3schools.com/cs/cs_properties.asp
         * Get - returning value of variable
         * Set - setting the value of variable
        */
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }


        public decimal DetermineMarketValue()
        {
            decimal carValue;

            if (Year > 1990) // comparing of Year
            {
                carValue = 10000;
            }
            else
            {
                carValue = 2000;
            }

            return carValue;
        }

    }
}
