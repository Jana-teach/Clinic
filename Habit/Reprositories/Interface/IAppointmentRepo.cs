using Hospital.Models;
using Hospital.ViewModels;

namespace Hospital.Reprositories.Interface
{
    public interface IAppointmentRepo
    {
        public Task<IEnumerable<Appointment>> GetAll();
        public Task Add(AppointmentViewModel appointmentViewModel );
        public Task Update(AppointmentViewModel appointmentViewModel);
        public Task<Appointment> GetAppByID(int id);
        public Task Delete(Appointment appointment);
       
    }
}
