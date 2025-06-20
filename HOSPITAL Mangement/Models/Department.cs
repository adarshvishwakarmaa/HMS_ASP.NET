using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_Mangement.Models
{
    public class Department
    {
        public int Id { get; set; } 
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
