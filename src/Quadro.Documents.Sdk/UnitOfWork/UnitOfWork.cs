using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Documents.UnitOfWork
{
	public class UnitOfWork
	{
        public UnitOfWork() { }
        public UnitOfWork(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; } = null!;
        public ContainerCollection Containers { get; set; } = new ContainerCollection();

      
    }
}
