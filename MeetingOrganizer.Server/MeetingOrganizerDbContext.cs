using MeetingOrganizer.Server.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MeetingOrganizer.Server
{
    public class MeetingOrganizerDbContext : DbContext
    {
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public MeetingOrganizerDbContext() : base("MeetingOrganizerDbContext")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>()
                .HasRequired(p => p.Meeting)
                .WithMany(m => m.Participants)
                .HasForeignKey(p => p.MeetingId)
                .WillCascadeOnDelete(true);
        }
    }
}