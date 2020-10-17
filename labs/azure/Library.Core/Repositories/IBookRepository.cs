using System;
using Library.Core.Entities;

namespace Library.Core.Repositories
{
    public interface IBookRepository : IRepository<Book, Guid>
    {
    }
}