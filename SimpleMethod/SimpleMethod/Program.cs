using System;

namespace SimpleMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorld(); // calling method
        }

        /* Creating a new method within class Program
         * Private - only accessible within this class? namespace?
         * 
        */
        private static void HelloWorld()
        {
            Console.WriteLine("Hello World");
        }
    }
}
