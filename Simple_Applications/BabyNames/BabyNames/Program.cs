using System;
using System.Collections.Generic;
using System.IO;

namespace BabyNames
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine((1910 % 1900) / 10);
            List<string> testing = new List<string>();
            testing.Add("a");
            testing.Add("z");
            testing.Add("d");
            testing.Add("r");
            testing.Sort();
            foreach (var letter in testing)
            {
                Console.WriteLine(letter);
            }

            // prepare Directory of baby names
            Dictionary<string, List<int>> babyDirectory = new Dictionary<string, List<int>>();

            // opening up file and populating baby directory
            bool successfulOpen = false;
            do
            {
                try
                {
                    Console.Write("Enter location/name of baby names text file: ");
                    var file = Console.ReadLine();
                    using var reader = File.OpenText(file);

                    Console.WriteLine("File Found Successfully!");
                    Console.WriteLine();
                    successfulOpen = true;

                    // populate baby directory from names.txt
                    babyDirectory = populateDirectory(babyDirectory, reader);
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine(e.Message + " Must put in a file name.");
                }
            } while (!successfulOpen);

            // asking for user input, and responding with corresponding actions
            string input = "";
            do
            {
                bool correctInput = false;
                do
                {
                    try
                    {
                        Console.Write("Enter a choice (number)" +
                            "\n1 - to search for a name. " +
                            "\n2 - to display data for one name." +
                            "\n3 - to display all names that appear in a specified decade." +
                            "\n4 - to display all names that appear in all decades." +
                            "\n5 - to display all names that are more popular in every decade." +
                            "\n6 - to display all names that are less popular in every decade." +
                            "\n7 - to quit" +
                            "\n\nYour input: ");
                        input = Console.ReadLine();
                        int intInput = int.Parse(input);

                        if (intInput > 0 && intInput < 8)
                        {
                            correctInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter an integer between 1 and 7 (inclusive).");
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Please enter an integer between 1 and 7 (inclusive).");
                    }
                } while (!correctInput);

                switch (input)
                {
                    case "1":
                        Console.Write("Enter a name to search in baby directory: ");
                        var nameCase1 = Console.ReadLine();
                        Console.WriteLine();
                        if (nameExists(babyDirectory, nameCase1.ToLower()))
                        {
                            Console.WriteLine($"{nameCase1} exists in the directory!");
                        }
                        else
                        {
                            Console.WriteLine($"{nameCase1} does not exist!");
                        }
                        Console.WriteLine();

                        break;

                    case "2":
                        Console.Write("Enter a name to retrieve data: ");
                        var nameCase2 = Console.ReadLine();
                        Console.WriteLine();
                        if (nameExists(babyDirectory, nameCase2))
                        {
                            List<int> babyRanks = getRanks(babyDirectory, nameCase2.ToLower());

                            Console.Write($"{nameCase2}:");
                            foreach (var rank in babyRanks)
                            {
                                Console.Write($" {rank}");
                            }
                            Console.WriteLine();

                            var year = 1900;
                            foreach (var rank in babyRanks)
                            {
                                Console.WriteLine($"{year}: {rank}");
                                year += 10;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{nameCase2} does not exist!");
                        }
                        Console.WriteLine();

                        break;

                    case "3":
                        bool correctDecade = false;
                        do
                        {
                            Console.Write("Enter a decade (1900 - 2000): ");
                            var strDecade = Console.ReadLine();
                            try
                            {
                                int intDecade = int.Parse(strDecade);
                                if (intDecade < 1900 || intDecade > 2000 || intDecade % 10 != 0)
                                {
                                    Console.WriteLine("Please inpute a decade, between 1900-2000");
                                }
                                else
                                {
                                    correctDecade = true;

                                    // getting all names within a decade in order
                                    List<(string, int)> orderedNamesbyDecade = getNamesinDecade(babyDirectory, intDecade);
                                    foreach (var baby in orderedNamesbyDecade)
                                    {
                                        Console.WriteLine($"{baby.Item1}: {baby.Item2}");
                                    }
                                }
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine("Please input a decade, between 1900-2000");
                            }
                        } while (!correctDecade);
                        Console.WriteLine();

                        break;

                    case "4":
                        List<string> namesInAllDecades = getNamesInAllDecades(babyDirectory);
                        Console.WriteLine($"{namesInAllDecades.Count} names appear in every decade. The names are: ");
                        foreach (var name in namesInAllDecades)
                        {
                            Console.WriteLine(name);
                        }
                        Console.WriteLine();

                        break;

                    case "5":
                        List<string> ascendingNames = getAscendingPopularNames(babyDirectory);
                        Console.WriteLine($"{ascendingNames.Count} names are more popular in every decade");
                        foreach (var name in ascendingNames)
                        {
                            Console.WriteLine(name);
                        }
                        Console.WriteLine();
                        break;

                    case "6":
                        List<string> descendingNames = getDescendingPopularNames(babyDirectory);
                        Console.WriteLine($"{descendingNames.Count} names are less popular in every decade");
                        foreach (var name in descendingNames)
                        {
                            Console.WriteLine(name);
                        }
                        Console.WriteLine();
                        break;
                }

            } while (input != "7");

            Console.WriteLine("Thank you for using the baby dictionary!");
        }

        /// <summary>
        /// Given successfully opened file of baby names, populate dictionary with data
        /// </summary>
        /// <param name="babyDirectory"></param>
        /// <param name="reader"></param>
        /// <returns> dictionary populated with baby names </returns>
        private static Dictionary<string, List<int>> populateDirectory(Dictionary<string, List<int>> babyDirectory, StreamReader reader)
        {
            string? line = "";

            // read line, parse, add data to dictionary
            line = reader.ReadLine();

            do
            {
                string[] babyNameInfo = line.Split();

                // extract name
                string babyName = babyNameInfo[0].ToLower();

                // extract data
                List<int> babyRanks = new List<int>();
                for (int i = 1; i < babyNameInfo.Length; i++)
                {
                    var rank = int.Parse(babyNameInfo[i]);
                    babyRanks.Add(rank);
                }

                // add name and rankings to baby dictionary
                babyDirectory.Add(babyName, babyRanks);

                // add readline command at end of loop to catch potential nullreferenceexception
                line = reader.ReadLine();

            } while (line != null);

            return babyDirectory;
        }

        /// <summary>
        /// determine if a given name input exists in the dictionary
        /// </summary>
        /// <returns> returns true if name exists in the directory </returns>
        private static bool nameExists(Dictionary<string, List<int>> babyDirectory, string name)
        {
            if (babyDirectory.ContainsKey(name))
            {
                return true;
            }
            return false;
        }

        // function that returns all rankings for a given name
        private static List<int> getRanks(Dictionary<string, List<int>> babyDirectory, string name)
        {
            // return all rankings for a given name
            return babyDirectory[name];
        }

        // function that returns list of names that have a rank in a decade, sorted by rank
        private static List<(string, int)> getNamesinDecade(Dictionary<string, List<int>> babyDirectory, int year)
        {
            //            Console.WriteLine((2000%1900)/10);
            List<(string, int)> namesInDecade = new List<(string, int)>();
            foreach (var baby in babyDirectory)
            {
                // List<int> of ranks for a baby
                var babyRankList = baby.Value;
                var babyRank = babyRankList[(year % 1900) / 10]; // specific rank for the year
                if (babyRank != 0) // checking if the name even ranks in the year
                {
                    namesInDecade.Add((baby.Key, babyRank));
                }
            }
            namesInDecade.Sort((x, y) => x.Item2.CompareTo(y.Item2)); // sorting in place

            return namesInDecade;
        }

        // function that displays all the names that have a rank in a decade, ordered by rank
        private static List<string> getNamesInAllDecades(Dictionary<string, List<int>> babyDirectory)
        {
            List<string> namesInAllDecades = new List<string>();
            foreach (var baby in babyDirectory) // going through each baby
            {
                var babyRankList = baby.Value; // list of rankings for each baby
                bool rankInAllDecades = true;
                foreach (var rank in babyRankList)
                {
                    if (rank == 0) // baby was not ranked in a decade, does not meet flag
                    {
                        rankInAllDecades = false;
                    }
                }
                // if a baby has a rank in every decade
                if (rankInAllDecades)
                {
                    namesInAllDecades.Add(baby.Key);
                }
            }
            namesInAllDecades.Sort();

            return namesInAllDecades;
        }

        // function that display all names that get more popular per decade. Ordered by name
        private static List<string> getAscendingPopularNames(Dictionary<string, List<int>> babyDictionary)
        {
            List<string> babyAscendingNamesList = new List<string>();
            foreach (var baby in babyDictionary)
            {
                bool ascendingRanks = true;
                var babyRanks = baby.Value;
                for (int i = 1; i < babyRanks.Count; i++)
                {
                    // smaller # means higher rank
                    if (babyRanks[i] >= babyRanks[i - 1]
                        || babyRanks[i] == 0
                        || babyRanks[i-1] == 0)
                    {
                        ascendingRanks = false;
                    }
                }
                if (ascendingRanks)
                {
                    babyAscendingNamesList.Add(baby.Key);
                }
            }
            babyAscendingNamesList.Sort();

            return babyAscendingNamesList;
        }

        // function that display all names that get less popular per decade. Ordered by name
        private static List<string> getDescendingPopularNames(Dictionary<string, List<int>> babyDictionary)
        {
            List<string> babyDescendingNamesList = new List<string>();
            foreach (var baby in babyDictionary)
            {
                bool descendingRanks = true;
                var babyRanks = baby.Value;
                for (int i = 1; i < babyRanks.Count; i++)
                {
                    // smaller # means higher rank
                    if (babyRanks[i] <= babyRanks[i - 1]
                        || babyRanks[i] == 0
                        || babyRanks[i - 1] == 0)
                    {
                        descendingRanks = false;
                    }
                }
                if (descendingRanks)
                {
                    babyDescendingNamesList.Add(baby.Key);
                }
            }
            babyDescendingNamesList.Sort();

            return babyDescendingNamesList;
        }
    }
}
