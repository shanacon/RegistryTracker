using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistryTracker
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
            InitialResult();
        }
        private void InitialResult()
        {
            ResultListView.View = View.Details;
            ResultListView.GridLines = true;
            ResultListView.LabelEdit = false;
            ResultListView.Columns.Add("Path", 500);
            ResultListView.Columns.Add("added, deleted or modify", 500);
        }
        public void AddResult(string path, bool added)
        {
            var item = new ListViewItem(path);
            item.SubItems.Add(added ? "added" : "delete");
            ResultListView.Items.Add(item);
        }
    }
}
