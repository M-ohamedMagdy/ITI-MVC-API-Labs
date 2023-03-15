using DataAccessLayer.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories;

public interface ITicketsRepo
{
    IEnumerable<Ticket> GetAll();
    Ticket? GetById(Guid id);
    void Add(Ticket ticket);
    void Update(Ticket ticket);
    void Delete(Guid id);
    int SaveChanges();
}
