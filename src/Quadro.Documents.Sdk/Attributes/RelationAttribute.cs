using Quadro.Documents.UnitOfWork;
using Quadro.Utils.Logging;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Documents.Attributes
{
    public class RelationAttribute:Attribute
    {
        public RelationAttribute(Type targetType, DeletionType deletionType, ConsistencyType consistency)
        {
            this.Type = targetType;
            this.DeletionType = deletionType;
            this.ConsistencyType = consistency;
        }

        public Type Type { get;  }
        public DeletionType DeletionType { get; }
        public ConsistencyType ConsistencyType { get;  }
    }

    public enum DeletionType
    {
        None = 0,
        Cascade = 1,
    }

    public enum ConsistencyType
    {
        AllowReferences = 0,
        ProhibitReferences = 1,
    }
}
