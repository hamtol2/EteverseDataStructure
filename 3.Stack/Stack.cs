using System;

public class Stack<T>
{
    // 스택 저장소.
    private T[] data;

    // 스택에 저장할 수 있는 최대 데이터 수.
    private const int maxCapacity = 100;

    // 현재 스택에 저장된 데이터 수.
    public int Count { get; private set; } = 0;

    // 스택이 비었는지 확인하는 프로퍼티.
    public bool IsEmpty { get { return Count == 0; } }

    // 생성자.
    public Stack()
    {
        Count = 0;
        data = new T[maxCapacity];
    }

    // 스택 생성 시 크기를 지정할 때 사용하는 생성자.
    public Stack(int capacity)
    {
        Count = 0;
        data = new T[capacity];
    }

    // 스택을 비우는 함수.
    public void Clear()
    {
        Count = 0;
    }

    // 스택에 데이터를 추가하는 Push 함수.
    public bool Push(T newData)
    {
        // 스택이 꽉 찼는지 확인.
        if (Count >= data.Length)
        {
            return false;       // 데이터 추가 실패.
        }

        // 새로운 데이터 추가.
        data[Count] = newData;
        Count++;

        // 데이터 추가 성공.
        return true;
    }

    // 스택에 저장된 데이터를 추출하는 Pop 함수.
    public T Pop()
    {
        // 스택이 비었는지 확인.
        if (IsEmpty == true)
        {
            return default(T);
        }

        // 스택 카운트를 줄이고, 데이터 반환.
        Count--;
        return data[Count];
    }
}