using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Library.Core.Entities;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    internal sealed class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }

        public Book Find(Guid id) => MakeInclusions().SingleOrDefault(x => x.Id == id);

        public IEnumerable<Book> List(Expression<Func<Book, bool>> predicate = null)
        {
            var query = MakeInclusions().OrderBy(x => x.Title).AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }

        private IQueryable<Book> MakeInclusions() =>
            DbSet.Include(x => x.BookAuthor).ThenInclude(x => x.Author).Include(x => x.Publisher);
    }
}