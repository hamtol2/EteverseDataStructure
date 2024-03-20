using System;

// 큐(Queue) 자료구조 클래스.
// Container -> Enumerator.
public class Queue<T>
{
    // 큐에서 사용할 데이터 컨테이너.
    private T[] data = null;

    // 데이터를 추출할 때의 위치(앞).
    private int front = 0;

    // 데이터를 삽입할 때의 위치(뒤).
    private int rear = 0;

    // 큐 컨테이너의 기본 크기 - 큐를 생성할 때 크기를 지정하지 않은 경우에 사용함.
    // const / readonly.
    private const int defaultCapacity = 100;

    // 큐 저장소의 크기.
    private int capacity = 0;

    // 큐에 저장된 요소의 개수.
    private int size = 0;

    // 큐에 저장된 요소의 개수를 반환하는 프로퍼티.
    public int Size { get { return size; } }

    // 큐가 비었는 지 확인하는 프로퍼티.
    public bool IsEmpty { get { return front == rear; } }

    // 큐가 가득찼는지 확인하는 프로퍼티.
    // 우선순위가 혼동되거나, 수식에서 가독성이 떨어질 때는 괄호를 붙여주는 게 좋습니다.
    public bool IsFull { get { return ( (rear + 1) % capacity ) == front; } }

    // 기본 생성자
    public Queue()
    {
        Reset();
    }

    // 크기를 지정하는 생성자.
    public Queue(int newCapacity)
    {
        capacity = newCapacity;
        Reset();
    }

    // 큐에 데이터를 추가하는 함수.
    // 큐에 뒤(rear)에 추가.
    public bool Enqueue(T value)
    {
        // 예외 처리.
        if (IsFull == true)
        {
            Console.WriteLine("Error: 큐가 가득차 있어 데이터를 추가하지 못했습니다.");
            return false;
        }

        // 데이터 삽입 위치를 구한 뒤 데이터 삽입.
        // 이미 앞에서 큐가 가득차 있는지 확인을 했기 때문에 빈공간이 있다고 확신할 수 있음.
        rear = (rear + 1) % capacity;
        data[rear] = value;

        return true;
    }

    // 큐에서 앞에 있는 데이터를 추출하는 함수.
    // ref 키워드는 참조 전달할 때 사용. (주소 값을 전달함).
    // out 키워드와 비교해서 out은 함수 내부에서 값을 무조건 할당해야하는 반면,
    // ref는 그런 강제성이 없음. (ref - reference의 약자).
    // out은 output의 약자.
    public bool Dequeue(ref T outValue)
    {
        // 예외처리 - 큐가 비었는지 확인.
        if (IsEmpty == true)
        {
            Console.WriteLine("Error: 큐가 비어 있어 추출할 데이터가 없습니다.");
            return false;
        }

        // 데이터를 추출할 위치(front)를 구한 뒤 데이터 추출.
        front = (front + 1) % capacity;
        outValue = data[front];

        return true;
    }

    // 큐에 저장된 데이터 출력.
    public void Print()
    {
        // 예외처리.
        if (IsEmpty == true)
        {
            Console.WriteLine("Error: 큐가 비어있어 출력할 데이터가 없습니다.");
            return;
        }

        Console.Write("큐 내용: ");

        // 큐에 저장된 최대 인덱스를 구함.
        int max = (front < rear) ? rear : rear + capacity;

        // 큐를 순회하면서 데이터를 출력함.
        for (int ix = front + 1; ix <= max; ++ix)
        {
            Console.Write($"{data[ix % capacity]} ");
        }

        // 엔터.
        Console.WriteLine();
    }

    // 리셋 함수.
    private void Reset()
    {
        // 큐 저장소 크기 값 초기화.
        capacity = capacity == 0 ? defaultCapacity : capacity;

        // 저장소 생성.
        data = new T[capacity];

        // 변수 초기화.
        size = 0;
        front = 0;
        rear = 0;
    }
}