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

        [Required, Display(Name = "Konu")]
        public string Subject { get; set; }

        [Display(Name = "Tarih")]
        [DisplayFormat(DataFormatString = "{0:ddd, dd.MM.yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [Display(Name = "Başlangıç Saati")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime StartedDate { get; set; }

        [Display(Name = "Bitiş Saati")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime FinishedDate { get; set; }

        [Display(Name = "Katılımcılar")]
        public IList<ParticipantModel> Participants { get; set; }
    }
}