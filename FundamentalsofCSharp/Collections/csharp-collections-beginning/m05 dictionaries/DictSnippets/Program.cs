using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.BegCShCollections.DictSnippets
{
	class Program
	{
		static void Main(string[] args)
		{
			Country norway = new Country("Norway", "NOR", "Europe", 5_282_223);
			Country finland = new Country("Finland", "FIN", "Europe", 5_511_303);

			var countries = new Dictionary<string, Country>();
			countries.Add(norway.Code, norway);
			countries.Add(finland.Code, finland);

			Console.WriteLine("Enumerating...");
			foreach (Country nextCountry in countries.Values)
				Console.WriteLine(nextCountry.Name);
			Console.WriteLine();

			//Console.WriteLine(countries["MUS"].Name);
			bool exists = countries.TryGetValue("MUS", out Country country);
			if (exists)
				Console.WriteLine(country.Name);
			else
				Console.WriteLine("There is no country with the code MUS");

		}
	}
}
