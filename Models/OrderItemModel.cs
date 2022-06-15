using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class OrderItem
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("orderId")]
        public string OrderId { get; set; }

        [BsonElement("saladId")]
        public string SaladId { get; set; }

        [BsonElement("count")]
        public double Count { get; set; }

    }
}
