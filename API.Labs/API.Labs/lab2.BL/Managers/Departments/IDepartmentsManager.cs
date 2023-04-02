using lab2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.BL;

public interface IDepartmentsManager
{
    IQueryable<Department> GetAllDepartments();
    DepartmentReadVM? GetDepartment(int id);
}
