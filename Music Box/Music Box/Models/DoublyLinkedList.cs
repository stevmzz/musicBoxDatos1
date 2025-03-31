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

        public void PrintList()
        {
            if (IsEmpty())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Console.WriteLine("Contenido de la lista enlazada:");
            var current = Head;
            int index = 1;

            while (current != null)
            {
                Console.WriteLine($"[{index}] Nota: {current.Data.NoteName}, Duración: {current.Data.Duration}");
                current = current.Next;
                index++;
            }
        }

    }
}