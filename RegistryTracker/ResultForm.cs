using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace RegistryTracker
{
    public partial class ResultForm : Form
    {
        public ResultForm(bool NoAccessForm = false)
        {
            InitializeComponent();
            if (!NoAccessForm)
                InitialResult();
            else
                InitialNoAccess();
        }
        private void InitialResult()
        {
            ResultListView.View = View.Details;
            ResultListView.GridLines = true;
            ResultListView.LabelEdit = false;
            ResultListView.AllowColumnReorder = true;
            ResultListView.Columns.Add("Path", 200);
            ResultListView.Columns.Add("added, deleted or modify", 150);
            ResultListView.Columns.Add("Value", 50);
            ResultListView.Columns.Add("Start Value", 120);
            ResultListView.Columns.Add("End Value", 120);
            ColumnSorter = new ListViewColumnSorter();
            ResultListView.ListViewItemSorter = ColumnSorter;
        }
        private void InitialNoAccess()
        {
            ResultListView.View = View.Details;
            ResultListView.GridLines = true;
            ResultListView.LabelEdit = false;
            ResultListView.AllowColumnReorder = true;
            ResultListView.Columns.Add("Path", 300);
            ResultListView.Columns.Add("root", 300);
            ColumnSorter = new ListViewColumnSorter();
            ResultListView.ListViewItemSorter = ColumnSorter;
        }
        public void AddResult(string path, bool? added,string Value, string startvalue, string endvalue)
        {
            ListViewItem item = new ListViewItem(path);
            if (added == null)
                item.SubItems.Add("modify");
            else if (added == true)
                item.SubItems.Add("added");
            else if(added == false)
                item.SubItems.Add("delete");
            item.SubItems.Add(Value);
            item.SubItems.Add(startvalue);
            item.SubItems.Add(endvalue);
            ResultListView.Items.Add(item);
        }
        public void AddNoAccess(string path, string root)
        {
            ListViewItem item = new ListViewItem(path);
            item.SubItems.Add(root);
            ResultListView.Items.Add(item);
        }
        private void ResultListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == ColumnSorter.SortColumn)
            {
                if (ColumnSorter.Order == SortOrder.Ascending)
                {
                    ColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    ColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                ColumnSorter.SortColumn = e.Column;
                ColumnSorter.Order = SortOrder.Ascending;
            }
            // Perform the sort with these new sort options.
            ResultListView.Sort();
        }
        private ListViewColumnSorter ColumnSorter;
    }
    public class ListViewColumnSorter : IComparer
    {
        /// Specifies the column to be sorted
        private int ColumnToSort;

        /// Specifies the order in which to sort (i.e. 'Ascending').
        private SortOrder OrderOfSort;

        /// Case insensitive comparer object
        private CaseInsensitiveComparer ObjectCompare;

        /// Class constructor. Initializes various elements
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;
            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;
            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface. It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
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

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }
}
