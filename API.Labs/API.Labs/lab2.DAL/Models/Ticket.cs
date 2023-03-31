using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.DAL;

public class Ticket
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public Severity? Severity { get; set; }
    public double EstimationCost { get; set; }
    [ForeignKey(nameof(Department))]
    public int DeptId { get; set; }
    public Department? Department { get; set; }
    public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
    public Ticket(int id, string description, double cost, int deptid)
    {
        Id = id;
        Description = description;
        EstimationCost = cost;
        DeptId = deptid;
    }
    public Ticket()
    {

    }
}

public enum Severity
{
    High, Medium, Low
}