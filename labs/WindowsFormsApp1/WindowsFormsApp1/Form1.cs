using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form, IMainView
    {
        public int prevDeminsion;
        public TextBox[,] firstMatrix;
        private int posX;
        private int posY;
        public TextBox[,] ResultMatrix;
        public TextBox[,] SecondMatrix;
        private Label plusLabel;
       

        public Form1()
        {
            InitializeComponent();

            
           DemenssionTextBox.Enabled = false;
        }

        public int FirstMatrixDimension
        {
            get => int.Parse(DemenssionTextBox.Text);
            set => DemenssionTextBox.Text = value.ToString();
        }

        public bool IsEnabled
        {
            get => DemenssionTextBox.Enabled;
            set => DemenssionTextBox.Enabled = value;
        }

        public event EventHandler<EventArgs> EditMatrix;

        public event EventHandler<EventArgs> CreateTwoMatrix;
        public event EventHandler<EventArgs> AddTwoMatrix;

        public void Delete(ref int prev)
        {
           
            for (var i = 0; i < prev; i++)
            {
                for (var j = 0; j < prev; j++)
                {
                    if (firstMatrix == null || ResultMatrix == null || SecondMatrix == null || plusLabel == null) continue;
                    this.Controls.Remove(ResultMatrix[i,j]);
                    this.Controls.Remove(SecondMatrix[i,j]);
                    this.Controls.Remove(firstMatrix[i,j]);
                    this.Controls.Remove(plusLabel);
                    ResultMatrix[i, j].Dispose();
                    plusLabel.Dispose();
                    firstMatrix[i, j].Dispose();
                    SecondMatrix[i, j].Dispose();
                   
                }
            }
            firstMatrix = null;
            ResultMatrix = null;
            SecondMatrix = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var p = new FormPresenter(this);
            prevDeminsion = FirstMatrixDimension;
           EditButton.Click += EditButton_Click;
            AddTwoMatrixButton.Click += AddTwoMatrixButton_Click;
            CreateTwoMatrixButton.Click += CreateTwoMatrixButton_Click;
        }


        public void CreateFirstMatrix()
        {
            posX = 379;
            posY = 24;
            firstMatrix = new TextBox[FirstMatrixDimension, FirstMatrixDimension];
            Draw(ref posX, ref posY, firstMatrix, "+");
        }

        public void CreateSecondMatrix()
        {
            SecondMatrix = new TextBox[FirstMatrixDimension, FirstMatrixDimension];

            Draw(ref posX, ref posY, SecondMatrix, "=");
        }

        public void CreateResultMatrix()
        {
            ResultMatrix = new TextBox[FirstMatrixDimension, FirstMatrixDimension];
            Draw(ref posX, ref posY, ResultMatrix, "");
        }


        private void Draw(ref int posX, ref int posY, TextBox[,] matrixButton, string text)
        {
            var y = posY;
            for (var i = 0; i < FirstMatrixDimension; i++)
            {
                for (var j = 0; j < FirstMatrixDimension; j++)
                {
                    matrixButton[i, j] = new TextBox {Location = new Point(posX, y), Width = 35};
                    Controls.Add(matrixButton[i, j]);
                    y += 20;
                }

                y = posY;
                posX += 35;
            }

            posX += 45;
            plusLabel = new Label
            {
                Text = text, Location = new Point(posX - 20,
                    (matrixButton[0, 0].Location.Y + matrixButton[0, FirstMatrixDimension - 1].Location.Y) / 2),
                Width = 10
            };

            Controls.Add(plusLabel);
        }


        private void EditButton_Click(object sender, EventArgs e)
        {
            EditMatrix?.Invoke(this, new EventArgs());
        }

        private void CreateTwoMatrixButton_Click(object sender, EventArgs e)
        {
            CreateTwoMatrix?.Invoke(this, new EventArgs());
        }

        private void AddTwoMatrixButton_Click(object sender, EventArgs e)
        {
            AddTwoMatrix?.Invoke(this, new EventArgs());
        }
    }
}