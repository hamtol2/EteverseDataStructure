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
        Root = InsertNodeRecursive(Root, null, newData);
        return true;
    }

    // 재귀적으로 삽입을 처리하는 함수.
    // node: 현재 비교하는 노드.
    // parent: node의 부모 노드.
    // newData: 삽입하려는 새 데이터.
    private Node InsertNodeRecursive(Node node, Node parent, int newData)
    {
        // node가 null이면 새로 생성 후 생성한 노드를 반환.
        if (node == null)
        {
            // 새 노드 생성.
            Node newNode = new Node(newData);

            // 새 노드의 부모 노드 지정.
            newNode.Parent = parent;

            // 노드 반환.
            return newNode;
        }

        // 추가하려는 값이 비교 노드보다 작으면, 왼쪽 서브 트리로 탐색.
        if (node.Data > newData)
        {
            node.Left = InsertNodeRecursive(node.Left, node, newData);
        }

        // 추가하려는 값이 비교 노드보다 크면, 오른쪽 서브 트리로 탐색.
        else
        {
            node.Right = InsertNodeRecursive(node.Right, node, newData);
        }

        return node;
    }

    // 삭제.
    public void DeleteNode(int deleteData)
    {
        // 재귀적으로 삭제하는 함수를 호출.
        // 삭제 연산의 시작은 Root 노드.
        // 예외 처리가 안된 코드.
        Root = DeleteNodeRecursive(Root, deleteData);
    }

    // 삭제 재귀 함수.
    private Node DeleteNodeRecursive(Node node, int deleteData)
    {
        // 종료 조건.
        // 노드가 null이면 삭제할 노드를 찾지 못한 것이기 때문에 null을 반환하고 종료.
        if (node == null)
        {
            return null;
        }

        // 삭제하려는 데이터가 비교 데이터보다 작으면 왼쪽 서브 트리로 이동.
        if (node.Data > deleteData)
        {
            node.Left = DeleteNodeRecursive(node.Left, deleteData);
        }

        // 삭제하려는 데이터가 비교 데이터보다 크면 오른쪽 서브 트리로 이동.
        else if (node.Data < deleteData)
        {
            node.Right = DeleteNodeRecursive(node.Right, deleteData);
        }

        // 찾으면, 삭제 처리.
        else
        {
            // 경우1 - 자식이 없는 경우. (둘 모두 null인 경우)
            if (node.Left == null && node.Right == null)
            {
                return null;
            }

            // 경우3 - 자식이 둘 다 있는 경우. (둘 모두 null이 아닌 경우).
            if (node.Left != null && node.Right != null)
            {
                // 삭제되는 노드의 오른쪽 서브 트리에서 가장 작은 값을 검색해서 삭제하는 노드의 값을 업데이트.
                node.Data = SearchMinValue(node.Right).Data;

                // 위에서 구한 오른쪽 서브 트리에서 가장 작은 값을 가진 노드를 삭제.
                node.Right = DeleteNodeRecursive(node.Right, node.Data);
            }
            else
            {
                // 경우2 - 자식이 하나만 있는 경우 (둘 중 하나만 null인 경우).
                if (node.Left == null)
                {
                    return node.Right;
                }

                else if (node.Right == null)
                {
                    return node.Left;
                }
            }
        }

        return node;
    }

    // 최소값 검색 함수.
    // node: 검색을 시작하는 노드.
    private Node SearchMinValue(Node node)
    {
        // 검색 시작.
        //int minValue = node.Data;

        // 왼쪽 서브 트리로 계속해서 이동하면서, 최소 값 업데이트.
        while (node.Left != null)
        {
            // 왼쪽 노드의 값을 최소 값으로 업데이트.
            //minValue = node.Left.Data;

            // 왼쪽 서브 노드로 이동.
            node = node.Left;
        }

        // 최소 값을 가진 노드를 반환.
        return node;
    }

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

    // 출력 (순회).
    public void InorderTraverse()
    {
        // 출력을 위해 중위 순회 방식으로 재귀 함수를 호출.
        // 탐색 시작은 루트 노트에서 부터.
        InorderTraverseRecursive(Root);
    }

    // 중위 순회 재귀 함수.
    private void InorderTraverseRecursive(Node node)
    {
        if (node != null)
        {
            // 왼쪽 서브 트리를 중위 순회.
            InorderTraverseRecursive(node.Left);

            // 부모 노드 처리.
            Console.Write($"{node.Data} ");

            // 오른쪽 서브 트리를 중위 순회.
            InorderTraverseRecursive(node.Right);
        }
    }
}