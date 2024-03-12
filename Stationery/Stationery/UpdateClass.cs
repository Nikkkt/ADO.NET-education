using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery
{
    internal class UpdateClass
    {
        string CONNECTION_STRING;

        public UpdateClass(string CONNECTION_STRING) { this.CONNECTION_STRING = CONNECTION_STRING; }

        // I know that I could split all the methods below, but it would be a lot of code and I don't have much time(
        public void UpdateStationary(string name, int type, double price, int stock, string changeName, int changeType, double changePrice, int changeStock)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "UPDATE StationeryItems SET ItemName = @changeName, ItemTypeID = @changeType, Price = @changePrice, StockQuantity = @changeStock " +
                        "WHERE ItemName = @name AND ItemTypeID = @type AND Price = @price AND StockQuantity = @stock";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@changeName", changeName);
                        command.Parameters.AddWithValue("@changeType", changeType);
                        command.Parameters.AddWithValue("@changePrice", changePrice);
                        command.Parameters.AddWithValue("@changeStock", changeStock);
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

        public void UpdateStationaryType(string typeName, string changeName)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "UPDATE StationeryTypes SET TypeName = @changeName WHERE TypeName = @name";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@changeName", changeName);
                        command.Parameters.AddWithValue("@name", typeName);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex) { Console.WriteLine("\nConnection error: " + ex.Message); }
                finally { connection.Close(); Console.WriteLine("\nConnection close"); }
            }
        }

        public void UpdateManagers(string name, string email, int sales, double profit, string changeName, string changeEmail, int changeSales, double changeProfit)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "UPDATE SalesManagers SET ManagerName = @changeName, ManagerEmail = @changeEmail, TotalSales = @changeSales, TotalProfit = @changeProfit " +
                        "WHERE ManagerName = @name AND ManagerEmail = @email AND TotalSales = @sales AND TotalProfit = @profit"; 
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@changeName", changeName);
                        command.Parameters.AddWithValue("@changeEmail", changeEmail);
                        command.Parameters.AddWithValue("@changeSales", changeSales);
                        command.Parameters.AddWithValue("@changeProfit", changeProfit);
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

        public void UpdateBuyerCompanies(string name, string address, string contactPerson, string changeName, string changeAddress, string changeContactPerson)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "UPDATE BuyerCompanies SET CompanyName = @changeName, CompanyAddress = @changeAddress, ContactPerson = @changePerson " +
                        "WHERE CompanyName = @name AND CompanyAddress = @address AND ContactPerson = @person";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@changeName", changeName);
                        command.Parameters.AddWithValue("@changeAddress", changeAddress);
                        command.Parameters.AddWithValue("@changePerson", changeContactPerson);
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
