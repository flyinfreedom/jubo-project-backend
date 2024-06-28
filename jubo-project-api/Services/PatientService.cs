using jubo_project_api.Entities;
using jubo_project_api.Services.Interface;

namespace jubo_project_api.Services;

public class PatientService(IPatientRepository patientRepository)
{
    public Task<IEnumerable<Patient>> GetPaitentsAsync()
        => patientRepository.GetPaitentsAsync();
}
