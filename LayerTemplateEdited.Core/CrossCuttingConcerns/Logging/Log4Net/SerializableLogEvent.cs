﻿using log4net.Core;

namespace LayerTemplateEdited.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public object Message => _loggingEvent.MessageObject;
    }
}
