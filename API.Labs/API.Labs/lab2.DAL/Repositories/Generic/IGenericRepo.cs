using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.DAL;

public interface IGenericRepo<T> where T : class
{
    IQueryable<T> GetAll();
    int SaveChanges();
}
