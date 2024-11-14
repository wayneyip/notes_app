using System.Collections;

class NotesApp()
{
    private static List<Note> notes = new List<Note>();

    public static void Main(string[] args)
    {
        bool appRunning = true;

        while (appRunning)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Create New Note");
            Console.WriteLine("2. View Notes");
            Console.WriteLine("3. Delete Note");
            Console.WriteLine("4. Exit");

            string userInput = Console.ReadLine() ?? string.Empty;
            switch (userInput.Trim())
            {
                case "1":
                    CreateNote();
                    break;
                case "2":
                    ListNotes();
                    break;
                case "3":
                    Console.WriteLine("Delete Note");
                    break;
                case "4":
                    appRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice - please enter the number for your option (1, 2, or 3)");
                    break;
            }
        }
        
        Console.WriteLine("See you later!");
    }

    private static void CreateNote()
    {
        Console.WriteLine("Enter the title for your new note:");

        string title = Console.ReadLine() ?? string.Empty;
        
        Console.WriteLine("Enter the content for your new note:");

        string content = Console.ReadLine() ?? string.Empty;
        
        Note newNote = new Note(title, content);
        
        notes.Add(newNote);
    }

    private static void ListNotes()
    {
        foreach (Note note in notes)
        {
            Console.WriteLine(note.Title);
        }
    }
}