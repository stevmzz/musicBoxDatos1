using NUnit.Framework;
using Music_Box.Models;
using Music_Box.Services;

namespace Music_Box.Tests
{
    [TestFixture] // clase de pruebas unitarias
    public class StevenUnitTests
    {
        [Test] // prueba #1: si se agrega una nota a una lista vac�a, el contador aumenta
        public void AddNotes()
        {
            // Arrange: datos necesarios
            var playlist = new DoublyLinkedList(); // creaci�n de una lista vac�a
            var note = new Note("Do", "negra"); // creaci�n de una nota

            // Act: acci�n a probar
            playlist.addNote(note);

            // Assert: verificamos que el resultado sea el esperado
            Assert.AreEqual(1, playlist.GetCount());
        }

        [Test] // prueba #2: prueba que returna falso al ingresar un tempo invalido
        public void FalseTempo()
        {
            // Arrange: datos necesarios
            var player = new MusicPlayer(new DoublyLinkedList());

            // Act: acci�n a probar
            bool result = player.setTempo(10.0f);

            // Assert: verifica que el resultado sea falso
            Assert.IsFalse(result);
        }

        [Test]
        public void GetCorrectNext() // prueba #3: prueba que al tener varias notas, el m�todo devuelve la siguiente correctamente 
        {
            // Arrange: datos necesarios
            var playlist = new DoublyLinkedList();
            var note1 = new Note("Do", "negra");
            var note2 = new Note("Re", "corchea");
            playlist.addNote(note1);
            playlist.addNote(note2);

            // Act: acci�n a probar
            var firstNote = playlist.GetFirst();
            var nextNote = playlist.GetNext();

            // Assert: la siguiente nota no debe ser null
            Assert.IsNotNull(nextNote);
        }

        [Test]
        public void GetCorrectFrequency()
        {
            // Arrange: datos necesarios
            var note = new Note("Do", "negra");

            // Act: acci�n a probar
            double frequency = note.Frequency;

            // Assert: la frecuencia de "Do" debe ser 261.63    
            Assert.AreEqual(261.63, frequency);
        }

        [Test]
        public void PlaySingleNote()
        {
            // Arrange: datos necesarios
            var playlist = new DoublyLinkedList();
            var player = new MusicPlayer(playlist);
            var note = new Note("Do", "negra");

            // Act & Assert: la reproducci�n no debe lanzar excepciones
            Assert.DoesNotThrow(() => player.PlaySingleNote(note));
        }
    }
}
