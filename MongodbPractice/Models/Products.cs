using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongodbPractice.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string name { get; set; }

        public string color { get; set; }

        public string size { get; set; }

        public decimal price { get; set; }
    }
}
