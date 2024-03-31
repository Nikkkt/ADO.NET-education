using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

// To start file you need to comment all code in Program.cs
class Program
{
    static async Task Main()
    {
        string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["FruitsAndVegetablesDB"].ConnectionString;

        DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
        DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

        using (var connection = factory.CreateConnection())
        {
            connection.ConnectionString = CONNECTION_STRING;

            try
            {
                await connection.OpenAsync();
                Console.WriteLine("Connection open\n");

                var command = factory.CreateCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM Produce";
                using (var reader = await command.ExecuteReaderAsync()) { while (await reader.ReadAsync()) Console.WriteLine(string.Format("Name: {0,-10}\tType: {1,-10}\tColour: {2,-10}\tCalories: {3,-10}", reader["name"], reader["type"], reader["color"], reader["calories"])); }

                command.CommandText = "UPDATE Produce SET name = 'Apples' WHERE id = 1";
                await command.ExecuteNonQueryAsync();

                command.CommandText = "DELETE FROM Produce WHERE id = 10";
                await command.ExecuteNonQueryAsync();

                await connection.CloseAsync();
            }
            catch (DbException ex) { Console.WriteLine("Connection error: " + ex.Message); }
        }
    }
}