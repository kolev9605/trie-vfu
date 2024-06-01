using System.Text;

namespace Exercises.ExerciseTwo;

// Задание 1:
// 1.1 Да се създаде BST (Binary Search Tree)
public class BinarySearchTree
{
    public TreeNode? Root;

    // 1.2 Да се създаде функция, която добавя елемент към BST
    public void Insert(int value)
    {
        Root = Insert(Root, value);
    }

    // 1.3 Да се създаде функция, която търси елемент в BST
    public bool Search(int value)
    {
        if (Root is null)
        {
            return false;
        }

        if (Root.Value == value)
        {
            return true;
        }

        return Search(Root, value) is not null;
    }

    // 1.4 Да се създаде  функция, която връща път до елемент
    public string? Path(int value)
    {
        return PathToElement(new StringBuilder(), Root, value)?.ToString();
    }

    // 1.5 Да се създаде функция, която изтрива елемент от BST
    public void Delete(int value)
    {
        Root = Delete(Root, value);
    }

    private TreeNode? Search(TreeNode? node, int value)
    {
        if (node is null)
        {
            return null;
        }

        if (value < node.Value)
        {
            return Search(node.Left, value);
        }
        else if (value > node.Value)
        {
            return Search(node.Right, value);
        }
        else if (value == node.Value)
        {
            return node;
        }

        return null;
    }

    private StringBuilder? PathToElement(StringBuilder currentPath, TreeNode? node, int value)
    {
        if (node is null)
        {
            return null;
        }

        if (value < node.Value)
        {
            currentPath.Append($"({node.Value})>");
            return PathToElement(currentPath, node.Left, value);
        }
        else if (value > node.Value)
        {
            currentPath.Append($"({node.Value})>");
            return PathToElement(currentPath, node.Right, value);
        }
        else if (value == node.Value)
        {
            currentPath.Append($"({node.Value})");
            return currentPath;
        }

        return null;
    }

    private TreeNode Insert(TreeNode? node, int value)
    {
        if (node is null)
        {
            return new TreeNode(value);
        }

        if (value < node.Value)
        {
            node.Left = Insert(node.Left, value);
        }
        if (value > node.Value)
        {
            node.Right = Insert(node.Right, value);
        }

        return node;
    }

    private TreeNode? Delete(TreeNode? node, int value)
    {
        if (node == null)
        {
            return node;
        }

        if (value < node.Value)
        {
            node.Left = Delete(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = Delete(node.Right, value);
        }
        else
        {
            // Node with only one child or no child
            if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }

            // Node with two children: Get the inorder successor (smallest in the right subtree)
            node.Value = MinValue(node.Right);

            // Delete the inorder successor
            node.Right = Delete(node.Right, node.Value);
        }

        return node;
    }

    private int MinValue(TreeNode node)
    {
        int minValue = node.Value;
        while (node.Left != null)
        {
            minValue = node.Left.Value;
            node = node.Left;
        }
        return minValue;
    }
}

public class TreeNode
{
    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }

    public int Value { get; set; }

    public TreeNode? Left { get; set; }

    public TreeNode? Right { get; set; }

    public override string ToString()
    {
        return Value.ToString();
    }
}