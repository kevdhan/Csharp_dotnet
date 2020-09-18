using System;
/// <summary>
/// The goal of this program is to compute the date of Easter Sunday,
/// an algorithm invented by Carl Friedrich Gauss
/// </summary>
namespace EasterSunday
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a year: ");
            var input = Console.ReadLine();
            var year = int.Parse(input);

            // Carl Friedrich Gauss' Algorithm
            int a = year % 19; // grabbing remainder, modulo
            int b = year / 100; // grabbing quotient
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int g = (8 * b + 13) / 25;
            int h = (19 * a + b - d - g + 15) % 30;
            int j = c / 4;
            int k = c % 4;
            int m = (a + 11 * h) / 319;
            int r = (2 * e + 2 * j - k - h + m + 32) % 7;
            int n = (h - m + r + 90) / 25;
            int p = (h - m + r + n + 19) % 32;

            Console.WriteLine("In the year {0}, Easter Sunday was on {1}/{2}/{0}", year, n, p);
        }
    }
}
