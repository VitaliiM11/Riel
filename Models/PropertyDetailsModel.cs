using System;
using System.Collections.Generic;

namespace riel.Models
{
    public class PropertyDetailsModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public decimal Area { get; set; }
        public string Category { get; set; }
        public string AgentFirstName { get; set; }
        public string AgentLastName { get; set; }
        public string AgentPhone { get; set; }
        public string AgentEmail { get; set; }
        public string Type { get; set; }

        public List<string> ImagesUrl { get; set; }
    }

}

