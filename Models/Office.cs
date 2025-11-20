using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppointmentApi.Models
{
    public class Office
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        [BsonElement("Name")]
        public string? Name { get; set; }
        
        [BsonElement("City")]
        public int? CityCode { get; set; }
        
        [BsonElement("Address")]
        public string? Address { get; set; }
    }
}
