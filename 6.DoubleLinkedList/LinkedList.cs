// 더블 연결 리스트.
// 데이터 필드와 이전/다음 노드를 가리킬 수 있는 링크 필드를 지원하는 리스트.
using System;

public class LinkedList<T>
{
    // 연결 리스트의 노드 클래스.
    public class Node
    {
        public T data;                  // 데이터 필드.
        public Node next = null;        // 다음 노드를 가리키는 링크 필드.
        public Node previous = null;    // 이전 노드를 가리키는 링크 필드.

        // 기본 생성자.
        // 모든 값을 초기화.
        public Node()
        {
            data = default(T);
            next = null;
            previous = null;
        }

        // 전달 받은 데이터를 데이터 필드에 저장하는 생성자.
        public Node(T newData)
        {
            data = newData;
            next = null;
            previous = null;
        }
    }

    // 연결 리스트 코드 시작.
    private Node first = null;          // 연결 리스트의 시작 노드.
    private Node last = null;           // 연결 리스트의 마지막 노드.
    private int count = 0;              // 연결 리스트에 저장된 요소의 수.

    // 리스트가 비었는지 확인.
    // 저장된 요소의 수가 0인지 확인하면, 리스트가 비었는지 알 수 있음.
    public bool IsEmpty { get { return count == 0; } }

    // 첫번째 노드가 가진 데이터를 반환하는 프로퍼티.
    public T First
    {
        get
        {
            if (IsEmpty == true)
            {
                Console.WriteLine("Error: 리스트가 비어 있음.");
                return default(T);
            }

            return first.next.data;
        }
    }

    // 마지막 노드가 가진 데이터를 반환하는 프로퍼티.
    public T Last
    {
        get
        {
            if (IsEmpty == true)
            {
                Console.WriteLine("Error: 리스트가 비어 있음.");
                return default(T);
            }

            return last.previous.data;
        }
    }

    // 생성자.
    public LinkedList()
    {
        // 시작/끝 노드 생성.
        first = new Node();
        last = new Node();

        // 시작-끝 노드를 서로 연결.
        first.next = last;
        last.previous = first;

        // 값 초기화.
        count = 0;
    }

    // 리셋 함수.
    public void Clear()
    {
        // 모든 값을 생성한 초기 상태로 다시 설정.
        first.next = last;
        first.previous = null;

        last.previous = first;
        last.next = null;

        count = 0;
    }

    // 노드 추가 함수.
    // 마지막 위치에 새로운 노드를 추가하는 함수.
    public void Insert(T newData)       // PushLast
    {
        // 전달 받은 데이터를 가지는 새로운 노드를 생성하고,
        // 리스트의 포인터를 설정.
        Node newNode = new Node(newData);

        // 포인터 설정.
        // last.previous->next  --  previous<-newNode->next  --  previous<-last
        last.previous.next = newNode;
        newNode.previous = last.previous;

        newNode.next = last;
        last.previous = newNode;

        count++;
    }

    public void PushFirst(T newData)
    {
        Node newNode = new Node(newData);

        first.next.previous = newNode;
        newNode.next = first.next;
        
        newNode.previous = first;
        first.next = newNode;

        count++;
    }

    // 지정한 데이터를 가진 노드 삭제 함수.
    // Boolean - 불린 (사람이름).
    public bool Delete(T deleteData)
    {
        // 비어있는지?
        // IsEmpty 비었니?
        if (IsEmpty)
        {
            Console.WriteLine("Error: 리스트가 비어서 삭제 실패.");
            return false;
        }

        // 삭제할 노드 검색.
        Node deleteNode = first.next;

        // 순방향 검색.
        while (deleteNode != last && deleteNode != null)
        {
            // 데이터 일치하는 노드를 검색 시도.
            if (deleteNode.data.Equals(deleteData) == true)
            {
                break;
            }

            // 그 다음 노드로 이동.
            deleteNode = deleteNode.next;
        }

        // 경우 1 - 검색 성공함.
        if (deleteNode != null && deleteNode != last)
        {
            // 포인터 연산 처리.
            deleteNode.previous.next = deleteNode.next;
            deleteNode.next.previous = deleteNode.previous;

            // 데이터 저장 수 감소처리.
            count--;
            return true;
        }

        // 경우 2 - 검색 실패함.
        Console.WriteLine("Error: 삭제하려는 데이터를 찾지 못함.");
        return false;
    }

    // 자료 출력 함수.
    public void Print()
    {
        Node current = first.next;
        while (current != null && current != last)
        {
            Console.Write($"{current.data} ");
            current = current.next;
        }

        Console.WriteLine();
    }

    // 첫 번재 노드 삭제 함수.

    // 마지막 노드 삭제 함수.
}