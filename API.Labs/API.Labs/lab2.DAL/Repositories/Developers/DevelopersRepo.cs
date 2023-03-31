using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.DAL;

public class DevelopersRepo : GenericRepo<Developer>, IDevelopersRepo
{
    public DevelopersRepo(myContext _context) : base(_context)
    {
    }
}
