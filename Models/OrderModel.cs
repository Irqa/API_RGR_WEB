using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("deliveryType")]
        public string DeliveryType { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("street")]
        public string Street { get; set; }

        [BsonElement("buildingNumber")]
        public string BuildingNumber { get; set; }

        [BsonElement("entrance")]
        public string Entrance { get; set; }

        [BsonElement("floor")]
        public double Floor { get; set; }

        [BsonElement("appartment")]
        public double Appartment { get; set; }

        [BsonElement("comment")]
        public string Comment { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
    }

}
