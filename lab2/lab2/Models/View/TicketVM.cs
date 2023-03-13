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
        public DateTime CreatedDate { get; init; }
        [Display(Name = "Is Closed?")]
        public bool IsClosed { get; init; }
        public Severity Severity { get; init; }
        public string? Description { get; init; }
    }
}
