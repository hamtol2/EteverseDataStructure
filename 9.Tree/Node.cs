using System;

// 트리의 요소인 노드 클래스.
// GUID / UUID.
public class Node<T>
{
    // 데이터를 저장할 프로퍼티.
    public T Data { get; set; }

    // 부모 노드.
    public Node<T> Parent { get; set; }

    // 자식 노드 (배열).
    public List<Node<T>> Children { get; set; }

    // 자손(자식) 노드의 수를 구하는 프로퍼티.
    public int Count
    {
        get
        {
            int count = 1;
            foreach (Node<T> child in Children)
            {
                count += child.Count;
            }

            return count;
        }
    }

    // 생성자.
    public Node()
    {
        Data = default(T);
        Parent = null;
        Children = new List<Node<T>>();
    }

    public Node(T newData)
    {
        Data = newData;
        Parent = null;
        Children = new List<Node<T>>();
    }

    // 자식 노드 추가 함수.
    public void AddChild(T data)
    {
        // 전달 받은 데이터를 갖는 새로운 노드 생성.
        Node<T> newChild = new Node<T>(data);

        // 자식 목록에 새 노드 추가.
        Children.Add(newChild);

        // 나를 부모로 지정.
        newChild.Parent = this;
    }

    // 자식 노드 추가 함수2.
    public void AddChild(Node<T> child)
    {
        // 자식 목록에 새 노드 추가.
        Children.Add(child);

        // 나를 부모로 지정.
        child.Parent = this;
    }

    // 노드 삭제 함수.
    public void Destroy()
    {
        // 부모의 자식 목록에서 나를 제거.
        if (Parent != null)
        {
            Parent.Children.Remove(this);
        }

        //// 부모 링크 제거.
        //Parent = null;

        //// 자식 배열 초기화.
        //Children = new List<Node<T>>();
    }
}