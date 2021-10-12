using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioCore
{
    public interface ILibroRepository:IRepository<Libro>
    {
        Libro GetByIsbn(string libroIsbn);
    }
}
