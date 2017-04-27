using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RingkoebingSkjern.Models
{
    public class Tidsregistrering
    {
        [Required]
        public int FrivilligId { get; set; } //foreign key
        [Required]
        public int LaugId { get; set; } //foreign key
        public string StartTid { get; set; }
        public string SlutTid { get; set; }
        public int AntalTimer { get; set; }
    }
}