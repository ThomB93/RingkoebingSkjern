﻿namespace RingkoebingSkjern.Models
{
    public class Frivillig
    {
        public int Id { get; set; } //primary key
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public int? PostNr { get; set; } //foreign key
    }
}