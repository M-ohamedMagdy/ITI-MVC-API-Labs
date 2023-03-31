using lab2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.BL;

public record TicketAddVM(string Description, double EstimationCost, int Department, HashSet<int> Developers);
