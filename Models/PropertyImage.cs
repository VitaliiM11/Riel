using System;
namespace riel.Models
{
    public class PropertyImage
    {
        public int ID { get; set; }
        public int PropertyID { get; set; }
        public string ImageURL { get; set; }

        public Property Property { get; set; }
    }
}

