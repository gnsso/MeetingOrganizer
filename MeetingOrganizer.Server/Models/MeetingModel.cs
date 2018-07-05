using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeetingOrganizer.Server.Models
{
    public class MeetingModel
    {
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public IList<ParticipantModel> Participants { get; set; }
    }
}