using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Configuration;
using Model;

namespace WindowsFormsApp1
{
    public partial class Main : Form, IMainView
    {
        private MainPresenter _mainPresenter;

        public Main()
        {
            InitializeComponent();
            LockGUIElemnt();
            EditButton.Click += EditButton_Click;
            ApplyButton.Click += ApplyButton_Click;
            DeleteButton.Click += DeleteButton_Click;
            AddButton.Click += AddButton_Click;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddRecordBook?.Invoke(this,new EventArgs());
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
           DeleteRecordBook?.Invoke(this,new SelectedItem(listBox2.SelectedItem as RecordBook));
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            LockGUIElemnt();
            ApplyRecordBook?.Invoke(this, new SelectedItem(listBox2.SelectedItem as RecordBook));
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            UnLockGUIElemnt();
        }

        public List<RecordBook> ListRecordView
        {
            get => (List<RecordBook>) listBox2.DataSource;
            set => listBox2.DataSource = value;
        }

        public List<Group> ListGroupView
        {
            get => (List<Group>) listBox1.DataSource;
            set => listBox1.DataSource = value;
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


        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public event EventHandler<SelectedItem> DeleteRecordBook;
        public event EventHandler AddRecordBook;
      
        public event EventHandler<SelectedItem> ApplyRecordBook;


        public event EventHandler<SelectedEvent> SelectedForGroups;
        public event EventHandler<SelectedItem> SelectedForRecordBooks;


        private void Form1_Load(object sender, EventArgs e)
        {
            _mainPresenter = new MainPresenter(new UnitOfWork(), this);
            _mainPresenter.GetAllGroup();
            listBox1.SelectedIndexChanged += GroupListBox_SelectedIndexChanged;
            listBox2.SelectedIndexChanged += ListBox2_SelectedIndexChanged;
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedForRecordBooks?.Invoke(this, new SelectedItem(listBox2.SelectedItem as RecordBook));
        }


        private void GroupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedForGroups?.Invoke(this, new SelectedEvent(listBox1.SelectedIndex + 1));
        }




        public void LockGUIElemnt()
        {
            FirstNameTextBox.Enabled = false;
            LastNameTextBox.Enabled = false;
            CourseTextBox.Enabled = false;
            NumberOfGroupTextBox.Enabled = false;
        }

        public void UnLockGUIElemnt()
        {
            FirstNameTextBox.Enabled = true;
            LastNameTextBox.Enabled = true;
            CourseTextBox.Enabled = true;
            NumberOfGroupTextBox.Enabled = true;
        }
    }
}