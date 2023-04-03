using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace lab2.DAL;

public class DepartmentsRepo : GenericRepo<Department>, IDepartmentsRepo
{
    private readonly myContext _context;

    public DepartmentsRepo(myContext context) : base(context)
    {
        _context = context;
    }

    public Department? GetDepartment(int id)
    {
        return _context.Set<Department>()
            .Include(d => d.Tickets)
            .ThenInclude(t => t.Developers)
            .FirstOrDefault(x => x.Id == id);
    }
}
