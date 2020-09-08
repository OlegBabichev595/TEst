using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Repositories;

namespace Configuration.Repositories
{
    public class RecordBookRepository : IRecordBookRepository
    {
        private readonly RecordBookContext _context;

        public RecordBookRepository(RecordBookContext context)
        {
            _context = context;
        }


        public RecordBook Get(int id)
        {
            return _context.RecordBooks.Select(x => x).Include(x => x.Group).FirstOrDefault(x => x.Id == id);
        }


        public IEnumerable<RecordBook> GetAll()
        {
            return _context.RecordBooks.Select(x => x).Include(x => x.Group).ToList();
        }
    }
}