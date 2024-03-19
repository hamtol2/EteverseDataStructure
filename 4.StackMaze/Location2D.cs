using System;
using System.Data;

// 2차원 위치를 나타내는 자료형.
public class Location2D
{
    // 행.
    public int row;

    // 열.
    public int col;

    // 생성자.
    public Location2D(int row = 0, int col = 0)
    {
        this.row = row;
        this.col = col;
    }
}

// 미로를 나타내는 클래스.
public class Maze
{
    // 맵의 가로/세로 크기.
    public static int size = 0;

    // 맵 데이터 배열.
    private char[,] map;

    // 맵 정보를 반환하는 인덱서.
    public char this[int row, int col]
    {
        get { return map[row, col]; }
        set { map[row, col] = value; }
    }

    // 생성자.
    public Maze()
    {
        // Todo: 아직 작성 안함.
        // 파일에서 맵 읽어오기.
        ReadMap("Map.txt");
    }

    // 맵의 출력 함수.
    public void Print()
    {
        // 미로 출력.
        for (int ix = 0; ix < Maze.size; ++ix)
        {
            for (int jx = 0; jx < Maze.size; ++jx)
            {
                Console.Write($"{map[ix, jx]} ");
            }

            Console.WriteLine();
        }
    }

    // 파일에서 맵을 읽어서 맵 데이터를 설정하는 함수.
    private void ReadMap(string path)
    {
        // 파싱 (Parcing) - 해석.

        // 텍스트 파일을 라인으로 분리해서 읽어오기.
        string[] lines = File.ReadAllLines(path);

        // 라인 별로 파싱을 위해 루프 처리.
        int lineIndex = 0;
        foreach (string line in lines)
        {
            // 콤마(,)를 기준으로 파싱.
            string[] chars = line.Split(',');

            // 파싱한 맵의 문자를 맵 배열에 저장.
            for (int ix = 0; ix < chars.Length; ++ix)
            {
                map[lineIndex, ix] = chars[ix][0];
            }

            // 라인 인덱스 증가.
            ++lineIndex;
        }
    }
}