using System;

public class LinkedList<T>
{
    public class Node
    {
        public T data;
        public Node next = null;
        public Node previous = null;

        public Node()
        {
            data = default(T);
            next = null;
            previous = null;
        }

        public Node(T data)
        {
            this.data = data;
            next = null;
            previous = null;
        }
    }

    private Node first = null;
    private Node last = null;
    private int count = 0;

    public bool IsEmpty { get { return count == 0; } }

    public T First
    {
        get
        {
            if (IsEmpty == true)
            {
                Console.WriteLine("Error: 리스트가 비어 있습니다.");
                return default(T);
            }

            return first.next.data;
        }
    }

    public T Last
    {
        get
        {
            if (IsEmpty == true)
            {
                Console.WriteLine("Error: 리스트가 비어 있습니다.");
                return default(T);
            }

            return last.previous.data;
        }
    }

    public LinkedList()
    {
        first = new Node();
        last = new Node();
        count = 0;

        first.next = last;
        last.previous = first;
    }

    public Node this[int targetIndex]
    {
        get
        {
            Node current = first.next;
            int index = 0;

            if (IsEmpty == true)
            {
                Console.WriteLine("Error: 리스트가 비어 있습니다.");
                return null;
            }

            while (current != last && index < targetIndex)
            {
                current = current.next;
                index++;
            }

            return current;
        }
    }

    public void Clear()
    {
        first.next = last;
        first.previous = null;
        last.previous = first;
        last.next = null;

        count = 0;
    }

    public Node Find(T data)
    {
        Node current = first.next;

        while (current != null && current != last)
        {
            if (current.data.Equals(data) == true)
            {
                return current;
            }

            current = current.next;
        }

        return null;
    }

    public Node FindReverse(T data)
    {
        Node current = last.previous;

        while (current != null && current != first)
        {
            if (current.data.Equals(data) == true)
            {
                return current;
            }

            current = current.previous;
        }

        return null;
    }

    public void PushFirst(T data)
    {
        Node newNode = new Node(data);

        // 새 노드의 다음 노드를 first.next 노드로 설정하고,
        // 이전에 저장한 first.next의 이전 노드를 새 노드로 설정.
        first.next = newNode;
        newNode.previous = first;

        count++;
    }

    public void PushLast(T data)
    {
        Node newNode = new Node(data);

        last.previous.next = newNode;
        newNode.previous = last.previous;

        newNode.next = last;
        last.previous = newNode;

        count++;
    }

    public void Insert(T data)
    {
        PushLast(data);
    }

    public void PopFirst()
    {
        if (IsEmpty == true)
        {
            Console.WriteLine("Error: 리스트가 비어 있어 작업을 수행할 수 없습니다.");
            return;
        }

        Node next = first.next.next;

        first.next = next;
        next.previous = first;

        count--;
    }

    public void PopLast()
    {
        if (IsEmpty == true)
        {
            Console.WriteLine("Error: 리스트가 비어 있어 작업을 수행할 수 없습니다.");
            return;
        }

        Node previous = last.previous.previous;

        last.previous = previous;
        previous.next = last;

        count--;
    }

    public void Delete(T data)
    {
        if (IsEmpty == true)
        {
            Console.WriteLine("Error: 리스트가 비어 있어 삭제 작업을 진행할 수 없습니다.");
            return;
        }

        Node deleteNode = first.next;

        while (deleteNode != null && deleteNode != last)
        {
            if (deleteNode.data.Equals(data) == true)
            {
                break;
            }

            deleteNode = deleteNode.next;
        }

        if (deleteNode == null || deleteNode == last)
        {
            Console.WriteLine("Error: 삭제하려는 데이터를 찾지 못했습니다.");
            return;
        }

        deleteNode.previous.next = deleteNode.next;
        deleteNode.next.previous = deleteNode.previous;

        count--;
    }

    public int Count { get { return count; } }

    public void Print()
    {
        Node current = first.next;
        Console.WriteLine($"리스트 항목 수: {Count}");

        while (current != null && current != last)
        {
            Console.Write($"{current.data} ");
            current = current.next;
        }

        Console.WriteLine();
    }
}