using System;

namespace Goldbachs_Conjecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            // initial query for input from user
            Console.WriteLine("Testing Goldbach's Conjecture: Every even number greater than or " +
                "equal to 4 can be expressed as the sum of two prime numbers.");
            Console.Write("Enter the lower limit (Even Number, >= 4): ");
            var lower_input = Console.ReadLine();
            var lower = int.Parse(lower_input);
            Console.Write("Enter the upper limit (Even Number): ");
            var upper_input = Console.ReadLine();
            var upper = int.Parse(upper_input);

            // loop, until write response is given
            // even number, greater or equal than 4, where lower number must be smaller or equal
            // to upper 
            while ((lower<4) || (lower%2 != 0) || (upper%2!=0) || (lower>=upper))
            {
                Console.Write("Enter the lower limit (Even Number, >= 4): ");
                lower_input = Console.ReadLine();
                lower = int.Parse(lower_input);
                Console.Write("Enter the upper limit (Even Number): ");
                upper_input = Console.ReadLine();
                upper = int.Parse(upper_input);
            }

            Goldbachs_Alg(lower, upper);

        }

        public static void Goldbachs_Alg(int lower, int upper)
        {
            for (int userrange = lower; userrange < upper+1; userrange+=2)
            {
                Console.Write(userrange + " ");
                for (int lowprime = 2; lowprime < (userrange/2)+1; lowprime++)
                {
                    if (is_prime(lowprime) && (lowprime*2 == userrange))
                    {
                        Console.Write("=" + lowprime + "+" + lowprime + " ");
                    }
                    for (int highprime = (userrange/2)+1; highprime < userrange; highprime++)
                    {
                        if (is_prime(lowprime) && is_prime(highprime)
                            && (lowprime+highprime) == userrange)
                        {
                            Console.Write("=" + lowprime + "+" + highprime + " ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// takes in a number and determines if it is prime
        /// </summary>
        /// <param name="numb"></param>
        /// <returns>bool, if number is prime, return true, otherwise false</returns>
        public static bool is_prime(int numb)
        {
            if (numb == 1)
            {
                return false;
            }
            var limit = Math.Floor(Math.Pow(numb, 0.5)) + 1;
            var div = 2;

            while (div < limit)
            {
                if (numb % div ==0)
                {
                    return false;
                }
                div++;
            }

            return true;
        }
    }
}
