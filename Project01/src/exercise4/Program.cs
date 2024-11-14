class MyProgram {
    static void Main(){
        MyStack stack = new MyStack() ;
        string ? input = Console.ReadLine();
        if(input != null) {
            stack.PushString(input);
            stack.Shuffle();
        }
    }
}

public class MyStack {
    ListNode top;
    public int Count { get; set; }
    public MyStack () {
        this.top = null;
        this.Count = 0;
    }

    public void PushString(string input){
        string[] inputSplit = input.Split(",");
        foreach(var item in inputSplit) {
            int val;
            if(int.TryParse(item, out val)) {
                Push(val);
            }
        }
    }

    public void Shuffle() {
        Reverse();
        Console.Write(Pop());
        while(Count > 0) {
            Reverse();
            Console.Write( $", {Pop()}");
        }
    }

    public void Reverse() {
        MyStack temp = new MyStack();
        while(Count > 0){
            temp.Push(this.Pop());
        }
        this.top = temp.top;
        this.Count = temp.Count;
    }
    public void Push(int value) {
        ListNode newNode = new ListNode(value, this.top);
        this.top = newNode;
        Count++;
    }
    public int Pop() {
        int value = top.val;
        top = top.next;
        Count--;
        return value;
    }
}

public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
}
