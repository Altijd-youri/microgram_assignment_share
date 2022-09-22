namespace Dag10.TreeBinary;

public class Empty<T> : BinaryTree<T>
    where T : IComparable<T>
{ 
    public override int Depth() => 0;

    public override int Count() => 0;
    public override BinaryTree<T> Add(T item)
    {
        return new Branch<T>(item, Empty(), Empty());
    }

    public override bool Contains(T item) => false;
}