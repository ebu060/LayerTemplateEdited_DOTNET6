using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplateEdited.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DatabaseExceptionLogger : LoggerServiceBase
    {
        public DatabaseExceptionLogger() : base("DatabaseExceptionLogger")
        {
        }
    }
}
