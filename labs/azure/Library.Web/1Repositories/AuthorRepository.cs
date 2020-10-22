using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Library.Core.Entities;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    internal sealed class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext context) : base(context)
        {
        }

        public Author Find(Guid id) => MakeInclusions().SingleOrDefault(x => x.Id == id);

        public IEnumerable<Author> List(Expression<Func<Author, bool>> predicate = null)
        {
            var query = MakeInclusions().OrderBy(x => x.FirstName).ThenBy(x => x.LastName).AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }

        private IQueryable<Author> MakeInclusions() => DbSet.Include(x => x.BookAuthor).ThenInclude(x => x.Book);
    }
}