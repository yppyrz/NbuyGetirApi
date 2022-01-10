﻿using NbuyGetir.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Repositories
{
    /// <summary>
    /// Sadece okuma işlemleri yapacağız.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDapperRepository<TEntity> : IReadOnylRepository<TEntity> where TEntity : IAggregateRoot
    {

    }
}
