using System;

public class Node<T>
{
    public T Data { get; set; }

    public Node<T> Parent { get; set; }

    public Node<T> Left { get; set; }

    public Node<T> Right { get; set; }

    public Node()
    {
        Data = default(T);
        Parent = null;
        Left = null;
        Right = null;
    }

    public Node(T data)
    {
        Data = data;
        Parent = null;
        Left = null;
        Right = null;
    }

    public void AddLeftChild(T data)
    {
        Node<T> newChild = new Node<T>(data);
        newChild.Parent = this;
        Left = newChild;
    }

    public void AddLeftChild(Node<T> child)
    {
        child.Parent = this;
        Left = child;
    }

    public void AddRightChild(T data)
    {
        Node<T> newChild = new Node<T>(data);
        newChild.Parent = this;
        Right = newChild;
    }

    public void AddRightChild(Node<T> child)
    {
        child.Parent = this;
        Right = child;
    }
}