using MeetingOrganizer.Server.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MeetingOrganizer.Server.Repositories
{
    public class MeetingRepository : Repository<Meeting>
    {
        protected override IQueryable<Meeting> OnGetting(DbSet<Meeting> entities)
        {
            return entities.Include(m => m.Participants);
        }
    }
}