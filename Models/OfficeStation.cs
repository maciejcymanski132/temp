﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OfficeStation
    {
        Guid Id { get; set; }

        Guid AssignedEmployee { get; set; }
    }
}