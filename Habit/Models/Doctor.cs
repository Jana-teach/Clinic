using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Doctor
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public IEnumerable<Appointment>? Appointments { get; set; }
    }
}
