using System;
using System.IO;
using System.Net;

/*
 * Working with MyClient.cs file/project
 * 
 * Notice because this is a class library type, you can only build
 */
namespace MyCodeLibrary
{
    public class Scrape
    {
        public string ScrapeWebpage(string url)
        {
            return GetWebpage(url); // GetWebpage returns string value
        }

        public string ScrapeWebpage(string url, string filepath)
        {
            string reply = GetWebpage(url);

            File.WriteAllText(filepath, reply);
            return reply;
        }


        // creating private helper method for ScrapeWebpage (reduce redunancy)
        private string GetWebpage(string url)
        {
            WebClient client = new WebClient();
            return client.DownloadString(url);
        }
    }
}
