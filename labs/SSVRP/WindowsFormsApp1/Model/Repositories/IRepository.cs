using System.Collections.Generic;

namespace Model.Repositories
{
    public interface IRepository<out TEntity, in TKey> where TEntity : Entity<TKey>
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
    }
}   