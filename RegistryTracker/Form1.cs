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
            mylabel.Text = Global.After.CheckSame(Global.Before, Global.After) + "";
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
    }
}
