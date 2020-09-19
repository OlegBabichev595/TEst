using System.Collections.Generic;
using System.Linq;
using Model;
using Model.Repositories;

namespace Configuration.Repositories
{
    public class GroupRepository:IGroupRepository
    {

        private readonly RecordBookContext _context;

        public GroupRepository(RecordBookContext context)
        {
            _context = context;
        }

        public Group Get(int id)
        {
            return _context.Groups.Select(x => x).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Group> GetAll()
        {
            return _context.Groups.Select(x => x);
        }
    }
}