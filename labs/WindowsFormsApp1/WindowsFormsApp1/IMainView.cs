using System;

namespace WindowsFormsApp1
{
    public interface IMainView
    {
        int FirstMatrixDimension { get; set; }
        bool IsEnabled { get; set; }


        event EventHandler<EventArgs> EditMatrix;
        event EventHandler<EventArgs> CreateTwoMatrix;
        event EventHandler<EventArgs> AddTwoMatrix;
      

    }
}