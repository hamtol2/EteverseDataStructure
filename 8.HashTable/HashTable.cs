using System;

public class HashTable<Tkey, TValue>
{
    // 버킷 크기.
    private const int bucketCount = 19;

    // 버킷(테이블). 해시테이블의 저장소.
    // 연결리스트의 배열. -> 체이닝 방식으로 해시 충돌을 해결하기 위함.
    private LinkedList<Pair<Tkey, TValue>>[] table;

    // 해시 테이블이 비었는지 확인하는 프로퍼티.
    public bool IsEmpty
    {
        get
        {
            // 각 연결리스트에 접근해서, 연결 리스트에 저장된 요소의 수를 합산.
            for (int ix = 0; ix < bucketCount; ++ix)
            {
                if (table[ix].Count > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }

    // 생성자.
    public HashTable()
    {
        // 해시테이블의 저장소 생성. (연결리스트의 배열).
        table = new LinkedList<Pair<Tkey, TValue>>[bucketCount];

        // 배열 내부의 각 연결 리스트 객체 생성.
        for (int ix = 0; ix < bucketCount; ++ix)
        {
            table[ix] = new LinkedList<Pair<Tkey, TValue>>();
        }
    }

    // 데이터 추가 함수.
    public void Add(Tkey key, TValue value)
    {
        // 1. 저장할 버킷의 인덱스 구하기.
        // - key를 기반으로 해시를 구한 뒤 나머지 연산을 통해 인덱스를 구한다.
        int bucketIndex = GenerateKey(key) % bucketCount;

        // 데이터를 추가할 연결리스트 참조 값 저장 (임시로, 편의를 위해).
        //LinkedList<Pair<Tkey, TValue>> bucketList = table[bucketIndex];
        var bucketList = table[bucketIndex];

        // 해시테이블의 전제 조건 - 동일한 키는 저장할 수 없음.
        for (int ix = 0; ix < bucketList.Count; ++ix)
        {
            // 동일한 키가 존재하는 지 확인.
            if (bucketList[ix].data.key.Equals(key) == true)
            {
                Console.WriteLine("Error: 이미 동일한 키의 데이터가 저장되어 있습니다.");
                return;
            }
        }

        // 문제가 없으면, 데이터 추가.
        bucketList.PushLast(new Pair<Tkey, TValue>(key, value));
    }

    // 삭제 함수.
    public void Delete(Tkey key)
    {
        // 1. 키를 기반으로 저장되어 있는 연결리스트의 인덱스를 찾는다.
        // - key를 기반으로 해시를 구한 뒤 나머지 연산을 통해 인덱스를 구한다.
        int bucketIndex = GenerateKey(key) % bucketCount;

        // 데이터를 추가할 연결리스트 참조 값 저장 (임시로, 편의를 위해).
        //LinkedList<Pair<Tkey, TValue>> bucketList = table[bucketIndex];
        var bucketList = table[bucketIndex];

        // 2. 1에서 찾은 연결리스트에서 동일한 키를 가진 데이터가 있는지 찾는다.
        for (int ix = 0; ix < bucketList.Count; ++ix)
        {
            // 동일한 키가 존재하는 지 확인.
            if (bucketList[ix].data.key.Equals(key) == true)
            {
                // 연결 리스트에서 해당 데이터를 삭제.
                bucketList.Delete(bucketList[ix].data);
                Console.WriteLine($"키 {key} 항목이 삭제되었습니다.");
                return;
            }
        }

        // 3. 없으면 삭제 실패.
        Console.WriteLine("Error: 삭제할 데이터를 찾지 못했습니다.");
    }

    // 검색 함수1 -> Value 값만 반환.
    public bool Find(Tkey key, ref TValue outValue)
    {
        // 키를 기반으로 인덱스 찾기.
        int bucketIndex = GenerateKey(key) % bucketCount;

        // 검색한 인덱스로 연결 리스트 참조 저장 (편의를 위해).
        var bucketList = table[bucketIndex];

        // 연결 리스트 안에서 키를 가진 데이터를 검색 후 검색이 되면 해당 데이터 반환. (검색 성공).
        for (int ix = 0; ix < bucketList.Count; ++ix)
        {
            // 키를 가진 데이터가 있으면, outValue에 해당 값을 할당하고, 함수 종료.
            if (bucketList[ix].data.key.Equals(key) == true)
            {
                outValue = bucketList[ix].data.value;
                return true;
            }
        }

        // 위에서 검색에 실패했으면, 데이터 찾기 실패.
        return false;
    }

    // 검색 함수2 -> Pair<Key, Value> 쌍을 반환.
    public bool Find(Tkey key, ref Pair<Tkey, TValue> outPair)
    {
        // 키를 기반으로 인덱스 찾기.
        int bucketIndex = GenerateKey(key) % bucketCount;

        // 검색한 인덱스로 연결 리스트 참조 저장 (편의를 위해).
        var bucketList = table[bucketIndex];

        // 연결 리스트 안에서 키를 가진 데이터를 검색 후 검색이 되면 해당 데이터 반환. (검색 성공).
        for (int ix = 0; ix < bucketList.Count; ++ix)
        {
            // 키를 가진 데이터가 있으면, outValue에 해당 값을 할당하고, 함수 종료.
            if (bucketList[ix].data.key.Equals(key) == true)
            {
                outPair = bucketList[ix].data;
                return true;
            }
        }

        // 위에서 검색에 실패했으면, 데이터 찾기 실패.
        return false;
    }

    // 출력 함수.
    public void Print()
    {
        // 이중 루프.
        for (int ix = 0; ix < bucketCount; ++ix)
        {
            // 예외 처리 - 연결 리스트가 비었으면 점프.
            if (table[ix].IsEmpty == true)
            {
                continue;
            }

            // 연결 리스트 순회하면서 데이터 출력.
            for (int jx = 0; jx < table[ix].Count; ++jx)
            {
                Console.WriteLine($"키: { table[ix][jx].data.key } 값: { table[ix][jx].data.value }");
            }
        }
    }

    // 해시 생성 함수.
    // 키를 전달 받아서, 문자열로 변환한 뒤, 이를 활용해서 해시 값을 구함.
    private int GenerateKey(Tkey key)
    {
        // 최종 반환할 해시 값.
        int hash = 0;

        // 키를 문자열로 변환한 뒤, 문자(Character) 배열로 생성.
        char[] chars = key.ToString().ToCharArray();

        // 해시 생성.
        for (int ix = 0; ix < chars.Length; ++ix)
        {
            // 가장 기본 (단순함).
            //hash += chars[ix];

            // 조금 양념.
            //hash += chars[ix] * (ix + 1);

            hash = hash * 31 + chars[ix];
        }

        // 해시 값 반환.
        return Math.Abs(hash);
    }
}