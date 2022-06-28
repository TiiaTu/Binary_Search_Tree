// See https://aka.ms/new-console-template for more information

namespace Binary_Search_Tree
{

    public class BinarySearchTree<T> : BST_G<T>, BST_VG<T> where T : IComparable<T>
    {
        private int count;
        private Node<T>? Root = null;

        // Remember: the most efficient tree is a balanced tree. A balanced tree has the same (or as close as possible to) amount of nodes on the left as on the right.

        // Inserts a new value to the tree
        public void Insert(T value) // loopa igenom 
            //är det tomt?
        {
            var currentNode = 0;

            //jämför 
            //loopa
            //
            // om Root är tom, lägg till data
            if (Root == null)
            {
                Root = new Node<T>(value);
            }
            // om value är mindre än root --> leftchild
            else if (Root.Data.CompareTo(value) > 0)
            {
                Root.LeftChild = new Node<T>(value);
            }
            // om value är större än root --> rightchild
            else if (Root.Data.CompareTo(value) < 0)
            {
                Root.RightChild = new Node<T>(value);
            }
            else // (Root.Data.CompareTo(value) == 0)
            {
                // 
                if(Root.LeftChild == null)
                {
                    Root.LeftChild = new Node<T>(value);
                }
                else if(Root.RightChild == null)
                {
                    Root.RightChild = new Node<T>(value);
                }
            }
        }

        // Returns true if an object that is equal to value exists in the tree
        // Uses the IComparable<T> interface. x.CompareTo(y) == 0
        public bool Exists(T value)
        {
            // om rooten är tom
            if (Root == null)
                return false;

            // jämför med rooten så att man vet vilken sida man ska jämföra
            var node = Root;

            int decideSide = Root.Data.CompareTo(value);

            while (node != null)
            {
                if (node.LeftChild.Data.CompareTo(value) > 0)// om value är mindre än leftchild
                {
                    node = node.LeftChild;
                }
                else if(node.RightChild.Data.CompareTo(value) < 0)
                {

                }
            }

            while (node != null)
            {

            }
            return false;
        }

        // Returns the number of objects currently in the tree
        public int Count()
        {
            // när träden är tom
            if (Root == null)
                return 0;

            return count;

            //returnera antalet nodes
        }

        public void Print()
        {
            Queue<Node<T>?> nodes = new Queue<Node<T>?>();
            Queue<Node<T>?> newNodes = new Queue<Node<T>?>();
            nodes.Enqueue(Root);
            int depth = 0;

            bool exitCondition = false;
            while (nodes.Count > 0 && !exitCondition)
            {
                depth++;
                newNodes = new Queue<Node<T>?>();

                string xs = "[";
                foreach (var maybeNode in nodes)
                {
                    string data = maybeNode == null ? " " : "" + maybeNode.Data;
                    if (maybeNode == null)
                    {
                        xs += "_, ";
                        newNodes.Enqueue(null);
                        newNodes.Enqueue(null);
                    }
                    else
                    {
                        Node<T> node = maybeNode;
                        string s = node.Data.ToString();
                        xs += s.Substring(0, Math.Min(4, s.Length)) + ", ";
                        if (node.LeftChild != null) newNodes.Enqueue(node.LeftChild);
                        else newNodes.Enqueue(null);
                        if (node.RightChild != null) newNodes.Enqueue(node.RightChild);
                        else newNodes.Enqueue(null);
                    }
                }
                xs = xs.Substring(0, xs.Length - 2) + "]";

                Console.WriteLine(xs);

                nodes = newNodes;
                exitCondition = true;
                foreach (var m in nodes)
                {
                    if (m != null) exitCondition = false;
                }
            }
        }

        // VG METODER----------------------------------


        // Remove a value from the tree
        public void Remove(T value)
        {

        }

        // You need a method to balance the tree, whenever it is unbalanced. All methods that change the tree can cause it to become unbalanced.
        public void Balance()
        {

        }

        // Methods that you may find useful:
        // private int GetMaxDepth()
        // private int GetMinDepth()
    }
}
