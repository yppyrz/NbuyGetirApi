using NbuyGetir.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Repositories
{
    /// <summary>
    /// Kayıt işlemlerinden sorumlu olacak
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IWriteOnlyRepository<TEntity> where TEntity : IAggregateRoot
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(string key);
        void Save();

    }
}
