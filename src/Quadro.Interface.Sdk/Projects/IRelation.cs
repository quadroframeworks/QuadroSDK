﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Interface.Projects
{
    public interface IRelation
    {
        string? ERPId { get; set; }
        string Name { get; }
    }
}
