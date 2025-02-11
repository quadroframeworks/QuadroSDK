using Quadro.Utils.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Utils.DataContext
{
    public interface ICallContext
    {
        ILog AppLog { get; }
        ILog CallLog { get; }
        IDataContext Data { get; }
    }
}
