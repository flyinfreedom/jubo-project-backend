using jubo_project_api.Entities;

namespace jubo_project_api.Services.Interface;

public interface IPatientRepository
{
    public Task<IEnumerable<Patient>> GetPaitentsAsync();
    public Task<Patient> PushPatientOrderAsync(string patientId, string orderId);
    public Task InsertManyAsync(List<Patient> patients);
}
