﻿using NbuyGetir.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Entities
{
    public interface IEntity
    {
        public interface IEntity
        {
            IReadOnlyList<IDomainEvent> DomainEvents { get; }
        }
    }
}
