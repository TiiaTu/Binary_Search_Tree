// See https://aka.ms/new-console-template for more information

public class Node<T>
{
	public T Data { get; set; }
	public Node<T>? LeftChild { get; set; }
	public Node<T>? RightChild { get; set; }

	public Node(T value)
	{
		LeftChild = null;
		RightChild = null;
		Data = value;
	}

	// A balanced tree should be as close as possible to equal amount of nodes on both sides
	// 0 is best, but +1 and -1 is ok.
	public int GetBalance()
	{
		int left = (LeftChild == null) ? 0 : LeftChild.GetDepth(0) + 1;
		int right = (RightChild == null) ? 0 : RightChild.GetDepth(0) + 1;
		return right - left;
	}

    
    // en rekursiv metod som räknar djupet på left och right subträd och returnerar den som har högre (dvs. den som är djupare)
    private int GetDepth(int depth)
    {
        int left = (LeftChild == null) ? depth : LeftChild.GetDepth(depth+ 1);
        int right = (RightChild == null) ? depth : RightChild.GetDepth(depth+1);
		return left > right ? left : right;
    }
}
