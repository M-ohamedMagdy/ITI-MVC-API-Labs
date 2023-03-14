using lab2.Models.View;

namespace lab2.Models.Domain;

public class Ticket
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsClosed { get; set; }
    public Severity severity { get; set; }
    public string? Description { get; set; }
    public Department Department { get; set; } = null!;
    public HashSet<Developer> Developers { get; set; } = new HashSet<Developer>();
    public static List<Ticket> TicketList { get; set; } 
        = new() { new (DateTime.Now, true, Severity.low, "Default Ticket", new Department (), new HashSet<Developer>())};
    public Ticket() { Id = Guid.NewGuid(); }
    public Ticket(DateTime createdDate, bool isClosed = false, Severity _severity = Severity.medium, string? description = "NO Desc", Department department = null!, HashSet<Developer> developers = null!)
    {
        Id = Guid.NewGuid();
        CreatedDate = createdDate;
        IsClosed = isClosed; 
        severity = _severity;
        Description = description;
        Department = department;
        Developers = developers;
    }
}
