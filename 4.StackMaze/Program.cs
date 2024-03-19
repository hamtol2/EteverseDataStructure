using System;

public class Program
{
    // 화면에 맵을 출력하고, 플레이어의 위치를 보여주는 함수.
    // map: 맵 (2차원 맵).
    // posX: x 위치 | posY: y 위치.
    // delay: 화면을 갱신(업데이트)할 지연 시간 값. (밀리세컨드 단위).
    static void PrintLocation(Maze map, int posX, int posY, int delay)
    {
        // 재우기.
        Thread.Sleep(delay);

        // 커서 안보이도록 설정 (화면 깜박거리지 말라고).
        Console.CursorVisible = false;

        // 커서의 위치를 초기화. (0, 0)으로 설정.
        Console.SetCursorPosition(0, 0);

        // 맵을 가로/세로 순회하면서 그리기.
        // 플레이어 위치는 따로 그리기.
        for (int ix = 0; ix < Maze.size; ++ix)
        {
            for (int jx = 0; jx < Maze.size; ++jx)
            {
                // 플레이어 위치 출력. (P).
                if (ix == posX && jx == posY)
                {
                    // 플레이어 색상 설정.
                    Console.ForegroundColor = ConsoleColor.Green;

                    // 플레이어 위치 출력.
                    Console.Write("P ");

                    // 색상을 원래데로 돌리기.
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                // 지나온 길은 빨간색으로 표기.
                if (map[ix, jx] == '.')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                // 맵 문자 출력.
                Console.Write($"{map[ix, jx]} ");

                // 색상 원래데로 복구.
                Console.ForegroundColor = ConsoleColor.White;
            }

            // 그 다음줄로 이동.
            Console.WriteLine();
        }
    }

    // 미로 탐색을 진행.
    static void Main(string[] args)
    {
        // 맵 생성.
        Maze maze = new Maze();

        // 시작 지점 저장을 위한 변수.
        Location2D startLocation = new Location2D();

        // 시작 지점 검출. (무식한 방법).
        for (int ix = 0; ix < Maze.size; ++ix)
        {
            for (int jx = 0; jx < Maze.size; ++jx)
            {
                // 시작 지점인지 확인 후 위치 저장.
                if (maze[ix, jx] == 'e')
                {
                    startLocation.row = ix;
                    startLocation.col = jx;
                    break;
                }
            }
        }

        // 탐색.
        // 스택을 활용해서 상/하/좌/우 순서로 다음 이동할 위치를 탐색.
        // 조건부 무한 루프.
        // !! 무한루프를 작성할 때는 먼저 종료조건을 확인해야함.

        // 스택 생성.
        Stack<Location2D> locationStack = new Stack<Location2D>();

        // 스택에 시작 위치를 추가하고, 탐색 시작.
        locationStack.Push(startLocation);

        // 미로 탐색 진행.
        while (locationStack.IsEmpty == false)
        {
            // 현재 위치 반환.
            Location2D currentLocation = locationStack.Pop();

            // 맵 및 플레이어 정보 출력.
            PrintLocation(maze, currentLocation.row, currentLocation.col, 200);

            // 출구에 도착했는지 확인 (미로 탈출 했는지).
            if (maze[currentLocation.row, currentLocation.col] == 'x')
            {
                Console.WriteLine("\n\n미로 탐색 성공.");
                Console.ReadKey();

                // 프로그램 종료.
                return;
            }

            // 출구가 아니라면, 스택에 다음 탐색할 위치를 추가. (상/하/좌/우).
            // 탐색한 위치의 문자(character)를 '.' 으로 변경.
            maze[currentLocation.row, currentLocation.col] = '.';

            // 다음 탐색할 위치를 스택에 추가.
            if (maze.IsValidLocation(currentLocation.row - 1, currentLocation.col) == true)
            {
                locationStack.Push(new Location2D(currentLocation.row - 1, currentLocation.col));
            }
            if (maze.IsValidLocation(currentLocation.row + 1, currentLocation.col) == true)
            {
                locationStack.Push(new Location2D(currentLocation.row + 1, currentLocation.col));
            }
            if (maze.IsValidLocation(currentLocation.row, currentLocation.col - 1) == true)
            {
                locationStack.Push(new Location2D(currentLocation.row, currentLocation.col - 1));
            }
            if (maze.IsValidLocation(currentLocation.row, currentLocation.col + 1) == true)
            {
                locationStack.Push(new Location2D(currentLocation.row, currentLocation.col + 1));
            }
        }

        // 탐색 실패.
        Console.WriteLine("\n\n미로 탐색 실패.");

        Console.ReadKey();
    }
}