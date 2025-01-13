namespace Music_Box.Models {
    public class Note {
        public string NoteName {get; set;}
        public double Frequency {get; set;}
        public string Duration {get; set;}

        public Note(string noteName, string duration) {
            NoteName = noteName;
            Duration = duration;
            Frequency = getFrequency(noteName); // por implementar
        }

        private double getFrequency(string note) {
            return 440.0; // por ahora valor por defecto
        }
    }
}