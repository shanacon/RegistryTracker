using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegistryTracker
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    class NodeTree
    {
        private string name;
        private string path;
        private LinkedList<NodeTree> child;
        public NodeTree(string name, string path)
        {
            this.name = name;
            this.path = path;
            child = new LinkedList<NodeTree>();
        }
        public string getName()
        {
            return name;
        }
        public string getPath()
        {
            return path;
        }
        public LinkedList<NodeTree> getChild()
        {
            return child;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public void setPath(string path)
        {
            this.path = path;
        }
        public void AddChild(NodeTree node)
        {
            child.AddLast(node);
        }
        public void Construct()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(path);
            string[] names = rk.GetSubKeyNames();
            foreach (string s in names)
            {
                child.AddLast(new NodeTree(s, path + "\\" + s));
            }
            foreach (NodeTree kid in child)
            {
                kid.Construct();
            }
        }
        public void BFS()
        {
            Queue<NodeTree> queue = new Queue<NodeTree>();
            MessageBox.Show(this.path);
            foreach (NodeTree kid in child)
            {
                queue.Enqueue(kid);
            }
            while (queue.Count != 0)
            {
                queue.Dequeue()._BFS(ref queue);
            }
        }
        public void _BFS(ref Queue<NodeTree> queue)
        {
            MessageBox.Show(this.path);
            foreach (NodeTree kid in child)
            {
                queue.Enqueue(kid);
            }
            while (queue.Count != 0)
            {
                queue.Dequeue()._BFS(ref queue);
            }
        }
        public void DFS()
        {
            MessageBox.Show(this.path);
            foreach (NodeTree kid in child)
            {
                kid.DFS();
            }
        }
    }
}
