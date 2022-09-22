namespace Dag10.TreeBinary;

public class Branch<T> : BinaryTree<T> 
    where T : IComparable<T>
{
    public BinaryTree<T> Left { get; private set; }
    public BinaryTree<T> Right { get; private set; }
    public readonly T Item;

    public Branch(T item, BinaryTree<T> left, BinaryTree<T> right)
    {
        Left = left;
        Right = right;
        Item = item;
    }

    public override int Depth()
    {
        return Math.Max(Left.Depth(), Right.Depth()) + 1;
    }

    public override int Count()
    {
        return Left.Count() + Right.Count() + 1;
    }

    private BinaryTree<T> Add(ref BinaryTree<T> member, T item)
    {
        if (member is Empty<T>)
        {
            member = new Branch<T>(item, Empty(), Empty());
        }
        else
        {
            member.Add(item);
        }
        return member;
    }

    public override BinaryTree<T> Add(T item)
    {
        BinaryTree<T> member;
        switch (Item.CompareTo(item))
        {
            case 1:
                member = Left;
                Left = Add(ref member, item);
                break;
            case -1:
                member = Right;
                Right = Add(ref member, item);
                break;
            case 0:
                break;
        };
        return this;
    }

    public override bool Contains(T item)
    {
        var comparison = Item.CompareTo(item);
        return comparison switch
        {
            0 => true,
            1 => Left.Contains(item),
            -1 => Right.Contains(item)
        };
    }
}