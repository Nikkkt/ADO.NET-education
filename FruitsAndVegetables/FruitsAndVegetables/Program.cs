using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["FruitsAndVegetablesDB"].ConnectionString;

Console.Write("Choose DBMS:\n1 - SQL Server\n2 - MySQL\n3 - PostgreSQL\n>>> ");
var dbChoice = Console.ReadLine();

string providerName = dbChoice switch { "1" => "System.Data.SqlClient", "2" => "MySql.Data.MySqlClient", "3" => "Npgsql", _ => throw new Exception("Невідомий вибір СКБД") };

DbProviderFactories.RegisterFactory(providerName, SqlClientFactory.Instance);
DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

using (var connection = factory.CreateConnection())
{
    connection.ConnectionString = CONNECTION_STRING;

    try
    {
        var stopwatch = Stopwatch.StartNew();

        connection.Open();
        Console.WriteLine("Connection open\n");

        var command = factory.CreateCommand();
        command.Connection = connection;

        command.CommandText = "SELECT * FROM Produce";
        using (var reader = command.ExecuteReader()) { while (reader.Read()) Console.WriteLine(string.Format("Name: {0,-10}\tType: {1,-10}\tColour: {2,-10}\tCalories: {3,-10}", reader["name"], reader["type"], reader["color"], reader["calories"])); }
        Console.WriteLine($"\nTime: {stopwatch.Elapsed.TotalSeconds} s\n");

        command.CommandText = "SELECT Name FROM Produce";
        using (var reader = command.ExecuteReader()) { while (reader.Read()) Console.WriteLine($"Name: {reader["name"]}"); }
        Console.WriteLine($"\nTime: {stopwatch.Elapsed.TotalSeconds} s\n");

        command.CommandText = "SELECT DISTINCT color FROM Produce";
        using (var reader = command.ExecuteReader()) { while (reader.Read()) Console.WriteLine($"Colour: {reader["color"]}"); }
        Console.WriteLine($"\nTime: {stopwatch.Elapsed.TotalSeconds} s\n");

        command.CommandText = "SELECT MAX(calories) FROM Produce";
        Console.WriteLine($"Max calories: {command.ExecuteScalar()}");
        Console.WriteLine($"\nTime: {stopwatch.Elapsed.TotalSeconds} s\n");

        command.CommandText = "SELECT MIN(calories) FROM Produce";
        Console.WriteLine($"Min calories: {command.ExecuteScalar()}");
        Console.WriteLine($"\nTime: {stopwatch.Elapsed.TotalSeconds} s\n");

        command.CommandText = "SELECT AVG(calories) FROM Produce";
        Console.WriteLine($"Average calories: {command.ExecuteScalar()}");
        Console.WriteLine($"\nTime: {stopwatch.Elapsed.TotalSeconds} s\n");

        connection.Close();
    }
    catch (DbException ex) { Console.WriteLine("Connection error: " + ex.Message); }
}