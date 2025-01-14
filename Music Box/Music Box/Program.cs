using Music_Box.Models;
using Music_Box.Services;

class Program {
    static void Main() {
        Console.WriteLine("---------MusicBox Iniciado---------");
        var playlist = new DoublyLinkedList(); // Crear la lista enlazada
        var player = new MusicPlayer(playlist);
        bool running = true;
        player.setTempo(1.0f); // establece tiempo inicial en 1 segundo

        while (running) {

            Console.WriteLine("\nMusicBox - Menú Principal");
            Console.WriteLine("1. Ingresar partitura");
            Console.WriteLine("2. Reproducir hacia adelante");
            Console.WriteLine("3. Reproducir hacia atrás");
            Console.WriteLine("4. Configurar tempo");
            Console.WriteLine("5. Mostrar partitura actual");
            Console.WriteLine("6. Salir");

            Console.Write("\nSeleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion) {

                case "1": // ingresar partitura
                    Console.WriteLine("Ingrese las notas en el formato (Nota, Figura), separadas por comas:"); // Pedir entrada al usuario
                    string input = Console.ReadLine();
                    var notes = Parser.ParseNotes(input); // Parsear las notas
                    
                    foreach (var note in notes) { // Añadir cada nota a la lista enlazada
                        playlist.addNote(note);
                    }
                    Console.WriteLine($"Se añadieron {playlist.GetCount()} notas a la lista.");
                    break;

                case "2": // reproducir hacia adelante

                case "3": // reproducir hacia atrás

                case "4": // configurar tempo
                    Console.WriteLine("Ingrese la duración de la negra en segundos (0.1 a 5.0): ");
                    if (float.TryParse(Console.ReadLine(), out float tempo)) { // si convierte el valor ingresado a float
                        if (player.setTempo(tempo)) { // si se logra establecer como tempo
                            Console.WriteLine("Tempo actualizado.");
                        }
                        
                        else {
                            Console.WriteLine("El tempo debe estar entre 0.1 y 5.0 segundos.");
                        }
                    }
                    break;

                case "5": // mostrar partitura actual
                    playlist.PrintList();
                    break;

                case "6": // salir
                    running = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;

            }
            if (running) {
                Console.WriteLine("\nPresione Enter para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}