using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLogger
{
    public class LogFactory: ILogFactory
    {
        public LogFactory(
            //IConfigurationProxy configProxy,
            params ILoggerSinkProvider[] loggerSinkProviders)
        {
            var logConfig = new LoggerConfiguration()
                    // TODO: from configProxy
                    //.MinimumLevel.Debug() 
                    //.Filter.ByIncludingOnly(l =>
                    //{})
                    .Enrich.With<Enrichment>();
            foreach (var sinkProvider in loggerSinkProviders)
            {
                // TODO: from configProxy
                //.MinimumLevel.Debug() 
                //.Filter.ByIncludingOnly(l =>
                //{})
                logConfig = logConfig.WriteTo.Logger(c => sinkProvider.Sink(c.WriteTo));
            }
            Log.Logger = logConfig.CreateLogger();
        }

        public ILogger Create<T>() => Log.Logger.ForContext<T>();
    }
}
