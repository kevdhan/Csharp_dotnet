using System;
using System.Collections.Generic;
using System.IO;

namespace DNA
{
    class Program
    {
        static void Main(string[] args)
        {
            // File.OpenText vs StreamReader
            // opening file
            using var reader = File.OpenText("dna.txt");
            string? line = reader.ReadLine();
            var num_pairs = double.Parse(line);
            Console.WriteLine("Number of Pairs: " + num_pairs);

            Console.WriteLine("Longest Common Sequences");

            for (int i = 0; i < num_pairs; i++)
            {
                Console.Write($"Pair {i + 1}:");

                var first_sequence = reader.ReadLine().Replace(" ", String.Empty).ToUpper();
                var second_sequence = reader.ReadLine().Replace(" ", String.Empty).ToUpper();

                // get substrings for each sequence, O(n^2), where n = sequence length
                var first_sequence_substrings = GetSubStrings(first_sequence);
                var second_sequence_substrings = GetSubStrings(second_sequence);

                // compare substrings to find highest common
                List<string> common_substrings = new List<string>();
                var common_substring_len = 0;
                foreach (var substr in first_sequence_substrings)
                {
                    foreach (var substr2 in second_sequence_substrings)
                    {
                        if (String.Equals(substr,substr2))
                        {
                            common_substrings.Add(substr);
                            if (substr.Length > common_substring_len)
                            {
                                common_substring_len = substr.Length;
                            }
                        }
                    }
                }

                if (common_substring_len == 0)
                {
                    Console.WriteLine(" No Common Sequence Found");
                }
                else
                {
                    // print out highest common substrings for each pair
                    foreach (var substr in common_substrings)
                    {
                        if (substr.Length == common_substring_len)
                        {
                            Console.Write($" {substr}");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        // get substrings for a DNA sequence
        public static List<string> GetSubStrings(string dna_sequence)
        {
            List<string> substrings = new List<string>();
            for (int pos1 = 0; pos1 < dna_sequence.Length; pos1++)
            {
                for (int pos2 = 2; pos1 + pos2 < dna_sequence.Length+1; pos2++)
                {
                    substrings.Add(dna_sequence.Substring(pos1, pos2));
                }
            }
            return substrings;
        }

    }
}
