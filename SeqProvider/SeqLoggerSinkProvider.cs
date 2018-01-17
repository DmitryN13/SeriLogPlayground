using CommonLogger;
using Serilog;
using Serilog.Configuration;
using System;

namespace SeqProvider
{
    public class SeqLoggerSinkProvider : ILoggerSinkProvider
    {
        public LoggerConfiguration Sink(LoggerSinkConfiguration config)
        {
            return config.Seq("http://localhost:5341");
        }
    }
}
