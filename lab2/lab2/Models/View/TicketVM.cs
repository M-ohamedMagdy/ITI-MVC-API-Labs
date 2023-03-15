using lab2.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace lab2.Models.View
{
    public enum Severity
    {
        high, medium, low
    }
    public record TicketVM
    {
        public DateTime CreatedDate { get; init; } = DateTime.Now;

        [Display(Name = "Is Closed?")]
        public bool IsClosed { get; init; }
        [Display(Name = "Severity")]
        public Severity severity { get; init; }
        public string? Description { get; init; }
        public Guid Department { get; set; }
        public HashSet<Guid> Developers { get; set; } = new HashSet<Guid>();
    }
}
