namespace Dag10.TreeBinary;

public abstract class BinaryTree<T>
    where T : IComparable<T>
{
    public static BinaryTree<T> Empty()
    {
        return new Empty<T>();
    }

    public abstract int Depth();

    public abstract int Count();
    
    public abstract BinaryTree<T> Add(T item);

    public abstract bool Contains(T item);
}