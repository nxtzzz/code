using Vtitbid.ISP20.Abuzarov.Note;

namespace Vtitbid.ISP20.Abuzarov.Note
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество людей: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                Note[] array = Note.GetNote(value);
                Console.WriteLine();
                Console.WriteLine(Note.NoteSearch(array));
            }
            else
            {
                Console.WriteLine("\nОшибка");
            }
        }
    }
}