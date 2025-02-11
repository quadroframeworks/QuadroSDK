using Quadro.DataModel.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Api
{
    public class EntityTypeProvider : IEntityTypeProvider
    {
        public Type GetType(string type)
        {
            return typeof(CustomerDto);
        }
    }
}
