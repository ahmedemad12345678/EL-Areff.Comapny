using EL_Areff.Comapny.BLL.Iterfaces;
using EL_Areff.Comapny.DAL.Data.Contexts;
using EL_Areff.Comapny.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Areff.Comapny.BLL.Repositories
{
    public class  DepartmentRepository : IDepartmentRepository
    {
        private readonly CompanyDbContext _context; 

        public DepartmentRepository (CompanyDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Department> GetAll()
        {
            
            return _context.Departments.ToList();
        }

        public Department? Get(int Id)
        {
            
            return _context.Departments.Find(Id);
        }

        public int Add(Department model)
        {

            _context.Departments.Add(model);
            return _context.SaveChanges();
            
        }

        public int Update(Department model)
        {

            _context.Departments.Update(model);
            _context.SaveChanges();
            return _context.SaveChanges();
        }
        public int Delete(Department model)
        {

            _context.Departments.Remove(model);
            return _context.SaveChanges();

        }

       
    }
}
