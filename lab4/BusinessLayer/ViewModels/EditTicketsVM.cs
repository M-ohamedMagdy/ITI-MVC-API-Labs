﻿using DataAccessLayer.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModels;

public record EditTicketsVM (Guid Id, string Title, string Description, Severity Severity);

