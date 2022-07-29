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
    public partial class MainForm : Form
    {
        private ResultForm resultForm;
        public MainForm()
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
            /*Global.Before = new NodeTree("7-Zip", "SOFTWARE\\7-Zip");
            Global.Before.Construct();
            //Global.Before.BFS();
            mylabel.Text = "Tracking";*/
        }
        private void button2_Click(object sender, EventArgs e)
        {
            /*Global.After = new NodeTree("7-Zip", "SOFTWARE\\7-Zip");
            Global.After.Construct();
            //Global.After.BFS();
            mylabel.Text = Global.CheckSame(Global.Before, Global.After) + "";
            foreach (DiffStruct diff in Global.CheckNodeDiff(Global.Before, Global.After))
            {
                if (diff.After)
                    MessageBox.Show("After多的: " + diff.nodetree.getPath());
                else
                    MessageBox.Show("Before多的: " + diff.nodetree.getPath());
            }*/
        }
        static void PrintKeys(string rkey)
        {
            //Queue<string> queue = new Queue<string>();
            //queue.Enqueue(rkey);
            //BFSTraversal(ref queue);
            
        }
        private void AddPathBtn_Click(object sender, EventArgs e)
        {
            RegistryKey rk = null;
            if (RootPathChoose.SelectedIndex == -1)
            {
                MessageBox.Show("Please select root path.");
                return;
            }
            string tmp = (PathBox.Text.Length != 0 && PathBox.Text[0] == '\\' ? PathBox.Text.Remove(0,1) : PathBox.Text);

            if (RootPathChoose.SelectedIndex == 0)
                rk = Registry.ClassesRoot.OpenSubKey(tmp);
            else if (RootPathChoose.SelectedIndex == 1)
                rk = Registry.CurrentUser.OpenSubKey(tmp);
            else if (RootPathChoose.SelectedIndex == 2)
                rk = Registry.LocalMachine.OpenSubKey(tmp);
            else if (RootPathChoose.SelectedIndex == 3)
                rk = Registry.Users.OpenSubKey(tmp);
            else if (RootPathChoose.SelectedIndex == 4)
                rk = Registry.CurrentConfig.OpenSubKey(tmp);

            if(rk == null)
            {
                MessageBox.Show("Path does not exist.");
                return;
            }
            Global.TrackList.Add(new NodeTree(tmp.Split('\\').Last(), tmp, RootPathChoose.SelectedIndex));
            TrackedPathBox.Items.Add(RootPathChoose.Text + "\\" + tmp);
        }
        private void DeletePathBtn_Click(object sender, EventArgs e)
        {
            bool continueflag = true;
            int count = 0;
            while(continueflag)
            {
                continueflag = false;
                for (int i = 0; i < TrackedPathBox.Items.Count; i++)
                {
                    if (TrackedPathBox.GetItemChecked(i))
                    {
                        continueflag = true;
                        Global.TrackList.RemoveAt(i);
                        TrackedPathBox.Items.RemoveAt(i);
                        break;
                    }
                    if(count == 0 && i == TrackedPathBox.Items.Count - 1)
                        MessageBox.Show("Please select path to delete.");
                }
                count++;
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
        private void StartTrackBtn_Click(object sender, EventArgs e)
        {
            foreach (NodeTree node in Global.TrackList)
                node.Construct();
            mylabel.Text = "Tracking";
        }

        private void StopTrackBtn_Click(object sender, EventArgs e)
        {
            mylabel.Text = "Stoping";
            foreach (NodeTree node in Global.TrackList)
                Global.TrackListAfter.Add(new NodeTree(node.getName(), node.getPath(), node.getRoot()));
            foreach (NodeTree node in Global.TrackListAfter)
                node.Construct();
            mylabel.Text = "Making result";
            for(int i = 0; i < Global.TrackList.Count; i++)
            {
                Global.DiffList.AddRange(Global.CheckNodeDiff(Global.TrackList[i], Global.TrackListAfter[i]));
            }
        }
        private void ShowResultBtn_Click(object sender, EventArgs e)
        {
            resultForm = new ResultForm();
            foreach (DiffStruct diff in Global.DiffList)
                resultForm.AddResult(diff.nodetree.getPath(), diff.After);
            resultForm.Show();
        }
    }
}
