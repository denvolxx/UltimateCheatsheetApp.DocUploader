using MongoDB.Bson.Serialization.Attributes;

namespace DocUploader.Models
{
    public class Product
    {
        [BsonElement("Name")]
        public string? Name { get; set; }

        [BsonElement("Price")]
        public string? Price { get; set; }
    }
}
