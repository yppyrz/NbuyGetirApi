using NbuyGetir.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Repositories
{
    // ISP => Interface Seggreagation.

    /// <summary>
    /// EF yi hem read hem de write işlemleri için kullanacağız.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IEFRepository<TEntity> : IReadOnylRepository<TEntity>,IWriteOnlyRepository<TEntity> where TEntity: IAggregateRoot
    {
       
    }
}
