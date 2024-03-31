using System.Data;
using System.Data.SqlClient;

const string CONNECTION_STRING = "Data Source=Nikita_laptop;Initial Catalog=CoffeeShop;Integrated Security=True";

// Task 1
using (SqlConnection coffeeConnection = new SqlConnection(CONNECTION_STRING))
{
    SqlDataAdapter coffeeAdapter = new SqlDataAdapter("SELECT * FROM Coffee", coffeeConnection);
    SqlCommandBuilder coffeeCommandBuilder = new SqlCommandBuilder(coffeeAdapter);

    DataSet coffeeDataSet = new DataSet();
    coffeeAdapter.Fill(coffeeDataSet, "Coffee");

    DataTable coffeeTable = coffeeDataSet.Tables["Coffee"];
    DataRow newCoffeeRow = coffeeTable.NewRow();
    newCoffeeRow["name"] = "Coffee";
    newCoffeeRow["description"] = "Some description";
    newCoffeeRow["type"] = "Arabica";
    newCoffeeRow["origin_country"] = "Brazil";
    newCoffeeRow["cost_price"] = 10.00;
    newCoffeeRow["selling_price"] = 20.00;
    newCoffeeRow["grams"] = 350;

    coffeeTable.Rows.Add(newCoffeeRow);

    DataRow editCoffeeRow = coffeeTable.Rows[0];
    editCoffeeRow["name"] = "Brazilian Super Blend";

    DataRow deleteCoffeeRow = coffeeTable.Rows[7];
    coffeeTable.Rows.Remove(deleteCoffeeRow);

    coffeeAdapter.Update(coffeeDataSet, "Coffee");
}

// Task 2
using (SqlConnection coffeeConnection = new SqlConnection(CONNECTION_STRING))
{
    SqlDataAdapter coffeeAdapter = new SqlDataAdapter("SELECT * FROM Coffee", coffeeConnection);
    SqlCommandBuilder coffeeCommandBuilder = new SqlCommandBuilder(coffeeAdapter);

    DataSet coffeeDataSet = new DataSet();
    coffeeAdapter.Fill(coffeeDataSet, "Coffee");

    DataTable coffeeTable = coffeeDataSet.Tables["Coffee"];

    // 1
    var cherryCoffee = coffeeTable.AsEnumerable().Where(row => row.Field<string>("description").Contains("cherry"));

    Console.WriteLine("Coffee with cherry: ");
    foreach (var row in cherryCoffee) Console.WriteLine($"Name: {row.Field<string>("name")}\nDescription: {row.Field<string>("description")}");

    // 2
    var costRangeCoffee = coffeeTable.AsEnumerable().Where(row => row.Field<decimal>("cost_price") >= 7 && row.Field<decimal>("cost_price") <= 10);

    Console.WriteLine("\nCoffee with a cost price within the specified range: ");
    foreach (var row in costRangeCoffee) Console.WriteLine($"Name: {row.Field<string>("name")}\nCost price: {row.Field<decimal>("cost_price")}");

    // 3
    var weightRangeCoffee = coffeeTable.AsEnumerable().Where(row => row.Field<double>("grams") >= 250 && row.Field<double>("grams") <= 300);

    Console.WriteLine("\nCoffee with the number of grams in the specified range:");
    foreach (var row in weightRangeCoffee) Console.WriteLine($"Name: {row.Field<string>("name")}\nGrams: {row.Field<double>("grams")}");

    // 4
    var specificCountryCoffee = coffeeTable.AsEnumerable().Where(row => row.Field<string>("origin_country") == "Brazil" || row.Field<string>("origin_country") == "Vietnam");

    Console.WriteLine("\nCoffee from the following countries: ");
    foreach (var row in specificCountryCoffee) Console.WriteLine($"Name: {row.Field<string>("name")}\nCountry: {row.Field<string>("origin_country")}");
}

