using lab2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.BL;
public class DepartmentsManager : IDepartmentsManager
{
    private readonly IDepartmentsRepo DeptRepo;

    public DepartmentsManager(IDepartmentsRepo _deptRepo)
    {
        DeptRepo = _deptRepo;
    }
    public IQueryable<Department> GetAllDepartments()
    {
        return DeptRepo.GetAll();
    }

    public DepartmentReadVM? GetDepartment(int id)
    {
        var dept = DeptRepo.GetDepartment(id);
        
        if (dept == null) return null;
        
        IEnumerable<TicketInDepartmentVM> tickets = dept.Tickets
            .Select(t => new TicketInDepartmentVM(t.Id, t.Description, t.Developers.Count));

        return new DepartmentReadVM(id, dept.Name, tickets);
    }
}
