namespace Exercises.ExerciseThree;

public class DnaPrefixTree
{
    private DnaPrefixTreeNode _root = new DnaPrefixTreeNode();

    public void InsertDnaFragment(string dnaFragment)
    {
        var currentNode = _root;
        for (int i = 0; i < dnaFragment.Length; i++)
        {
            if (!currentNode.Children.ContainsKey(dnaFragment[i]))
            {
                currentNode.Children[dnaFragment[i]] = new DnaPrefixTreeNode();
            }

            currentNode = currentNode.Children[dnaFragment[i]];

        }

        currentNode.IsEndOfWord = true;
    }

    public List<DnaPrefixTreeNode> GetNodesByDepth(int depth)
    {
        var result = new List<DnaPrefixTreeNode>();

        if (depth < 0)
        {
            return result;
        }

        var queue = new Queue<(DnaPrefixTreeNode node, int currentDepth)>();
        queue.Enqueue((_root, 0));

        while (queue.Count > 0)
        {
            var (node, currentDepth) = queue.Dequeue();

            if (currentDepth == depth)
            {
                result.Add(node);
            }

            if (currentDepth < depth)
            {
                foreach (var child in node.Children.Values)
                {
                    queue.Enqueue((child, currentDepth + 1));
                }
            }
        }

        return result;
    }

    public Dictionary<DnaPrefixTreeNode, List<DnaPrefixTreeNode>> CreateAdjacencyList()
    {
        var adjacencyList = new Dictionary<DnaPrefixTreeNode, List<DnaPrefixTreeNode>>();
        var queue = new Queue<DnaPrefixTreeNode>();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (!adjacencyList.ContainsKey(node))
            {
                adjacencyList[node] = new List<DnaPrefixTreeNode>();
            }

            foreach (var child in node.Children.Values)
            {
                adjacencyList[node].Add(child);
                queue.Enqueue(child);
            }
        }

        return adjacencyList;
    }

    public List<string> GetContigs()
    {
        var contigs = new List<string>();
        var path = new List<char>();
        CollectContigs(_root, path, contigs);
        return contigs;
    }

    private void CollectContigs(DnaPrefixTreeNode node, List<char> path, List<string> contigs)
    {
        // If the current node has more than one child or is the end of a word, it's a contig boundary.
        if (node.Children.Count != 1 || node.IsEndOfWord)
        {
            if (path.Count > 0)
            {
                contigs.Add(new string(path.ToArray()));
            }
            // If it's an end of word and has children, the path should reset here for further contigs.
            if (node.IsEndOfWord && node.Children.Count > 0)
            {
                contigs.Add(new string(path.ToArray()));
            }
        }

        // Continue with the children nodes.
        foreach (var kvp in node.Children)
        {
            path.Add(kvp.Key);
            CollectContigs(kvp.Value, path, contigs);
            path.RemoveAt(path.Count - 1);  // Backtrack
        }
    }
}

public class DnaPrefixTreeNode
{
    public bool IsEndOfWord { get; set; } = false;

    public Dictionary<char, DnaPrefixTreeNode> Children { get; init; } = new Dictionary<char, DnaPrefixTreeNode>();
}