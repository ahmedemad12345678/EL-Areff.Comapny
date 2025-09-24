
using EL_Areff.Comapny.BLL.Iterfaces;
using EL_Areff.Comapny.BLL.Repositories;
using EL_Areff.Comapny.DAL.Model;
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
    }
}
