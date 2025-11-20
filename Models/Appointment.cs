using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppointmentApi.Models
{
    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        [BsonElement("officeId")]
        public string? OfficeId { get; set; }
        
        [BsonElement("citizenId")]
        public string? CitizenId { get; set; }
        
        [BsonElement("date")]
        public DateTime Date { get; set; }
        
        [BsonElement("serviceTypeId")]
        public string? ServiceTypeId { get; set; }
        
        [BsonElement("status")]
        public string Status { get; set; } = "Scheduled";
    }
}
