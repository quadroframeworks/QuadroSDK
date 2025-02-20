using Quadro.DataModel.Entities.Customers;
using Quadro.DataModel.Geometrics;
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
            if (type == typeof(ImageEntityDto).FullName)
                return typeof(ImageEntityDto);
            else if (type == typeof(CustomerDto).FullName)
                return typeof(CustomerDto);

            throw new Exception("Type not found");
        }
    }
}
