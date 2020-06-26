using System;

namespace HelloWorld // namespace - 
{
    class Program // class - container for all different kinds of methods
    {
        static void Main(string[] args) // method
        {
            Console.WriteLine("Hello World!");
            /*
            Program2 hope = new Program2();
            hope.Pickle();
            */
            // Console.ReadLine();
            // comment
        }
    }

    class Program2
    {
        public void Pickle(int x)
        {
            Console.WriteLine("It worked!");
        }
    }
}
