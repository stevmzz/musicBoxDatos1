namespace Music_Box.Models {
    public class Note {
        public string NoteName {get; set;} // nombre de la nota además de get y set
        public double Frequency {get; set; } // frecuencia de la nota además de get y set
        public string Duration {get; set; } // duración de la nota además de get y set

        public Note(string noteName, string duration) {
            NoteName = noteName;
            Duration = duration;
            Frequency = getFrequency(noteName);
        }

        private double getFrequency(string note) // método para obtener las frecuencias respectivas
        {
            return note switch
            {
                "Do" => 261.63,
                "Re" => 293.66,
                "Mi" => 329.63,
                "Fa" => 349.23,
                "Sol" => 392.00,
                "La" => 440.00,
                "Si" => 493.88,
                _ => 440.00
            };
        }
    }
}