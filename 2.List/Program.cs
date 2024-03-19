using System;

// Home / End.
// Ctrl + 좌우 방향키.
// VS: Ctrl + . 인텔리센스.
// F12 / Ctrl + -.

class Program
{
    static void Main(string[] args)
    {
        // 리스트 생성.
        List<int> list = new List<int>();

        // 값 설정.
        for (int ix = 0; ix < 10; ++ix)
        {
            list.Add(ix + 1);
        }

        // 6번째 값 제거.
        list.RemoveAt(5);

        // 출력.
        //for (int ix = 0; ix < list.Size; ++ix)
        //{
        //    Console.WriteLine(list[ix]);
        //}

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        // 크기 값 출력.
        Console.WriteLine($"Size: {list.Size} | Capacity: {list.Capacity}");

        // 
        Console.ReadKey();
    }
}