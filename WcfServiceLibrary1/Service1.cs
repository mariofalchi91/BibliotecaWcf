using BiblioCore;
using EntityFramework;
using System.Collections.Generic;

namespace Biblioteca
{
    public class Service1 : IService1
    {
        public IMainBL mainBL;
        public Service1()
        {
            DependencyContainer.Register<IMainBL, MainBL>();
            DependencyContainer.Register<ILibroRepository, EFLibroRepository>();
            DependencyContainer.Register<IPrestitoRepository, EFPrestitoRepository>();
            mainBL = DependencyContainer.Resolve<IMainBL>();

        }
        public int FaiNiente()
        {
            return 12;
        }

        public List<Libro> GetLibri()
        {
            return mainBL.GetAllLibri();
        }
    }
}
