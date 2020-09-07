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


        //private IQueryable<RecordBook> MakeInclusions() => _context.RecordBooks.Select(x=>x);



        public RecordBook Get(int id) =>  new RecordBook();


        public IEnumerable<RecordBook> GetAll() =>
            _context.RecordBooks.Select(x => x).ToList();
    }
}