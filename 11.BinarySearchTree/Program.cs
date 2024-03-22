using System;

public class Program
{
    static void Main(string[] args)
    {
        // BST 트리 생성.
        BinarySearchTree tree = new BinarySearchTree();

        // 요소 추가.
        tree.InsertNode(50);
        tree.InsertNode(80);
        tree.InsertNode(20);
        tree.InsertNode(30);
        tree.InsertNode(40);
        tree.InsertNode(10);
        
        tree.InsertNode(50);

        // 중위 순회 방식으로 트리 요소 출력.
        Console.Write("트리 순회 결과: ");
        tree.InorderTraverse();

        Console.WriteLine("\n");
        
        // 검색.
        // 오버 엔지니어링.
        int keyToSearch = 100;
        if (tree.SearchNode(keyToSearch) == true)
        {
            Console.WriteLine($"트리에 {keyToSearch}이 있습니다.");
        }
        else
        {
            Console.WriteLine($"트리에 {keyToSearch}이 없습니다.");
        }

        // 삭제.
        int keyToDelete = 50;
        tree.DeleteNode(keyToDelete);

        // 요소 출력.
        Console.WriteLine();
        Console.Write($"노드 {keyToDelete} 삭제 후 순회 결과: ");
        tree.InorderTraverse();

        // 종료 대기.
        Console.ReadKey();
    }
}