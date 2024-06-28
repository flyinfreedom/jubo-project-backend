using jubo_project_api.Entities;
using jubo_project_api.Services;
using jubo_project_api.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace jubo_project_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController(PatientService patientService) : ControllerBase
{
    [HttpGet]
    public Task<IEnumerable<Patient>> GetPatients()
        => patientService.GetPaitentsAsync();
}
