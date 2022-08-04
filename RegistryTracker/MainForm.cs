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
        private Dictionary<string, int> PathMatch = new Dictionary<string, int> 
        { 
            { "HKEY_CLASSES_ROOT", 0},
            { "HKEY_CURRENT_USER", 1},
            { "HKEY_LOCAL_MACHINE", 2},
            { "HKEY_USERS", 3},
            { "HKEY_CURRENT_CONFIG", 4},
        };
        public MainForm()
        {
            InitializeComponent();
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
            string[] PathSplit = PathBox.Text.Split('\\');
            int root = -1;
            int rootindex = -1;
            if (PathMatch.ContainsKey(PathSplit[0]))
            {
                rootindex = 0;
                root = PathMatch[PathSplit[0]];
            }
            else if(PathSplit.Length == 1)
            {
                MessageBox.Show("Please enter correct path include root path.");
                MessageBox.Show("Root path include\nHKEY_CLASSES_ROOT\nHKEY_CURRENT_USER\nHKEY_LOCAL_MACHINE\nHKEY_USERS\nHKEY_CURRENT_CONFIG");
                return;
            }
            else if (PathMatch.ContainsKey(PathSplit[1]))
            {
                rootindex = 1;
                root = PathMatch[PathSplit[1]];
            }
            else
            {
                MessageBox.Show("Please enter correct path include root path.");
                MessageBox.Show("Root path include\nHKEY_CLASSES_ROOT\nHKEY_CURRENT_USER\nHKEY_LOCAL_MACHINE\nHKEY_USERS\nHKEY_CURRENT_CONFIG");
                return;
            }
            string tmp = "";
            if(PathSplit.Length != rootindex + 1)
                tmp = PathSplit[rootindex + 1];
            for (int i = rootindex == 0 ? 2 : 3; i < PathSplit.Length; i++)
                tmp += "\\" + PathSplit[i];
            if (root == 0)
                rk = Registry.ClassesRoot.OpenSubKey(tmp);
            else if (root == 1)
                rk = Registry.CurrentUser.OpenSubKey(tmp);
            else if (root == 2)
                rk = Registry.LocalMachine.OpenSubKey(tmp);
            else if (root == 3)
                rk = Registry.Users.OpenSubKey(tmp);
            else if (root == 4)
                rk = Registry.CurrentConfig.OpenSubKey(tmp);
            if(rk == null)
            {
                MessageBox.Show("Path does not exist.");
                return;
            }
            TrackedPathBox.Items.Add(PathSplit[rootindex] + "\\" + tmp);
            PathBox.Text = "";
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
            Global.Initialize();
            foreach (var item in TrackedPathBox.Items)
            {
                string[] tmp = TrackedPathBox.GetItemText(item).Split('\\');
                Global.TrackList.Add(new NodeTree(tmp.Last(), string.Join("\\", tmp.Skip(1)), PathMatch[tmp[0]]));
            }
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
                Global.NodeDiffList.AddRange(Global.CheckNodeDiff(Global.TrackList[i], Global.TrackListAfter[i]));
            }
            resultForm = new ResultForm();
            foreach (NodeDiffStruct diff in Global.NodeDiffList)
                resultForm.AddResult(diff.nodetree.getPath(), diff.After, "", "", "");
            foreach (ValueDiffStruct diff in Global.ValueDiffList)
                resultForm.AddResult(diff.nodetree.getPath(), diff.After, diff.ValueName, diff.StartValue, diff.EndValue);
            resultForm.Show();
            mylabel.Text = "Result has been show";
        }
        private void ShowResultBtn_Click(object sender, EventArgs e)
        {
            resultForm = new ResultForm();
            foreach (NodeDiffStruct diff in Global.NodeDiffList)
                resultForm.AddResult(diff.nodetree.getPath(), diff.After, "", "", "");
            foreach (ValueDiffStruct diff in Global.ValueDiffList)
                resultForm.AddResult(diff.nodetree.getPath(), diff.After, diff.ValueName, diff.StartValue, diff.EndValue);
            resultForm.Show();
        }
    }
}
