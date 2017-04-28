using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RingkoebingSkjern.Models
{
    public class Tovholder
    {
        public int Id { get; set; } //primary key
        [Required]
        public string Fornavn { get; set; }
        [Required]
        public string Efternavn { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        [Required]
        public int? PostNr { get; set; } //foreign key
    }
}