using System;

class Program
{
    static void PrintNode<T>(Node<T> node)
    {
        Console.WriteLine($"{node.Data}");
    }

    static void Main(string[] args)
    {
        // 트리 생성.
        Tree<string> tree = new Tree<string>("A");
        tree.AddChild("B");
        tree.Children[0].AddChild("E");
        tree.Children[0].AddChild("F");
        tree.Children[0].AddChild("G");

        // 출력.
        //tree.PreorderTraverse(PrintNode<string>);
        Console.WriteLine("전위순회");
        tree.PreorderTraverse(node => { Console.WriteLine($"{node.Data}"); });

        Console.WriteLine("\n후위순회");
        tree.PostorderTraverse(node => { Console.WriteLine($"{node.Data}"); });

        Console.ReadKey();
    }
}