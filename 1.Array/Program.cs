using System;

// 직접 구현하는 배열.
// 구조체(struct) - 값 타입(Value Type).
public struct Array<T>
{
    // 자료 저장 공간.
    private T[] data;

    // 기본 배열 크기.
    private const int defaultLength = 5;

    // 생성자.
    public Array(int size)
    {
        // 배열 생성.
        // 인자로 전달된 size의 값이 0이면 기본 배열 크기를 사용.
        data = size == 0 ? new T[defaultLength] : new T[size];
    }

    // 인덱서 (Indexer).
    public T this[int index]
    {
        get { return data[index]; }
        set { data[index] = value; }
    }

    //// 읽기 함수.
    //public T At(int index)
    //{
    //    return data[index];
    //}

    //// 쓰기 함수.
    //public void SetData(int index, T newData)
    //{
    //    data[index] = newData;
    //}

    // 배열의 크기 반환.
    public int Length
    {
        get
        {
            if (data == null)
            {
                data = new T[defaultLength];
            }

            return data.Length;
        }
    }
}

// 프로그램.
public class Program
{
    // 함수/메소드.
    // AOT(Ahead Of Time) 컴파일러 / JIT (Just In Time).
    static void Main(string[] args)
    {
        // 배열 생성.
        int length = 10;
        Array<int> array = new Array<int>(length);

        // 배열에 데이터 설정.
        for (int ix = 0; ix < array.Length; ++ix)
        {
            //array.SetData(ix, ix + 1);
            array[ix] = ix + 1;
        }

        // 출력.
        for (int ix = 0; ix < array.Length; ++ix)
        {
            //Console.WriteLine(array.At(ix));
            Console.WriteLine(array[ix]);
        }

        // 과제.
        // Enumerator 구현해보기.
        //foreach (var element in array)
        //{
        //}

        // 바로 종료되지 말라고 추가함 (코드적 의미는 없음).
        Console.ReadKey();
    }
}