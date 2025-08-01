using System;
public class BinaryTreeNode<T>
{
    public T Value { get; set; }
    public BinaryTreeNode<T> Left { get; set; }
    public BinaryTreeNode<T> Right { get; set; }
    public BinaryTreeNode(T value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}
public class  BinaryTree<T>
{
    public BinaryTreeNode<T>Root { get; private set; }

    public BinaryTree()
    {
        Root = null;
    }

    public void Insert(T value)
    {
        //we use level-order insertion strategy, filling the tree from left to right level by level
        //this insures that the tree is balanced before any nodes are added to a new level

        var newNode = new BinaryTreeNode<T>(value);
        if(Root == null)
        {
            Root = newNode;
            return;
        }

        Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
        queue.Enqueue(Root);

        while(queue.Count>0)
        {
            var current = queue.Dequeue();
            if(current.Left == null)
            {
                current.Left = newNode;
                return;
            }
            else
            {
                queue.Enqueue(current.Left);
            }
            if(current.Right == null)
            {
                current.Right = newNode;
                break;
            }
            else
            {
                queue.Enqueue(current.Right);
            }
        }

    }
    public void PrintTree()
    {
        PrintTree(Root, 0);
    }
    private void PrintTree(BinaryTreeNode<T> node, int level)
    {
        if (node == null) return;
        PrintTree(node.Right, level + 1);
        Console.WriteLine(new string(' ', level * 4) + node.Value);
        PrintTree(node.Left, level + 1);
    }
    private void PreOrderTraversal(BinaryTreeNode<T> node)
    {
        /*
          PreOrder Traversal visits the current node before its child nodes. 
          The process for PreOrder Traversal is as follows:


             - Visit the current node.
             - Recursively perform PreOrder Traversal of the left subtree.
             - Recursively perform PreOrder Traversal of the right subtree.
        */


        if (node != null)
        {
            Console.Write(node.Value + " ");
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);
        }
    }


    public void PreOrderTraversal()
    {
        PreOrderTraversal(Root);
        Console.WriteLine();
    }

    public void PostOrderTraversal(BinaryTreeNode<T>node)
    {
        //Left, Right, Root


        if (node != null)
        {
            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
            Console.Write(node.Value + " ");
        }
    }
    public void PostOrderTraversal()
    {
        PostOrderTraversal(Root);
        Console.WriteLine();
    }

    public void InOrderTraversal(BinaryTreeNode<T> node)
    {
        //Left, Root, Right
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.Write(node.Value + " ");
            InOrderTraversal(node.Right);
        }
    }
    public void InOrderTraversal()
    {
        InOrderTraversal(Root);
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BinaryTree<int> tree = new BinaryTree<int>();
        tree.Insert(1);
        tree.Insert(2);
        tree.Insert(3);
        tree.Insert(4);
        tree.Insert(5);
        tree.Insert(6);
        tree.Insert(7);
        Console.WriteLine("Binary Tree created with level-order insertion.");
        tree.PrintTree();

        Console.WriteLine("PreOrder Traversal of the tree:");
        tree.PreOrderTraversal();

        Console.WriteLine("PostOrder Traversal of the tree:");
        tree.PostOrderTraversal();

        Console.WriteLine("InOrder Traversal of the tree:");
        tree.InOrderTraversal();


    }
}