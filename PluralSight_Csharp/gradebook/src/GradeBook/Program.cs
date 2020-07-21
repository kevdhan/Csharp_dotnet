using System;

namespace GradeBook
{
    class Program
    {
        // input of Main is an array of strings
        static void Main(string[] args) 
        {
            if (args.Length > 0)
            {
                Console.WriteLine("Hello, {0}!", args[0]);
            }
            else
            {
                Console.WriteLine("Hello");
            }
        }
    }
}
