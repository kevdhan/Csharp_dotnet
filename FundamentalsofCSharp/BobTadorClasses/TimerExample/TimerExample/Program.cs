using System;
using System.Timers;

namespace TimerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Event-driven programming - at the heart of Microsoft presentation API
             * 
             * Event-driven programming is essential to all API's
             * 
             * Events - allow developers to respond to an event being raised
             */

            Timer myTimer = new Timer(2000);

            Console.WriteLine("Press enter to remove the red event.");

            // both of these methods will execute when elapsed event is raised by timer
            // += adding/subscribing items to an event
            myTimer.Elapsed += MyTimer_Elapsed; //registering an event called MyTimer_Elapsed
            myTimer.Elapsed += MyTimer_Elapsed1; // adding another event trigger

            myTimer.Start(); // start timer


            // basically every 2 seconds, the SignalTime will be printed out until someone presses enter
            Console.ReadLine();

            // detaching second event handler
            myTimer.Elapsed -= MyTimer_Elapsed1;


            Console.ReadLine();
        }

        private static void MyTimer_Elapsed1(object sender, ElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Elapsed: {0:HH:mm:ss.fff}", e.SignalTime);
            // throw new NotImplementedException();
        }


        // code that will execute when elapsed time even is triggered
        private static void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // throw new NotImplementedException();

            Console.ForegroundColor = ConsoleColor.Blue;

            // SignalTime --> time when exact event was raised
            Console.WriteLine("Elapsed: {0:HH:mm:ss.fff}",e.SignalTime);
        }
    }
}
