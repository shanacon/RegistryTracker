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
            Application.Run(new MainForm());
        }
    }
    public static class Global
    {
        public static NodeTree Before;
        public static NodeTree After;
        public static List<NodeTree> TrackList = new List<NodeTree> ();
        public static List<NodeTree> TrackListAfter = new List<NodeTree> ();
        public static List<DiffStruct> DiffList = new List<DiffStruct> ();
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
        private enum ROOT { HKEY_CLASSES_ROOT, HKEY_CURRENT_USER , HKEY_LOCAL_MACHINE , HKEY_USERS , HKEY_CURRENT_CONFIG }
        private ROOT root;
        private LinkedList<NodeTree> child;
        public NodeTree(string name, string path, int root)
        {
            this.name = name;
            this.path = path;
            this.root = (ROOT)root;
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
        public int getRoot()
        {
            return (int)this.root;
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
            RegistryKey rk = null;
            //MessageBox.Show(root.ToString());
            if (root == ROOT.HKEY_CLASSES_ROOT)
                rk = path == "" ? Registry.ClassesRoot : Registry.ClassesRoot.OpenSubKey(path);
            else if (root == ROOT.HKEY_CURRENT_USER)
                rk = path == "" ? Registry.CurrentUser : Registry.CurrentUser.OpenSubKey(path);
            else if (root == ROOT.HKEY_LOCAL_MACHINE)
                rk = path == "" ? Registry.LocalMachine : Registry.LocalMachine.OpenSubKey(path);
            else if (root == ROOT.HKEY_USERS)
                rk = path == "" ? Registry.Users : Registry.Users.OpenSubKey(path);
            else if (root == ROOT.HKEY_CURRENT_CONFIG)
                rk = path == "" ? Registry.CurrentConfig : Registry.CurrentConfig.OpenSubKey(path);
            if (rk == null)
            {
                MessageBox.Show("Error in Construct.");
                Environment.Exit(0);
            }
            string[] names = rk.GetSubKeyNames();
            foreach (string s in names)
            {
                child.AddLast(new NodeTree(s, path == "" ? s : path + "\\" + s, (int)root));
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
