using System.Collections.Generic;

namespace BiblioCore
{
    public interface IMainBL
    {
        // LIBRI
        List<Libro> GetAllLibri();
        bool AddNewLibro(Libro newLibro);
        Libro GetLibroById(int id);
        Libro GetLibroByIsbn(string isbn);
        bool EditLibro(Libro l);
        bool DeleteLibro(int id);

        // UTENTI
        List<Utente> GetAllUtenti();
        bool AddNewUtente(Utente newUtente);
        bool EditUtente(Utente utente);
        bool DeleteUtente(int id);

        // PRESTITI
    }
}
