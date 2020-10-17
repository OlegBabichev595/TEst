using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Library.Core.Entities;
using Library.Core.Repositories;

namespace Library.Infrastructure.Repositories
{
    internal sealed class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(LibraryContext context) : base(context)
        {
        }

        public Publisher Find(Guid id) => DbSet.Find(id);

        public IEnumerable<Publisher> List(Expression<Func<Publisher, bool>> predicate = null)
        {
            var query = DbSet.OrderBy(x => x.Name).AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }
    }
}