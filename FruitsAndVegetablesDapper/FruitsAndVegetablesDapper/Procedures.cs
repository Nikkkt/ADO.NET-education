using FruitsAndVegetablesDapper.Entities;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;


namespace FruitsAndVegetablesDapper
{
    public class Procedures
    {
        private SqlConnection connection;

        public Procedures(SqlConnection connection) { this.connection = connection; }

        public Produce? GetProductById(int id) { return connection.QueryFirstOrDefault<Produce>("GetProductById", new { Id = id }, commandType: CommandType.StoredProcedure); }

        public List<Produce> GetAllProducts() { return connection.Query<Produce>("GetAllProducts", commandType: CommandType.StoredProcedure).ToList(); }

        public void UpdateProduct(Produce Product) { connection.Execute("UpdateProduct", Product, commandType: CommandType.StoredProcedure); }

        public void DeleteProduct(int id) { connection.Execute("DeleteProduct", new { Id = id }, commandType: CommandType.StoredProcedure); }

        public double GetAverageCalories() { return connection.Query<double>("GetAverageCalories", commandType: CommandType.StoredProcedure).Single(); }
    }
}
