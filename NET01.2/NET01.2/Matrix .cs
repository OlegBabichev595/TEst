using System;

namespace NET01._2
{
    namespace Matrix
    {
        namespace DiagonalMatrix
        {
            /// <summary>
            ///     The <c>DiagonalMatrix</c> class represents work with a two-dimensional matrix
            /// </summary>
            /// <typeparam name="T">any build-in type(string,double,int and so on)</typeparam>
            public class DiagonalMatrix<T> : IElementMatrixChangedEventArgs<T>
            {
                /// <summary>
                ///     represent diagonal of matrix
                /// </summary>
                private readonly T[] _data;

                /// <summary>
                ///     Save size of _data param/>
                /// </summary>
                private int _size;

                /// <summary>
                ///     Constructor of class
                /// </summary>
                /// <param name="size">Size of matrix</param>
                /// <param name="data">Diagonal Elements</param>
                /// <exception cref="ArgumentOutOfRangeException">Throws when <paramref name="size" /> != data.Length </exception>
                /// <exception cref="NullReferenceException">Throws when <paramref name="data" /> is null </exception>
                public DiagonalMatrix(int size, params T[] data)
                {
                    Size = size;
                    if (Size != data.Length)
                    {
                        throw new ArgumentOutOfRangeException("size shoulde be = data.length");
                    }

                    if (data == null)
                    {
                        throw new NullReferenceException(nameof(data));
                    }

                    _data = new T[data.Length];
                    data.CopyTo(_data, 0);
                }

                /// <summary>
                ///     <value>Get Size of <see cref="_data" /></value>
                ///     <exception cref="ArgumentOutOfRangeException">Throws when Size less then 0</exception>
                /// </summary>
                public int Size
                {
                    get => _size;
                    set
                    {
                        if (value < 0)
                        {
                            throw new ArgumentOutOfRangeException("Size can't be < 0");
                        }

                        _size = value;
                    }
                }

                /// <summary>
                ///     <exception>
                ///         <see cref="CheckIndexes" />
                ///     </exception>
                /// </summary>
                /// <param name="i">i position of matrix</param>
                /// <param name="j">j position of matrix</param>
                /// <returns>return T value</returns>
                public T this[int i, int j]
                {
                    get
                    {
                        CheckIndexes(i, j);
                        return i == j ? _data[i] : default;
                    }
                    set
                    {
                        CheckIndexes(i, j);
                        if (i != j)
                        {
                            return;
                        }

                        var oldValue = _data[i];
                        if (!Equals(oldValue, value))
                        {
                            _data[i] = value;
                            OnElementChanged(new ElementMatrixChangedEventArgs<T>(i, j, oldValue, value));
                        }
                    }
                }

                /// <summary>
                ///     Event for tracking for change element
                ///     <example>
                ///         <code>
                ///  dm.ElementChanged += (s, e) =>
                /// {
                ///     Console.WriteLine($"OldValue {e.OldValue}, New value = {e.NewValue}, position [i,j] = {e.I},{e.J} ");
                /// };
                ///   dm[0, 0] = 0;
                /// </code>
                ///     </example>
                /// </summary>
                public event EventHandler<ElementMatrixChangedEventArgs<T>> ElementChanged;

                /// <summary>
                ///     Checking indexes for valid range
                ///     <exception cref="IndexOutOfRangeException">Throws when i or j do not fit into the range</exception>
                /// </summary>
                /// <param name="i">i position of matrix</param>
                /// <param name="j">j position of matrix</param>
                private void CheckIndexes(int i, int j)
                {
                    if (i < 0 || i >= Size)
                    {
                        throw new IndexOutOfRangeException(nameof(i));
                    }

                    if (j < 0 || j >= Size)
                    {
                        throw new IndexOutOfRangeException(nameof(j));
                    }
                }

                /// <summary>
                ///     Invoke this method when element is changed
                /// </summary>
                /// <param name="value">Object of Event to track change</param>
                protected void OnElementChanged(ElementMatrixChangedEventArgs<T> value)
                {
                    ElementChanged?.Invoke(this, value);
                }
            }
        }


