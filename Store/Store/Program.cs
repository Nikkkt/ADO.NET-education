using System.Data.SqlClient;
const string CONNECTION_STRING = "Data Source=Nikita_laptop;Initial Catalog=Store2;Integrated Security=True";

// Tasks 1-3
using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
{
    try
    {
        connection.Open(); Console.WriteLine("\nConnection open");

        const string insert = "INSERT INTO Product (name, id_category, price, quantity, id_producer, id_measurement, id_discount) VALUES (@name, @id_category, @price, @quantity, @id_producer, @id_measurement, @id_discount)";
        using (SqlCommand cmd = new SqlCommand(insert, connection))
        {
            cmd.Parameters.AddWithValue("@name", "Beer");
            cmd.Parameters.AddWithValue("@id_category", 4);
            cmd.Parameters.AddWithValue("@price", 30);
            cmd.Parameters.AddWithValue("@quantity", 1000);
            cmd.Parameters.AddWithValue("@id_producer", 3);
            cmd.Parameters.AddWithValue("@id_measurement", 3);
            cmd.Parameters.AddWithValue("@id_discount", 2);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Product added");
        }

        const string update = "UPDATE Product SET name = @new_name WHERE id = @id";
        using (SqlCommand cmd = new SqlCommand(update, connection))
        {
            cmd.Parameters.AddWithValue("@new_name", "Chocolate");
            cmd.Parameters.AddWithValue("@id", 6);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Product updated");
        }

        const string delete = "DELETE FROM Product WHERE id = @id";
        using (SqlCommand cmd = new SqlCommand(delete, connection))
        {
            cmd.Parameters.AddWithValue("@id", 9);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Product deleted");
        }
    }
    catch (SqlException ex) { Console.WriteLine("\nConnection error: " + ex.Message); }
    finally { connection.Close(); Console.WriteLine("\nConnection close"); }
}

// Task 4
using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
{
    try
    {
        connection.Open(); Console.WriteLine("\nConnection open");

        // 1
        string query1 = "SELECT TOP 1 s.id, s.name, COUNT(p.id) as product_count FROM Supplier s JOIN Product p ON s.id = p.id_producer GROUP BY s.id, s.name ORDER BY product_count DESC";
        using (SqlCommand cmd = new SqlCommand(query1, connection)) { using (SqlDataReader reader = cmd.ExecuteReader()) { while (reader.Read()) Console.WriteLine($"supplier_id:\t{reader["id"]}," + $"\tname:\t{reader["name"]}," + $"\tproduct_count:\t{reader["product_count"]}"); } }

        // 2
        string query2 = "SELECT TOP 1 s.id, s.name, COUNT(p.id) as product_count FROM Supplier s JOIN Product p ON s.id = p.id_producer GROUP BY s.id, s.name ORDER BY product_count";
        using (SqlCommand cmd = new SqlCommand(query2, connection)) { using (SqlDataReader reader = cmd.ExecuteReader()) { while (reader.Read()) Console.WriteLine($"supplier_id:\t{reader["id"]}," + $"\tname:\t{reader["name"]}," + $"\tproduct_count:\t{reader["product_count"]}"); } }

        // 3
        string query3 = "SELECT TOP 1 c.id, c.name, SUM(p.quantity) as total_quantity FROM Category c JOIN Product p ON c.id = p.id_category GROUP BY c.id, c.name ORDER BY total_quantity DESC";
        using (SqlCommand cmd = new SqlCommand(query3, connection)) { using (SqlDataReader reader = cmd.ExecuteReader()) { while (reader.Read()) Console.WriteLine($"category_id:\t{reader["id"]}," + $"\tname:\t{reader["name"]}," + $"\ttotal_quantity:\t{reader["total_quantity"]}"); } }

        // 4
        string query4 = "SELECT TOP 1 c.id, c.name, SUM(p.quantity) as total_quantity FROM Category c JOIN Product p ON c.id = p.id_category GROUP BY c.id, c.name ORDER BY total_quantity";
        using (SqlCommand cmd = new SqlCommand(query4, connection)) { using (SqlDataReader reader = cmd.ExecuteReader()) { while (reader.Read()) Console.WriteLine($"category_id:\t{reader["id"]}," + $"\tname:\t{reader["name"]}," + $"\ttotal_quantity:\t{reader["total_quantity"]}"); } }

        // 5
        string query5 = "SELECT p.id, p.name FROM Product p JOIN Delivery d ON p.id = d.id_product WHERE DATEDIFF(day, d.date_of_delivery, GETDATE()) > @days";
        using (SqlCommand cmd = new SqlCommand(query5, connection))
        {
            cmd.Parameters.AddWithValue("@days", 30);
            using (SqlDataReader reader = cmd.ExecuteReader()) { while (reader.Read()) Console.WriteLine($"product_id:\t{reader["id"]}," + $"\tname:\t{reader["name"]}"); }
        }

    }
    catch (SqlException ex) { Console.WriteLine("\nConnection error: " + ex.Message); }
    finally { connection.Close(); Console.WriteLine("\nConnection close"); }
}