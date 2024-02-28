using System.ComponentModel.Design;
using System.Data.SqlClient;
const string CONNECTION_STRING = "Data Source=Nikita_laptop;Initial Catalog=FruitsAndVegetables;Integrated Security=True";

// Second task
using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
{
    try { connection.Open(); Console.WriteLine("Connection open"); }
    catch (SqlException ex) { Console.WriteLine("Connection error: " + ex.Message); }
    finally
    {
        try { connection.Close(); Console.WriteLine("Connection close\n\n"); }
        catch (SqlException ex) { Console.WriteLine("Connection error: " + ex.Message); }
    }
}

// Third task
using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
{
    try
    {
        connection.Open();
        Console.WriteLine("Connection open\n");

        // 1
        SqlCommand cmd = new SqlCommand("SELECT * FROM Produce", connection);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read()) Console.WriteLine(string.Format("Name: {0,-10}\tType: {1,-10}\tColour: {2,-10}\tCalories: {3,-10}", reader["name"], reader["type"], reader["color"], reader["calories"]));
        reader.Close();

        Console.WriteLine();

        // 2
        cmd = new SqlCommand("SELECT Name FROM Produce", connection);
        reader = cmd.ExecuteReader();

        while (reader.Read()) Console.WriteLine($"Name: {reader["name"]}");
        reader.Close();

        Console.WriteLine();

        // 3
        cmd = new SqlCommand("SELECT DISTINCT color FROM Produce", connection);
        reader = cmd.ExecuteReader();

        while (reader.Read()) Console.WriteLine($"Colour: {reader["color"]}");
        reader.Close();

        Console.WriteLine();

        // 4
        cmd = new SqlCommand("SELECT MAX(calories) FROM Produce", connection);
        Console.WriteLine($"MAX Calories: {cmd.ExecuteScalar()}\n");

        // 5
        cmd = new SqlCommand("SELECT MIN(calories) FROM Produce", connection);
        Console.WriteLine($"MIN Calories: {cmd.ExecuteScalar()}\n");

        // 6
        cmd = new SqlCommand("SELECT AVG(calories) FROM Produce", connection);
        Console.WriteLine($"AVG Calories: {cmd.ExecuteScalar()}\n");

        connection.Close();
        Console.WriteLine("Connection close\n\n");
    }
    catch (SqlException ex) { Console.WriteLine("Connection error: " + ex.Message); }
}

// Fourth task
using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
{
    try
    {
        connection.Open();
        Console.WriteLine("Connection open\n");

        // 1
        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Produce WHERE type = 'Vegetable'", connection);
        Console.WriteLine($"Vegetables amount: {cmd.ExecuteScalar()} \n");

        // 2
        cmd = new SqlCommand("SELECT COUNT(*) FROM Produce WHERE type = 'Fruit'", connection);
        Console.WriteLine($"Fruits amount: {cmd.ExecuteScalar()} \n");

        // 3
        string color = "Green";
        cmd = new SqlCommand($"SELECT COUNT(*) FROM Produce WHERE color = '{color}'", connection);
        Console.WriteLine($"Amount {color}: {cmd.ExecuteScalar()}\n");

        // 4
        cmd = new SqlCommand("SELECT color, COUNT(*) FROM Produce GROUP BY color", connection);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read()) Console.WriteLine($"Colour: {reader[0]}, Amount: {reader[1]}");
        reader.Close();

        Console.WriteLine();

        // 5
        int maxCalories = 40;
        cmd = new SqlCommand($"SELECT * FROM Produce WHERE calories < {maxCalories}", connection);
        reader = cmd.ExecuteReader();

        while (reader.Read()) Console.WriteLine(string.Format("Name: {0,-10}\tType: {1,-10}\tColour: {2,-10}\tCalories: {3,-10}", reader["name"], reader["type"], reader["color"], reader["calories"]));
        reader.Close();

        Console.WriteLine();

        // 6
        int minCalories = 80;
        cmd = new SqlCommand($"SELECT * FROM Produce WHERE calories > {minCalories}", connection);
        reader = cmd.ExecuteReader();

        while (reader.Read()) Console.WriteLine(string.Format("Name: {0,-10}\tType: {1,-10}\tColour: {2,-10}\tCalories: {3,-10}", reader["name"], reader["type"], reader["color"], reader["calories"]));
        reader.Close();

        Console.WriteLine();

        // 7
        int mnCalories = 40;
        int mxCalories = 80;

        cmd = new SqlCommand($"SELECT * FROM Produce WHERE calories BETWEEN {mnCalories} AND {mxCalories}", connection);
        reader = cmd.ExecuteReader();

        while (reader.Read()) Console.WriteLine(string.Format("Name: {0,-10}\tType: {1,-10}\tColour: {2,-10}\tCalories: {3,-10}", reader["name"], reader["type"], reader["color"], reader["calories"]));
        reader.Close();

        Console.WriteLine();

        // 8
        cmd = new SqlCommand("SELECT * FROM Produce WHERE color IN ('Желтый', 'Красный')", connection);
        reader = cmd.ExecuteReader();

        while (reader.Read()) Console.WriteLine(string.Format("Name: {0,-10}\tType: {1,-10}\tColour: {2,-10}\tCalories: {3,-10}", reader["name"], reader["type"], reader["color"], reader["calories"]));
        reader.Close();

        Console.WriteLine();
    }
    catch (SqlException ex) { Console.WriteLine("Connection error: " + ex.Message); }
    finally { connection.Close(); Console.WriteLine("Connection close"); }
}