using BiblioCore;
using System.Collections.Generic;
using System.ServiceModel;

namespace Biblioteca
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Libro> GetLibri();

        [OperationContract]
        int FaiNiente();
    }
}
