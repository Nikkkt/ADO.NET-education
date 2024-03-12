using System.Data.SqlClient;
using System.Xml.Linq;

namespace Stationery
{
    internal class InsertClass
    {
        string CONNECTION_STRING;

        public InsertClass(string CONNECTION_STRING) { this.CONNECTION_STRING = CONNECTION_STRING; }

        public void InsertNewStationary(string name, int type, double price, int stock)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "INSERT INTO StationeryItems (ItemName, ItemTypeID, Price, StockQuantity) VALUES (@name, @type, @price, @stock)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@type", type);
                        command.Parameters.AddWithValue("@price", price);
                        command.Parameters.AddWithValue("@stock", stock);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex) { Console.WriteLine("\nConnection error: " + ex.Message); }
                finally { connection.Close(); Console.WriteLine("\nConnection close"); }
            }
        }

        public void InsertNewStationaryType(string typeName)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "INSERT INTO StationeryTypes (TypeName) VALUES (@name)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", typeName);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex) { Console.WriteLine("\nConnection error: " + ex.Message); }
                finally { connection.Close(); Console.WriteLine("\nConnection close"); }
            }
        }

        public void InsertNewManagers(string name, string email, int sales, double profit)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "INSERT INTO SalesManagers (ManagerName, ManagerEmail, TotalSales, TotalProfit) VALUES (@name, @email, @sales, @profit)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@sales", sales);
                        command.Parameters.AddWithValue("@profit", profit);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex) { Console.WriteLine("\nConnection error: " + ex.Message); }
                finally { connection.Close(); Console.WriteLine("\nConnection close"); }
            }
        }

        public void InsertNewBuyerCompanies(string name, string address, string contactPerson)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "INSERT INTO BuyerCompanies (CompanyName, CompanyAddress, ContactPerson) VALUES (@name, @address, @person)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@person", contactPerson);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex) { Console.WriteLine("\nConnection error: " + ex.Message); }
                finally { connection.Close(); Console.WriteLine("\nConnection close"); }
            }
        }
    }
}
