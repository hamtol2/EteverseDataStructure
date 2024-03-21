using System;

// 트리 클래스.
public class Tree<T>
{
    // 루트 노트.
    private Node<T> root;

    // 자식 노드 배열 (루트 노드의 자식 배열을 반환 - 편의 목적.
    public List<Node<T>> Children { get { return root.Children; } }

    // 트리의 노드 개수를 반환하는 프로퍼티.
    public int Count { get { return root.Count; } }

    // 생성자.
    public Tree()
        : this(default(T))
    {
    }

    public Tree(T newData)
    {
        root = new Node<T>(newData);
    }

    // 자식 노드 추가 함수.
    public void AddChild(T data, Node<T> parent = null)
    {
        // 자식 노드 생성.
        Node<T> newChild = new Node<T>(data);

        // 생성한 자식 노드의 부모 지정.
        newChild.Parent = parent == null ? root : parent;

        // 자식 노드 배열에 새 노드 추가.
        newChild.Parent.AddChild(newChild);
    }

    // 자식 노드 추가 함수.
    public void AddChild(Node<T> newChild, Node<T> parent = null)
    {
        // 생성한 자식 노드의 부모 지정.
        newChild.Parent = parent == null ? root : parent;

        // 자식 노드 배열에 새 노드 추가.
        newChild.Parent.AddChild(newChild);
    }

    // 순회.
    // 전위 순회 (부모를 먼저, 왼쪽, 오른쪽 순서로).
    // action: 순회하면서 실행할 메소드를 받는 딜리게이트(Delegate).
    // Delegate: 함수 포인터.
    // depth: 트리에서 계층을 보여주기 위한 변수.
    public void PreorderTraverse(Action<Node<T>> action, int depth = 0)
    {
        // 재귀 함수 호출.
        PreorderTraverseRecursive(root, action, depth);
    }

    private void PreorderTraverseRecursive(Node<T> node, Action<Node<T>> action, int depth = 0)
    {
        // 재귀 호출.
        
        // 종료 조건.
        if (node == null)
        {
            return;
        }

        // 뎊스 표현을 위한 출력.
        for (int ix = 0; ix < depth; ++ix)
        {
            Console.Write(" ");
        }

        // 노드 처리.
        action(node);

        // 자식 노드 처리.
        foreach (Node<T> child in node.Children)
        {
            PreorderTraverseRecursive(child, action, depth + 1);
        }
    }

    public void PostorderTraverse(Action<Node<T>> action, int depth = 0)
    {
        // 재귀 함수 호출.
        PostorderTraverseRecursive(root, action, depth);
    }

    private void PostorderTraverseRecursive(Node<T> node, Action<Node<T>> action, int depth = 0)
    {
        // 재귀 호출.
        // 종료 조건.
        if (node == null)
        {
            return;
        }

        // 자식 노드 처리.
        foreach (Node<T> child in node.Children)
        {
            PostorderTraverseRecursive(child, action, depth + 1);
        }

        // 뎊스 표현을 위한 출력.
        for (int ix = 0; ix < depth; ++ix)
        {
            Console.Write(" ");
        }

        // 노드 처리.
        action(node);
    }
}