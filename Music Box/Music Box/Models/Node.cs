namespace Music_Box.Models {
    public class Node {
        public Note Data {get; set;}
        public Node? Next {get; set;}
        public Node? Previus {get; set;}

        public Node(Note data) {
            Data = data;
            Next = null;
            Previus = null;
        }
    }
}