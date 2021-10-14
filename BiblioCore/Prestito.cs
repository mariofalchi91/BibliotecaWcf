using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BiblioCore
{
    [DataContract]
    public class Prestito
    {
        [DataMember]
        public int Id { get; set; }

        //[DataMember]
        //public string Utente { get; set; } // utente è diventata un'entità

        [DataMember]
        public DateTime DataPrestito { get; set; }

        [DataMember]
        public DateTime? DataReso { get; set; }

        [DataMember]
        public int LibroId { get; set; } //fk libro

        [DataMember]
        public int UtenteId { get; set; } //fk utente

        [DataMember]
        public Libro Libro { get; set; } //navigation property

        [DataMember]
        public Utente Utente { get; set; } //navigation property
    }
}
