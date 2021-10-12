using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiblioCore;

namespace EntityFramework
{
    public class EFBiblioRepo : ILibroRepository
    {
        private BiblioContext c;
        public EFBiblioRepo()
        {
            c = new BiblioContext();
        }

        public IEnumerable<Libro> Fetch(Func<Libro,bool> filter=null)
        {
            if (filter != null)
                return c.Libri.Where(filter).ToList(); ;
            return c.Libri.ToList() ;
        }

        public bool Add(Libro newItem)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Libro GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Libro GetByIsbn(string libroIsbn)
        {
            throw new NotImplementedException();
        }

        public bool Update(Libro updateItem)
        {
            throw new NotImplementedException();
        }
    }
}
