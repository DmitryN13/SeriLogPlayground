using Autofac;
using CommonLogger;
using SeqProvider;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UseCommonLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<CommonLoggerRegistration>()
                   .RegisterModule<SeqProviderRegistration>();
            var ioc = builder.Build();
            ILogFactory loggerFactory = ioc.Resolve<ILogFactory>();
            ILogger logger = loggerFactory.Create<Program>();
            for (int i = 0; i < 100; i++)
            {
                logger.Information("my log {@A} {@B}", i, i * i);
                Thread.Sleep(1000);
            }
            Console.ReadKey();
        }
    }
}
