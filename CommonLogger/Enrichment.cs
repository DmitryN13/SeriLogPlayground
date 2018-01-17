using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonLogger
{
    class Enrichment : ILogEventEnricher
    {
        private static readonly Assembly ENTRY_ASSEMBLY = Assembly.GetEntryAssembly();
        private static readonly string APP_VERSION = ENTRY_ASSEMBLY.GetName().Version.ToString();
        private static readonly string APP_NAME = ENTRY_ASSEMBLY.GetName().Name;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var trd = propertyFactory.CreateProperty(
                            "ThreadId", Thread.CurrentThread.ManagedThreadId);
            logEvent.AddPropertyIfAbsent(trd);
            var mac = propertyFactory.CreateProperty(
                            "Machine", Environment.MachineName);
            logEvent.AddPropertyIfAbsent(mac);

            var appVer = propertyFactory.CreateProperty(
                            "app-version", APP_VERSION);
            logEvent.AddPropertyIfAbsent(appVer);

            var appName = propertyFactory.CreateProperty(
                            "app-name", APP_NAME);
            logEvent.AddPropertyIfAbsent(appName);
        }
    }
}
