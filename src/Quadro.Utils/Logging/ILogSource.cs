using System;

namespace Quadro.Utils.Logging
{
    public interface ILogSource
    {
        event EventHandler<NewLogMessageEventArgs> OnNewMessage;
    }
}
