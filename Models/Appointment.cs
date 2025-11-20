using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppointmentApi.Models
{
    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? OfficeId { get; set; }
        public string? CitizenId { get; set; }
        public DateTime Date { get; set; }
        public string? ServiceTypeId { get; set; }
        public string Status { get; set; } = "Scheduled"; // Scheduled, Cancelled, Done
    }
}
