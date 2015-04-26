using System;
using System.Diagnostics;

namespace DryIocSampleWebApi.Domain
{
    public class Logger : ILogger
    {
        private readonly Action<string> _loggerAction;

        public Logger(Action<string> loggerAction)
        {
            Debug.WriteLine(GetType().Name + " ctor");

            if (loggerAction == null)
            {
                throw new ArgumentNullException("loggerAction");
            }

            _loggerAction = loggerAction;
        }

        public void Log(string message)
        {
            _loggerAction(message);
        }
    }
}