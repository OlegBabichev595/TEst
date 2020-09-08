using System;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public interface IMainView
    {
        public List<string> ListRecordView { get; set; }
        public List<string> ListGroupView { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Course { get; set; }
        public int NumberOfRecordBook { get; set; }


        public event EventHandler DeleteRecordBook;
        public event EventHandler AddRecordBook;
        public event EventHandler EditRecordBook;
        public event EventHandler ApplyRecordBook;
        

    }
}