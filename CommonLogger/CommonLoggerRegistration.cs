using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLogger
{
    public class CommonLoggerRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LogFactory>()
                .As<ILogFactory>()
                .SingleInstance();
            base.Load(builder);
        }
    }
}
