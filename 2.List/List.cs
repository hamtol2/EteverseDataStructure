using System;
using System.Collections;

// 직접 구현하는 동적 배열(List - Dynamic Array).
public class List<T> : IEnumerator
{
    // 외부 프로퍼티.

    // 리스트의 크기 값.
    public int Capacity { get { return capacity; } }

    // 리스트에 저장된 요소의 개수.
    public int Size { get { return size; } }

    public object Current { get { return current; } }

    // 내부 변수.
    // 자료 저장 공간.
    private T[] data;

    // 리스트에 저장된 요소의 개수.
    private int size = 0;

    // 리스트 크기.
    private int capacity = 4;

    // 현재 인덱스를 가리키는 변수.
    private int index = 0;

    // 현재 값 위치를 가리키는 변수.
    private T current;

    // 생성자.
    public List()
    {
        // 배열 생성.
        data = new T[capacity];

        // 배열 요소 개수 초기화.
        size = 0;
    }

    // Getter.
    public T this[int index]
    {
        get { return data[index]; }
    }

    // 데이터 추가 함수.
    public void Add(T newData)
    {
        // 현재 배열이 다 찼으면, 새로 할당.
        if (size == capacity)
        {
            // 기존 크기에 두배.
            ReAllocate(capacity * 2);
        }

        // 배열에 저장된 제일 마지막 위치에 데이터 추가.
        data[size] = newData;

        // 배열의 크기 1 증가.
        ++size;
    }

    // 삭제 함수.
    public bool Remove(T removeData)
    {
        // size가 0인 경우, 배열에 저장된 값이 없음.
        if (size == 0)
        {
            // 삭제 실패.
            return false;
        }

        // 삭제할 배열의 인덱스 값.
        int targetIndex = -1;

        // 검색.
        for (int ix = 0; ix < size; ++ix)
        {
            // 삭제할 데이터를 찾은 경우.
            if (data[ix].Equals(removeData) == true)
            {
                targetIndex = ix;
                break;
            }
        }

        // 검색에 성공 했는지 확인.
        if (targetIndex >= 0)
        {
            // 인덱스 기반으로 삭제하는 함수 호출.
            RemoveAt(targetIndex);
            return true;
        }

        // 여기까지 왔으면, 삭제에 실패한 것.
        return false;
    }

    // 인덱스를 사용해 삭제하는 함수.
    public void RemoveAt(int index)
    {
        // 예외처리 (배열 크기 검증, 인덱스 검증).
        if (size == 0 || index < 0 || index >= size)
        {
            return;
        }

        // 데이터 보존에 사용할 인덱스 값.
        int listIndex = 0;
        for (int ix = 0; ix < size; ++ix)
        {
            // 삭제할 인덱스에 해당하면 루프 건너뜀.
            if (ix == index)
            {
                continue;
            }

            // 데이터 보존.
            data[listIndex] = data[ix];

            // 인덱스 증가.
            ++listIndex;
        }

        // 삭제 후 크기 감소.
        --size;

        // 마지막 값은 기본 값으로 설정 (쓰레기 값이 저장되는 것을 방지하기 위함).
        data[size] = default(T);
    }

    // 배열 재할당 함수 (내부에서 활용).
    private void ReAllocate(int newCapacity)
    {
        // 새로운 크기의 배열 생성.
        T[] newData = new T[newCapacity];

        // 예외 처리.
        if (newCapacity < size)
        {
            size = newCapacity;
        }

        // 기존 데이터 복사.
        //System.Array.Copy
        for (int ix = 0; ix < size; ++ix)
        {
            newData[ix] = data[ix];
        }

        // 내부 데이터 전환(바꾸기).
        data = newData;

        // 크기 확장.
        capacity = newCapacity;
    }

    public bool MoveNext()
    {
        // 인덱스 검증.
        if (index < size)
        {
            current = data[index++];
            return true;
        }

        // 인덱스를 벗어난 경우에는 실패.
        return false;
    }

    public void Reset()
    {
        index = 0;
    }

    // IEnumerator를 반환하는 함수.
    public IEnumerator GetEnumerator()
    {
        Reset();
        return this;
    }
}