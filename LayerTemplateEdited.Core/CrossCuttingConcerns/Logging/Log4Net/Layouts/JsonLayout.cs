﻿using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using System.Xml;

namespace LayerTemplateEdited.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts
{
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {

        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent = new SerializableLogEvent(loggingEvent);
            var json = JsonConvert.SerializeObject(logEvent, Newtonsoft.Json.Formatting.Indented);
            writer.WriteLine(json);
        }
    }
}
