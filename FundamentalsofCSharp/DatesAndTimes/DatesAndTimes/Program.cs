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

            // Console.WriteLine(myValue.ToShortTimeString());

            // Console.WriteLine(myValue.ToLongTimeString());

            // adding days to date
            // Console.WriteLine(myValue.AddDays(3).ToLongDateString());

            // adding hours to time
            // Console.WriteLine(myValue.AddHours(3).ToLongTimeString());

            // to subtract hours, add negatie hours
            // Console.WriteLine(myValue.AddDays(-3).ToLongDateString());

            // Console.WriteLine(myValue.Month);


            // creating custom datetime --> remember to convert to string before printing
            /*
            DateTime myBirthday = new DateTime(1996, 12, 31);
            Console.WriteLine(myBirthday.ToShortDateString());
            */


            // parsing string to DateTime
            DateTime myBirthday = DateTime.Parse("12/31/1996"); // parsing string to DateTime
            TimeSpan myAge = DateTime.Now.Subtract(myBirthday); // creating a new class called TimeSpan
            Console.WriteLine(myAge.TotalDays);

            Console.ReadLine();

        }
    }
}
