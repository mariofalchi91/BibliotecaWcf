using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BiblioCore
{
    [DataContract]
    public class Utente
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Cognome { get; set; }

        [DataMember]
        public DateTime? DataIscrizione { get; set; }

        [DataMember]
        public List<Prestito> Prestiti { get; set; } //navigation property

    }
}
