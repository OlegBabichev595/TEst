using System;
using System.Windows.Forms;
using AddMatrix;

namespace WindowsFormsApp1
{
    public class FormPresenter
    {
        private readonly IMainView _iMainView;
        public FormPresenter(IMainView iMainView)
        {
            _iMainView = iMainView;
            _iMainView.EditMatrix += _iMainView_EditMatrix;
            _iMainView.AddTwoMatrix += _iMainView_AddTwoMatrix;
            _iMainView.CreateTwoMatrix += _iMainView_CreateTwoMatrix;
        }

        private void _iMainView_EditMatrix(object sender, EventArgs e)
        {
            _iMainView.IsEnabled = true;
        }

        private void _iMainView_CreateTwoMatrix(object sender, System.EventArgs e)
        {
            var mainForm = sender as Form1;
            mainForm.Delete(ref mainForm.prevDeminsion);
            mainForm.CreateFirstMatrix();
            mainForm.CreateSecondMatrix();
            mainForm.CreateResultMatrix();
            FillMatrix(((Form1) sender).firstMatrix);
            FillMatrix(((Form1) sender).SecondMatrix);
           
            _iMainView.IsEnabled = false;

        }

     

        private void _iMainView_AddTwoMatrix(object sender, System.EventArgs e)
        {
            var mainForm = sender as Form1;
            var result = AddTwoMatrix.AddMatrix(Convert(mainForm.firstMatrix),Convert(mainForm.SecondMatrix));
            FillResult(result);
            void FillResult(int[,] resultMatrix)
            {
                for (var i = 0; i < _iMainView.FirstMatrixDimension; i++)
                {
                    for (var j = 0; j < _iMainView.FirstMatrixDimension; j++)
                    {
                        mainForm.ResultMatrix[i, j].Text = resultMatrix[i, j].ToString();
                    }
                }
            }
        }


        private int[,] Convert(TextBox[,] matrix)
        {
            var convertedMatrixFromText = new int[_iMainView.FirstMatrixDimension, _iMainView.FirstMatrixDimension];
            for (var i = 0; i < _iMainView.FirstMatrixDimension; i++)
            {
                for (var j = 0; j < _iMainView.FirstMatrixDimension; j++)
                {
                    convertedMatrixFromText[i, j] = int.Parse((matrix[i, j].Text));
                }
            }

            return convertedMatrixFromText;
        }


        private void FillMatrix(TextBox[,] matrix)
        {
            var rng = new Random();
            for (int i = 0; i < _iMainView.FirstMatrixDimension; i++)
            {
                for (int j = 0; j < _iMainView.FirstMatrixDimension; j++)
                {
                    matrix[i, j].Text = rng.Next(-1000,1000).ToString();
                }
            }
        }
    }
}