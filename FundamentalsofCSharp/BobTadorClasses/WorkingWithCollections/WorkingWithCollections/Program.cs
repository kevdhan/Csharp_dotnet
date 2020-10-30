using System;
using System.Collections;
using System.Collections.Generic;

namespace WorkingWithCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array v.s. Collections (Arrays on Steroids)
            // usage depends on Use Cases
            // LINQ - language integrated query

            Car car1 = new Car();
            car1.Make = "Oldsmobile";
            car1.Model = "Cutlas Supreme";
            car1.VIN = "A1";

            Car car2 = new Car();
            car2.Make = "Geo";
            car2.Model = "Prism";
            car2.VIN = "B2";

            Book b1 = new Book();
            b1.Author = "Robert Tabor";
            b1.Title = "Microsoft .NET XML Web Services";
            b1.ISBN = "0-000-00000-0";


            /* ArrayLists - old style, has some limitations
             * Pros:
             * - dynamically sized
             * - cool features like sorting, remove
             * 
             * Cons:
             * - can't restrict data types thats allowed. Issues arise in certain instances like iterating through the collection
             */
            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(car1);
            myArrayList.Add(car2);
            myArrayList.Add(b1); // not strongly typed, can add anything.
            myArrayList.Remove(b1); // removing Book b1
            // This arraylist is a list of cars and books.


            /* List<T> (Generic List) - Generic Collections
             * 
             * Allow to specify which data types can be in a collection but still have benefits of collections
             * 
             * Part of Collections.Generic
             */
            List<Car> myList = new List<Car>();
            myList.Add(car1);
            myList.Add(car2);
            // myList.Add(b1); we get an error here because the list is specific to car datatype
            foreach (Car car in myList)
            {
                Console.WriteLine(car.Model);
            }


            /* Dictionary - Dictionary<TKey, TValue>
             * Key & Value
             */
            Dictionary<string, Car> myDictionary = new Dictionary<string, Car>();
            myDictionary.Add(car1.VIN, car1);
            myDictionary.Add(car2.VIN, car2);

            Console.WriteLine(myDictionary["B2"].Make);
            // Console.WriteLine(myDictionary["B2"]); no default print for overall class


            /* Arrays
             * In arrays, to instiate an array with values, you can use the notation down below
             */
            //string[] names = {"Bob", "Steve", "Brian", "Chuck" };

            /* Similar to Arrays, you can do the same thing with creating an object
             * "Object Initalizer Syntax"
             * No need for a Constructor
             */
            Car car3 = new Car() { Make = "BMW", Model = "750li", VIN = "C3" };
            Car car4 = new Car() { Make = "Toyota", Model = "4Runner" ,VIN = "D4" };


            /* Collection initializer
             * Created a list, added cars, and initialized cars
             */
            List<Car> mylist2 = new List<Car>()
            {
                new Car { Make = "Oldsmobile", Model = "Cutlas Supreme", VIN = "E5" },
                new Car { Make = "Nissan", Model = "Altima", VIN = "F6" }
            };


        }
    }

    class Car
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}
