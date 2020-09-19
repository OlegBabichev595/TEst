using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Configuration;

namespace WindowsFormsApp1
{
    public partial class RecordBookAddWindow : Form,IAddRecordBookWindowView
    {
        public RecordBookAddWindow()
        {
            InitializeComponent();
        }

        private void RecordBookAddWindow_Load(object sender, EventArgs e)
        {
            var addPresenter = new AddRecordBookPresenter(new UnitOfWork(),this);
            AddButton.Click += AddButton_Click;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddRecordBook?.Invoke(this, new EventArgs());
        }

        public event EventHandler AddRecordBook;
        public string FirstName
        {
            get => FirstNameBox.Text;
            set => FirstNameBox.Text = value;
        }

        public string LastName
        {
            get => LastNameBox.Text;
            set => LastNameBox.Text = value;
        }

        public int Course
        {
            get => int.Parse(CourseBox.Text);
            set => CourseBox.Text = value.ToString();
        }

        public int NumberOfRecordBook
        {
            get => int.Parse(NumberOfRecordBox.Text);
            set => NumberOfRecordBox.Text = value.ToString();
        }

        public int Group
        {
            get => int.Parse(GroupBox.Text);
            set => GroupBox.Text = value.ToString();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
        }
    }
}
