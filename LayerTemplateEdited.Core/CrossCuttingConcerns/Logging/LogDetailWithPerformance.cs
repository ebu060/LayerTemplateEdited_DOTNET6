using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplateEdited.Core.CrossCuttingConcerns.Logging
{
    public class LogDetailWithPerformance : LogDetail
    {
        public double ElapsedTime { get; set; }
    }
}
