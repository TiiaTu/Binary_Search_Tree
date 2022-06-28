// See https://aka.ms/new-console-template for more information

using Binary_Search_Tree;

BinarySearchTree<int> tree = new BinarySearchTree<int>();

int[] values = { 7, 5, 9, 10, -1, 8, 2 };

foreach (int num in values)
{
    tree.Insert(num);
}

tree.Remove(2); // inga children
tree.Remove(5); // en child
tree.Remove(9); // två children

tree.Print();
tree.Count();

Exists(9);

void Exists(int num)
{
    if (tree.Exists(num))
    {
        Console.WriteLine($"Number {num} exists in the tree.");
    }
    else
        Console.WriteLine($"Number {num} doesn not exist in the tree.");
}
