using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.DAL;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly myContext context;

    public GenericRepo(myContext _context)
    {
        context = _context;
    }
    public IQueryable<T> GetAll()
    {
        return context.Set<T>();
    }
    public int SaveChanges()
    {
        return context.SaveChanges();
    }
}
