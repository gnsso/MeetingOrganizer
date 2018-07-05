using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingOrganizer.Logging
{
    public interface ILogger
    {
        void Log(string message, Priority priority);
    }
}