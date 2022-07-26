using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegistryTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RootPathChoose.Items.Add("\\HKEY_CLASSES_ROOT");
            RootPathChoose.Items.Add("\\HKEY_CURRENT_USER");
            RootPathChoose.Items.Add("\\HKEY_LOCAL_MACHINE");
            RootPathChoose.Items.Add("\\HKEY_USERS");
            RootPathChoose.Items.Add("\\HKEY_CURRENT_CONFIG");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Global.Before = new NodeTree("7-Zip", "SOFTWARE\\7-Zip");
            Global.Before.Construct();
            //Global.Before.BFS();
            mylabel.Text = "Tracking";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Global.After = new NodeTree("7-Zip", "SOFTWARE\\7-Zip");
            Global.After.Construct();
            //Global.After.BFS();
            mylabel.Text = Global.CheckSame(Global.Before, Global.After) + "";
            foreach (DiffStruct diff in Global.CheckNodeDiff(Global.Before, Global.After))
            {
                if (diff.After)
                    MessageBox.Show("After多的: " + diff.nodetree.getPath());
                else
                    MessageBox.Show("Before多的: " + diff.nodetree.getPath());
            }
        }
        static void PrintKeys(string rkey)
        {
            //Queue<string> queue = new Queue<string>();
            //queue.Enqueue(rkey);
            //BFSTraversal(ref queue);
            
        }
        static void BFSTraversal(ref Queue<string> queue)
        {
            while (queue.Count != 0)
            {
                string Node = queue.Dequeue();
                MessageBox.Show(Node);
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(Node); ;
                string[] names = rk.GetSubKeyNames();
                foreach (string s in names)
                {
                    queue.Enqueue(Node + "\\" + s);
                }
            }
        }

        private void AddPathBtn_Click(object sender, EventArgs e)
        {
            if(RootPathChoose.SelectedIndex == -1)
            {
                MessageBox.Show("Please select root path.");
                return;
            }
            string tmp = (PathBox.Text[0] != '\\' ? "\\" : "") + PathBox.Text;
            TrackedPathBox.Items.Add(RootPathChoose.Text + tmp);
        }

        private void DeletePathBtn_Click(object sender, EventArgs e)
        {
            bool continueflag = true;
            while(continueflag)
            {
                continueflag = false;
                for (int i = 0; i < TrackedPathBox.Items.Count; i++)
                {
                    if (TrackedPathBox.GetItemChecked(i))
                    {
                        continueflag = true;
                        TrackedPathBox.Items.RemoveAt(i);
                        break;
                    }
                }
            }
            
        }

        private void SelectAllBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < TrackedPathBox.Items.Count; i++)
                TrackedPathBox.SetItemChecked(i, true);
        }

        private void PathBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddPathBtn_Click(this, new EventArgs());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
