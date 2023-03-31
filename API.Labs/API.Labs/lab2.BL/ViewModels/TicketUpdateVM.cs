using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.BL;

public record TicketUpdateVM(int Id, string Description, double EstimationCost, int Department, HashSet<int> Developers);
