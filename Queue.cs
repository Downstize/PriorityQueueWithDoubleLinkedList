using System.Collections;

namespace PriorityQueueWithDoubleLinkedList;

public class Queue<T> : IAbstractQueue<T>, IEnumerable<T> where T : IComparable<T>
{
    private class QueueNode
    {
        public T Data { get; }
        public int Priority { get; } //Pascal Case
        public QueueNode Next { get; set; }
        public QueueNode Previous { get; set; }

        public QueueNode(T data, int priority) //Camel Case
        {
            Data = data;
            Priority = priority;
            Next = null;
            Previous = null;
        }
    }

    private QueueNode head;
    private QueueNode tail;

    public void Add(T data, int priority)
    {
        var newNode = new QueueNode(data, priority);

        if (head == null || priority < head.Priority)
        {
            newNode.Next = head;
            if (head != null)
            {
                head.Previous = newNode;
            }

            head = newNode;
        }
        else
        {
            var current = newNode.Next;
            while (current.Next != null && priority >= current.Next.Priority)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            newNode.Previous = current;
            if (current.Next != null)
            {
                current.Next.Previous = newNode;
            }

            current.Next = newNode;
        }

        if (tail == null)
        {
            tail = newNode;
        }
    }

    public T Poll()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Очередь пуста!");
        }

        T data = head.Data;
        head = head.Next;

        if (head == null)
        {
            tail = null;
        }
        else
        {
            head.Previous = null;
        }

        return data;
    }

    public T Peek()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Очередь пуста!");
        }

        return head.Data;
    }

    public int Size()
    {
        int count = 0;
        var current = head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }

        return count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new QueueEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class QueueEnumerator : IEnumerator<T>
    {
        private QueueNode current;
        private QueueNode head;

        public QueueEnumerator(Queue<T> queue)
        {
            head = queue.head;
            current = null;
        }

        public T Current
        {
            get
            {
                if (current == null)
                {
                    throw new InvalidOperationException("Итератор ещё не начал свою работу!");
                }

                return current.Data;
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
        
        public bool MoveNext()
        {
            if (current == null)
            {
                current = head;
            }
            else
            {
                current = current.Next;
            }

            return current != null;
        }

        public void Reset()
        {
            current = null;
        }
    }
}