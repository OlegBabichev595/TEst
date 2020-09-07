using System;
using Configuration.Repositories;
using Model.Repositories;

namespace Configuration
{
    public class UnitOfWork: IUnitOfWork
    {
        private RecordBookContext _context;
        private IRecordBookRepository _recordBookRepository;

        private RecordBookContext Context => _context ??= new RecordBookContext();

        public IRecordBookRepository UserRepository => _recordBookRepository ??= new RecordBookRepository(Context);
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