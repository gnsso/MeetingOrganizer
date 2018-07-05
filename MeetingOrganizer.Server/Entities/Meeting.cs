using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeetingOrganizer.Server.Entities
{
    public class Meeting : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime FinishedDate { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
    }
}