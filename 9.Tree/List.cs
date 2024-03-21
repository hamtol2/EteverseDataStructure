using System;
using System.Collections;

public class List<T> : IEnumerator
{
    private T[] data;
    private T current;
    private int index = 0;
    private int size = 0;
    private int capacity = 4;

    public int Capacity { get { return capacity; } }
    public int Size { get { return size; } }
    public object Current { get { return current; } }

    public List()
    {
        data = new T[capacity];
        size = 0;
    }

    public T this[int index]
    {
        get { return data[index]; }
    }

    public void Add(T item)
    {
        if (size == capacity)
        {
            ReAllocate(capacity * 2);
        }

        data[size] = item;
        size++;
    }

    public bool Remove(T item)
    {
        if (size == 0)
        {
            return false;
        }

        int targetIndex = -1;
        for (int ix = 0; ix < size; ++ix)
        {
            if (data[ix].Equals(item) == true)
            {
                targetIndex = ix;
                break;
            }
        }

        if (targetIndex >= 0)
        {
            RemoveAt(targetIndex);
            return true;
        }

        return false;
    }

    public void RemoveAt(int index)
    {
        if (size == 0 || index < 0 || index >= size)
        {
            return;
        }

        if (index < size)
        {
            int listIndex = 0;
            for (int ix = 0; ix < size; ++ix)
            {
                if (ix == index)
                {
                    continue;
                }

                data[listIndex] = data[ix];
                listIndex++;
            }
        }

        size--;
        data[size] = default(T);
    }

    private void ReAllocate(int newCapacity)
    {
        T[] newData = new T[newCapacity];

        if (newCapacity < size)
        {
            size = newCapacity;
        }

        for (int ix = 0; ix < size; ++ix)
        {
            newData[ix] = data[ix];
        }

        data = newData;
        capacity = newCapacity;
    }

    public bool MoveNext()
    {
        if (index < size)
        {
            current = data[index++];
            return true;
        }

        return false;
    }

    public void Reset()
    {
        index = 0;
    }

    public IEnumerator GetEnumerator()
    {
        Reset();
        return this;
    }
}