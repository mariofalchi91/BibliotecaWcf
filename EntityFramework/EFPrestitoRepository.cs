using BiblioCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework
{
    public class EFPrestitoRepository : IPrestitoRepository
    {
        private BiblioContext c;
        public EFPrestitoRepository()
        {
            c = new BiblioContext();
        }

        public bool Add(Prestito newItem)
        {
            if (newItem == null)
                return false;

            try
            {
                c.Prestiti.Add(newItem);
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
            throw new NotImplementedException();
        } // TODO : delete prestito

        public IEnumerable<Prestito> Fetch(Func<Prestito, bool> filter = null)
        {
            if (filter != null)
                return c.Prestiti.Where(filter).ToList(); ;
            return c.Prestiti.ToList();
        }

        public Prestito GetById(int id)
        {
            if (id <= 0)
                return null;

            return c.Prestiti.Find(id);
        }

        public Prestito GetByIsbn(string prestitoIsbn)
        {
            throw new NotImplementedException();
        } // TODO : get prestiti by isbn?

        public bool Update(Prestito updateItem)
        {
            if (updateItem == null)
                return false;

            try
            {
                c.Prestiti.Update(updateItem);
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
