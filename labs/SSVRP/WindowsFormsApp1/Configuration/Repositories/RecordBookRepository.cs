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


        private IQueryable<RecordBook> MakeInclusions() => _context.RecordBooks;



        public RecordBook Get(int id) => MakeInclusions().SingleOrDefault(x => x.Id == id);


        public IEnumerable<RecordBook> GetAll() =>
            MakeInclusions().OrderBy(x => x.FirstName).ThenBy(x => x.LastName).AsQueryable();
    }
}