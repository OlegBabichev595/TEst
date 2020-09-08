using System.Collections.Generic;

namespace Model
{
    public class Group:Entity<int>
    {
        public int Number { get; set; }


        public ICollection<RecordBook> ListRecordBooks { get; set; }


        public Group()
        {
            ListRecordBooks = new HashSet<RecordBook>();
        }


        public override string ToString()
        {
            return $" Number of Group - {Number}";
        }
    }
}