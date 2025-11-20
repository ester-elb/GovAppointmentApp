using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppointmentApi.Models
{
    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        [BsonElement("Office")]
        public Office? Office { get; set; }
        
        [BsonElement("CitizenId")]
        public int? CitizenId { get; set; }
        
        [BsonElement("Date")]
        public DateTime Date { get; set; }
        
        [BsonElement("ServiceTypeId")]
        public int? ServiceTypeId { get; set; }
        
        [BsonElement("Status")]
        public string Status { get; set; } = "Scheduled";
    }
}
