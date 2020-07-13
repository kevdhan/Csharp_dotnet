using System;
using ScrapeLibrary;

namespace ScrapeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // because we added a reference to this file, we can now use MyCodeLibrary
            // now we can use classes/methods from this namespace
            Scrape myScrape = new Scrape();
            string value = myScrape.ScrapeWebpage("https://docs.microsoft.com/en-us/");
            Console.WriteLine(value);


        }
    }
}
