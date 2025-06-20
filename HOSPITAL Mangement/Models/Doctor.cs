using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_Mangement.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Phone { get; set; }
        // Foreign Key
        public int DepartmentId { get; set; }
    }
}
