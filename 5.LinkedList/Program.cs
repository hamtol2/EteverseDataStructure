using System;

public class Program
{
    static void Main(string[] args)
    {
        // 리스트 생성.
        LinkedList<int> list = new LinkedList<int>();

        // 데이터 추가.
        for (int ix = 0; ix < 10; ++ix)
        {
            list.Insert(ix + 1);
        }

        // 데이터 삭제.
        list.DeleteNode(5);
        list.DeleteNode(7);
        list.DeleteNode(1);
        
        list.DeleteNode(20);

        // 데이터 출력.
        list.Print();

        Console.ReadKey();
    }
}