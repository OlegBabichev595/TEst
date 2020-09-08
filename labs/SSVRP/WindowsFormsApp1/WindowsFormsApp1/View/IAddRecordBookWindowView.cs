using System;

namespace WindowsFormsApp1
{
    public interface IAddRecordBookWindowView
    {
        public event EventHandler AddRecordBook;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Course { get; set; }
        public int NumberOfRecordBook { get; set; }
        public int Group { get; set; }
        public void ShowMessage(string message);
    }
}