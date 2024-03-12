using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery
{
    internal class Queries
    {
        string CONNECTION_STRING;

        public Queries(string CONNECTION_STRING) { this.CONNECTION_STRING = CONNECTION_STRING; }

        public void ManagerWithHighestUnitSales()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "SELECT TOP 1 ManagerName FROM StationeryManagers ORDER BY TotalSales DESC";
                    using (SqlCommand command = new SqlCommand(query, connection)) 
                    { 
                        using (SqlDataReader reader = command.ExecuteReader()) 
                        { 
                            while (reader.Read()) Console.WriteLine(reader["ManagerName"]); 
                        } 
                    }
                }
                catch (SqlException ex) { Console.WriteLine("\nConnection error: " + ex.Message); }
                finally { connection.Close(); Console.WriteLine("\nConnection close"); }
            }
        }

        public void ManagerWithHighestProfit()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "SELECT TOP 1 ManagerName FROM StationeryManagers ORDER BY TotalProfit DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) Console.WriteLine(reader["ManagerName"]);
                        }
                    }
                }
                catch (SqlException ex) { Console.WriteLine("\nConnection error: " + ex.Message); }
                finally { connection.Close(); Console.WriteLine("\nConnection close"); }
            }
        }

        // This method won't work with my db, because I forgot to add date in my db
        void ManagerWithHighestProfitInPeriod()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "SELECT TOP 1 ManagerName FROM StationeryManagers WHERE LastSaleDate BETWEEN DATEADD(year, -1, GETDATE()) AND GETDATE() ORDER BY TotalProfit DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) Console.WriteLine(reader["ManagerName"]);
                        }
                    }
                }
                catch (SqlException ex) { Console.WriteLine("\nConnection error: " + ex.Message); }
                finally { connection.Close(); Console.WriteLine("\nConnection close"); }
            }
        }

        public void FindTopBuyingCompany()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "SELECT TOP 1 c.CompanyName " +
                        "FROM StationeryCompanies c " +
                        "JOIN StationeryManagers m ON c.ContactPerson = m.ManagerName " +
                        "ORDER BY m.TotalSales DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) Console.WriteLine(reader["CompanyName"]);
                        }
                    }
                }
                catch (SqlException ex) { Console.WriteLine("\nConnection error: " + ex.Message); }
                finally { connection.Close(); Console.WriteLine("\nConnection close"); }
            }
            
        }

        public void FindMostSoldStationeryType()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "SELECT ST.TypeName, SUM(SI.StockQuantity) AS TotalSales " +
                        "FROM StationeryItems SI " +
                        "JOIN StationeryTypes ST ON SI.ItemTypeID = ST.TypeID " +
                        "GROUP BY ST.TypeName " +
                        "ORDER BY TotalSales DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) Console.WriteLine($"{reader["TypeName"]}: {reader["TotalSales"]}");
                        }
                    }
                }
                catch (SqlException ex) { Console.WriteLine("\nConnection error: " + ex.Message); }
                finally { connection.Close(); Console.WriteLine("\nConnection close"); }
            }
        }

        public void FindMostProfitableStationeryType()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "SELECT ST.TypeName, SUM(SI.Price * SI.StockQuantity) AS TotalProfit " +
                        "FROM StationeryItems SI " +
                        "JOIN StationeryTypes ST ON SI.ItemTypeID = ST.TypeID " +
                        "GROUP BY ST.TypeName " +
                        "ORDER BY TotalProfit DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) Console.WriteLine($"{reader["TypeName"]}: {reader["TotalSales"]}");
                        }
                    }
                }
                catch (SqlException ex) { Console.WriteLine("\nConnection error: " + ex.Message); }
                finally { connection.Close(); Console.WriteLine("\nConnection close"); }
            }
        }

        public void FindMostPopularStationery()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "SELECT SI.ItemName, SUM(SI.StockQuantity) AS TotalSales FROM StationeryItems SI GROUP BY SI.ItemName ORDER BY TotalSales DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) Console.WriteLine($"{reader["ItemName"]}: {reader["TotalSales"]}");
                        }
                    }
                }
                catch (SqlException ex) { Console.WriteLine("\nConnection error: " + ex.Message); }
                finally { connection.Close(); Console.WriteLine("\nConnection close"); }
            }
        }

        // This method won't work with my db, because I forgot to add date in my db
        void FindStationeryNotSoldForDays(int numDays)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open(); Console.WriteLine("\nConnection open");

                    string query = "SELECT ItemName FROM StationeryItems WHERE DATEDIFF(day, LastSoldDate, GETDATE()) > @days";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@days", numDays);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) Console.WriteLine(reader["ItemName"]);
                        }
                    }
                }
                catch (SqlException ex) { Console.WriteLine("\nConnection error: " + ex.Message); }
                finally { connection.Close(); Console.WriteLine("\nConnection close"); }
            }
        }
    }
}
