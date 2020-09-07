using System.Collections.Generic;

namespace Model
{
    public class RecordBook: Entity<int>
    {
        public int NumberOfRecordBook { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Group GroupId { get; set; }
        public Group Group { get; set; }
            
        
        public int Course { get; set; }
    }
}
