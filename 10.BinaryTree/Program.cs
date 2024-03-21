using System;

public class Program
{
    static void Main(string[] args)
    {
        BinaryTree<string> tree = new BinaryTree<string>("1");
        tree.AddLeftChild("2");
        tree.Left.AddLeftChild("4");
        tree.Left.Left.AddLeftChild("8");
        tree.Left.Left.AddRightChild("9");

        tree.Left.AddRightChild("5");
        tree.Left.Right.AddLeftChild("10");
        tree.Left.Right.AddRightChild("11");

        tree.AddRightChild("3");
        tree.Right.AddLeftChild("6");
        tree.Right.Left.AddLeftChild("12");
        tree.Right.Left.AddRightChild("13");

        tree.Right.AddRightChild("7");
        tree.Right.Right.AddLeftChild("14");
        tree.Right.Right.AddRightChild("15");

        Console.WriteLine("전위 순회");
        tree.PreorderTraverse(n => { Console.WriteLine($"{n.Data}"); });

        Console.WriteLine("\n중위 순회");
        tree.InorderTraverse(n => { Console.WriteLine($"{n.Data}"); });

        Console.WriteLine("\n후위 순회");
        tree.PostorderTraverse(n => { Console.WriteLine($"{n.Data}"); });

        Console.ReadKey();
    }
}