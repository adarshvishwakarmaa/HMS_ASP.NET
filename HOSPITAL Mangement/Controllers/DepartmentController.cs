using HOSPITAL_Mangement.data;
using HOSPITAL_Mangement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOSPITAL_Mangement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly HospitalDbContext context; 
        public DepartmentController(HospitalDbContext context)
        {
            this.context=context;
        }
        public IActionResult Index(int page = 1)
        {
            int pageSize = 5; // Number of employees per page
            int totalRecords = context.Departments.Count();

            var department = context.Departments
                                   .OrderBy(e => e.Id)
                                   .Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                context.Departments.Add(department);
                context.SaveChanges();
                return View(department);
             
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Details(int ?id)
        {
            if (id != null)
            {
                var department = context.Departments.FirstOrDefault(a => a.Id == id);
                if (department != null)
                {
                    return View(department);
                }
                
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int?id) {
            if (id != null) { 
                var department = context.Departments.FirstOrDefault(a=>a.Id == id);
                if (department != null) { 
                    return View(department);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Department department) {
            if (department != null) {
                context.Departments.Update(department);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Delete(int? id) {
            if (id != null) { 
                var department = context.Departments.FirstOrDefault(c=>c.Id == id);
                if (department != null) { 
                    return View(department);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(Department department) {
            if (department != null) {
                context.Departments.Remove(department);
                context.SaveChanges();
       
            }
            return RedirectToAction("Index");

        }

    }
}
