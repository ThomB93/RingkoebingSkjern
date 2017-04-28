using System.ComponentModel.DataAnnotations;

namespace RingkoebingSkjern.Models
{
    public class Frivillig
    {
        public int Id { get; set; } //primary key
        [Required] //data validation
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