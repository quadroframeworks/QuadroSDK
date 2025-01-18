using System;

namespace Quadro.Utils.Logging
{
    public class LogMessage
    {
        public DateTime Date { get; set; }
        public Severity Severity { get; set; }
        public string? SourceClass { get; set; }
        public string? Message { get; set; }
        public string? SourceMethod { get; set; }
        public int LineNumber { get; set; }
    }
    public enum Severity
    {
        Trace=0,
        Debug=1,
        Info=2,
        Warn=3,
        Error=4,
        Fatal=5,
    }
}
