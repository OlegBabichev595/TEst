using System;
using Model;

namespace WindowsFormsApp1
{
    public class SelectedItem:EventArgs
    {
        public RecordBook SelectedItemFromList { get; }

        public SelectedItem(RecordBook selectedItemFromList)
        {
            SelectedItemFromList = selectedItemFromList;
        }
    }
}