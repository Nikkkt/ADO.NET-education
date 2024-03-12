using Stationery;
using System.Data.SqlClient;

string connectionString = "Data Source=Nikita_laptop;Initial Catalog=Stationery;Integrated Security=True";

// 1
InsertClass task1 = new InsertClass(connectionString);
task1.InsertNewStationaryType("For university");
task1.InsertNewStationary("AI", 6, 14.99, 150);
task1.InsertNewManagers("Evdokim", "evdokim@example.com", 5, 500);
task1.InsertNewBuyerCompanies("CDE company", "example address", "someone");

// 2
UpdateClass task2 = new UpdateClass(connectionString);
task2.UpdateStationaryType("For university", "For work");
task2.UpdateStationary("AI", 6, 14.99, 150, "ChatGPT", 6, 19.99, 200);
task2.UpdateManagers("Evdokim", "evdokim@example.com", 5, 500, "Dobrynya", "dobrynya@example.com", 2, 100);
task2.UpdateBuyerCompanies("CDE company", "example address", "someone", "FGI corporation", "somewhere", "testPerson");


// 3
DeleteClass task3 = new DeleteClass(connectionString);
task3.DeleteStationaryType("For work");
task3.DeleteStationary("ChatGPT", 6, 19.99, 200);
task3.DeleteManagers("Dobrynya", "dobrynya@example.com", 2, 100);
task3.DeleteBuyerCompanies("FGI corporation", "somewhere", "testPerson");