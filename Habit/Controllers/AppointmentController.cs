using Hospital.Models;
using Hospital.Reprositories.Interface;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepo _repo;
        private readonly IPatientRepo _patientRepo;
        private readonly IDoctorRepo _doctorRepo;

        public AppointmentController(IAppointmentRepo repo , IPatientRepo patientRepo,IDoctorRepo doctorRepo)
        {
            _repo=repo;
            _patientRepo=patientRepo;
            _doctorRepo=doctorRepo;
        }

        public async Task<IActionResult> GetAll()
        {
            var app = await _repo.GetAll();
            return View(app);
        }

        public async Task<IActionResult> Details(int ID)
        {
            var app = await _repo.GetAppByID(ID);
            return View(app);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var pat = await _patientRepo.GetAll();
            var doc = await _doctorRepo.GetAll();

            AppointmentViewModel viewModel = new AppointmentViewModel()
            {
                patients = pat,
                doctors= doc 
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentViewModel VM)
        {
           await _repo.Add(VM);
            return RedirectToAction("GetAll");   
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var app = await _repo.GetAppByID(id);
            var pat = await _patientRepo.GetAll();
            var doc = await _doctorRepo.GetAll();

            AppointmentViewModel viewModel = new AppointmentViewModel()
            {
                Date = app.Date,
                Notes = app.Notes,
                patients = pat,
                doctors= doc,
            };
            return View(viewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(AppointmentViewModel VM)
        {
           await _repo.Update(VM);
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int ID)
        {
           var app = await _repo.GetAppByID(ID);
           return View(app);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Appointment app)
        {
            await _repo.Delete(app);
            return RedirectToAction("GetAll");
        }

    }
}
