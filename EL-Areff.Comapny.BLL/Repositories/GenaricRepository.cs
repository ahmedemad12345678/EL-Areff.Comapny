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
    public class GenaricRepository<T> : IGenaricRepository<T> where T : BaseEntity
    {
        private readonly CompanyDbContext _context;

        public GenaricRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T? Get(int id)
        {
            return _context.Set<T>().Find(id);

        }


        public int Add(T model)
        {
           _context.Set<T>().Add(model);
              return _context.SaveChanges();
        }


        public int Update(T model)
        {
            _context.Set<T>().Update(model);
            return _context.SaveChanges();
        }

        public int Delete(T model)
        {
            _context.Set<T>().Remove(model);
            return _context.SaveChanges();
        }

       
    
    }
}