        namespace SquareMatrix
        {
            public class SquareMatrix<T> : IElementMatrixChangedEventArgs<T>
            {
                /// <summary>
                ///     represent diagonal of square matrix
                /// </summary>
                private readonly T[,] _data;

                /// <summary>
                ///     Save size of _data param/>
                /// </summary>
                private int _size;

                /// <summary>
                ///     Constructor of class
                /// </summary>
                /// <param name="size">Size of matrix</param>
                /// <param name="data">Diagonal Elements</param>
                /// <exception cref="ArgumentOutOfRangeException">Throws when <paramref name="size" /> != data.Length </exception>
                /// <exception cref="NullReferenceException">Throws when <paramref name="data" /> is null </exception>
                /// <exception cref="ArgumentException">Throws when <paramref name="data" />data.GetLength(0) != data.GetLength(1) </exception>
                public SquareMatrix(int size, T[,] data)
                {
                    Size = size;

                    if (data.GetLength(0) != data.GetLength(1))
                    {
                        throw new ArgumentException("Rows count should be equal Cells count");
                    }

                    if (Size != data.GetLength(0))
                    {
                        throw new ArgumentOutOfRangeException("size shoulde be = data.length");
                    }

                    if (data == null)
                    {
                        throw new NullReferenceException(nameof(data));
                    }

                    _data = data.Clone() as T[,];
                }

                /// <summary>
                ///     <value>Get Size of <see cref="_data" /></value>
                ///     <exception cref="ArgumentOutOfRangeException">Throws when Size less then 0</exception>
                /// </summary>
                public int Size
                {
                    get => _size;
                    set
                    {
                        if (value < 0)
                        {
                            throw new ArgumentOutOfRangeException("Size can't be < 0");
                        }

                        _size = value;
                    }
                }

                /// <summary>
                ///     <exception>
                ///         <see cref="CheckIndexes" />
                ///     </exception>
                /// </summary>
                /// <param name="i">i position of matrix</param>
                /// <param name="j">j position of matrix</param>
                /// <returns>return T value</returns>
                public T this[int i, int j]
                {
                    get
                    {
                        CheckIndexes(i, j);
                        return _data[i, j];
                    }
                    set
                    {
                        CheckIndexes(i, j);
                        var oldValue = _data[i, j];
                        if (!Equals(oldValue, value))
                        {
                            _data[i, j] = value;
                            OnElementChanged(new ElementMatrixChangedEventArgs<T>(i, j, oldValue, value));
                        }

                        _data[i, j] = value;
                    }
                }

                /// <summary>
                ///     Event for tracking for change element
                ///     <example>
                ///         <code>
                ///  dm.ElementChanged += (s, e) =>
                /// {
                ///     Console.WriteLine($"OldValue {e.OldValue}, New value = {e.NewValue}, position [i,j] = {e.I},{e.J} ");
                /// };
                ///   dm[0, 0] = 0;
                /// </code>
                ///     </example>
                /// </summary>
                public event EventHandler<ElementMatrixChangedEventArgs<T>> ElementChanged;

                /// <summary>
                ///     Checking indexes for valid range
                ///     <exception cref="IndexOutOfRangeException">Throws when i or j do not fit into the range</exception>
                /// </summary>
                /// <param name="i">i position of matrix</param>
                /// <param name="j">j position of matrix</param>
                private void CheckIndexes(int i, int j)
                {
                    if (i < 0 || i >= Size)
                    {
                        throw new IndexOutOfRangeException(nameof(i));
                    }

                    if (j < 0 || j >= Size)
                    {
                        throw new IndexOutOfRangeException(nameof(j));
                    }
                }

                /// <summary>
                ///     Invoke this method when element is changed
                /// </summary>
                /// <param name="value">Object of Event to track change</param>
                protected void OnElementChanged(ElementMatrixChangedEventArgs<T> value)
                {
                    ElementChanged?.Invoke(this, value);
                }
            }
        }
    }
}