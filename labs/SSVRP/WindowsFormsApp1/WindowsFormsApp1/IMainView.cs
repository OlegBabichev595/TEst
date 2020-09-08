using System;
using System.Collections.Generic;
using Model;

namespace WindowsFormsApp1
{
    public interface IMainView
    {
        public List<RecordBook> ListRecordView { get; set; }
        public List<Group> ListGroupView { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Course { get; set; }
        public int NumberOfRecordBook { get; set; }

        public void LockGUIElemnt();
        public void UnLockGUIElemnt();


        public void ShowMessage(string message);
        public event EventHandler<SelectedItem> DeleteRecordBook;
        public event EventHandler AddRecordBook;
        public event EventHandler<SelectedItem> ApplyRecordBook;
        public event EventHandler<SelectedEvent> SelectedForGroups;
        public event EventHandler<SelectedItem> SelectedForRecordBooks;


    }
}