using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PatientController : ControllerBase
{
    private static List<Patient> patients = new List<Patient>();

    [HttpGet]
    public IActionResult GetAll() => Ok(patients);

    [HttpPost]
    public IActionResult Add(Patient p)
    {
        patients.Add(p);
        return Ok(p);
    }
}