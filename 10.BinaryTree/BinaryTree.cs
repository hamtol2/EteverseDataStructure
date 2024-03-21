using System;

public class BinaryTree<T>
{
    private Node<T> Root;

    public Node<T> Left { get { return Root.Left; } }

    public Node<T> Right { get { return Root.Right; } }

    public BinaryTree()
    {
        Root = new Node<T>();
    }

    public BinaryTree(T data)
    {
        Root = new Node<T>(data);
    }

    public void AddLeftChild(T data, Node<T> parent = null)
    {
        Node<T> finalParent = parent == null ? Root : parent;
        finalParent.AddLeftChild(data);
    }

    public void AddLeftChild(Node<T> child, Node<T> parent = null)
    {
        child.Parent = parent == null ? Root : parent;
        child.Parent.AddLeftChild(child);
    }

    public void AddRightChild(T data, Node<T> parent = null)
    {
        Node<T> finalParent = parent == null ? Root : parent;
        finalParent.AddRightChild(data);
    }

    public void AddRightChild(Node<T> child, Node<T> parent = null)
    {
        child.Parent = parent == null ? Root : parent;
        child.Parent.AddRightChild(child);
    }

    public void PreorderTraverse(Action<Node<T>> action, int depth = 0)
    {
        PreorderTraverseRecursive(Root, action, depth);
    }

    private void PreorderTraverseRecursive(Node<T> node, Action<Node<T>> action, int depth = 0)
    {
        if (node == null)
        {
            return;
        }

        for (int ix = 0; ix < depth; ++ix)
        {
            Console.Write(" ");
        }

        action(node);

        PreorderTraverseRecursive(node.Left, action, depth + 1);
        PreorderTraverseRecursive(node.Right, action, depth + 1);
    }

    public void PostorderTraverse(Action<Node<T>> action, int depth = 0)
    {
        PostorderTraverseRecursive(Root, action, depth);
    }

    private void PostorderTraverseRecursive(Node<T> node, Action<Node<T>> action, int depth = 0)
    {
        if (node == null)
        {
            return;
        }

        PostorderTraverseRecursive(node.Left, action, depth + 1);
        PostorderTraverseRecursive(node.Right, action, depth + 1);

        for (int ix = 0; ix < depth; ++ix)
        {
            Console.Write(" ");
        }

        action(node);
    }

    public void InorderTraverse(Action<Node<T>> action, int depth = 0)
    {
        InorderTraverseRecursive(Root, action, depth);
    }

    private void InorderTraverseRecursive(Node<T> node, Action<Node<T>> action, int depth = 0)
    {
        if (node == null)
        {
            return;
        }

        InorderTraverseRecursive(node.Left, action, depth + 1);

        for (int ix = 0; ix < depth; ++ix)
        {
            Console.Write(" ");
        }

        action(node);

        InorderTraverseRecursive(node.Right, action, depth + 1);
    }
}