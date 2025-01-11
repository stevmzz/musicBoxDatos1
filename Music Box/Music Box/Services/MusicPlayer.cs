using Music_Box.Models;
using NAudio.Wave; // etc...

namespace Music_Box.Services {
    public class MusicPlayer {
        private readonly DoublyLinkedList playlist;
        
        public MusicPlayer() {
            playlist = new DoublyLinkedList();
        }
        // Aquí irán los métodos:
        // playForward
        // playBackward
        // setTempo
        // etc...
    }
}