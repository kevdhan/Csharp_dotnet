using System;

namespace DatesAndTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime myValue = DateTime.Now; // get the date and time of now

            // Console.WriteLine(myValue.ToString());

            // Console.WriteLine(myValue.ToShortDateString()); // only show date, not time

            Console.WriteLine(myValue.ToShortTimeString());

        }
    }
}