// Task 3
using (SqlConnection coffeeConnection = new SqlConnection(CONNECTION_STRING))
{
    SqlDataAdapter coffeeAdapter = new SqlDataAdapter("SELECT * FROM Coffee", coffeeConnection);
    SqlCommandBuilder coffeeCommandBuilder = new SqlCommandBuilder(coffeeAdapter);

    DataSet coffeeDataSet = new DataSet();
    coffeeAdapter.Fill(coffeeDataSet, "Coffee");

    DataTable coffeeTable = coffeeDataSet.Tables["Coffee"];

    // 1
    var coffeeCountByCountry = coffeeTable.AsEnumerable()
                                          .GroupBy(row => row.Field<string>("origin_country"))
                                          .Select(group => new { Country = group.Key, Count = group.Count() });

    Console.WriteLine("Country name and number of coffee varieties: ");
    foreach (var group in coffeeCountByCountry) Console.WriteLine($"Country: {group.Country}\nNumber of coffee varieties: {group.Count}");

    // 2
    var averageGramsByCountry = coffeeTable.AsEnumerable()
                                           .GroupBy(row => row.Field<string>("origin_country"))
                                           .Select(group => new { Country = group.Key, AverageGrams = group.Average(row => row.Field<double>("grams")) });

    Console.WriteLine("\nAverage number of grams of coffee per country: ");
    foreach (var item in averageGramsByCountry) Console.WriteLine($"Country: {item.Country}\nAverage number of grams: {Math.Round(item.AverageGrams, 2)}");

    // 3
    var cheapestCoffeeFromBrazil = coffeeTable.AsEnumerable()
                                              .Where(row => row.Field<string>("origin_country") == "Brazil")
                                              .OrderBy(row => row.Field<decimal>("cost_price"))
                                              .Take(3);

    Console.WriteLine("\nThree of the cheapest types of coffee (Brazil): ");
    foreach (var row in cheapestCoffeeFromBrazil) Console.WriteLine($"Name: {row.Field<string>("name")}\nCost: {row.Field<decimal>("cost_price")}");

    // 4
    var mostExpensiveCoffeeFromBrazil = coffeeTable.AsEnumerable()
                                                   .Where(row => row.Field<string>("origin_country") == "Brazil")
                                                   .OrderByDescending(row => row.Field<decimal>("cost_price"))
                                                   .Take(3);

    Console.WriteLine("\nThree most expensive types of coffee (Brazil): ");
    foreach (var row in mostExpensiveCoffeeFromBrazil) Console.WriteLine($"Name: {row.Field<string>("name")}\nCost: {row.Field<decimal>("cost_price")}");

    // 5
    var cheapestCoffee = coffeeTable.AsEnumerable()
                                    .OrderBy(row => row.Field<decimal>("cost_price"))
                                    .Take(3);

    Console.WriteLine("\nThe three cheapest coffees (all countries): ");
    foreach (var row in cheapestCoffee) Console.WriteLine($"Name: {row.Field<string>("name")}\nCost: {row.Field<decimal>("cost_price")}");

    // 6
    var mostExpensiveCoffee = coffeeTable.AsEnumerable()
                                         .OrderByDescending(row => row.Field<decimal>("cost_price"))
                                         .Take(3);

    Console.WriteLine("\nThe three most expensive coffees (all countries): ");
    foreach (var row in mostExpensiveCoffee) Console.WriteLine($"Name: {row.Field<string>("name")}\nCost: {row.Field<decimal>("cost_price")}");
}

// Task 4
using (SqlConnection coffeeConnection = new SqlConnection(CONNECTION_STRING))
{
    SqlDataAdapter coffeeAdapter = new SqlDataAdapter("SELECT * FROM Coffee ", coffeeConnection);
    SqlCommandBuilder coffeeCommandBuilder = new SqlCommandBuilder(coffeeAdapter);

    DataSet coffeeDataSet = new DataSet();
    coffeeAdapter.Fill(coffeeDataSet, "Coffee");

    DataTable coffeeTable = coffeeDataSet.Tables["Coffee"];

    // 1
    var top3CountriesByCoffeeVariety = coffeeTable.AsEnumerable()
                                                  .GroupBy(row => row.Field<string>("origin_country"))
                                                  .Select(group => new { Country = group.Key, Count = group.Count() })
                                                  .OrderByDescending(group => group.Count)
                                                  .Take(3);

    Console.WriteLine("Top 3 countries by number of coffee types: ");
    foreach (var item in top3CountriesByCoffeeVariety) Console.WriteLine($"Country: {item.Country}\nNumber of coffee types: {item.Count}");

    // 2
    var top3CountriesByCoffeeWeight = coffeeTable.AsEnumerable()
                                                 .GroupBy(row => row.Field<string>("origin_country"))
                                                 .Select(group => new { Country = group.Key, TotalGrams = group.Sum(row => row.Field<double>("grams")) })
                                                 .OrderByDescending(group => group.TotalGrams)
                                                 .Take(3);

    Console.WriteLine("\nTop 3 countries by the number of grams of coffee: ");
    foreach (var item in top3CountriesByCoffeeWeight) Console.WriteLine($"Country: {item.Country}\nTotal grams: {item.TotalGrams}");

    // 3
    Console.WriteLine();
    string[] coffeeTypes = { "Arabica", "Robusta", "blend" };
    foreach (var type in coffeeTypes)
    {
        var top3CoffeeByWeight = coffeeTable.AsEnumerable()
                                            .Where(row => row.Field<string>("type") == type)
                                            .OrderByDescending(row => row.Field<double>("grams"))
                                            .Take(3);

        Console.WriteLine($"\nTop 3 types of coffee {type} by the number of grams: ");
        foreach (var row in top3CoffeeByWeight) Console.WriteLine($"Name: {row.Field<string>("name")}\nGrams: {row.Field<double>("grams")}");
    }
    Console.WriteLine();

    // 4
    var allCoffeeTypes = coffeeTable.AsEnumerable().Select(row => row.Field<string>("type")).Distinct();

    foreach (var type in allCoffeeTypes)
    {
        var top3CoffeeByWeight = coffeeTable.AsEnumerable()
                                            .Where(row => row.Field<string>("type") == type)
                                            .OrderByDescending(row => row.Field<double>("grams"))
                                            .Take(3);

        Console.WriteLine($"\nTop 3 types of coffee {type} by the number of grams:");
        foreach (var row in top3CoffeeByWeight) Console.WriteLine($"Name: {row.Field<string>("name")}\nGrams: {row.Field<double>("grams")}");
    }
}