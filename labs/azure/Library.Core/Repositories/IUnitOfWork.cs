using System;

namespace Library.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        IPublisherRepository PublisherRepository { get; }

        void Commit();
    }
}