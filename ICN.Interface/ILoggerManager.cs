using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Interface
{
    public interface ILoggerManager
    {
        void Information(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
    }
}
