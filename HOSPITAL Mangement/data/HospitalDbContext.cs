using HOSPITAL_Mangement.Models;
using Microsoft.EntityFrameworkCore;

namespace HOSPITAL_Mangement.data
{
    public class HospitalDbContext:DbContext
    {
        public HospitalDbContext(DbContextOptions options): base(options) { 
        }
        public HospitalDbContext() { }  
        public DbSet<Patient>Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        
    }
}
