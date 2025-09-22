using EL_Areff.Comapny.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Areff.Comapny.BLL.Iterfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        Department? Get(int Id);
        int Add(Department model);
        int Update(Department model);
        int Delete(Department model);
    }
}
