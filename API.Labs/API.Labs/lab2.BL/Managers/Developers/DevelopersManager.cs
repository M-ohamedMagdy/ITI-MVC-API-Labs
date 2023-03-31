using lab2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.BL;

public class DevelopersManager : IDevelopersManager
{
    private readonly IDevelopersRepo DevRepo;
    public DevelopersManager(IDevelopersRepo _devRepo)
    {
        DevRepo = _devRepo;
    }
    public IQueryable<Developer> GetAllDevelopers()
    {
        return DevRepo.GetAll();
    }
}
