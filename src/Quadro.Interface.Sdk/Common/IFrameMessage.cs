
using Quadro.Utils.Logging;

namespace Quadro.Interface.Common
{
	public interface IFrameMessage
    {
        Severity Severity { get; set; }
        string Message { get; set; }
    }
}
