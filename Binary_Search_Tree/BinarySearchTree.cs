// See https://aka.ms/new-console-template for more information

namespace Binary_Search_Tree
{

	public class BinarySearchTree<T> : BST_G<T>, BST_VG<T> where T : IComparable<T>
	{
		private Node<T>? Root = null;

		// Remember: the most efficient tree is a balanced tree. A balanced tree has the same (or as close as possible to) amount of nodes on the left as on the right.

		// Inserts a new value to the tree
		public void Insert(T value)
		{
			// om Root är tom, lägg till data
			if (Root == null)
			{
				Root = new Node<T>(value);
			}
			// om value är mindre än root --> leftchild
			else if (Root.Data.CompareTo(value) > 0)
			{
                Root.LeftChild.Data = value;
			}
			// om value är större än root --> rightchild
			else if (Root.Data.CompareTo(value) < 0)
			{
				Root.RightChild.Data = value;
			}
			else // (Root.Data.CompareTo(value) == 0)
            {
				//TODO
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

			if(decideSide > 0) // om value är större än root
            {

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

			// när den inte är tom
			int counter = 0;
			var node = Root;
			while (node != null)
			{
				counter++;
				node = node.LeftChild;
			}
			return false;

			//returnera antalet nodes
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
