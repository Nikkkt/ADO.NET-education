using MailingList.Entities;
using Microsoft.Data.SqlClient;
using Dapper;

namespace MailingList
{
    internal class AsyncFunctions
    {
        private static string connectionString = @"Server=Nikita_laptop;Database=MailingList;Trusted_Connection=True;Encrypt=False;";

        public AsyncFunctions() { }
        public static async Task InsertDataAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                Country country = new Country { Name = "Ukraine" };
                await connection.ExecuteAsync("INSERT INTO Country (Name) VALUES (@Name)", country);

                City city = new City { Name = "Odesa", CountryId = 1 };
                await connection.ExecuteAsync("INSERT INTO City (Name, CountryId) VALUES (@Name, @CountryId)", city);

                Section section = new Section { Name = "Computering technologes" };
                await connection.ExecuteAsync("INSERT INTO Section (Name) VALUES (@Name)", section);

                Product product = new Product { Name = "Diya", IsPromotional = true, SectionId = 1 };
                await connection.ExecuteAsync("INSERT INTO Product (Name, IsPromotional, SectionId) VALUES (@Name, @IsPromotional, @SectionId)", product);

                Customer customer = new Customer { Name = "Taras", Surname = "Shevchenko", Email = "Glory.To.Ukraine@gmail.com", SectionId = 1 };
                await connection.ExecuteAsync("INSERT INTO Customer (Name, Surname, Email, SectionId) VALUES (@Name, @Surname, @Email, @SectionId)", customer);
            }
        }

        public static async Task UpdateDataAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                Country country = new Country { Id = 1, Name = "Poland" };
                await connection.ExecuteAsync("UPDATE Country SET Name = @Name WHERE Id = @Id", country);

                City city = new City { Id = 1, Name = "Warsaw", CountryId = 1 };
                await connection.ExecuteAsync("UPDATE City SET Name = @Name, CountryId = @CountryId WHERE Id = @Id", city);

                Section section = new Section { Id = 1, Name = "Agricultural products" };
                await connection.ExecuteAsync("UPDATE Section SET Name = @Name WHERE Id = @Id", section);

                Product product = new Product { Id = 1, Name = "Grain", IsPromotional = false, SectionId = 1 };
                await connection.ExecuteAsync("UPDATE Product SET Name = @Name, IsPromotional = @IsPromotional, SectionId = @SectionId WHERE Id = @Id", product);

                Customer customer = new Customer { Id = 1, Name = "Pshek", Surname = "Pshekovich", Email = "pshekpshek@gmail.com", SectionId = 1 };
                await connection.ExecuteAsync("UPDATE Customer SET Name = @Name, Email = @Email, SectionId = @SectionId WHERE Id = @Id", customer);
            }
        }

        public static async Task DeleteDataAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                int countryId = 1;
                int productId = 1;
                int customerId = 1;
                int sectionId = 1;

                await connection.ExecuteAsync("DELETE FROM City WHERE CountryId = @Id", new { Id = countryId });
                await connection.ExecuteAsync("DELETE FROM Country WHERE Id = @Id", new { Id = countryId });
                await connection.ExecuteAsync("DELETE FROM Product WHERE Id = @Id", new { Id = productId });
                await connection.ExecuteAsync("DELETE FROM Customer WHERE Id = @Id", new { Id = customerId });
                await connection.ExecuteAsync("DELETE FROM Section WHERE Id = @Id", new { Id = sectionId });
            }
        }

        public static async Task DisplayDataAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                int countryId = 1;
                var cities = await connection.QueryAsync<City>("SELECT * FROM City WHERE CountryId = @CountryId", new { CountryId = countryId });

                Console.WriteLine("Cities:");
                foreach (var city in cities) Console.WriteLine($"Id: {city.Id}\nName: {city.Name}\nCountryId: {city.CountryId}");

                var customerId = 1;
                var sections = await connection.QueryAsync<Section>("SELECT * FROM Section JOIN Customer ON Section.Id = Customer.SectionId WHERE Customer.Id = @CustomerId", new { CustomerId = customerId });

                Console.WriteLine("\nSections:");
                foreach (var section in sections) Console.WriteLine($"Id: {section.Id}\nName: {section.Name}");

                var sectionId = 1;
                var products = await connection.QueryAsync<Product>("SELECT * FROM Product WHERE SectionId = @SectionId AND IsPromotional = 1", new { SectionId = sectionId });

                Console.WriteLine("\nPromotional Products:");
                foreach (var product in products) Console.WriteLine($"Id: {product.Id}\nName: {product.Name}\nIsPromotional: {product.IsPromotional}\nSectionId: {product.SectionId}\n");
            }
        }
    }
}
