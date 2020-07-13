using System;
using NET01._2.Matrix.DiagonalMatrix;
using NET01._2.Matrix.SquareMatrix;

namespace NET01._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var twoDMatrix = new int[,]
            {
                {0,0},
                {1,20}
            };
            var dm = new SquareMatrix<int>(2, twoDMatrix);
            dm.ElementChanged += delegate { Console.WriteLine("Changed"); };
            dm.ElementChanged += Dm_ElementChanged;
            dm.ElementChanged += (s, e) =>
            {
                Console.WriteLine($"OldValue {e.OldValue}, New value = {e.NewValue}, position [i,j] = {e.I},{e.J} ");
            };
            dm[0, 2] = 0;
            dm[1, 1] = 0;

        }

        private static void Dm_ElementChanged(object sender, ElementMatrixChangedEventArgs<int> e)
        {
            Console.WriteLine($"OldValue {e.OldValue}, New value = {e.NewValue}, position [i,j] = {e.I},{e.J} ");
        }
    }
}
