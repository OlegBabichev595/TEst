using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Library.Core.Entities;

namespace Library.Core.Repositories
{
    public interface IRepository<TEntity, in TKey> where TEntity : Entity<TKey>
    {
        TEntity Find(TKey id);
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate = null);
    }
}