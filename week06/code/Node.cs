public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        // If the value is equal to Data, it's a duplicate. 
        // We return without doing anything to ensure unique values only.
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        // Success case: we found the value
        if (value == Data)
        {
            return true;
        }

        if (value < Data)
        {
            // If the value is smaller, look left (if a left child exists)
            return Left != null && Left.Contains(value);
        }
        else
        {
            // If the value is larger, look right (if a right child exists)
            return Right != null && Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        // Recursively find the height of the left side. If null, height is 0.
        int leftHeight = Left?.GetHeight() ?? 0;

        // Recursively find the height of the right side. If null, height is 0.
        int rightHeight = Right?.GetHeight() ?? 0;

        // The height of this node is 1 plus the height of the taller child.
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
