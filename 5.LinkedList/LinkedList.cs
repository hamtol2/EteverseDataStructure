using System;

public class LinkedList<T>
{
    // 연결 리스트가 저장할 노드 클래스.
    class Node
    {
        // 데이터 필드.
        public T data;

        // 링크 필드.
        public Node next = null;

        // 생성자.
        //public Node()
        //{
        //    data = default(T);
        //    next = null;
        //}

        public Node(T newData)
        {
            data = newData;
            next = null;
        }
    }

    // 헤드 필드.
    private Node head = null;

    // 연결 리스트에 저장된 요소의 개수.
    private int count = 0;

    // 노드 추가 함수.
    public void Insert(T newData)
    {
        // 새로 추가할 노드를 생성. 생성할 때 전달받은 데이터를 저장.
        Node newNode = new Node(newData);

        // 헤드가 빈 경우.
        if (head == null)
        {
            head = newNode;
            count++;
            return;
        }

        // 헤드가 비어 있지 않은 경우.
        Node current = head;
        Node trail = null;

        // next가 비어있을 때까지 순회.
        while (current != null)
        {
            // 현재 노드를 이전(꼬랑지) 노드에 저장.
            trail = current;

            // 현재 노드에는 그 다음 노드를 저장.
            current = current.next;
        }

        // 리스트 제일 마지막 위치에 자료 추가.
        trail.next = newNode;
        count++;
    }

    // 노드 삭제 함수.
    public void DeleteNode(T deleteData)
    {
        // 경우 1 - 빈 리스트.
        if (head == null) // if (count == 0)
        {
            Console.WriteLine("리스트가 비었음.");
            return;
        }

        // 순회.
        Node current = head;
        Node trail = null;
        while (current != null)
        {
            // 삭제할 데이터를 찾은 경우, 루프 종료.
            if (current.data.Equals(deleteData) == true)
            {
                break;
            }

            // 찾지 못했으면, 계속 진행.
            trail = current;
            current = current.next;

            // 따라서, 루프가 종료되는 경우는
            // 1. 삭제할 노드를 찾았거나
            // 2. 리스트를 모두 순회했는데 못 찾은 경우.
        }

        // 경우 2 - 삭제할 데이터가 있는 노드 검색에 실패한 경우.
        if (current == null)
        {
            Console.WriteLine($"값 {deleteData}를 가진 노드를 찾지 못했음.");
            return;
        }

        // 경우 3 - 찾았는데 삭제할 노드가 head인 경우.
        if (current == head)
        {
            head = head.next;
            count--;
            return;
        }

        // 경우 4 - 찾았는데 삭제할 노드가 head가 아닌 경우.
        trail.next = current.next;
        count--;
    }

    // 출력 함수.
    public void Print()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write($"{current.data} ");
            current = current.next;
        }

        Console.WriteLine();
    }

    // 검색 함수.
}