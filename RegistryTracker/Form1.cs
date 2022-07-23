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
            PrintKeys("SOFTWARE\\7-Zip");
            mylabel.Text = "Tracking";
        }
        static void PrintKeys(string rkey)
        {
            //Queue<string> queue = new Queue<string>();
            //queue.Enqueue(rkey);
            //BFSTraversal(ref queue);
            NodeTree root = new NodeTree(rkey.Split('\\')[1], rkey);
            root.Construct();
            root.DFS();
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
