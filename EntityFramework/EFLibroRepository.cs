using System;
using System.Collections.Generic;
using System.Linq;
using BiblioCore;

namespace EntityFramework
{
    public class EFLibroRepository : ILibroRepository
    {
        private BiblioContext c;
        public EFLibroRepository()
        {
            c = new BiblioContext();
        }

        public IEnumerable<Libro> Fetch(Func<Libro, bool> filter = null)
        {
            if (filter != null)
                return c.Libri.Where(filter).ToList();

            return c.Libri.ToList();
        }

        public bool Add(Libro newItem)
        {
            if (newItem == null)
                return false;

            try
            {
                c.Libri.Add(newItem);
                c.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            if (id<=0)
                return false;

            try
            {
                var libroDaEliminare = c.Libri.Find(id);

                if (libroDaEliminare != null)
                    c.Libri.Remove(libroDaEliminare);

                c.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Libro GetById(int id)
        {
            if (id <= 0)
                return null;

            return c.Libri.Find(id);
        }

        public Libro GetByIsbn(string libroIsbn)
        {
            if (string.IsNullOrEmpty(libroIsbn))
                return null;

            try
            {
                var libroTrovato = c.Libri.FirstOrDefault(l => l.Isbn == libroIsbn);

                return libroTrovato;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Libro updateItem)
        {
            if (updateItem == null)
                return false;

            try
            {
                c.Libri.Update(updateItem);
                c.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
