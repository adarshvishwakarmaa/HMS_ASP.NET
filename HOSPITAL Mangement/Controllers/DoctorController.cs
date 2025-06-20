using HOSPITAL_Mangement.data;
using HOSPITAL_Mangement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOSPITAL_Mangement.Controllers
{
    public class DoctorController : Controller
    {
        private readonly HospitalDbContext context;
        public DoctorController(HospitalDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(int page = 1)
        {
            int pageSize = 5; // Number of employees per page
            int totalRecords = context.Doctors.Count();

            var doctors = context.Doctors
                                   .OrderBy(e => e.Id)
                                   .Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            return View(doctors);
        }
        [HttpGet]
        public IActionResult Create() { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doctor doctor) {
            if (ModelState.IsValid) {
                context.Doctors.Add(doctor);
                context.SaveChanges();
                return RedirectToAction("Index");
                
            }
            return View(doctor);

        }
        [HttpGet]
        public IActionResult Details(int? id) {
            if (id != null)
            {
                var doctor = context.Doctors.FirstOrDefault(c => c.Id == id);
                if (doctor != null)
                {
                    return View(doctor);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id) {
            if (id != null) { 
                var doctor = context.Doctors.FirstOrDefault(c=>c.Id==id);
                if (doctor != null) { 
                    return View(doctor);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Doctor doctor) {
            if (doctor != null) {
                context.Doctors.Update(doctor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var doctor = context.Doctors.FirstOrDefault(a => a.Id == id);
                if (doctor != null)
                {
                    return View(doctor);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(Doctor doctor) {
            if (doctor != null) {
                context.Remove(doctor);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
