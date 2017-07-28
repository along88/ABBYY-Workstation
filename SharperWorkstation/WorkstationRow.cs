using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace SharperWorkstation
{
    public class WorkstationRow
    {
        private List<string> dataRow;

        public WorkstationRow()
        {
            dataRow = new List<string>();
        }

        /// <summary>
        /// Wrapper for List.Add(). Adds the content of the cell to the column.
        /// </summary>
        /// <param name="value">The cell content as a string</param>
        public void Add(string value)
        {
            dataRow.Add(value);
        }

        /// <summary>
        /// Wrapper for List.Remove(). Removes a piece of content from the column.
        /// </summary>
        /// <param name="value">The content to remove from the column as a string</param>
        public void Remove(string value)
        {
            dataRow.Remove(value);
        }

        /// <summary>
        /// Wrapper for List.RemoveAt(). Removes a piece of content from the column.
        /// </summary>
        /// <param name="index">The content to remove from the column at a specified index</param>
        public void RemoveFromColumn(int index)
        {
            dataRow.RemoveAt(index);
        }

        /// <summary>
        /// Replace the value at the specified index with another
        /// </summary>
        /// <param name="index">The numerical position where the replacement should occur in the list</param>
        /// <param name="value">The value to provide as replacement</param>
        public void Replace(int index, string value)
        {
            dataRow[index] = value;
        }

        /// <summary>
        /// Wrapper for List.Count. Returns the number of items in the column.
        /// </summary>
        /// <returns>The number of items in the column as an integer</returns>
        public int Length()
        {
            return dataRow.Count;
        }

        /// <summary>
        /// Wrapper for index-based access of List. Returns the item at the specified index.
        /// </summary>
        /// <param name="index">Location to access as an integer</param>
        /// <returns>The data at the specified index</returns>
        public string DataAtIndex(int index)
        {
            return dataRow[index];
        }
    }
}
