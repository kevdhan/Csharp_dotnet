using System;

namespace ForIteration
{
    class Program
    {
        static void Main(string[] args)
        {

            /* to debug, click on left most side and add a red circle to a specific line
             * Click on Step over or Step in to debug...
             * Some things to notice is terminal, local variables, etc.
             * 
             * Right Click breakpoint and click "edit breakpoint"
            */

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                if (i == 7)
                {
                    Console.WriteLine("Found {0}!!", i);
                }
            }

            // for, then touble tap "tab"
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Number: " + i);

            }

        }
    }
}
