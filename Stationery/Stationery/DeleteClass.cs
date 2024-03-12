using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Stationery
{
    internal class DeleteClass
    {
        string CONNECTION_STRING;

        public DeleteClass(string CONNECTION_STRING) { this.CONNECTION_STRING = CONNECTION_STRING; }

        public void DeleteStationary(string name, int type, double price, int stock)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "SET IDENTITY_INSERT ArchivedStationeryItems ON " +
                    "INSERT INTO ArchivedStationeryItems (ItemName, ItemTypeID, Price, StockQuantity)" +
                    "SELECT ItemName, ItemTypeID, Price, StockQuantity FROM StationeryItems " +
                    "WHERE ItemName = @name AND ItemTypeID = @type AND Price = @price AND StockQuantity = @stock; " +
                    
                    "SET IDENTITY_INSERT ArchivedStationeryItems OFF " +
                    "DELETE FROM StationeryItems " +
                    "WHERE ItemName = @name AND ItemTypeID = @type AND Price = @price AND StockQuantity = @stock ";

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

        public void DeleteStationaryType(string typeName)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "SET IDENTITY_INSERT ArchivedStationeryTypes ON " +
                        "INSERT INTO ArchivedStationeryTypes (TypeName) " +
                        "SELECT TypeName FROM StationeryTypes " +
                        "WHERE TypeName = @name " +
                        
                        "DELETE FROM StationeryTypes " +
                        "WHERE TypeName = @name " +
                        "SET IDENTITY_INSERT ArchivedStationeryTypes OFF ";

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

        public void DeleteManagers(string name, string email, int sales, double profit)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "SET IDENTITY_INSERT ArchivedSalesManagers ON " +
                        "INSERT INTO ArchivedSalesManagers (ManagerName, ManagerEmail, TotalSales, TotalProfit) " +
                        "SELECT ManagerName, ManagerEmail, TotalSales, TotalProfit FROM SalesManagers " +
                        "WHERE ManagerName = @name AND ManagerEmail = @email AND TotalSales = @sales AND TotalProfit = @profit " +

                        "SET IDENTITY_INSERT ArchivedSalesManagers OFF " +
                        "DELETE FROM SalesManagers " +
                        "WHERE ManagerName = @name AND ManagerEmail = @email AND TotalSales = @sales AND TotalProfit = @profit ";

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

        public void DeleteBuyerCompanies(string name, string address, string contactPerson)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "SET IDENTITY_INSERT ArchivedBuyerCompanies ON " +
                        "INSERT INTO ArchivedBuyerCompanies (CompanyName, CompanyAddress, ContactPerson)" +
                        "SELECT CompanyName, CompanyAddress, ContactPerson FROM BuyerCompanies " +
                        "WHERE CompanyName = @name AND CompanyAddress = @address AND ContactPerson = @person " +
                        
                        "SET IDENTITY_INSERT ArchivedBuyerCompanies OFF " +
                        "DELETE FROM BuyerCompanies " +
                        "WHERE CompanyName = @name AND CompanyAddress = @address AND ContactPerson = @person "; 

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
