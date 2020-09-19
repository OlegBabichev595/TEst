using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Repositories;

namespace Configuration.Repositories
{
    public class RecordBookRepository:IRecordBookRepository
    {
        private readonly RecordBookContext _context;

        public RecordBookRepository(RecordBookContext context)
        {
            _context = context;
        }

        public RecordBook Get(int id) =>  _context.RecordBooks.Select(x => x).Include(x=>x.Group).FirstOrDefault(x => x.Id == id);

        public void Update(RecordBook recordBook)
        {
            _context.RecordBooks.Update(recordBook);
            
        }

        public void Add(RecordBook record)
        {
            _context.RecordBooks.Add(record);
        }

        public void Delete(RecordBook recordBook)
        {
            _context.RecordBooks.Remove(recordBook);
        }

        public IEnumerable<RecordBook> GetAll() =>
            _context.RecordBooks.Select(x => x).Include(x => x.Group).ToList();

        public List<RecordBook> GetAllByGroup(int id)
        {
            return _context.RecordBooks.Select(x => x).Where(x => x.GroupId == id).Include(x => x.Group).ToList();
        }
    }
}