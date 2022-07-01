// See https://aka.ms/new-console-template for more information

using Binary_Search_Tree;

BinarySearchTree<int> tree = new BinarySearchTree<int>();

int[] values = { 35, 50, 25, 27, 28, 20, 22, 15, 17, 26 };
//int[] values = { 3,2,1};

foreach (int num in values)
{
    tree.Insert(num);
}

//tree.Remove(2); // inga children
//tree.Remove(5); // en child
//tree.Remove(9); // två children

tree.Remove(25);
//tree.Remove(25);

tree.Print();
tree.Count();

Exists(9);

Console.WriteLine("The depth difference in the tree: " + tree.GetMaxDepth());

void Exists(int num)
{
    if (tree.Exists(num))
    {
        Console.WriteLine($"Number {num} exists in the tree.");
    }
    else
        Console.WriteLine($"Number {num} doesn not exist in the tree.");
}
