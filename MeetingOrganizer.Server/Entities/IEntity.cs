using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingOrganizer.Server.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
    }
}