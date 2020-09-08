using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Configuration;

namespace WindowsFormsApp1
{
    public partial class Main : Form,IMainView
    {

        private MainPresenter _mainPresenter;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            _mainPresenter = new MainPresenter(new UnitOfWork(), this);
            _mainPresenter.GetAllGroup();


        }

        public List<string> ListRecordView
        {
            get => (List<string>) RecordBookList.DataSource;
            set => RecordBookList.DataSource = value;
        }

        public List<string> ListGroupView
        {
            get => (List<string>)GroupListBox.DataSource;
            set => GroupListBox.DataSource = value;
        }

        public string FirstName
        {
            get => FirstNameTextBox.Text;
            set => FirstNameTextBox.Text = value;
        }

        public string LastName
        {
            get => LastNameTextBox.Text;
            set => LastNameTextBox.Text = value;
        }

        public int Course
        {
            get => int.Parse(CourseTextBox.Text);
            set => CourseTextBox.Text = value.ToString();
        }

        public int NumberOfRecordBook
        {
            get => int.Parse(NumberOfGroupTextBox.Text);
            set => NumberOfGroupTextBox.Text = value.ToString();
        }


        public event EventHandler DeleteRecordBook;
        public event EventHandler AddRecordBook;
        public event EventHandler EditRecordBook;
        public event EventHandler ApplyRecordBook;
    }
}
