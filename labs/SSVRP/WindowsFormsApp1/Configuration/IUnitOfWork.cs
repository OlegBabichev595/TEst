using System;
using Model.Repositories;

namespace Configuration
{
    public interface IUnitOfWork : IDisposable
    {
        IRecordBookRepository RecordBookRepository { get; }
        IGroupRepository GroupRepository { get; }

        void Commit();
    }
}