using System.Linq;

public class Triee
{
    private readonly TrieNode _root = new TrieNode();

    public void Insert(string word)
    {
        var currentNode = _root;
        for (int i = 0; i < word.Length; i++)
        {
            if (!currentNode.Children.ContainsKey(word[i]))
            {
                currentNode.Children[word[i]] = new TrieNode();
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

public class TrieNode
{
    // public TrieNode(char character, bool isEndOfWord)
    // {
    //     IsEndOfWord = isEndOfWord;
    //     Children[character] = new TrieNode[26];
    // }

    public void AddChild(char character)
    {
        // Children[character].Add(new TrieNode());
    }

    public bool IsEndOfWord { get; set; } = false;

    public Dictionary<char, TrieNode> Children { get; init; } = new Dictionary<char, TrieNode>();
}