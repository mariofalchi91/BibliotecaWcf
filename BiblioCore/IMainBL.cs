using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioCore
{
    public interface IMainBL
    {
        List<Libro> GetAllLibri();
        bool AddNewLibro(Libro newLibro);
    }
}
