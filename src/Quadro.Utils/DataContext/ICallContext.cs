using Quadro.Globalization;
using Quadro.Utils.Logging;

namespace Quadro.Utils.DataContext
{
    public interface ICallContext
    {
        ILog AppLog { get; }
        ILog CallLog { get; }
        IDataContext Data { get; }
        Language Language { get; }
    }
}
