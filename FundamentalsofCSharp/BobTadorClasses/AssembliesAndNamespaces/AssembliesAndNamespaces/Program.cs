/* list of namespaces
 * Faded out namespaces --> not used
 */
using System;
using System.IO;
using System.Net;

namespace AssembliesAndNamespaces
{
    /* .NET library is just bunch of classes w/ methods
     * .NET assemblies
     * .dll --> shareable libraries across different projects/apps
    */
    class Program
    {
        static void Main(string[] args)
        {
            // Link: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file
            // Example #2: Write one string to a text file.
            string text = "We want to write this to our file.";
            // WriteAllText creates a file, writes the specified string to the file,
            // and then closes the file.    You do NOT need to call Flush() or Close().
            File.WriteAllText(@"/Users/kevhan/Documents/Csharp_dotnet/FundamentalsofCSharp/AssembliesAndNamespaces/WriteText.txt", text);

            
            // https://docs.microsoft.com/en-us/dotnet/api/system.net.webclient.downloadstring?view=netcore-3.1
            WebClient client = new WebClient();
            string reply = client.DownloadString("https://docs.microsoft.com/en-us/");
            File.WriteAllText(@"/Users/kevhan/Documents/Csharp_dotnet/FundamentalsofCSharp/AssembliesAndNamespaces/HTML_example.txt", reply);
            Console.WriteLine(reply);


        }
    }

   
} 
