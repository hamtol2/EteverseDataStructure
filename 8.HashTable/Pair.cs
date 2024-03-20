using System;

public class Pair<TKey, TValue>
{
    // 키를 저장하는 변수.
    public TKey key;

    // 값(value)을 저장하는 변수.
    public TValue value;

    public Pair()
    {
        key = default(TKey);
        value = default(TValue);
    }

    public Pair(TKey key, TValue value)
    {
        this.key = key;
        this.value = value;
    }
}