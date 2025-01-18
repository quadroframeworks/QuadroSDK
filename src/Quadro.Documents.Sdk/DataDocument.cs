using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quadro.Documents
{
    public class DataDocument
    {
        public DataDocument() { }
        public string DtoId { get; set; } = null!;
        public bool Valid { get; set; } = true;
        public List<DataInstance> DataObjects { get; set; } = new List<DataInstance>();
        public List<DataAction> Actions { get; set; } = new List<DataAction>();
        public List<DocumentMessage> Messages { get; set; } = new List<DocumentMessage>();
        public string? FilterString { get; set; }
       
    }
}
