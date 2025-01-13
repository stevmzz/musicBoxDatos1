using System.Timers;

namespace Music_Box.Models {
    public class DoublyLinkedList { // clase para la lista doblemente enlazada

        private Node? Head; // nodo inical (cabeza)
        private Node? Tail; // nodo final (cola)
        private int Count; // contador de nodos
        private Node? currentNote; // nodo actual seleccionado

        public DoublyLinkedList() { // constructor
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void addNote(Note note) { // método para agregar un nodo a la lista
            Node newNode = new Node(note); // crea un nodo con la nota
            
            if (Count == 0) { // si la lista es vacía el único nodo será "todos"
                Head = newNode; 
                Tail = newNode;
                currentNote = newNode;
            }

            else {
                newNode.Previus = Tail; // el nodo anterior apunta a la cola
                Tail!.Next = newNode; // el siguiente nodo apunta al nuevo nodo
                Tail = newNode; // el nuevo nodo es la cola
            }
            Count += 1;
        }

        public Node? GetNext() { // método para obtener el siguiente nodo desde el actual
            if (currentNote != null) {
                return currentNote.Next;
            }
            return null;
        }

        public Node? GetPrevious() { // método para obtener el anterior nodo desde el actual
            if (currentNote?.Previus != null) {
                currentNote = currentNote.Previus;
                return currentNote;
            }
            return null;
        }

        // getters and setters básicos
        public Node? GetCurrentNote() {
            return currentNote;
        }

        public void SetCurrentNote(Node? node) {
            currentNote = node;
        }

        public Node? GetFirst() {
            currentNote = Head;
            return Head;
        }

        public Node? GetLast() {
            currentNote = Tail;
            return Tail;
        }

        public int GetCount() {
            return Count;
        }

        public bool IsEmpty() { // método para ver si la lista es vacía
            return Count == 0;
        }
    }
}