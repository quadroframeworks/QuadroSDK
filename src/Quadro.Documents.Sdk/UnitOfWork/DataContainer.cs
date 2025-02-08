using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Documents.UnitOfWork
{

    public class DataContainer
    {
        public string Id { get; set; } = null!;
        public string Hash { get; set; } = null!;
        public string Type { get; set; } = null!;
        public IStorable Model { get; set; } = null!;
        public DataDocument? ViewModel { get; set; }
    }

}
