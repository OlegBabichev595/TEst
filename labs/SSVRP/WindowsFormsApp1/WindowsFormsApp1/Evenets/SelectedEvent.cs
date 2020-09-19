using System;

namespace WindowsFormsApp1
{
    public class SelectedEvent : EventArgs
    {
        public SelectedEvent(int index)
        {
            Index = index;
        }

        public int Index { get; }
    }
}