using BiblioCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
