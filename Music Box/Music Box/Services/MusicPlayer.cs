using Music_Box.Models;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Music_Box.Services {
    public class MusicPlayer { // clase para reproducir música

        private readonly DoublyLinkedList playlist; // lista doblemente enlazada
        private float quarterNoteDuration = 1.0f; // duración base de negra
        private readonly Dictionary<string, float> durationMultipliers; // diccionario duraciones musicales con sus valores
        
        public MusicPlayer(DoublyLinkedList playlist) { // constructor
            this.playlist = playlist;
            durationMultipliers = new Dictionary<string, float> {
                { "redonda", 4.0f },
                { "blanca", 2.0f },
                { "negra", 1.0f },
                { "corchea", 0.5f },
                { "semicorchea", 0.25f }
            };
        }

        public bool setTempo(float seconds) { // método para establecer el tempo
            if (seconds < 0.1f || seconds > 5.0f) // duración en rango válido
                return false;

            quarterNoteDuration = seconds;
            return true;
        }

        private void PlaySingleNote(Note note) { // método para reproducir una nota
        
            var sineWaveProvider = new SignalGenerator() { // crea un generador de ondas
            
                Gain = 0.2,  // volumen de onda
                Frequency = note.Frequency, // frecuancia de nota
                Type = SignalGeneratorType.Sin // define el tipo como onda
            };

            using var waveOut = new WaveOutEvent(); // crea un dispositivo de salida
            waveOut.Init(sineWaveProvider); // inicializa el dispositivo
            waveOut.Play(); // reproduce la onda

            float duration = quarterNoteDuration * durationMultipliers[note.Duration.ToLower()]; // calcula la duración de la nota
            Thread.Sleep((int)(duration * 1000)); // pausa el hilo durante la reproducción
            waveOut.Stop(); // detiene la onda
            Thread.Sleep(50);
        }

        public void PlayForward() { // método para moverse hacia adelante
        
        }

        public void PlayBackward() { // método para moverse hacia atrás
        
        }
    }
}