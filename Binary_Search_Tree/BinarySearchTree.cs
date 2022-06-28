// See https://aka.ms/new-console-template for more information

namespace Binary_Search_Tree
{

    public class BinarySearchTree<T> : BST_G<T>, BST_VG<T> where T : IComparable<T>
    {
        private int nodeCount;
        private Node<T>? Root = null;

        #region G methods

        /// <summary>
        /// Inserts a new value to the tree
        /// </summary>
        /// <param name="value">The value that is added to the tree.</param>
        public void Insert(T value)
        {
            if (Exists(value)) return; //ifall det blir dubletter

            if (Root == null)
            {
                Root = new Node<T>(value);
                nodeCount++;
            }
            else
            {
                Root = InsertTo(Root, value);
                nodeCount++;
            }
        }

        /// <summary>
        /// Recursive help method for Insert(value) that can be used to determine which side of the tree (and subtree) the value is added to.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="value">The value that is being added to the tree.</param>
        /// <returns></returns>
        private Node<T> InsertTo(Node<T> node, T value)
        {

            //om första noden är tom, skapa en ny node
            if (node == null)
            {
                node = new Node<T>(value);
            }
            else if (node.Data.CompareTo(value) > 0)
            {
                node.LeftChild = InsertTo(node.LeftChild, value);
            }
            else if (node.Data.CompareTo(value) < 0)
            {
                node.RightChild = InsertTo(node.RightChild, value);
            }
            else //node.Data.CompareTo(value) == 0
            {
                CheckChildren(node);

            }

            return node;
        }

        //help method for the InsertDirection
        private Node<T> CheckChildren(Node<T> node)
        {
            //om leftchild är null --> lägg värdet dit
            //om right är null --> lägg till värdet dit
            if (node.LeftChild == null) node = node.LeftChild;
            else node = node.RightChild;

            return node;
        } //TODO: gör bättre

        /// <summary>
        /// Returns true if an object that is equal to value exists in the tree
        /// </summary>
        /// <param name="value">The value that is beeing searched from the tree.</param>
        /// <returns></returns>
        public bool Exists(T value)
        {
            if (Root == null)
                return false;

            var node = Root;

            while (node != null)
            {
                if (node.Data.CompareTo(value) == 0)
                {
                    return true;
                }
                else if (node.Data.CompareTo(value) > 0)// om value är mindre än leftchild
                {
                    node = node.LeftChild;
                }
                else //(decideSide < 0)
                {
                    node = node.RightChild;
                }

            }
            return false;
        }

        /// <summary>
        /// Returns the number of objects currently in the tree
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            // när träden är tom
            if (Root == null)
                return 0;

            Console.WriteLine($"The tree has {nodeCount} elements.");
            return nodeCount;
        }



        /// <summary>
        /// Prints the binary tree in console
        /// </summary>
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

        #endregion

        #region VG methods

        // Remove a value from the tree
        public void Remove(T value)
        {
            if (Root == null)
            {
                Console.WriteLine("The tree is empty!");
                return;
            }
            else
            {
                Root = RemoveFrom(Root, value);
                nodeCount--;
            }
        }

        private Node<T> RemoveFrom(Node<T> node, T value)
        {
            if (node.Data.CompareTo(value) > 0)
            {
                node.LeftChild = RemoveFrom(node.LeftChild, value);
            }
            else if (node.Data.CompareTo(value) < 0)
            {
                node.RightChild = RemoveFrom(node.RightChild, value);
            }
            else
            {
                // fall 1: inga children (leaf node)
                if (node.LeftChild == null && node.RightChild == null)
                {
                    return node = null;
                }

                // fall 2: har en child (den andra måste isf vara null)
                else if (node.LeftChild == null || node.RightChild == null)
                {
                    if (node.LeftChild == null) return node.RightChild;
                    else return node.LeftChild;
                }

                // fall 3: har två children
                else
                {
                    Node<T> temp = getMaxValue(node.LeftChild);
                    node.Data = temp.Data;
                    node.LeftChild = RemoveFrom(node.LeftChild, temp.Data);
                }
            }
            return node;
        }

        //hämtar det högsta värdet på trädet
        private Node<T> getMaxValue(Node<T> node)
        {
            while (node.RightChild != null)
            { 
                node = node.RightChild; 
            }
            return node;
        }

        // You need a method to balance the tree, whenever it is unbalanced. All methods that change the tree can cause it to become unbalanced.
        public void Balance()
        {

        }

        // Methods that you may find useful:
        // private int GetMaxDepth()
        // private int GetMinDepth()

        #endregion
    }
}
