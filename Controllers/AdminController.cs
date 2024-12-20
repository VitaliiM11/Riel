using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.Utilities.Zlib;
using riel.Models;
using static System.Net.Mime.MediaTypeNames;

namespace riel.Controllers
{
    public class CatalogService1
    {
        private static string connectionString = "server=localhost;user=root;password=password;database=riel;";
        private MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

        public List<Property> GetProperties()
        {
            string sql = @"
    SELECT 
    p.ID, 
    p.Name, 
    p.Description, 
    p.Price, 
    p.Location, 
    p.Area,  
    pc.Name AS CategoryName,
    pt.Type AS Type, 
    CONCAT(a.FirstName, ' ', a.LastName) AS AgentName,
    GROUP_CONCAT(pi.ImageURL) AS ImageUrls
FROM Property p
JOIN Property_Category pc ON p.CategoryID = pc.ID
JOIN Agent a ON p.AgentID = a.ID
JOIN Property_Type pt ON p.Type = pt.ID
LEFT JOIN Property_Images pi ON p.ID = pi.PropertyID
GROUP BY p.ID;";

            List<Property> properties = new List<Property>();

            try
            {
                mySqlConnection.Open();
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var property = new Property
                    {
                        ID = reader.GetInt32("ID"),
                        Name = reader.GetString("Name"),
                        Description = reader.GetString("Description"),
                        Price = reader.GetDecimal("Price"),
                        Location = reader.GetString("Location"),
                        Area = reader.GetDecimal("Area"),
                        CategoryName = reader.GetString("CategoryName"),
                        AgentName = reader.GetString("AgentName"),
                        Type = reader.GetString("Type"),
                        ImagesUrl = reader["ImageUrls"] != DBNull.Value
                            ? reader.GetString("ImageUrls").Split(',').ToList()
                            : new List<string>() // Handle cases where no images exist
                    };

                    properties.Add(property);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }

            return properties;
        }
        public PropertyDetailsModel GetPropertyDetails(int id)
        {
            string connectionString = "server=localhost;user=root;password=password;database=riel;";

            string propertySql = @"
        SELECT p.ID, p.Name, p.Description, p.Price, p.Location, p.Area, 
               pc.Name AS Category,
               pt.Type AS Type, 
               a.FirstName AS AgentFirstName, a.LastName AS AgentLastName, a.Phone AS AgentPhone, a.Email AS AgentEmail
        FROM Property p
        JOIN Property_Category pc ON p.CategoryID = pc.ID
        JOIN Agent a ON p.AgentID = a.ID
    JOIN Property_Type pt ON p.Type = pt.ID 
        WHERE p.ID = @id";

            string imagesSql = @"
        SELECT ImageURL
        FROM Property_Images
        WHERE PropertyID = @id";

            PropertyDetailsModel propertyDetails = null;

            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    mySqlConnection.Open();

                    // Fetch the main property details
                    using (MySqlCommand propertyCommand = new MySqlCommand(propertySql, mySqlConnection))
                    {
                        propertyCommand.Parameters.AddWithValue("@id", id);
                        var reader = propertyCommand.ExecuteReader();

                        if (reader.Read())
                        {
                            propertyDetails = new PropertyDetailsModel
                            {
                                ID = reader.GetInt32("ID"),
                                Name = reader.GetString("Name"),
                                Description = reader.GetString("Description"),
                                Price = reader.GetDecimal("Price"),
                                Location = reader.GetString("Location"),
                                Area = reader.GetDecimal("Area"),
                                Category = reader.GetString("Category"),
                                AgentFirstName = reader.GetString("AgentFirstName"),
                                AgentLastName = reader.GetString("AgentLastName"),
                                AgentPhone = reader.GetString("AgentPhone"),
                                AgentEmail = reader.GetString("AgentEmail"),
                                Type = reader.GetString("Type"),
                                ImagesUrl = new List<string>() // Initialize empty list
                            };
                        }

                        reader.Close();
                    }

                    // Fetch associated images
                    if (propertyDetails != null)
                    {
                        using (MySqlCommand imagesCommand = new MySqlCommand(imagesSql, mySqlConnection))
                        {
                            imagesCommand.Parameters.AddWithValue("@id", id);
                            var imagesReader = imagesCommand.ExecuteReader();

                            while (imagesReader.Read())
                            {
                                propertyDetails.ImagesUrl.Add(imagesReader.GetString("ImageURL"));
                            }

                            imagesReader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return propertyDetails;
        }
        public List<Agent> GetAgentDetails()
        {
            string agentSql = @"
        SELECT *, CONCAT(FirstName, ' ', LastName) AS FullName 
        FROM Agent";
            List<Agent> properties = new List<Agent>();

            try
            {
                mySqlConnection.Open();
                MySqlCommand command = new MySqlCommand(agentSql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var property = new Agent
                    {
                        Id = reader.GetInt32("ID"),
                        Name = reader.GetString("FullName"),
                        Phone = reader.GetString("LastName"),
                        Email = reader.GetString("Phone"),
                        Address = reader.GetString("Email")
                    };

                    properties.Add(property);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }

            return properties;
        }

        public List<PropertyCatagory> GetCategories()
        {
            string agentSql = @"
        SELECT *  
        FROM Property_Category";
            List<PropertyCatagory> properties = new List<PropertyCatagory>();

            try
            {
                mySqlConnection.Open();
                MySqlCommand command = new MySqlCommand(agentSql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var property = new PropertyCatagory
                    {
                        Id = reader.GetInt32("ID"),
                        Name = reader.GetString("Name"),
                    };

                    properties.Add(property);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }

            return properties;
        }
        public List<PropertyType> GetTypes()
        {
            string agentSql = @"
        SELECT *  
        FROM Property_Type";
            List<PropertyType> properties = new List<PropertyType>();

            try
            {
                mySqlConnection.Open();
                MySqlCommand command = new MySqlCommand(agentSql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var property = new PropertyType
                    {
                        Id = reader.GetInt32("ID"),
                        Type = reader.GetString("Type"),
                    };

                    properties.Add(property);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }

            return properties;
        }
    }
    public class AdminController : Controller
    {
        public IActionResult AdminPage()
        {
            return View();
        }
        private CatalogService1 catalogService1 = new CatalogService1();
        public IActionResult Index()
        {
            var properties = catalogService1.GetProperties();  
            return View(properties);
        }

        public IActionResult Add()
        {
            var agents = catalogService1.GetAgentDetails();
            
            ViewBag.Agents = new SelectList(agents, "Id", "Name");

            var categories = catalogService1.GetCategories();

            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            var types = catalogService1.GetTypes();

            ViewBag.Types = new SelectList(types, "Id", "Type");

            return View();
        }

        [HttpPost]
        public IActionResult Add(Property model, int AgentID, int CategoryID, int TypeID, List<IFormFile> Image)
        {
            string MyConnection2 = "server=localhost;user=root;password=password;database=riel;";
            string Query = $"INSERT INTO Property (Name, Description, Price, Location, Area, CategoryID, AgentID, Type) " +
                $"values('{model.Name}', '{model.Description}','{model.Price}','{model.Location}', '{model.Area}',  '{CategoryID}', '{AgentID}', '{TypeID}'); " +
                $"INSERT INTO Property_Images (PropertyID, ImageURL) Values";
           
            List<string> values = new List<string>();

            foreach (var file in Image)
            {
                values.Add($"({catalogService1.GetProperties().LastOrDefault().ID + 1}, '/images/{file.FileName}')");
            }

            Query += string.Join(", ", values);

            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var property = catalogService1.GetPropertyDetails(id);
            var agents = catalogService1.GetAgentDetails();

            ViewBag.Agents = new SelectList(agents, "Id", "Name");

            var categories = catalogService1.GetCategories();

            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            var types = catalogService1.GetTypes();

            ViewBag.Types = new SelectList(types, "Id", "Type");
            return View(property);
        }

        [HttpPost]
        public IActionResult Edit(PropertyDetailsModel model, int AgentID, int CategoryID, int TypeID, List<IFormFile> Image)
        {
            string MyConnection2 = "server=localhost;user=root;password=password;database=riel;";
            string Query = $"UPDATE Property SET Name = '{model.Name}', Description = '{model.Description}', Price = '{model.Price}', " +
                $"Location = '{model.Location}', Area = '{model.Area}', CategoryID = '{CategoryID}', AgentID = '{AgentID}', Type = '{TypeID}' " +
                $"WHERE ID = 1; DELETE FROM Property_Images WHERE PropertyID = '{model.ID}'; " +
                $"INSERT INTO Property_Images (PropertyID, ImageURL) Values ";

            List<string> values = new List<string>();

            foreach (var file in Image)
            {
                values.Add($"({model.ID}, '/images/{file.FileName}')");
            }

            Query += string.Join(", ", values);

            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var property = catalogService1.GetPropertyDetails(id);
            return View(property);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            string MyConnection2 = "server=localhost;user=root;password=password;database=riel;";
            string Query = $"delete from property " +
                $"where ID = '{id}'";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();
            return RedirectToAction("Index");
        }

       
    }
}
