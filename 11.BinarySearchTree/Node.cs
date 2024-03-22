using System;

// 이진 탐색 트리의 노드.
public class Node
{
    // 키.

    // 노드의 키 값.
    public int Data { get; set; }

    // 부모 노드.
    public Node Parent { get; set; }

    // 왼쪽 서브트리.
    public Node Left { get; set; }

    // 오른쪽 서브트리.
    public Node Right { get; set; }

    public Node(int data)
    {
        Data = data;
        Parent = null;
        Left = null;
        Right = null;
    }
}