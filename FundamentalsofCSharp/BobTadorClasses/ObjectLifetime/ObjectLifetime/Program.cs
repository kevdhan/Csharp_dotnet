using System;

namespace ObjectLifetime
{
    /* General Notes
     * One good thing about C# and .NET (similar to other languages like Java), you have Garbage Collection.
     * You don't have to worry about memory leaks or having to remember to erase memory etc.
     * 
     * With langauges like C or C++, which aren't as managed, Garbage collection is not a feature
     * A lot more manual work
     * 
     * A default constructor for a class is created automatically for you
     */
    class Program
    {
        static void Main(string[] args)
        {
            // by commenting out block of code below, we are using the constructor we created.
            // You will only get values for Make = Nissan
            // everything else will either be "" or 0 n
            Car myCar = new Car();

            /*
            myCar.Make = "Oldmobile";
            myCar.Model = "Cutlas Supreme";
            myCar.Year = 1986;
            myCar.Color = "Silver";
            */


            Car myOtherCar; // creating a car object
            myOtherCar = myCar; // referencing same address

            Console.WriteLine("{0} {1} {2} {3}",
                myOtherCar.Make, myOtherCar.Model,
                myOtherCar.Year, myOtherCar.Color);

            myCar.Make = "NewOldMobile";
            Console.WriteLine(myOtherCar.Make); // further proof showing the reference of same address

            // null is not 0 or an empty string, simply means indetermined
            // myOtherCar = null; // dereferencing, null
            /*
            Console.WriteLine("{0} {1} {2} {3}", // null refeence exception
                myOtherCar.Make, myOtherCar.Model,
                myOtherCar.Year, myOtherCar.Color);
            */

            myCar = null;
            Console.WriteLine("{0} {1} {2} {3}", // even though myCar was dereferenced, myOtherCar still points to the address with data
                myOtherCar.Make, myOtherCar.Model,
                myOtherCar.Year, myOtherCar.Color);


            // utilizing overloaded constructor
            Car myThirdCar = new Car("Ford", "Escape", 2005, "White");
            Console.WriteLine("{0} {1} {2} {3}",
                myThirdCar.Make, myThirdCar.Model,
                myThirdCar.Year, myThirdCar.Color);


            /* Question: How is that you can use certain classes without instantiating an object first?
             * An example is "Console.WriteLine()"
             * You are using the method WriteLine() from the class Console, but not instantiating
             * Answer: It is because the method is "Static"
            */

            Car.PrintCar(); // PrintCar() is a static method
            
        }
    }

    class Car
    {
        // This is best practice, internally its the same as declaring a a private variable
        // then creating a public method for setting and getting the private variable
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        // a default constructor is created for you automatically

        // creating our own first constructor
        public Car()
        {
            /* "this" is optional. Helps clarify where variable is coming from
             * so in this example, "this.Make" is referring to public string Make above
            */
            // this.Make = "Nissan" == Make = "Nissan"
            Make = "Nissan";

            // In addition to hard coding, you can load data from a configuration file, database, etc.
        }

        /* overloaded constructor
         * You are taking in values and setting them as the values for the object you are creating
        */
        public Car(string make, string model, int year, string color)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
        }

        public void PrintCars()
        {
            Console.WriteLine("non static");
        }


        /* creating a static method. Does not operate on a single instance.
         * 
         * Static v.s. Instace members of a class
         * 
         * Cannot use non static variables/methods
        */
        public static void PrintCar()
        {
            Console.WriteLine("Calling static PrintCar() Method");
        }
    }
}
