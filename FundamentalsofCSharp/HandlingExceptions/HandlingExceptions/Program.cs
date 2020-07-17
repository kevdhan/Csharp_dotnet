using System;
using System.IO;

/* Building applications that are robust and can withstand crashing due to errors, etc.
 * 
 * Compilation Error (not what this program is talking about)
 * 
 * We are talking about runtime errors...
 * 
 */
namespace HandlingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            /* one way to handle errors/except, try and catch blocks
             * try - will try the code, if something breaks, will go to the catch block
             */
            try
            {
                // here, the @ sign treats \ a strings
                string content = File.ReadAllText(@"/Users/kevhan/Documents/Csharp_dotnet/FundamentalsofCSharp/HandlingExceptions/Exampl.txt");
                Console.WriteLine(content);
            }
            catch (FileNotFoundException ex) // look at exceptions for File.ReadAllText
            {
                Console.WriteLine("There was a problem!");
                Console.WriteLine("Make sure the name of the file is named correctly: Example.txt");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("There was a problem!");
                Console.WriteLine("Make sure the directory exists.");
            }
            catch (Exception ex) // Exception ex --> catching the exception occurs. Example of most general exception
            {
                Console.WriteLine("There was a problem!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Code to finalize
                // Setting objects to null
                // Closing database Connections
                Console.WriteLine("Closing application now... ");
            }
            Console.ReadLine();
        }
    }
}
