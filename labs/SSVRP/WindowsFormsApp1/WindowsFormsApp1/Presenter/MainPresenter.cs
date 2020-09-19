using System.Linq;
using Configuration;

namespace WindowsFormsApp1
{
    public class MainPresenter
    {
        private readonly IMainView _iMainView;
        private readonly IUnitOfWork _iUnitOfWork;


        public MainPresenter(IUnitOfWork iUnitOfWork, IMainView iMainView)
        {
            _iUnitOfWork = iUnitOfWork;
            _iMainView = iMainView;
            _iMainView.SelectedForGroups += _iMainView_Selected;
            _iMainView.SelectedForRecordBooks += _iMainView_SelectedForRecordBooks;
            _iMainView.ApplyRecordBook += _iMainView_ApplyRecordBook;
            _iMainView.DeleteRecordBook += _iMainView_DeleteRecordBook;
            _iMainView.AddRecordBook += _iMainView_AddRecordBook;
        }

        private void _iMainView_AddRecordBook(object sender, System.EventArgs e)
        {
           var recordBookAdd = new RecordBookAddWindow();
           recordBookAdd.ShowDialog();
        }

        private void _iMainView_DeleteRecordBook(object sender, SelectedItem e)
        {
            var _recordBookForDelete = _iUnitOfWork.RecordBookRepository.Get(e.SelectedItemFromList.Id);
            if (_recordBookForDelete == null)
            {
                _iMainView.ShowMessage("Can't Find User");
                return;
            }

            _iUnitOfWork.RecordBookRepository.Delete(_recordBookForDelete);
            _iUnitOfWork.Commit();
        }

        private void _iMainView_ApplyRecordBook(object sender, SelectedItem e)
        {
            var _recordBookForChange = _iUnitOfWork.RecordBookRepository.Get(e.SelectedItemFromList.Id);

            if (_recordBookForChange == null)
            {
                _iMainView.ShowMessage("Can't Find User");
                return;
            }


            _recordBookForChange.FirstName = _iMainView.FirstName;
            _recordBookForChange.LastName = _iMainView.LastName;
            _recordBookForChange.Course = _iMainView.Course;
            _recordBookForChange.NumberOfRecordBook = _iMainView.NumberOfRecordBook;
            _iUnitOfWork.RecordBookRepository.Update(_recordBookForChange);
            _iUnitOfWork.Commit();
        }

        private void _iMainView_SelectedForRecordBooks(object sender, SelectedItem e)
        {
            var _recordBookForChange = _iUnitOfWork.RecordBookRepository.Get(e.SelectedItemFromList.Id);

            if (_recordBookForChange == null)
            {
                _iMainView.ShowMessage("Can't Find User");
                return;
            }

            _iMainView.FirstName = _recordBookForChange.FirstName;
            _iMainView.LastName = _recordBookForChange.LastName;
            _iMainView.Course = _recordBookForChange.Course;
            _iMainView.NumberOfRecordBook = _recordBookForChange.NumberOfRecordBook;
            _iMainView.LockGUIElemnt();
        }

        private void _iMainView_Selected(object sender, SelectedEvent e)
        {
            _iMainView.ListRecordView = _iUnitOfWork.RecordBookRepository.GetAllByGroup(e.Index);
        }

        public void GetAllGroup()
        {
            _iMainView.ListGroupView = _iUnitOfWork.GroupRepository.GetAll().ToList();
        }
    }
}