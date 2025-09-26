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
    public class EmployeeRepository : GenaricRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyDbContext context) : base(context)
        {
        }



    }
}
