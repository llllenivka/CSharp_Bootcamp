using System.ComponentModel;
using System.Runtime.InteropServices;

class MyProgram {
    static void Main() {
        List<int> ? parents;
        string ? symbols;

        while(!InputUser.InputParents(out parents)) {}
        if(parents == null) return;
      
        while(!InputUser.InputString(parents.Count, out symbols)) {}
        if(string.IsNullOrEmpty(symbols)) return;

        
        var MyTree = new Tree(parents, symbols);
        var path = new LongestPath(MyTree);
        path.Find();
        path.Show();
    }
}


