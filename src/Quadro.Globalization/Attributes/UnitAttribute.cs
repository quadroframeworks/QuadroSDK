using Quadro.Base.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Globalization.Attributes
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UnitAttribute:Attribute
    {
        public UnitAttribute(Unit unit)
        {
            this.Unit = unit;
        }

        public Unit Unit { get;  }
    }
}
