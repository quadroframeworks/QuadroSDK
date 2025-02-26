using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Documents.UnitOfWork
{
    public class UnitOfWorkUpdate
    {
        public UnitOfWork Uow { get; set; } = null!;
        public object Model { get; set; } = null!;
    }
}
