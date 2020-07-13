using System;
using MyCodeLibrary;

/* Want to reference "MyCodeLibrary"
 * add reference from MyCodeLibrary: bin --> release --> dll file
 * 
 * if you look under bin for MyClient, you can see that there are copies of
 * MyCodeLibrary
 */
namespace MyClient
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
