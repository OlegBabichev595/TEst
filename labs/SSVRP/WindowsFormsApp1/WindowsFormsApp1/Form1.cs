using System.Windows.Forms;
using Configuration;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            IUnitOfWork uow = new UnitOfWork();
            var recordBooks = uow.UserRepository.GetAll();
        }
    }
}
