using System;

//public class Constants
//{
//    public static string duplicateErrorMessage = "Error: 이미 중복된 값이 있어 데이터를 추가하지 못했습니다.";
//}

public class BinarySearchTree
{
    // 루트.
    private Node Root { get; set; } = null;

    // 생성자.
    public BinarySearchTree()
    {
        Root = null;
    }

    // 삽입.
    // 규칙 ->
    // 0. 중복된 값은 허용하지 않는다.
    // 1. 시작 - 루트에서부터 비교 시작.
    // 1-1 루트가 null이면 새 노드를 루트로 지정한다.
    // 2. 새로 추가하는 값이 비교하는 노드보다 작으면 왼쪽 서브 트리로 비교를 이어간다.
    // 3. 새로 추가하는 값이 비교하는 노드보다 크면 오른쪽 서브 트리로 비교를 이어간다.
    public bool InsertNode(int newData)
    {
        // 검색 (중복된 값이 있는지 확인) -> 허용 X.
        if (SearchNode(newData) == true)
        {
            //Console.WriteLine(Constants.duplicateErrorMessage);
            Console.WriteLine("Error: 이미 중복된 값이 있어 데이터를 추가하지 못했습니다.");
            return false;
        }

        // 루트가 null이면 루트로 지정.
        if (Root == null)
        {
            Root = new Node(newData);
            return true;
        }

        // Todo: 2와 3의 경우를 위해 재귀 함수 작성 후 호출해야 함.

        // Todo: 코드 제대로 다시 작성 필요.
        return false;
    } 

    // 삭제.

    // 검색.
    public bool SearchNode(int data)
    {
        // 루트에서 시작해서 재귀적으로 검색을 진행.
        return SearchNodeRecursive(Root, data);
    }

    private bool SearchNodeRecursive(Node node, int data)
    {
        // 검색 실패.
        if (node == null)
        {
            return false;
        }

        // 같으면 찾았다고 반환.
        if (node.Data.Equals(data) == true)
        {
            return true;
        }

        // 작은 경우 왼쪽으로.
        if (node.Data > data)
        {
            return SearchNodeRecursive(node.Left, data);
        }

        // 큰 경우 오른쪽으로.
        else
        {
            return SearchNodeRecursive(node.Right, data);
        }
    }

    // 출력.
}