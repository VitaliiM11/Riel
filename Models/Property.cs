using System;
using System.Collections.Generic;

namespace riel.Models
{
    public class Property
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public decimal Area { get; set; }
        public string CategoryName { get; set; }
        public string AgentName { get; set; }
        public string Type { get; set; }

        public List<string> ImagesUrl { get; set; }

    }

}

