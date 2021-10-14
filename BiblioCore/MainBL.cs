using System.Collections.Generic;
using System.Linq;

namespace BiblioCore
{
    public class MainBL : IMainBL
    {
        private readonly ILibroRepository libroRepo;
        private readonly IPrestitoRepository prestitoRepo;
        private readonly IUtenteRepository utenteRepo;

        public MainBL(ILibroRepository repoL, IPrestitoRepository repoP, IUtenteRepository repoU)
        {
            libroRepo = repoL;
            prestitoRepo = repoP;
            utenteRepo = repoU;
        }
        public MainBL()
        {
            libroRepo = DependencyContainer.Resolve<ILibroRepository>();
            prestitoRepo = DependencyContainer.Resolve<IPrestitoRepository>();
        } // costruttore per wcf

        #region OPERAZIONI SU TABELLA LIBRI
        public bool AddNewLibro(Libro newLibro)
        {
            if (newLibro == null)
                return false;

            return libroRepo.Add(newLibro);
        }

        public bool EditLibro(Libro l)
        {
            if (l == null) 
                return false;

            return libroRepo.Update(l);
        }

        public List<Libro> GetAllLibri()
        {
            return libroRepo.Fetch().ToList();
        }

        public Libro GetLibroById(int id)
        {
            return libroRepo.GetById(id);
        }

        public Libro GetLibroByIsbn(string isbn)
        {
            return libroRepo.GetByIsbn(isbn);
        }

        public bool DeleteLibro(int id)
        {
            if (id <= 0)
                return false;

            Libro libroDaEliminare = libroRepo.GetById(id);

            if (libroDaEliminare != null)
                return libroRepo.DeleteById(id);

            return false;
        }

        #endregion

        #region OPERAZIONI SU UTENTI
        public List<Utente> GetAllUtenti()
        {
            return utenteRepo.Fetch().ToList();
        }

        public bool AddNewUtente(Utente newUtente)
        {
            if (newUtente == null)
                return false;

            return utenteRepo.Add(newUtente);
        }

        public bool EditUtente(Utente utente)
        {
            if (utente == null)
                return false;

            return utenteRepo.Update(utente);
        }

        public bool DeleteUtente(int id)
        {
            if (id <= 0)
                return false;

            Utente utenteDaEliminare = utenteRepo.GetById(id);

            if (utenteDaEliminare != null)
                return utenteRepo.DeleteById(id);

            return false;
        }
        #endregion

        #region OPERAZIONI SU PRESTITI

        #endregion

    }
}
