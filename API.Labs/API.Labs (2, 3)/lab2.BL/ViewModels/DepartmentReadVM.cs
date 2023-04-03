using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.BL;

public record DepartmentReadVM(int Id, string Name, IEnumerable<TicketInDepartmentVM> Tickets);
