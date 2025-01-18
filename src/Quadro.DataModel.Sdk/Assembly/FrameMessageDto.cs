using Quadro.Interface.Common;
using Quadro.Utils.Logging;

namespace Quadro.DataModel.Model
{
	public class FrameMessageDto:IFrameMessage
    {
        public FrameMessageDto()
        {

        }

        public FrameMessageDto(Severity severity, string message)
        {
            Severity = severity;
            Message = message;
        }

        public Severity Severity { get; set; }
        public string Message { get; set; } = null!;
    }
}
