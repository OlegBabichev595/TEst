using System;

namespace NET01._2
{
    /// <summary>
    ///     Represent common event for matrix track
    /// </summary>
    /// <typeparam name="T">any build-in type(string,double,int and so on)</typeparam>
    public interface IElementMatrixChangedEventArgs<T>
    {
        event EventHandler<ElementMatrixChangedEventArgs<T>> ElementChanged;
    }
}