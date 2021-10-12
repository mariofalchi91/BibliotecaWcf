using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioCore
{
    public interface IRepository<T>
    {
        IEnumerable<T> Fetch(Func<T, bool> filter = null);
        T GetById(int id);
        bool Add(T newItem);
        bool Update(T updateItem);
        bool DeleteById(int id);
    }
}
