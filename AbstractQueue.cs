namespace PriorityQueueWithDoubleLinkedList;

public interface IAbstractQueue<T> where T : IComparable<T>
{
    int Size();
    void Add(T data, int priority);
    T Peek();
    T Poll();
}