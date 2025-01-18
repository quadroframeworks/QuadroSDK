using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Globalization
{
    public class ErrorResultException:Exception
    {
        public ErrorResultException(string message) : base(message)
        {
            this.Result = new ErrorResult(message);
        }
        public ErrorResultException(string englishMessage, string dutchMessage) : base(englishMessage)
        {
            this.Result = new ErrorResult(englishMessage, dutchMessage, base.StackTrace);
        }
        public ErrorResultException(ErrorResult errorResult) : base(errorResult.Messages.FirstOrDefault()?.Translation) 
        { 
            this.Result = errorResult;
        }   
        
        public ErrorResult Result { get; private set; }
    }
}
