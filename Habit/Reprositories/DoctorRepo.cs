using Hospital.Models;
using Hospital.Reprositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Reprositories
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly AppDbContext _context;

        public DoctorRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateDoctor(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctor(Doctor doctor)
        {
             _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            var doc= await _context.Doctors.ToListAsync();
            return doc;
        }

        public async Task<Doctor> GetDoctorByID(int id)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(x=> x.ID == id);
            return doctor;
        }
    }
}
