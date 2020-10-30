using System;

namespace TopTenPopulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"/Users/kevhan/Documents/Csharp_dotnet/Simple_Applications/TopTenPopulation/Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            // read the first 10 lines/countries
            Country[] countries = reader.ReadFirstNCountries(10);

            foreach (Country country in countries)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }
    }
}
