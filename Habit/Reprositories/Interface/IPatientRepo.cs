using Hospital.Models;

namespace Hospital.Reprositories.Interface
{
    public interface IPatientRepo
    {
        Task<IEnumerable<Patient>> GetAll();
        Task CreatePatient(Patient patient);

    }
}
