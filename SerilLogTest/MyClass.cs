using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerilLogTest
{
    class MyClass
    {
        private readonly ILogger _logger;
        public MyClass()
        {
            _logger = Log.Logger.ForContext<MyClass>()
                                .ForContext("CorrelationID", 123);
        }

        public void Hello(int i, string s)
        {
            _logger.Information("Hello {Now}: i = {i}, s = {s}", DateTimeOffset.Now, i, s);
            _logger.Warning("Problem");
            //var fruit = new[] { "Apple", "Pear", "Orange" };
            //_logger.Information("In my bowl I have {Fruit}", fruit);
            var sensorInput = new { Coutnt = i, Name = s };
            _logger.Information("Processing {@SensorInput}", sensorInput);

            var data = Tuple.Create(1, 2, 3);
            _logger.Information("Show {@data}", data);

            var unknown = new[] { 1, 2, 3 };
            _logger.Information("Received {$Data}", unknown);
        }
    }
}
