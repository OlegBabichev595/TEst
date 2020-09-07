using System;
using Model.Repositories;

namespace Configuration
{
    public interface IUnitOfWork : IDisposable
    {
        IRecordBookRepository UserRepository { get; }

        void Commit();
    }
}