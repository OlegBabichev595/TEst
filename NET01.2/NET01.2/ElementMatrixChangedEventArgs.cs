using System;

namespace NET01._2
{
    /// <summary>
    ///     Сustom event to determine which item has been changed and in what position
    /// </summary>
    /// <typeparam name="T">any build-in type(string,double,int and so on)</typeparam>
    public class ElementMatrixChangedEventArgs<T> : EventArgs
    {
        /// <summary>
        ///     Constructor for event, set I,J positions and oldValue,newValue
        /// </summary>
        /// <param name="i">I position of matrix</param>
        /// <param name="j">J position of matrix</param>
        /// <param name="oldValue"> Old value before change</param>
        /// <param name="newValue">New value after change</param>
        public ElementMatrixChangedEventArgs(int i, int j, T oldValue, T newValue)
        {
            I = i;
            J = j;
            OldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>
        ///     I position of matrix
        /// </summary>
        public int I { get; }

        /// <summary>
        ///     J position of matrix
        /// </summary>
        public int J { get; }

        /// <summary>
        ///     Old value before change
        /// </summary>
        public T OldValue { get; }

        /// <summary>
        ///     New value after change
        /// </summary>
        public T NewValue { get; }
    }
}