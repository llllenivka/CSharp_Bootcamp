using System.Collections;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

class Program {
    static void Main() {
        MyProgram.DeckCard deck = new MyProgram.DeckCard();
        deck.AddDeck();
        if(!deck.IsEmpty()){
            deck.Shuffle();
            deck.ShowDeck();
        }
    }
}

namespace MyProgram {
    public class DeckCard : Queue{
        List<int> Deck = new List<int>();
        public void Shuffle() {
            var order = new Queue();
            for(int i = 0; i < Deck.Count; i++) order.Enqueue(i);
            
            var result = new List<int> (Enumerable.Repeat(0, Deck.Count));
            for(int i = 0; i < Deck.Count; i++){
                int index = order.Dequeue();
                result[index] = Deck[i];
                if(order.Count > 1){
                    index = order.Dequeue();
                    order.Enqueue(index);
                } 
            }

            Deck = result;
            
        }
        public bool IsEmpty()
        {
            return Deck.Count > 0 ? false : true;
        }

        public void ShowDeck() {
            foreach(var item in Deck) {
                if(Deck[0] != item) Console.Write(',');
                Console.Write(item);
            }
        }

        public void AddDeck() {
            string ? input = Console.ReadLine();

            string [] tempString = input.Split(",");

            foreach (var item in tempString)
            {
                int val;
                if(int.TryParse(item, out val)){
                    Deck.Add(val);
                } else Console.WriteLine("Couldn't parse a number. Please, try again");
            }
            Deck.Sort();
        }


    }


    public class Queue {
        private Node head;
        private Node tail;
        public int Count { get; set; }
        public Queue(Node head = null, Node tail = null){
            this.head = head;
            this.tail = tail;
            this.Count = 0;
        }

        public void Enqueue(int val) {
            Node value = new Node(val);
            if(head == null) {
                head = value;
                tail = value;
            } else {
                tail.next = value;
                tail = value;
            }
            this.Count++;
        }

        public int Dequeue() {
            if(head == null) {
                throw new InvalidOperationException("Queue empty.");
            }
            int value = head.value;
            head = head.next;
            this.Count--;
            return value;
        }

        public int this [int index]{
            get {
                if(index < 0) {
                    throw new IndexOutOfRangeException("Invalid index");
                }
                Node temp = head;
                int val = 0;
                for(int i = 0;i <= index; i++){
                    if(temp == null) {
                        throw new IndexOutOfRangeException("Invalid index");
                    } else {
                        val = temp.value;
                        temp = temp.next;
                    }
                }
                return val;
            }
        }
    }

    public class Node {
        public int value;
        public Node next;
        public Node(int value = 0, Node next = null) {
            this.value = value;
            this.next = next;
        }
        
    }

}
