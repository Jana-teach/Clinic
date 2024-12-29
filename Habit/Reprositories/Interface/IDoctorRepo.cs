using Hospital.Models;

namespace Hospital.Reprositories.Interface
{
    public interface IDoctorRepo
    {
        Task CreateDoctor(Doctor doctor);
        Task<Doctor> GetDoctorByID(int id);
        Task DeleteDoctor(Doctor doctor);
        Task<IEnumerable<Doctor>> GetAll();
    }
}
