namespace Quadro.Utils.Logging
{
    public class NewLogMessageEventArgs
    {
        public NewLogMessageEventArgs(LogMessage msg)
        {
            Message = msg;
        }

        public LogMessage Message { get; }
    }
}
