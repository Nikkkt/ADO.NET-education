using FruitsAndVegetablesDapper;
using FruitsAndVegetablesDapper.Entities;
using Microsoft.Data.SqlClient;

string connectionString = "Server=Nikita_laptop;Database=FruitsAndVegetables;Trusted_Connection=True;Encrypt=False;";

using (var connection = new SqlConnection(connectionString))
{
    Procedures DataBase = new Procedures(connection);

    Produce? product = DataBase.GetProductById(1);
    Console.WriteLine($"Id: {product?.Id}\nName: {product?.Name}\nType: {product?.Type}\nColor: {product?.Color}\nCalories: {product?.Calories}\n");

    List<Produce> allProducts = DataBase.GetAllProducts();
    foreach (Produce? prod in allProducts) Console.WriteLine($"Id: {prod?.Id}\nName: {prod?.Name}\nType: {prod?.Type}\nColor: {prod?.Color}\nCalories: {prod?.Calories}");

    product.Name = "Red Apple";
    DataBase.UpdateProduct(product);

    DataBase.DeleteProduct(1);

    double averageCalories = DataBase.GetAverageCalories();
    Console.WriteLine($"Average calories: {averageCalories}\n");
}