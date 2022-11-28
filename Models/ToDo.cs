using System;

namespace MvcMovie.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Inhalt { get; set; }
        public DateTime ErstellDatum { get; set; }
        public DateTime Enddatum { get; set; }
        public string Abgehakt { get; set; }

        public ToDo(int id, string inhalt, DateTime EndDatum)
        {
            Id = id;
            Inhalt = inhalt;
            ErstellDatum = DateTime.Now;
            Enddatum = EndDatum;
            Abgehakt = "Nein";
        }
    }
}
