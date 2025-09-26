
using EL_Areff.Comapny.BLL.Iterfaces;
using EL_Areff.Comapny.BLL.Repositories;
using EL_Areff.Comapny.DAL.Model;
using EL_Areff.Comapny.PL.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

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

        [HttpGet]
        public IActionResult Details(int? id, string viewname = "Details")
        {
            if (id is null) return BadRequest("Invalid Id");
            var result=_departmentRepository.Get(id.Value);
            if (result is null) return NotFound(new { StatusCode = 400 ,Message=$"department with id {id} id not found" });
            return View(viewname,result);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            //if(id is null) return BadRequest("invalid Id");
            //var result =_departmentRepository.Get(id.Value);
            //if (result is null) return NotFound(new { StatusCode = 400, Message = $"department with id {id} id not found" });
            return Details(id, "Update");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update ([FromRoute]int id ,Department model)
        {
            if(ModelState.IsValid)
            {
                if (id != model.Id) return BadRequest();
                var result = _departmentRepository.Update(model);
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
            //if (id is null) return BadRequest("Invaid Id");
            //var department = _departmentRepository.Get(id.Value);
            //if(department is null ) return NotFound(new { StatusCode = 400, Message = $"department with id {id} id not found" });
            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute]int id,Department model)
        {
           if(id != model.Id) return BadRequest();
            var result = _departmentRepository.Delete(model);
            if(result > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
