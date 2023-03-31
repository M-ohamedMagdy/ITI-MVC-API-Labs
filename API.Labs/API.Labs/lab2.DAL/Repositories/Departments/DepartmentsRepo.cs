using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.DAL;

public class DepartmentsRepo : GenericRepo<Department>, IDepartmentsRepo
{
    public DepartmentsRepo(myContext _context) : base(_context)
    {
    }
}
