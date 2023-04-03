using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.BL;

public record TicketDetailsVM(string Description, string Severity, string Department, int DevelopersCount);
