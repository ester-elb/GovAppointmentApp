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

        public async Task<Appointment?> GetByIdAsync(string id)
        {
            return await _appointments.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Appointment>> GetByOfficeNameAsync(string officeName)
        {
            return await _appointments.Find(a => a.Office.Name == officeName).ToListAsync();
        }

        public async Task<List<Appointment>> GetByCityCodeAsync(int cityCode)
        {
            return await _appointments.Find(a => a.Office.CityCode == cityCode).ToListAsync();
        }

        public async Task<List<Appointment>> GetByCitizenIdAsync(int citizenId)
        {
            return await _appointments.Find(a => a.CitizenId == citizenId).ToListAsync();
        }

        public async Task<bool> CancelAsync(string id)
        {
            var update = Builders<Appointment>.Update.Set(a => a.Status, "Cancelled");
            var result = await _appointments.UpdateOneAsync(a => a.Id == id, update);
            return result.ModifiedCount > 0;
        }
    }
}
