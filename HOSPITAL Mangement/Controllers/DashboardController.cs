using HOSPITAL_Mangement.data;
using Microsoft.AspNetCore.Mvc;

namespace HOSPITAL_Mangement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly HospitalDbContext context;
        public DashboardController(HospitalDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            ViewBag.PatientCount = context.Patients.Count();
            ViewBag.DoctorCount = context.Doctors.Count();
            ViewBag.DepartmentCount = context.Departments.Count();
            return View();
        }
    }
}
