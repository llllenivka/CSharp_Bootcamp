class NodeTree {
    public int key;
    public char symbol;
    public int parent;
    public List<NodeTree> children;
    public NodeTree(int key, char symbol, int parent) {
        this.key = key;
        this.symbol = symbol;
        this.parent = parent;
        this.children = new List<NodeTree>();
    }

}