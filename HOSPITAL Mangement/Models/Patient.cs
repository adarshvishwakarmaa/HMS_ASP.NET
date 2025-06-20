using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_Mangement.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Name { get; set; }

        public DateTime DOB { get; set; }
      
        public string Gender { get; set; }

        public string Contact { get; set; }

        public string Address { get; set; }

        // Foreign Key - Doctor
        public int DoctorId { get; set; }

        // Foreign Key - Department
        public int DepartmentId { get; set; }
    }
}
