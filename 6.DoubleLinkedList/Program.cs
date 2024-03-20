using System;

public class Program
{
    static void Main(string[] args)
    {
        // 연결 리스트 데모.
        LinkedList<int> list = new LinkedList<int>();

        // 자료 추가.
        int index = 0;
        while (index < 10)
        {
            //list.Insert(index + 1);
            list.PushFirst(index + 1);
            index++;
        }

        list.Delete(1);
        list.Delete(3);
        list.Delete(20);

        // 출력.
        list.Print();

        // 대기.
        Console.ReadKey();
    }
}