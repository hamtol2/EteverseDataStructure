using System;

public class Program
{
    static void Main(string[] args)
    {
        // 해시 테이블 생성.
        HashTable<string, string> table = new HashTable<string, string>();

        // 자료 추가.
        table.Add("Ronnie", "010-12345678");
        table.Add("Ronnie", "010-29873498");
        table.Add("Kevin", "010-41987344");
        table.Add("Baker", "010-31284973");
        table.Add("Taejun", "010-49328574");

        // 출력.
        table.Print();
        Console.WriteLine();

        // 검색.
        Pair<string, string> outPair = new Pair<string, string>();
        if (table.Find("Ronnie", ref outPair) == true)
        {
            Console.WriteLine($"검색 결과1: {outPair.key}, {outPair.value} ");
        }

        if (table.Find("Test", ref outPair) == true)
        {
            Console.WriteLine($"검색 결과2: {outPair.key}, {outPair.value} ");
        }

        // 삭제.
        table.Delete("Ronnie");
        table.Delete("Baker");
        table.Delete("Test");

        // 최종 출력.
        Console.WriteLine("\n최종 출력.");
        table.Print();
        
        // 종료 대기.
        Console.ReadKey();
    }
}