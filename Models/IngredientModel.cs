using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Ingredient
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("groceryId")]
        public string GroceryId { get; set; }

        [BsonElement("saladId")]
        public string SaladId { get; set; }

        [BsonElement("weight")]
        public double Weight { get; set; }
    }
}
