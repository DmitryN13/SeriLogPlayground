using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLogger
{
    public interface ILogFactory
    {
        ILogger Create<T>();
    }
}
