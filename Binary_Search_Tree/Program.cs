// See https://aka.ms/new-console-template for more information

using Binary_Search_Tree;

BinarySearchTree<int> tree = new BinarySearchTree<int>();
tree.Insert(3);
tree.Insert(5);
tree.Insert(6);
tree.Insert(2);
tree.Insert(1);
tree.Insert(4);
tree.Insert(4);
tree.Insert(8);
tree.Insert(-4);
tree.Print();

//Console.WriteLine("The tree has {0} elements", tree.Count());
tree.Count();

tree.Exists(-1);
