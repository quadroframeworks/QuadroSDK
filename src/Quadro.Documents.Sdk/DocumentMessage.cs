using Quadro.Utils.Logging;

namespace Quadro.Documents
{
	public class DocumentMessage
    {
        public DocumentMessage(Severity severity, string message)
        {
            Severity = severity;
            Message = message;
        }

        public Severity Severity { get; set; }
        public string Message { get; set; } = null!; 
    }
}
