namespace Exercises.ExerciseOne;

// 2.1 Да се prefix tree,  което използва някакава избрана азбука (латинска)
public class PrefixTree
{
    private readonly PrefixTreeNode _root = new PrefixTreeNode();

    public void Insert(string word)
    {
        var currentNode = _root;
        for (int i = 0; i < word.Length; i++)
        {
            if (!currentNode.Children.ContainsKey(word[i]))
            {
                currentNode.Children[word[i]] = new PrefixTreeNode();
            }

            currentNode = currentNode.Children[word[i]];
        }

        currentNode.IsEndOfWord = true;
    }

    public bool StartsWith(string word)
    {
        var currentNode = _root;
        for (int i = 0; i < word.Length; i++)
        {
            if (!currentNode.Children.ContainsKey(word[i]))
            {
                return false;
            }

            currentNode = currentNode.Children[word[i]];
        }

        return true;
    }

    public bool Contains(string word)
    {
        var currentNode = _root;
        for (int i = 0; i < word.Length; i++)
        {
            if (!currentNode.Children.ContainsKey(word[i]))
            {
                return false;
            }

            currentNode = currentNode.Children[word[i]];
        }

        return currentNode.IsEndOfWord;
    }
}

public class PrefixTreeNode
{
    public bool IsEndOfWord { get; set; } = false;

    public Dictionary<char, PrefixTreeNode> Children { get; init; } = new Dictionary<char, PrefixTreeNode>();
}