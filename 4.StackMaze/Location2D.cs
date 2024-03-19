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

    // 전달된 위치가 이동 가능한 위치인지 판별하는 함수.
    // row: 맵에서 탐색할 행 번호.
    // col: 맵에서 탐색할 열 번호.
    public bool IsValidLocation(int row, int col)
    {
        // 이동 불가능 판단.
        // row나 col 값이 배열의 크기를 벗어나면 기본적으로 오류.
        if (row < 0 || col < 0 || row >= size || col >= size)
        {
            return false;
        }

        // 이동 가능 판단. (탐색하지 않은 0이거나, 출구이거나).
        return map[row, col] == '0' || map[row, col] == 'x';
    }

    // 파일에서 맵을 읽어서 맵 데이터를 설정하는 함수.
    private void ReadMap(string path)
    {
        // 파싱 (Parcing) - 해석.

        // 텍스트 파일을 라인으로 분리해서 읽어오기.
        string[] lines = File.ReadAllLines(path);

        // 파일의 라인(줄) 수를 사용해서 2차원 맵 배열을 생성.
        map = new char[lines.Length, lines.Length];

        // 크기 설정.
        Maze.size = lines.Length;

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