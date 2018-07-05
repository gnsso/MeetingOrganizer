using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingOrganizer.Logging
{
    public enum Priority
    {
        None = 0,
        Low = 1 << 0,
        Medium = 1 << 1,
        High = 1 << 2
    }
}