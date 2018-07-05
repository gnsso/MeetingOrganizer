using MeetingOrganizer.Server.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MeetingOrganizer.Logging
{
    public class DebugLogger : ILogger
    {
        public void Log(string message, Priority priority)
        {
            Debug.WriteLine(Settings.Default.DebugLogPattern, message, priority, DateTime.Now);
        }
    }
}