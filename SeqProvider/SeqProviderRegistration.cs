using Autofac;
using CommonLogger;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeqProvider
{
    public class SeqProviderRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SeqLoggerSinkProvider>()
                .As<ILoggerSinkProvider>()
                .SingleInstance();
            base.Load(builder);
        }
    }
}
