
using EL_Areff.Comapny.BLL.Iterfaces;
using EL_Areff.Comapny.BLL.Repositories;
using EL_Areff.Comapny.DAL.Model;
using EL_Areff.Comapny.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EL_Areff.Comapny.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository =departmentRepository;
        }
        [HttpGet]   
        public IActionResult Index()
        {
           
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentDto model)
        {
            if(ModelState.IsValid)
            {
                var department = new Department()
                {
                    Code = model.Code,
                    Name = model.Name,
                    CraeteAt= model.CraeteAt,
                };
                var result = _departmentRepository.Add(department);
                if(result>0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

      
    }
}
