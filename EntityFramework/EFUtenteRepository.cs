using BiblioCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework
{
    public class EFUtenteRepository : IUtenteRepository
    {
        private BiblioContext c;
        public EFUtenteRepository()
        {
            c = new BiblioContext();
        }
        public bool Add(Utente newItem)
        {
            if (newItem == null)
                return false;

            try
            {
                c.Utenti.Add(newItem);
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
            if (id <= 0)
                return false;

            try
            {
                var utenteDaEliminare = c.Utenti.Find(id);

                if (utenteDaEliminare != null)
                    c.Utenti.Remove(utenteDaEliminare);

                c.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Utente> Fetch(Func<Utente, bool> filter = null)
        {
            if (filter != null)
                return c.Utenti.Where(filter).ToList();

            return c.Utenti.ToList();
        }

        public Utente GetById(int id)
        {
            if (id <= 0)
                return null;

            return c.Utenti.Find(id);
        }

        public bool Update(Utente updateItem)
        {
            if (updateItem == null)
                return false;

            try
            {
                c.Utenti.Update(updateItem);
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
