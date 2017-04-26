using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RingkoebingSkjern.Models
{
    public class Tovholder
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public int? PostNr { get; set; } //nullable
    }
}