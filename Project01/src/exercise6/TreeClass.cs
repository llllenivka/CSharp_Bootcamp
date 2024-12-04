class Tree {
    public NodeTree ? root = null;
    private int key = 0;

    public Tree(List<int> parents, string symbols)
    {
        for(int index = 0; index < parents.Count; index++)
        {
            Insert(parents[index], symbols[index]);
        }
    }


    public void Insert(int parent, char symbol)
    {
        if(parent == -1) 
        {
            var node = new NodeTree(this.key, symbol, parent);
            this.root = node;
            this.key++;
        } 
        InsertRecurs(this.root,  parent,  symbol);
    }

    private bool InsertRecurs(NodeTree ? root, int parent, char symbol) 
    {
        if(root == null) return false;

        if(parent ==  root.key)
        {
            var node = new NodeTree(this.key, symbol, parent);
            root.children.Add(node);
            this.key++;
            return true;
        } 
        else 
        {
            foreach(var child in root.children)
            {
                if(InsertRecurs(child, parent, symbol) == true)
                {
                    return true;
                } 
            }
        }
        return false;
    }
}