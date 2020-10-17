using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    internal abstract class Repository<TEntity> where TEntity : Entity
    {
        protected readonly LibraryContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(LibraryContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }
    }
}