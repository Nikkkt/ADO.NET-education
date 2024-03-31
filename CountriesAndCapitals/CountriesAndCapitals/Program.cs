using System.Configuration;
using System.Data.SqlClient;
using System.Data;

string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["CountriesAndCapitalsDB"].ConnectionString;

// Task 2
using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
{
    connection.Open();

    DataTable countriesTable = new DataTable();
    using (SqlDataAdapter countriesAdapter = new SqlDataAdapter("SELECT * FROM Countries", connection)) { countriesAdapter.Fill(countriesTable); }

    // 1
    var allCountries = countriesTable.AsEnumerable();
    foreach (var country in allCountries) Console.WriteLine($"Id: {country.Field<int>("country_id")}\nName: {country.Field<string>("country_name")}\nPopulation: {country.Field<int>("population")}\nArea: {country.Field<double>("area")}\nIs in Europe: {country.Field<int>("isEurope") == 1}");
    Console.WriteLine();

    // 2
    var countryNames = allCountries.Select(row => row.Field<string>("country_name")).ToList();
    foreach (var name in countryNames) Console.WriteLine($"Country Name: {name}");
    Console.WriteLine();

    // 3
    DataTable capitalsTable = new DataTable();
    using (SqlDataAdapter capitalsAdapter = new SqlDataAdapter("SELECT * FROM Capitals", connection)) { capitalsAdapter.Fill(capitalsTable); }

    var capitalNames = capitalsTable.AsEnumerable().Select(row => row.Field<string>("capital_name")).ToList();
    foreach (var name in capitalNames) Console.WriteLine($"Capital Name: {name}");
    Console.WriteLine();

    // 4
    string targetCountryName = "China";

    DataTable bigCitiesTable = new DataTable();
    using (SqlDataAdapter citiesAdapter = new SqlDataAdapter($"SELECT TOP 1 City, population FROM (SELECT capital_name AS City, population FROM dbo.Capitals WHERE country_id = (SELECT country_id FROM dbo.Countries WHERE country_name = '{targetCountryName}') UNION ALL SELECT city_name AS City, population FROM dbo.Cities WHERE country_id = (SELECT country_id FROM dbo.Countries WHERE country_name = '{targetCountryName}')) AS CombinedCities ORDER BY population DESC", connection)) { citiesAdapter.Fill(bigCitiesTable); }

    var bigCitiesOfCountry = bigCitiesTable.AsEnumerable().Select(row => row.Field<string>("city")).ToList();
    foreach (var name in bigCitiesOfCountry) Console.WriteLine($"Big City Name: {name}");
    Console.WriteLine();

    // 5
    var bigCapitals = capitalsTable.AsEnumerable().Where(row => row.Field<int>("population") > 2000000).Select(row => row.Field<string>("capital_name")).ToList();
    foreach (var name in bigCapitals) Console.WriteLine($"Big Capital Name: {name}");
    Console.WriteLine();

    // 6
    var europeanCountries = countriesTable.AsEnumerable().Where(row => row.Field<int>("isEurope") == 1).Select(row => row.Field<string>("country_name")).ToList();
    foreach (var name in europeanCountries) Console.WriteLine($"European Country Name: {name}");
    Console.WriteLine();

    // 7
    double minArea = 600000;

    var largeCountries = countriesTable.AsEnumerable().Where(row => row.Field<double>("area") > minArea).Select(row => row.Field<string>("country_name")).ToList();
    foreach (var name in largeCountries) Console.WriteLine($"Large Country Name: {name}");
    Console.WriteLine();
}

// Task 3
using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
{
    connection.Open();

    // 1
    DataTable capitalsTable = new DataTable();
    using (SqlDataAdapter adapter3 = new SqlDataAdapter("SELECT * FROM Capitals", connection)) { adapter3.Fill(capitalsTable); }

    var capitalsWithAandP = capitalsTable.AsEnumerable().Where(row => row.Field<string>("capital_name").Contains("a", StringComparison.OrdinalIgnoreCase) && row.Field<string>("capital_name").Contains("p", StringComparison.OrdinalIgnoreCase)).ToList();
    foreach (var capital in capitalsWithAandP) Console.WriteLine($"Capital Name: {capital.Field<string>("capital_name")}");
    Console.WriteLine();

    // 2 (I do with letter "B" to get results)
    var capitalsStartingWithB = capitalsTable.AsEnumerable().Where(row => row.Field<string>("capital_name").StartsWith("b", StringComparison.OrdinalIgnoreCase)).ToList();
    foreach (var capital in capitalsStartingWithB) Console.WriteLine($"Capital Name: {capital.Field<string>("capital_name")}");
    Console.WriteLine();

    // 3
    DataTable countriesTable = new DataTable();
    using (SqlDataAdapter adapter4 = new SqlDataAdapter("SELECT * FROM Countries", connection)) { adapter4.Fill(countriesTable); }

    double minRange = 1000000;
    double maxRange = 10000000;

    var countriesInAreaRange = countriesTable.AsEnumerable().Where(row => row.Field<double>("area") >= minRange && row.Field<double>("area") <= maxRange).ToList();
    foreach (var country in countriesInAreaRange) Console.WriteLine($"Country Name: {country.Field<string>("country_name")}");
    Console.WriteLine();

    // 4
    int populationRange = 100000000;

    var countriesWithLargePopulation2 = countriesTable.AsEnumerable().Where(row => row.Field<int>("population") > populationRange).ToList();
    foreach (var country in countriesWithLargePopulation2) Console.WriteLine($"Country Name: {country.Field<string>("country_name")}");
    Console.WriteLine();
}

