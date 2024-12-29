using Hospital.Models;
using Hospital.Reprositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepo _repo;

        public DoctorController(IDoctorRepo repo)
        {
            _repo=repo;
        }

        public async Task<IActionResult> GetAll()
        {
            var doc =  await _repo.GetAll();
            return View(doc);
        }
        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
       {
              await _repo.CreateDoctor(doctor);
              return RedirectToAction("GetAll");
        }

    }
}
