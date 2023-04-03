using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.DAL;

public interface IDepartmentsRepo : IGenericRepo<Department>
{
    Department? GetDepartment(int id);
}
