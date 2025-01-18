using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Globalization
{
    public class ErrorResult
    {
        public ErrorResult() { }

        public ErrorResult(Exception ex) : this(ex.Message, null, ex.StackTrace)
        {
          
        }
        public ErrorResult(string message) : this(message, null, null)
        {

        }
        public ErrorResult(string englishMessage, string dutchMessage):this(englishMessage, dutchMessage, null)
        {

        }
        public ErrorResult(string? englishMessage, string? dutchMessage, string? stackstrace) 
        {
            if (englishMessage != null)
                Messages.Add(new ErrorText() { Translation = englishMessage, Language = Language.en });

            if (dutchMessage != null)
                Messages.Add(new ErrorText() { Translation = dutchMessage, Language = Language.nl });
            StackTrace = stackstrace;
        }
        public List<ErrorText> Messages { get; set; }  =new List<ErrorText>();

        public string? StackTrace { get; set; }
    }

    public class ErrorText : ITranslationText
    {
        public Language Language { get; set; }
        public string Translation { get; set; } = string.Empty;
    }
}
