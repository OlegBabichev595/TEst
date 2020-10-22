using System;
using Library.Core.Repositories;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Library.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextOptions<LibraryContext> _options;
        private LibraryContext _context;
        private IAuthorRepository _authorRepository;
        private IBookRepository _bookRepository;
        private IPublisherRepository _publisherRepository;

        private LibraryContext Context => _context ??= new LibraryContext(_options);

        public IAuthorRepository AuthorRepository => _authorRepository ??= new AuthorRepository(Context);
        public IBookRepository BookRepository => _bookRepository ??= new BookRepository(Context);
        public IPublisherRepository PublisherRepository => _publisherRepository ??= new PublisherRepository(Context);

        public UnitOfWork(IOptions<UnitOfWorkOptions> optionsAccessor) : this(optionsAccessor.Value)
        {
        }

        public UnitOfWork(UnitOfWorkOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            optionsBuilder.UseSqlServer(options.ConnectionString, x => x.CommandTimeout(options.CommandTimeout));
            _options = optionsBuilder.Options;
        }

        public void Commit()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("UnitOfWork");
            }

            Context.SaveChanges();
        }

        private bool _isDisposed;

        public void Dispose()
        {
            if (_context == null)
            {
                return;
            }

            if (!_isDisposed)
            {
                Context.Dispose();
            }

            _isDisposed = true;
        }
    }
}