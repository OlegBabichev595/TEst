using Configuration;
using Model;

namespace WindowsFormsApp1
{
    public class AddRecordBookPresenter
    {
        private IAddRecordBookWindowView _iAddRecordBookWindowView;
        private IUnitOfWork _imUnitOfWork;

        public AddRecordBookPresenter(IUnitOfWork imUnitOfWork, IAddRecordBookWindowView iAddRecordBookWindowView)
        {
            _imUnitOfWork = imUnitOfWork;
            _iAddRecordBookWindowView = iAddRecordBookWindowView;
            _iAddRecordBookWindowView.AddRecordBook += _iAddRecordBookWindowView_AddRecordBook;
        }

        private void _iAddRecordBookWindowView_AddRecordBook(object sender, System.EventArgs e)
        {
            var recordForAdd = new RecordBook()
            {
                FirstName =  _iAddRecordBookWindowView.FirstName,
                LastName =  _iAddRecordBookWindowView.LastName,
                GroupId =  _iAddRecordBookWindowView.Group,
                Course =  _iAddRecordBookWindowView.Course,
                NumberOfRecordBook = _iAddRecordBookWindowView.NumberOfRecordBook
            };
            _imUnitOfWork.RecordBookRepository.Add(recordForAdd);
            _imUnitOfWork.Commit();
            ((RecordBookAddWindow)sender).Close();


        }
    }
}