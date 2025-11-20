using AppointmentApi.Models;
using MongoDB.Driver;

namespace AppointmentApi.Services
{
    public class AppointmentService
    {
        private readonly IMongoCollection<Appointment> _appointments;

        public AppointmentService(IMongoClient client)
        {
            var database = client.GetDatabase("AppointmentsDB");
            _appointments = database.GetCollection<Appointment>("Appointments");
        }

        public async Task<Appointment> CreateAsync(Appointment appointment)
        {
            await _appointments.InsertOneAsync(appointment);
            return appointment;
        }


        public async Task<Appointment> GetByIdAsync(string id)
        {
            return await _appointments.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public Appointment GetById(string id)
        {
            return _appointments.Find(a => a.Id == id).FirstOrDefault();
        }

        public async Task<List<Appointment>> GetByOfficeAsync(string officeId)
        {
            return await _appointments.Find(a => a.OfficeId == officeId).ToListAsync();
        }

        public List<Appointment> GetByOffice(string officeId)
        {
            return _appointments.Find(a => a.OfficeId == officeId).ToList();
        }

        public async Task<bool> CancelAsync(string id)
        {
            var update = Builders<Appointment>.Update.Set(a => a.Status, "Cancelled");
            var result = await _appointments.UpdateOneAsync(a => a.Id == id, update);
            return result.ModifiedCount > 0;
        }

        public bool Cancel(string id)
        {
            var update = Builders<Appointment>.Update.Set(a => a.Status, "Cancelled");
            var result = _appointments.UpdateOne(a => a.Id == id, update);
            return result.ModifiedCount > 0;
        }
    }
}
