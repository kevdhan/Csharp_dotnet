using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TopTenPopulation
{
    public class CsvReader
    {
		private string _csvFilePath;

		public CsvReader(string csvFilePath)
		{
			this._csvFilePath = csvFilePath;
		}

		public Country[] ReadFirstNCountries(int nCountries)
		{
			Country[] countries = new Country[nCountries];

			using (StreamReader sr = new StreamReader(_csvFilePath))
			{
				// read header line
				sr.ReadLine();

				// reading N number of countries
				for (int i = 0; i < nCountries; i++)
				{
					string csvLine = sr.ReadLine();

					/* inputs a line to create a country from and 
					 * inserts into the array of countries
					*/ 
					countries[i] = ReadCountryFromCsvLine(csvLine);
				}
			}

			return countries;
		}

		/// <summary>
        /// Returns a class Country populated with data from a string, parsed by comma's
        /// </summary>
        /// <param name="csvLine"></param>
        /// <returns> class Country </returns>
		public Country ReadCountryFromCsvLine(string csvLine)
		{
			string[] parts = csvLine.Split(new char[] { ',' });

			string name = parts[0];
			string code = parts[1];
			string region = parts[2];
			int population = int.Parse(parts[3]);

			return new Country(name, code, region, population);
		}
	}
}
