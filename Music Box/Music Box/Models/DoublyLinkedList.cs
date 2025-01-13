namespace Music_Box.Models {
    public class DoublyLinkedList {

        private Node? Head;
        private Node? Tail;
        private int Count;
        private Node? currentNote;

        public DoublyLinkedList() {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void addNote(Note note) {
            Node newNode = new Node(note);
            
            if (Count == 0) { 
                Head = newNode;
                Tail = newNode;
                currentNote = newNode;
            }

            else {
                newNode.Previus = Tail;
                Tail!.Next = newNode;
                Tail = newNode;
            }
            Count += 1;
        }

        public Node? GetNext() {
            if (currentNote != null) {
                return currentNote.Next;
            }
            return null;
        }

        public Node? GetPrevious(Node currentNode) {
            return currentNode.Previus;
        }

        public Node? GetFirst() {
            return Head;
        }

        public Node? GetLast() {
            return Tail;
        }

        public int GetCount() {
            return Count;
        }

        public bool IsEmpty() {
            return Count == 0;
        }
    }
}