using System;

namespace UnderstandingScope
{
    class Program
    {
        /* Public - end users can interface with
         * Private - inside components that you don't want things to have direct access to outside of the scope
         * 
         * Encapsulation - encapsulating private components/methods through public interfaces
        */
        private static string k = ""; // accessible by anything within class

        static void Main(string[] args)
        {
            string j = "";

            for (int i = 0; i < 10; i++) // can only access "i" within for loop
            {
                string l = ""; // string l is only accessible within for loop
                j = i.ToString();
                k = i.ToString(); // here you can still access k and insert values 
                Console.WriteLine(i);
            }
            Console.WriteLine("Outside of the for loop: " + j); // j = 9
            Console.WriteLine("Outside of the for loop: " + k);

            HelperMethod(); // can call this method without instantiation b/c static

            // instantiate car object
            Car myCar = new Car();
            myCar.DoSomething(); // calling on a public method

            Console.ReadLine();
        }

        static void HelperMethod()
        {
            Console.WriteLine("Value of k from the HelperMethod(): " + k);
        }


        // non-static methods can still call on static methods
        public void CallingHi()
        {
            PrintingHi();
        }

        public static void PrintingHi()
        {
            Console.WriteLine("hi");
        }
    }

    // creating a new class called Car
    class Car
    {
        // example of encapsulation

        public void DoSomething()
        {
            Console.WriteLine(helperMethod()); // calling on a private helper method
        }

        private string helperMethod() // private method
        {
            return "Hello World";
        }
    }
}
