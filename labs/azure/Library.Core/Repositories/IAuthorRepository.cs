using System;
using Library.Core.Entities;

namespace Library.Core.Repositories
{
    public interface IAuthorRepository : IRepository<Author, Guid>
    {
    }
}