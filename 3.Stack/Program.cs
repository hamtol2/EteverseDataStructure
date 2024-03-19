using System;

// 스택 예제 프로그램.
// Ctl + ;
public class StackExample
{
    static void Main(string[] args)
    {
        // 스택 생성.
        Stack<float> stack = new Stack<float>();

        // 스택에 데이터 추가.
        stack.Push(123.4f);
        stack.Push(145.1f);
        stack.Push(183.8f);

        // 출력.
        int count = stack.Count;
        for (int ix = 0; ix < count; ++ix)
        {
            Console.WriteLine($"스택 값: { stack.Pop() }");
        }

        // F5로 실행했을 때 바로 꺼지지 말라고 넣은 코드 (의미 없음).
        Console.ReadKey();
    }
}