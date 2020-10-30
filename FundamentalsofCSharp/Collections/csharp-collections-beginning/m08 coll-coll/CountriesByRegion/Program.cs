using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.BegCShCollections.ReadAllCountries
{
	class Program
	{
		static void Main(string[] args)
		{
			string filePath = @"G:\G_Work\Pluralsight\Courses\Beginning Effective Collections\Code\Pop by Largest Final.csv";
			CsvReader reader = new CsvReader(filePath);

			Dictionary<string, List<Country>> countries = reader.ReadAllCountries();

			foreach (string region in countries.Keys)
				Console.WriteLine(region);

			Console.Write("Which of the above regions do you want? ");
			string chosenRegion = Console.ReadLine();

			if (countries.ContainsKey(chosenRegion))
			{
				// display 10 highest population countries in the selected region
				foreach (Country country in countries[chosenRegion].Take(10))
					Console.WriteLine($"{PopulationFormatter.FormatPopulation (country.Population).PadLeft(15)}: {country.Name}");
			}
			else
				Console.WriteLine("That is not a valid region");
		}
	}
}
