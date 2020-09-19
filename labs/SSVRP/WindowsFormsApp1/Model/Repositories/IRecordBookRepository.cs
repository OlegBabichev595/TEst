using System.Collections.Generic;

namespace Model.Repositories
{
    public interface IRecordBookRepository : IRepository<RecordBook, int>
    {
        List<RecordBook> GetAllByGroup(int id);
        void Update(RecordBook recordBook);

        void Delete(RecordBook recordBook);

        void Add(RecordBook record);
    }
}