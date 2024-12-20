using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using riel.Models;

namespace riel.Controllers
{
    
    public class CatalogService
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
GROUP BY p.ID;
";

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

    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        private CatalogService catalogService = new CatalogService();

        public IActionResult Catalog(string filterType, string filterCity, string filterCategory)
        {
            List<Property> properties = catalogService.GetProperties();

            if (!string.IsNullOrEmpty(filterType))
            {
                properties = properties.FindAll(p => p.Type == filterType);
            }
            if (!string.IsNullOrEmpty(filterCity))
            {
                properties = properties.FindAll(p => p.Location.Split(',')[0] == filterCity);
            }
            if (!string.IsNullOrEmpty(filterCategory))
            {
                properties = properties.FindAll(p => p.CategoryName == filterCategory);
            }

            return View(properties);
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

        public ActionResult Details(int id)
        {
            var property = GetPropertyDetails(id);
            return View(property);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
