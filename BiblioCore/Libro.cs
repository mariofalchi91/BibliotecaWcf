using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BiblioCore
{
    [DataContract]
    public class Libro
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Isbn { get; set; }

        [DataMember]
        public string Titolo { get; set; }

        [DataMember]
        public string Sommario { get; set; }

        [DataMember]
        public string Autore { get; set; }

        [DataMember]
        public List<Prestito> Prestiti { get; set; } //navigation property
    }
}
