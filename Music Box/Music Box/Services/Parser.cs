using System;
using System.Collections.Generic;
using Music_Box.Models;

namespace Music_Box.Services
{
    public class Parser
    {
        public static List<Note> ParseNotes(string input)
        {
            var notes = new List<Note>();

            // Dividir la entrada en notas individuales
            var noteStrings = input.Split("),");

            foreach (var noteString in noteStrings)
            {
                var cleanedNote = noteString.Trim().Trim('(', ')');
                var parts = cleanedNote.Split(',');

                if (parts.Length == 2)
                {
                    string noteName = parts[0].Trim();
                    string duration = parts[1].Trim();

                    // Crear una nueva nota y añadirla a la lista
                    notes.Add(new Note(noteName, duration));
                }
                else
                {
                    Console.WriteLine($"Formato inválido: {noteString}");
                }
            }

            return notes;
        }
    }
}
