using System;
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
    }
}
