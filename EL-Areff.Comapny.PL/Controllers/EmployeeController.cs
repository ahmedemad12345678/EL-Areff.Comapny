using EL_Areff.Comapny.BLL.Iterfaces;
using EL_Areff.Comapny.BLL.Repositories;
using EL_Areff.Comapny.DAL.Model;
using EL_Areff.Comapny.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EL_Areff.Comapny.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAll();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeTDO model)
        {
            if(ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Name = model.Name,
                    Age = model.Age,
                    Email = model.Email,
                    Address = model.Address,
                    CreateAt = model.CreateAt,
                    HiringDate = model.HiringDate,
                    IsActive = model.IsActive,
                    IsDeleted = model.IsDeleted,    
                    Phone = model.Phone,
                    Salary = model.Salary
                };

                var count = _employeeRepository.Add(employee);
                if(count > 0) return RedirectToAction(nameof(Index));

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int? id,string viewname= "Details")
        {
            if (id is null) return BadRequest("Invalid Id");
            var Emp= _employeeRepository.Get(id.Value);
            if (Emp is null) return NotFound("Not Found");
            return View(viewname,Emp);

        }
        [HttpGet]

        public IActionResult Update(int? id)
        {
            
            return Details(id, "Update");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromRoute] int id, Employee model)
        {
            if (ModelState.IsValid)
            {
                if (id != model.Id) return BadRequest();
                var result = _employeeRepository.Update(model);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {

            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Employee model)
        {
            if (id != model.Id) return BadRequest();
            var result = _employeeRepository.Delete(model);
            if (result > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

    }
}
