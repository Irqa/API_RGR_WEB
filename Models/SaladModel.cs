using Microsoft.AspNetCore.Http;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Salad
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("ingredients")]
        public List<SaladItem> Ingredients { get; set; }

        [BsonElement("isFromConstructor")]
        public bool IsFromConstructor { get; set; }

        [BsonElement("image")]
        public string Image { get; set; }

    }

    public class SaladItem
    {
        [BsonElement("groceryId")]
        public string GroceryId { get; set; }

        [BsonElement("weight")]
        public double Weight { get; set; }
    }

    public class SaladDto
    {
        public string Name { get; set; }
        public List<SaladItem> Ingredients { get; set; }
        public bool IsFromConstructor { get; set; }
        public IFormFile Image { get; set; }
    }

}
