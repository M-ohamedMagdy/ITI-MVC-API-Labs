using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.DAL;

public class Person : IdentityUser
{
    public int Dependants { get; set; }
}
