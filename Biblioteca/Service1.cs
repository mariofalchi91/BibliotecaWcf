using BiblioCore;
using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Biblioteca
{
    public class Service1 : IService1
    {
        public IMainBL mainBL;
        public Service1()
        {
            DependencyContainer.Register<IMainBL, MainBL>();
            DependencyContainer.Register<ILibroRepository, EFBiblioRepo>();
            mainBL = DependencyContainer.Resolve<IMainBL>();

        }
        public int FaiNiente()
        {
            throw new NotImplementedException();
        }

        public string GetData(int value)
        {
            throw new NotImplementedException();
        }

        public List<Libro> GetLibri()
        {
            return mainBL.GetAllLibri();
        }
    }
}
