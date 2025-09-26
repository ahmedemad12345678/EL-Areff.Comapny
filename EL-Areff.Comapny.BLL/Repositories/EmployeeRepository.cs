using EL_Areff.Comapny.BLL.Iterfaces;
using EL_Areff.Comapny.DAL.Data.Contexts;
using EL_Areff.Comapny.DAL.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Areff.Comapny.BLL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepository(CompanyDbContext context)
        {
            this._context = context;
        }
         
        public IEnumerable<Employee> GetAll()
        {
            return _context.Em.ToList();
        }

        public Employee? Get(int id)
        {
            return _context.Em.Find();
        }

        public int Add(Employee model)
        {
            _context.Em.Add(model);
            return _context.SaveChanges();
        }


        public int Update(Employee model)
        {
            _context.Em.Update(model);
            return _context.SaveChanges();
        }

        public int Delete(Employee model)
        {
            _context.Em.Remove(model);
            return _context.SaveChanges();
        }

     
       

    }
}
