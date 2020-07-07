using System;
using System.Text; // importing Text Library to use mutable string class: StringBuilder

namespace WorkingWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            // back slash allows for "" to be printed
            // string myString = "My \"so-called\" life";

            // \n = new line
            //string myString = "What if I need a\nnew line?";

            // \\ double back slash if you need single \
            // string myString = "Go to your c:\\ drive";

            // @ symbol said to recognize \ as a string
            // string myString = @"Go to your c:\ drive";

            // string formatting
            // string myString = String.Format("{0} = {1}", "First", "Second");

            // formatting. ":C" --> format in currency
            // string myString = string.Format("{0:C}", 123.45);

            // format to look like an actual number - adding commas, decimal, etc.
            // string myString = string.Format("{0:N}", 1234567890);

            // percentage
            // string myString = string.Format("{0:P}", .123);

            // customer # symbol to create custom formatting
            // string myString = string.Format("Phone Number: {0:(###) ###-####}", 1234567890);

            // START HERE FOR myString!!!!!!!!!!!!!!!!!
            //string myString = " That summer we took threes across the board   ";

            // myString = myString.Substring(4); // truncates first 6 char's, including spaces, and returns the rest
            // so 7 characters, " That "

            // truncates first 6 characters, then gets the next 14 characters and returns it
            // myString = myString.Substring(6, 14);

            // myString = myString.ToUpper();

            // replace spaces with --
            // myString = myString.Replace(" ", "--");

            // starting from the 6th character to 6+14 (20th) character, removes all these characters
            // acts as the opposite of SubString
            // myString = myString.Remove(6, 14);

            /*
            // get rid of trailing spaces (at the end of the string)
            myString = String.Format("Length before: {0} -- Length after: {1}",
                myString.Length, myString.Trim().Length);
            */



            // Strings: immutable vs mutable: https://stackoverflow.com/questions/4274193/what-is-the-difference-between-a-mutable-and-immutable-string-in-c
            /* Immutable Strings
             * Very memory intensive if you are constantly adding/deleting from string
             
            string myString = ""; // strings are immutable in c# 
           
            for (int i = 0; i < 100; i++)
            {
                myString += "--" + i.ToString();
            }
            */

            /* Mutable Strings
             * More efficient way of working with strings
             */
            StringBuilder myString = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                myString.Append("--");
                myString.Append(i);
            }

            Console.WriteLine(myString);
            Console.ReadLine();

        }
    }
}
