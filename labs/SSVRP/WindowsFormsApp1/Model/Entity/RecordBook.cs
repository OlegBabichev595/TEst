using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Model
{
    public class RecordBook: Entity<int>
    {
        public int NumberOfRecordBook { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
            
        
        public int Course { get; set; }


        public override string ToString() =>
            $"Number of Record Book - {NumberOfRecordBook}, " +
                $"First Name - {FirstName.Trim()}, " +
                $"Last Name - {LastName.Trim()}, " +
                $"{Group}, " +
                $"Course - {Course}";
     

    }
}
