using Hospital.Models;
using Hospital.Reprositories.Interface;
using Hospital.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Reprositories
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly AppDbContext _context;

        public AppointmentRepo(AppDbContext context)
        {
            _context=context;
        }

        public async Task Add(AppointmentViewModel VM)
        {
            Appointment appointment = new Appointment()
            {
                Date = VM.Date,
                Notes = VM.Notes,
                PatientID = VM.PatientID,
                DoctorID = VM.DoctorID,
            };
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Appointment appointment)
        {
             _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            var app = await _context.Appointments.Include(d=> d.Doctor).Include(p=> p.Patient).ToListAsync();
            return app;
        }

        public async Task<Appointment> GetAppByID(int id)
        {
            var app = await _context.Appointments
                .Include(d => d.Doctor)
                .Include(p => p.Patient).FirstOrDefaultAsync(x=>x.Id==id);
            return app;
        }

        public async Task Update(AppointmentViewModel appointmentViewModel)
        {
            var app = await _context.Appointments.FirstOrDefaultAsync(x => x.Id ==  appointmentViewModel.Id);
            app.Date = appointmentViewModel.Date;
            app.Notes = appointmentViewModel.Notes;
            app.PatientID = appointmentViewModel.PatientID;
            app.DoctorID =appointmentViewModel.DoctorID;

            _context.Appointments.Update(app);
            await _context.SaveChangesAsync();
        }

        
    }
}
