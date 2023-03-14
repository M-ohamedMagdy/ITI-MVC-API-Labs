using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace lab2.Models.View
{
    public class EditTicketVM
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; init; }

        [Display(Name = "Is Closed?")]
        public bool IsClosed { get; init; }
        public Severity severity { get; init; }
        public string? Description { get; init; }
        public Guid Department { get; set; }
        public HashSet<Guid> Developers { get; set; } = new HashSet<Guid>();
    }
}
