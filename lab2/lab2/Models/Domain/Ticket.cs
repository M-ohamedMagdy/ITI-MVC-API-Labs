using lab2.Models.View;

namespace lab2.Models.Domain;

public class Ticket
{
    public DateTime CreatedDate { get; set; }
    public bool IsClosed { get; set; }
    public Severity Severity { get; set; }
    public string? Description { get; set; }
    public static List<Ticket> TicketList { get; set; } 
        = new() { new (DateTime.Now, true, Severity.low, "Default Ticket") };
    public Ticket() { }
    public Ticket(DateTime createdDate, bool isClosed, Severity severity, string? description)
    {
        CreatedDate = createdDate;
        IsClosed = isClosed;
        Severity = severity;
        Description = description;  
    }
}
