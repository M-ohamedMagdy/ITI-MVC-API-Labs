using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DomainModels;
public enum Severity
{
    Low,
    Medium,
    High
}

public class Ticket
{
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public Severity Severity { get; set; }
    public Ticket()
    {

    }
    public Ticket(string title, string description, Severity severity)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Severity = severity;
    }
}