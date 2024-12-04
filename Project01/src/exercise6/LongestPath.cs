using System.Diagnostics;

class LongestPath 
{
    private List<List<NodeTree>> ? AllPaths;
    private List<int> ? LongPath;
    private Tree tree;

    public LongestPath(Tree tree)
    {
        this.tree = tree;
        this.AllPaths = null;
        this.LongPath = null;
    }

    public void Find() 
    {
        if (tree.root != null && tree.root.children.Count == 0) 
        {
            this.LongPath = new List<int> { tree.root.key };
            return;
        }

        var result = new List<List<NodeTree>>();
        AllPaths = CreatePaths(this.tree.root, result);
        LongPath = FindLongest();
    }

    private List<List<NodeTree>> CreatePaths( NodeTree ? node, List<List<NodeTree>> result) 
    {
        if(node == null) return result;
        result.Add(new List<NodeTree>{node});
        result = AddChildPaths(node, result);
        if(node.key != 0) 
        {
            result = AddParentPaths(node, result);
        }

        foreach(var child in node.children)
        {
            result = CreatePaths(child, result);
        }

        return result;
    }

    private List<List<NodeTree>> AddChildPaths(NodeTree node, List<List<NodeTree>> paths) 
    {
        var result = new List<List<NodeTree>>(paths);
        IReadOnlyList<NodeTree> parents = new List<NodeTree>(result[result.Count - 1]); 
        for(int i = 0; i < node.children.Count; i++)
        {
            if(i != 0)
            {
                var buffer = new List<NodeTree>(parents);
                result.Add(buffer);
            } 
            result[result.Count - 1].Add(node.children[i]);
            result = AddChildPaths(node.children[i], result);   
        }

        return result;
    }

    private List<List<NodeTree>> AddParentPaths(NodeTree node, List<List<NodeTree>> paths) 
    {
        var result = new List<List<NodeTree>>(paths);
        
        foreach(var path in paths) 
        {
            if(path[0].key == node.parent && path[1].key != node.key) 
            {
                var buffer = new List<NodeTree>{node};
                foreach(var item in path) {
                    buffer.Add(item);
                }
                result.Add(buffer);
            }
        }

        return result;
    }

    private List<int> FindLongest()
    {
        var result = new List<int> ();
        if(AllPaths == null) return result;
        int record = 0;

        foreach(var path in AllPaths) 
        {
            List<int> ? buffer = null;
            if(record < path.Count) {
                buffer = CorrectPath(path);
                if(record < buffer.Count)
                {
                    result = buffer;
                    record = buffer.Count;
                }
            }
        }

        return result;
    }

    private List<int> CorrectPath(List<NodeTree> path)
    {
        var result = new List<int> ();
        char prevSymbol = '\0';
        for(int item = 0; item < path.Count; item++)
        {
            if(item != 0 && path[item].symbol == prevSymbol)
            {
                result.Clear();
            }

            if(item != 0 &&path[item].key == path[0].key)
            {
                break;
            }

            result.Add(path[item].key);
            prevSymbol = path[item].symbol;
        }
        return result;
    }
    public void Show()
    {
        if(LongPath == null) 
        {
            Console.WriteLine(0);
            return;
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(LongPath.Count);
        Console.WriteLine(string.Join(", ", LongPath));
        Console.ResetColor();

    }
}

