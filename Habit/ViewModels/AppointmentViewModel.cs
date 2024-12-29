using Hospital.Models;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Hospital.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public DateOnly Date {  get; set; }
        public string Notes { get; set; }
        public int PatientID {  get; set; }
        public IEnumerable<Patient> patients { get; set; }
        public int DoctorID { get; set; }
        public IEnumerable<Doctor> doctors { get; set; }
    }
}
