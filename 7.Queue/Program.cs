using System;

public class Program
{
    // 난수 발생 객체 생성.
    static Random random = new Random();

    // 범위를 지정해서 난수를 발생시키는 함수.
    static float GetRandomInRange(float min, float max)
    {
        // 0.0에서 1.0 사이의 난수를 생성한 뒤, min - max 범위로 조정.
        float randomNumber = random.NextSingle();

        // 범위 뻥튀기.
        randomNumber *= (max - min);
        randomNumber += min;

        // 생성한 난수 반환.
        return randomNumber;
    }

    static void Main(string[] args)
    {
        // 큐 객체 생성.
        Queue<float> queue = new Queue<float>();

        // 큐에 난수로 데이터 삽입.
        for (int ix = 0; ix < 10; ++ix)
        {
            queue.Enqueue(GetRandomInRange(100f, 150f));
        }

        // 큐 데이터 출력.
        queue.Print();

        // 큐 데이터를 받을 변수 선언.
        float outValue = 0f;

        // 큐에서 데이터 추출.
        Console.Write("큐에서 추출된 데이터: ");
        for (int ix = 0; ix < 20; ++ix)
        {
            if (queue.Dequeue(ref outValue) == true)
            {
                Console.Write($"{outValue} ");
            }
        }

        // 큐에 남은 데이터 확인용 출력.
        queue.Print();

        // 종료 대기.
        Console.ReadKey();
    }
}