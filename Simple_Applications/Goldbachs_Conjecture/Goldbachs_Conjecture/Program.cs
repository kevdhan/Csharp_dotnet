using System;

namespace Goldbachs_Conjecture
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Testing Goldbach's Conjecture: Every even number greater than or" +
                "equal to 4 can be expressed as the sum of two prime numbers.");
            Console.WriteLine("Enter the lower limit (Even Number, >= 4): ");
            var lower_input = Console.ReadLine();
            var lower = int.Parse(lower_input);
            Console.WriteLine("Enter the upper limit (Even Number): ");
            var upper_input = Console.ReadLine();
            var upper = int.Parse(upper_input);

            while ((lower<4) || (lower%2 != 0) || (upper%2!=0) || (lower>=upper))
            {
                Console.WriteLine("Enter the lower limit (Even Number, >= 4): ");
                lower_input = Console.ReadLine();
                lower = int.Parse(lower_input);
                Console.WriteLine("Enter the upper limit (Even Number): ");
                upper_input = Console.ReadLine();
                upper = int.Parse(upper_input);
            }

        }

        public static void Goldbachs_Alg(int lower, int upper)
        {
            
        }

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
