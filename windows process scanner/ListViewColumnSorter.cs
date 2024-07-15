using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace windows_process_scanner
{
    // Implements a comparer for ListView items to enable custom sorting.
    public class ListViewColumnSorter : IComparer
    {
        // Property to get or set the number of the column to which to apply the sorting operation
        public int SortColumn { get; set; }
        // Property to get or set the order of sorting to apply (e.g., 'Ascending' or 'Descending').
        public SortOrder Order { get; set; }

        // Default constructor initializes a new instance of the ListViewColumnSorter class.
        public ListViewColumnSorter()
        {
            SortColumn = 0;
            Order = SortOrder.None;
        }

        // Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        public int Compare(object x, object y)
        {

            ListViewItem listViewX, listViewY;

            // Cast the objects to be compared to ListViewItem objects
            listViewX = (ListViewItem)x;
            listViewY = (ListViewItem)y;

            // If highlighting is enabled
            if (Form1.isHighlightingEnabled)
            {
                // Define the custom order of colors
                List<Color> colorOrder = new List<Color> { Color.LightPink, Color.LightGreen, Color.LightYellow, Color.LightSalmon };

                // Get the index of the colors in the custom order
                int colorIndexX = colorOrder.IndexOf(listViewX.BackColor);
                int colorIndexY = colorOrder.IndexOf(listViewY.BackColor);

                // Compare the two items based on the custom order of the colors
                return colorIndexX.CompareTo(colorIndexY);
            }
            else
            {
                // Compare the two items
                int compareResult = String.Compare(listViewX.SubItems[SortColumn].Text, listViewY.SubItems[SortColumn].Text);

                // Calculate correct return value based on object comparison
                if (Order == SortOrder.Ascending)
                {
                    // Ascending sort is selected, return normal result of compare operation
                    return compareResult;
                }
                else if (Order == SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of compare operation
                    return (-compareResult);
                }
                else
                {
                    // Return '0' to indicate they are equal
                    return 0;
                }
            }
        }
    }
}