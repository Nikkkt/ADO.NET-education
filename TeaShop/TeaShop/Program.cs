using System.Data;
using System.Data.SqlClient;

const string CONNECTION_STRING = "Data Source=Nikita_laptop;Initial Catalog=TeaShop;Integrated Security=True";

// Task 1
using (SqlConnection TeaConnection = new SqlConnection(CONNECTION_STRING))
{
    SqlDataAdapter TeaAdapter = new SqlDataAdapter("SELECT * FROM Tea", TeaConnection);
    SqlCommandBuilder TeaCommandBuilder = new SqlCommandBuilder(TeaAdapter);

    DataSet TeaDataSet = new DataSet();
    TeaAdapter.Fill(TeaDataSet, "Tea");

    DataTable TeaTable = TeaDataSet.Tables["Tea"];
    DataRow newTeaRow = TeaTable.NewRow();
    newTeaRow["name"] = "Tea";
    newTeaRow["description"] = "Some description";
    newTeaRow["type"] = "Black";
    newTeaRow["origin_country"] = "India";
    newTeaRow["cost_price"] = 10.00;
    newTeaRow["selling_price"] = 20.00;
    newTeaRow["grams"] = 350;

    TeaTable.Rows.Add(newTeaRow);

    DataRow editTeaRow = TeaTable.Rows[0];
    editTeaRow["name"] = "Indian Super Black tea";

    DataRow deleteTeaRow = TeaTable.Rows[7];
    TeaTable.Rows.Remove(deleteTeaRow);

    TeaAdapter.Update(TeaDataSet, "Tea");
}

// Task 2
using (SqlConnection TeaConnection = new SqlConnection(CONNECTION_STRING))
{
    SqlDataAdapter TeaAdapter = new SqlDataAdapter("SELECT * FROM Tea", TeaConnection);
    SqlCommandBuilder TeaCommandBuilder = new SqlCommandBuilder(TeaAdapter);

    DataSet TeaDataSet = new DataSet();
    TeaAdapter.Fill(TeaDataSet, "Tea");

    DataTable TeaTable = TeaDataSet.Tables["Tea"];

    // 1
    var cherryTea = TeaTable.AsEnumerable().Where(row => row.Field<string>("description").Contains("cherry"));

    Console.WriteLine("Tea with cherry: ");
    foreach (var row in cherryTea) Console.WriteLine($"Name: {row.Field<string>("name")}\nDescription: {row.Field<string>("description")}");

    // 2
    var costRangeTea = TeaTable.AsEnumerable().Where(row => row.Field<decimal>("cost_price") >= 7 && row.Field<decimal>("cost_price") <= 10);

    Console.WriteLine("\nTea with a cost price within the specified range: ");
    foreach (var row in costRangeTea) Console.WriteLine($"Name: {row.Field<string>("name")}\nCost price: {row.Field<decimal>("cost_price")}");

    // 3
    var weightRangeTea = TeaTable.AsEnumerable().Where(row => row.Field<double>("grams") >= 250 && row.Field<double>("grams") <= 300);

    Console.WriteLine("\nTea with the number of grams in the specified range:");
    foreach (var row in weightRangeTea) Console.WriteLine($"Name: {row.Field<string>("name")}\nGrams: {row.Field<double>("grams")}");

    // 4
    var specificCountryTea = TeaTable.AsEnumerable().Where(row => row.Field<string>("origin_country") == "India" || row.Field<string>("origin_country") == "Japan");

    Console.WriteLine("\nTea from the following countries: ");
    foreach (var row in specificCountryTea) Console.WriteLine($"Name: {row.Field<string>("name")}\nCountry: {row.Field<string>("origin_country")}");
}

