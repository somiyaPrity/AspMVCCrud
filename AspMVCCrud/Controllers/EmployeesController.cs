using AspMVCCrud.Data;
using AspMVCCrud.Models;
using AspMVCCrud.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspMVCCrud.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDbContext mDbContext;

        public EmployeesController(MVCDbContext mDbContext)
        {
            this.mDbContext = mDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
           var employee = await mDbContext.Employees.ToListAsync();    
            return View(employee);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeView)
        {
            var employee = new Employee()
            {
                id = Guid.NewGuid(),
                Name = addEmployeeView.Name,
                Email = addEmployeeView.Email,
                Salary = addEmployeeView.Salary,
                Department = addEmployeeView.Department,
                Dob = addEmployeeView.Dob,
            };
           await mDbContext.Employees.AddAsync(employee);
            await mDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
