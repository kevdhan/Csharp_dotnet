using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.BegCShCollections.IntroColls.TopTenPops
{
	class Program
	{
		static void Main(string[] args)
		{
			//// Declaring, not instantiating
			//Country[] countries = null;

			//// Specifying only the size
			//Country[] countries = new Country[nCountries];

			//// Specifying the values
			Country[] countries = new Country[]
				{
	new Country("United Kingdom", "GBR", "Europe", 66_000_000),
	new Country("Nepal", "NPL", "Asia", 29_000_000)
};

			// OK. int[] is a reference type
			int[] numbers = null;

			// Wrong. int is a value type so can't be null
			int number = null;

			string filePath = @"G:\G_Work\Pluralsight\Courses\Beginning Effective Collections\Code\Pop by Largest Final.csv";
			CsvReader reader = new CsvReader(filePath);

			Country[] countries = reader.ReadFirstNCountries(10);

			foreach (Country country in countries)
			{
				Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
			}
		}
	}
}
