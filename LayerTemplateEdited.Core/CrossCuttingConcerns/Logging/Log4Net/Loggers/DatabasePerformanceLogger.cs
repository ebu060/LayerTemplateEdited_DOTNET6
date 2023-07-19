using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplateEdited.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DatabasePerformanceLogger : LoggerServiceBase
    {
        public DatabasePerformanceLogger() : base("DatabasePerformanceLogger")
        {
        }
    }
}
