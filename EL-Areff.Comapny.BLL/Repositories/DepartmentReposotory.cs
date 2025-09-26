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
    public class DepartmentRepository : GenaricRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(CompanyDbContext context) :base(context)
        {

        }
    }
}
