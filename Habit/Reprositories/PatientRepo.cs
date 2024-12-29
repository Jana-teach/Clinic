using Hospital.Models;
using Hospital.Reprositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Reprositories
{
    public class PatientRepo : IPatientRepo
    {
        private readonly AppDbContext _context;

        public PatientRepo(AppDbContext context)
        {
            _context=context;
        }

        public async Task CreatePatient(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            var patient = await _context.Patients.ToListAsync();
            return patient;
        }
    }
}
