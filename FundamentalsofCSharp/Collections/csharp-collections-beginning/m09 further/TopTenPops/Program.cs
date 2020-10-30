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
			string filePath = @"G:\G_Work\Pluralsight\Courses\Beginning Effective Collections\Code\Pop by Largest Final.csv";
			CsvReader reader = new CsvReader(filePath);

			// using the array with an interface
			IList<Country> countries = reader.ReadFirstNCountries(10);

			foreach (Country country in countries)
			{
				Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
			}
		}
	}
}
