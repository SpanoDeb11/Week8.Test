using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week8.Esercitazione.Core.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> Fetch(Func<T, bool> filter);
        T GetById(int id);
        bool Add(T entity);
        bool Delete(int id);
        bool Update(T entity);
    }
}
