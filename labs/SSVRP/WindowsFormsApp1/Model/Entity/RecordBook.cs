
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


        public override bool Equals(object? obj)
        {
            return Equals(obj as RecordBook);
        }


        public bool Equals(RecordBook obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return FirstName.Length + LastName.Length + NumberOfRecordBook ;
        }

        public override string ToString() =>
            $"Number of Record Book - {NumberOfRecordBook}, " +
                $"Full Name  - {FirstName.Trim()} {LastName.Trim()}, " +
                $"{Group}, " +
                $"Course - {Course}";
     

    }
}
