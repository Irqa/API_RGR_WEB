using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Grocery
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("caloriesPerKg")]
        public double CaloriesPerKg { get; set; }

        [BsonElement("weightForConstructor")]
        public double WeightForConstructor { get; set; }

        [BsonElement("pricePerKg")]
        public double PricePerKg { get; set; }
    }
}
