using jubo_project_api.Entities;
using jubo_project_api.Services.Interface;
using MongoDB.Driver;

namespace jubo_project_api.Infrastructure.Repositories
{
    public class PatientRepository(PatientOrderContext context) : IPatientRepository
    {
        public async Task<IEnumerable<Patient>> GetPaitentsAsync()
        {
            var result = await context.Patients.FindAsync(Builders<Patient>.Filter.Empty);
            return result.ToEnumerable();
        }

        public async Task<Patient> PushPatientOrderAsync(string patientId, string orderId)
        {
            var filter = Builders<Patient>.Filter.Eq("_id", patientId);
            var patient = await context.Patients.Find(filter).FirstOrDefaultAsync();

            var newOrderIds = patient.OrderId.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            newOrderIds.Add(orderId);
            patient.OrderId = string.Join(",", newOrderIds);

            var update = Builders<Patient>.Update.Set(p => p.OrderId, patient.OrderId);
            await context.Patients.UpdateOneAsync(filter, update);

            return patient;
        }

        public async Task InsertManyAsync(List<Patient> patients)
        { 
            await context.Patients.InsertManyAsync(patients);
        }
    }
}
