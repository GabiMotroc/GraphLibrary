namespace Graphs
{
    public interface INode<T>
    {
        T Id { get; set; }
        bool Equals(object obj);
        int GetHashCode();
    }
}