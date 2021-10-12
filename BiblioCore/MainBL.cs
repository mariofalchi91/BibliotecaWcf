using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiblioCore
{
    public class MainBL : IMainBL
    {
        private ILibroRepository libroRepo;
        public MainBL()
        {
            libroRepo = DependencyContainer.Resolve<ILibroRepository>();
        }
        public bool AddNewLibro(Libro newLibro)
        {
            if (newLibro == null)
                return false;

            return libroRepo.Add(newLibro);
        }

        public List<Libro> GetAllLibri()
        {
            return libroRepo.Fetch().ToList();
        }
    }
}