// Task 4
using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
{
    connection.Open();

    // 1
    DataTable countriesTable = new DataTable();
    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Countries", connection)) { adapter.Fill(countriesTable); }

    var topCountriesByArea = countriesTable.AsEnumerable().OrderByDescending(row => row.Field<double>("area")).Take(5).ToList();
    foreach (var country in topCountriesByArea) Console.WriteLine($"Country Name: {country.Field<string>("country_name")}\nArea: {country.Field<double>("area")}");
    Console.WriteLine();

    // 2
    DataTable capitalsTable = new DataTable();
    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Capitals", connection)) { adapter.Fill(capitalsTable); }

    var topCapitalsByPopulation = capitalsTable.AsEnumerable().OrderByDescending(row => row.Field<int>("population")).Take(5).ToList();
    foreach (var capital in topCapitalsByPopulation) Console.WriteLine($"Capital Name: {capital.Field<string>("capital_name")}\nPopulation: {capital.Field<int>("population")}");
    Console.WriteLine();

    // 3
    var largestCountry = countriesTable.AsEnumerable().OrderByDescending(row => row.Field<double>("area")).First();
    Console.WriteLine($"Country with Largest Area: {largestCountry.Field<string>("country_name")}\nArea: {largestCountry.Field<double>("area")}\n");

    // 4
    var capitalWithLargestPopulation = capitalsTable.AsEnumerable().OrderByDescending(row => row.Field<int>("population")).First();
    Console.WriteLine($"Capital with Largest Population: {capitalWithLargestPopulation.Field<string>("capital_name")}\nPopulation: {capitalWithLargestPopulation.Field<int>("population")}\n");

    // 5
    var smallestEuropeanCountry = countriesTable.AsEnumerable().Where(row => row.Field<int>("isEurope") == 1).OrderBy(row => row.Field<double>("area")).First();
    Console.WriteLine($"Smallest European Country: {smallestEuropeanCountry.Field<string>("country_name")}\nArea: {smallestEuropeanCountry.Field<double>("area")}\n");

    // 6
    var averageAreaOfEuropeanCountries = countriesTable.AsEnumerable().Where(row => row.Field<int>("isEurope") == 1).Average(row => row.Field<double>("area"));
    Console.WriteLine($"Average Area of European Countries: {Math.Round(averageAreaOfEuropeanCountries, 2)}\n");

    // 7 (Do top-2)
    string countryName = "Germany";

    DataTable citiesOfCountryTable = new DataTable();
    using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT TOP 2 City, population FROM (SELECT capital_name AS City, population FROM dbo.Capitals WHERE country_id = (SELECT country_id FROM dbo.Countries WHERE country_name = '{countryName}') UNION ALL SELECT city_name AS City, population FROM dbo.Cities WHERE country_id = (SELECT country_id FROM dbo.Countries WHERE country_name = '{countryName}')) AS CombinedCities ORDER BY population DESC", connection)) { adapter.Fill(citiesOfCountryTable); }

    var topCitiesOfCountry = citiesOfCountryTable.AsEnumerable().OrderByDescending(row => row.Field<int>("population")).Take(3).ToList();
    foreach (var city in topCitiesOfCountry) Console.WriteLine($"City Name: {city.Field<string>("city")}\nPopulation: {city.Field<int>("population")}\n");

    // 8 
    var totalNumberOfCountries = countriesTable.AsEnumerable().Count();
    Console.WriteLine($"Total Number of Countries: {totalNumberOfCountries}\n");

    // 9 (With my bd it can't run)
    DataTable continentsTable = new DataTable();
    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Continents", connection)) { adapter.Fill(continentsTable); }

    var continentWithMostCountries = continentsTable.AsEnumerable().OrderByDescending(row => countriesTable.AsEnumerable().Count(c => c.Field<int>("id_continent") == row.Field<int>("id_continent"))).First();
    Console.WriteLine($"Continent with Most Countries: {continentWithMostCountries.Field<string>("continent_name")}\n");

    // 10 (With my bd it can't run)
    foreach (var continent in continentsTable.AsEnumerable())
    {
        var numOfCountriesInContinent = countriesTable.AsEnumerable().Count(c => c.Field<int>("id_continent") == continent.Field<int>("id_continent"));
        Console.WriteLine($"Continent: {continent.Field<string>("continent_name")}\nNumber of Countries: {numOfCountriesInContinent}");
    }
    Console.WriteLine();
}
