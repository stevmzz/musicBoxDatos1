using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Music_Box.Models;
using Music_Box.Services;

class Program
{
    static void Main()
    {

        // Crear la lista enlazada
        var playlist = new DoublyLinkedList();

        // Pedir entrada al usuario
        Console.WriteLine("Ingrese las notas en el formato (Nota, Figura), separadas por comas:");
        string input = Console.ReadLine();

        // Parsear las notas
        var notes = Parser.ParseNotes(input);

        // Añadir cada nota a la lista enlazada
        foreach (var note in notes)
        {
            playlist.addNote(note);
        }

        Console.WriteLine($"Se añadieron {playlist.GetCount()} notas a la lista.");

        // Opcional: mostrar las notas añadidas
        var current = playlist.GetFirst();
        while (current != null)
        {
            Console.WriteLine($"Nota: {current.Data.NoteName}, Duración: {current.Data.Duration}");
            current = current.Next;
        }
        // Frecuencias de las notas (en Hz)
        var notas = new Dictionary<string, double>
        {
            {"Do", 261.63},
            {"Re", 293.66},
            {"Mi", 329.63},
            {"Fa", 349.23},
            {"Sol", 392.00},
            {"La", 440.00},
            {"Si", 493.88}
        };

        Console.WriteLine("Reproduciendo escala musical...");

        foreach (var nota in notas)
        {
            Console.WriteLine($"Reproduciendo {nota.Key} ({nota.Value} Hz)");

            var sineWaveProvider = new SignalGenerator()
            {
                Gain = 0.2,
                Frequency = nota.Value,
                Type = SignalGeneratorType.Sin
            };

            // Cambia WaveOut por WaveOutEvent
            using (var waveOut = new WaveOutEvent())
            {
                waveOut.Init(sineWaveProvider);
                waveOut.Play();
                Thread.Sleep(500); // Duración de cada nota (500ms)
                waveOut.Stop();
            }

            Thread.Sleep(100); // Pequeña pausa entre notas
        }

        Console.WriteLine("¡Escala completada!");
        // Imprimir la lista enlazada
        playlist.PrintList();
        Console.ReadLine();
    }
}

////////////// AQUÍ IRÁ EL MENÚ PRINCIPAL //////////////////////////////////////////

////////////// REMPLAZAR //////////////////////////////////////////