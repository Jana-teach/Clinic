using Hospital.Models;
using Hospital.Reprositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepo _repo;

        public PatientController(IPatientRepo repo)
        {
            _repo=repo;
        }

        public async Task<IActionResult> GetAll()
        {
            var patient = await _repo.GetAll();
            return View(patient);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            await _repo.CreatePatient(patient);
            return RedirectToAction("GetAll");
        }
    }
}