// Task 3
using (SqlConnection TeaConnection = new SqlConnection(CONNECTION_STRING))
{
    SqlDataAdapter TeaAdapter = new SqlDataAdapter("SELECT * FROM Tea", TeaConnection);
    SqlCommandBuilder TeaCommandBuilder = new SqlCommandBuilder(TeaAdapter);

    DataSet TeaDataSet = new DataSet();
    TeaAdapter.Fill(TeaDataSet, "Tea");

    DataTable TeaTable = TeaDataSet.Tables["Tea"];

    // 1
    var TeaCountByCountry = TeaTable.AsEnumerable()
                                    .GroupBy(row => row.Field<string>("origin_country"))
                                    .Select(group => new { Country = group.Key, Count = group.Count() });

    Console.WriteLine("Country name and number of Tea varieties: ");
    foreach (var group in TeaCountByCountry) Console.WriteLine($"Country: {group.Country}\nNumber of Tea varieties: {group.Count}");

    // 2
    var averageGramsByCountry = TeaTable.AsEnumerable()
                                        .GroupBy(row => row.Field<string>("origin_country"))
                                        .Select(group => new { Country = group.Key, AverageGrams = group.Average(row => row.Field<double>("grams")) });

    Console.WriteLine("\nAverage number of grams of Tea per country: ");
    foreach (var item in averageGramsByCountry) Console.WriteLine($"Country: {item.Country}\nAverage number of grams: {Math.Round(item.AverageGrams, 2)}");

    // 3
    var cheapestTeaFromJapan = TeaTable.AsEnumerable()
                                        .Where(row => row.Field<string>("origin_country") == "Japan")
                                        .OrderBy(row => row.Field<decimal>("cost_price"))
                                        .Take(3);

    Console.WriteLine("\nThree of the cheapest types of Tea (Japan): ");
    foreach (var row in cheapestTeaFromJapan) Console.WriteLine($"Name: {row.Field<string>("name")}\nCost: {row.Field<decimal>("cost_price")}");

    // 4
    var mostExpensiveTeaFromJapan = TeaTable.AsEnumerable()
                                             .Where(row => row.Field<string>("origin_country") == "Japan")
                                             .OrderByDescending(row => row.Field<decimal>("cost_price"))
                                             .Take(3);

    Console.WriteLine("\nThree most expensive types of Tea (Japan): ");
    foreach (var row in mostExpensiveTeaFromJapan) Console.WriteLine($"Name: {row.Field<string>("name")}\nCost: {row.Field<decimal>("cost_price")}");

    // 5
    var cheapestTea = TeaTable.AsEnumerable()
                              .OrderBy(row => row.Field<decimal>("cost_price"))
                              .Take(3);

    Console.WriteLine("\nThe three cheapest Teas (all countries): ");
    foreach (var row in cheapestTea) Console.WriteLine($"Name: {row.Field<string>("name")}\nCost: {row.Field<decimal>("cost_price")}");

    // 6
    var mostExpensiveTea = TeaTable.AsEnumerable()
                                   .OrderByDescending(row => row.Field<decimal>("cost_price"))
                                   .Take(3);

    Console.WriteLine("\nThe three most expensive Teas (all countries): ");
    foreach (var row in mostExpensiveTea) Console.WriteLine($"Name: {row.Field<string>("name")}\nCost: {row.Field<decimal>("cost_price")}");
}

// Task 4
using (SqlConnection TeaConnection = new SqlConnection(CONNECTION_STRING))
{
    SqlDataAdapter TeaAdapter = new SqlDataAdapter("SELECT * FROM Tea ", TeaConnection);
    SqlCommandBuilder TeaCommandBuilder = new SqlCommandBuilder(TeaAdapter);

    DataSet TeaDataSet = new DataSet();
    TeaAdapter.Fill(TeaDataSet, "Tea");

    DataTable TeaTable = TeaDataSet.Tables["Tea"];

    // 1
    var top3CountriesByTeaVariety = TeaTable.AsEnumerable()
                                            .GroupBy(row => row.Field<string>("origin_country"))
                                            .Select(group => new { Country = group.Key, Count = group.Count() })
                                            .OrderByDescending(group => group.Count)
                                            .Take(3);

    Console.WriteLine("Top 3 countries by number of Tea types: ");
    foreach (var item in top3CountriesByTeaVariety) Console.WriteLine($"Country: {item.Country}\nNumber of Tea types: {item.Count}");

    // 2
    var top3CountriesByTeaWeight = TeaTable.AsEnumerable()
                                           .GroupBy(row => row.Field<string>("origin_country"))
                                           .Select(group => new { Country = group.Key, TotalGrams = group.Sum(row => row.Field<double>("grams")) })
                                           .OrderByDescending(group => group.TotalGrams)
                                           .Take(3);

    Console.WriteLine("\nTop 3 countries by the number of grams of Tea: ");
    foreach (var item in top3CountriesByTeaWeight) Console.WriteLine($"Country: {item.Country}\nTotal grams: {item.TotalGrams}");

    // 3
    Console.WriteLine();
    string[] TeaTypes = { "Black", "Green" };
    foreach (var type in TeaTypes)
    {
        var top3TeaByWeight = TeaTable.AsEnumerable()
                                      .Where(row => row.Field<string>("type") == type)
                                      .OrderByDescending(row => row.Field<double>("grams"))
                                      .Take(3);

        Console.WriteLine($"\nTop 3 types of Tea {type} by the number of grams: ");
        foreach (var row in top3TeaByWeight) Console.WriteLine($"Name: {row.Field<string>("name")}\nGrams: {row.Field<double>("grams")}");
    }
    Console.WriteLine();

    // 4
    var allTeaTypes = TeaTable.AsEnumerable().Select(row => row.Field<string>("type")).Distinct();

    foreach (var type in allTeaTypes)
    {
        var top3TeaByWeight = TeaTable.AsEnumerable()
                                      .Where(row => row.Field<string>("type") == type)
                                      .OrderByDescending(row => row.Field<double>("grams"))
                                      .Take(3);

        Console.WriteLine($"\nTop 3 types of Tea {type} by the number of grams:");
        foreach (var row in top3TeaByWeight) Console.WriteLine($"Name: {row.Field<string>("name")}\nGrams: {row.Field<double>("grams")}");
    }
}
