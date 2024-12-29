using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age {  get; set; }
        public IEnumerable<Appointment>? Appointments { get; set; }

    }
}
