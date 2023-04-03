using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.BL;

public record PersonReadVM(string UserName, string Email, string Role, int DependentsCount);
