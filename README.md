# 🏥 Hospital Management System - ASP.NET MVC

A simple and functional **Hospital Management System** built with **ASP.NET MVC**. This project supports **CRUD operations** for Patients, Doctors, and Departments. It also includes a **dashboard** with real-time counts using `ViewBag`, displayed with elegant **bootstrap cards**.

---

## 📌 Features

- 🧑‍⚕️ Add, View, Edit, Delete Doctors
- 👨‍👩‍⚕️ Add, View, Edit, Delete Patients
- 🏬 Add, View, Edit, Delete Departments
- 📊 Dashboard showing counts of:
  - Total Patients
  - Total Doctors
  - Total Departments
- 🔗 Relationships between:
  - Patient → Doctor
  - Patient → Department
  - Doctor → Department

---

## 🧱 Project Structure

HOSPITAL_Mangement/
│
├── Controllers/
│ ├── PatientController.cs
│ ├── DoctorController.cs
│ └── DepartmentController.cs
│
├── Models/
│ ├── Patient.cs
│ ├── Doctor.cs
│ └── Department.cs
│
├── Views/
│ ├── Patient/ (CRUD Views)
│ ├── Doctor/ (CRUD Views)
│ ├── Department/ (CRUD Views)
│ └── Dashboard/ (Index.cshtml)
│
├── Data/
│ └── HospitalDbContext.cs
│
└── README.md

---

## 🧾 Model Definitions

### ✅ Patient.cs
```csharp
public class Patient
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DOB { get; set; }
    public string Gender { get; set; }
    public string Contact { get; set; }
    public string Address { get; set; }
    public int DoctorId { get; set; }
    public int DepartmentId { get; set; }
}

public class Doctor
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public string Phone { get; set; }
    public int DepartmentId { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public IActionResult Index()
{
    ViewBag.PatientCount = context.Patients.Count();
    ViewBag.DoctorCount = context.Doctors.Count();
    ViewBag.DepartmentCount = context.Departments.Count();
    return View();
}

<div class="row">
    <div class="col-md-4">
        <div class="card text-white bg-primary mb-3">
            <div class="card-body">
                <h5 class="card-title">Patients</h5>
                <p class="card-text">@ViewBag.PatientCount</p>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <div class="card text-white bg-success mb-3">
            <div class="card-body">
                <h5 class="card-title">Doctors</h5>
                <p class="card-text">@ViewBag.DoctorCount</p>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <div class="card text-white bg-warning mb-3">
            <div class="card-body">
                <h5 class="card-title">Departments</h5>
                <p class="card-text">@ViewBag.DepartmentCount</p>
            </div>
        </div>
    </div>
</div>

⚙️ How to Run
git clone https://github.com/yourusername/Hospital-Mangement.git
✅ Open the project in Visual Studio

✅ Make sure Entity Framework Core is installed

✅ Run the following in Package Manager Console:
Add-Migration InitialCreate
Update-Database
✅ Press F5 or run the project. Navigate to /Dashboard.

📚 Technologies Used
ASP.NET Core MVC

Entity Framework Core

Bootstrap 4/5

SQL Server / LocalDB
