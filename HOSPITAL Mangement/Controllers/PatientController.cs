using HOSPITAL_Mangement.data;
using HOSPITAL_Mangement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOSPITAL_Mangement.Controllers
{
    public class PatientController : Controller
    {
        private readonly HospitalDbContext context;
        public PatientController(HospitalDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(int page = 1)
        {
            int pageSize = 5; // Number of employees per page
            int totalRecords = context.Patients.Count();

            var pateint = context.Patients
                                   .OrderBy(e => e.Id)
                                   .Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            return View(pateint);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

           
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid) { 
                context.Patients.Add(patient);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }
        [HttpGet]
        public IActionResult Details(int? id) {
            if (id != null) { 
                var patient=context.Patients.FirstOrDefault(x => x.Id == id);
                if (patient != null) {
                    return View(patient);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null) {
                var patient = context.Patients.FirstOrDefault(x => x.Id == id);
                if (patient != null) {
                    return View(patient);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Patient patient) {
            if (patient != null) {
                context.Patients.Update(patient);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var patient = context.Patients.FirstOrDefault(x => x.Id == id);
                if (patient != null)
                {
                    return View(patient);
                }
            }
            return RedirectToAction("Index");
        }
      
        [HttpPost]
        public IActionResult Delete(Patient patient)
        {
            if (patient != null)
            {
                context.Patients.Remove(patient);
                context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}
