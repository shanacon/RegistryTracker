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
    public static class Global
    {
        public static NodeTree Before;
        public static NodeTree After;
        public static List<NodeTree> TrackList = new List<NodeTree>();
       public static bool CheckSame(NodeTree tree1, NodeTree tree2)
        {
            if (tree1.getChild().Count == 0 && tree2.getChild().Count == 0)
                return tree1.getPath() == tree2.getPath() ? true : false;
            else if (tree1.getChild().Count != tree2.getChild().Count)
                return false;
            else
            {
                bool ret = true;
                for (int i = 0; i < tree1.getChild().Count; i++)
                    ret &= CheckSame(tree1.getChild().ElementAt(i), tree2.getChild().ElementAt(i));
                return ret;
            }
        }
        public static List<DiffStruct> CheckNodeDiff(NodeTree tree1, NodeTree tree2)
        {
            List<DiffStruct> ret = new List<DiffStruct>();
            Dictionary<string, NodeTree> DicTree1ToNode = new Dictionary<string, NodeTree>();
            Dictionary<string, NodeTree> DicTree2ToNode = new Dictionary<string, NodeTree>();
            ///
            foreach (NodeTree kid in tree1.getChild())
                DicTree1ToNode[kid.getPath()] = kid;
            foreach (NodeTree kid in tree2.getChild())
                DicTree2ToNode[kid.getPath()] = kid;
            foreach (KeyValuePair<string, NodeTree> entry in DicTree1ToNode)
            {
                if (!DicTree2ToNode.ContainsKey(entry.Key))
                    ret.Add(new DiffStruct(DicTree1ToNode[entry.Key], false));
                else
                {
                    List<DiffStruct> tmp = CheckNodeDiff(entry.Value, DicTree2ToNode[entry.Key]);
                    ret.AddRange(tmp);
                }
            }
            foreach (KeyValuePair<string, NodeTree> entry in DicTree2ToNode)
            {
                if (!DicTree1ToNode.ContainsKey(entry.Key))
                    ret.Add(new DiffStruct(DicTree2ToNode[entry.Key], true));
            }
            return ret;
        }
    }
    public struct DiffStruct
    {
        public NodeTree nodetree;
        public bool After;
        public DiffStruct(NodeTree nodetree, bool After)
        {
            this.nodetree = nodetree;
            this.After = After;
        }
    }
    public class NodeTree
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
