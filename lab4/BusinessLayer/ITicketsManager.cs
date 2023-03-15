using BusinessLayer.ViewModels;
using DataAccessLayer.DomainModels;

namespace BusinessLayer;

public interface ITicketsManager
{
    IEnumerable<EditTicketsVM> GetAll();
    EditTicketsVM? GetById(Guid id);
    void Add(AddTicketsVM ticket);
    void Update(EditTicketsVM ticket);
    void Delete(Guid id);
}