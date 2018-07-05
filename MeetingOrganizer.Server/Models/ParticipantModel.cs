using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeetingOrganizer.Server.Models
{
    public class ParticipantModel
    {
        [Display(Name = "İsim")]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}