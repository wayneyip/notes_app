using System.Collections;

class NotesApp()
{
    private static List<Note> notes = new List<Note>();

    public static void Main(string[] args)
    {
        bool appRunning = true;

        while (appRunning)
        {
            Console.Clear();

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
                    ListNotesToView();
                    break;
                case "3":
                    ListNotesToDelete();
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
        Console.Clear();

        Console.WriteLine("Enter the title for your new note:");

        string title = Console.ReadLine() ?? string.Empty;
        
        Console.WriteLine("Enter the content for your new note:");

        string content = Console.ReadLine() ?? string.Empty;
        
        Note newNote = new Note(title, content);
        
        notes.Add(newNote);
    }

    private static void ListNotesToView()
    {
        Console.Clear();

        int selectedNoteIndex = SelectFromNotes();

        if (selectedNoteIndex >= 0)
        {
            ViewNote(selectedNoteIndex);
        }
    }

    private static void ViewNote(int index)
    {
        Console.WriteLine(notes[index].Title);
        Console.WriteLine(notes[index].Content);
    }

    private static void ListNotesToDelete()
    {
        Console.Clear();

        int selectedNoteIndex = SelectFromNotes();

        if (selectedNoteIndex >= 0)
        {
            DeleteNote(selectedNoteIndex);
        }
    }

    private static int SelectFromNotes()
    {
        if (notes.Count > 0)
        {
            for (int i = 0; i < notes.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + notes[i].Title);
            }

            string userInput = Console.ReadLine() ?? string.Empty;

            try
            {
                int number = Int32.Parse(userInput);
                int trueNumber = number - 1;
                if (trueNumber < notes.Count)
                {
                    return trueNumber;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        return -1;
    }

    private static void DeleteNote(int index)
    {
        Console.WriteLine("Deleting note: " + notes[index].Title);
        notes.RemoveAt(index);
    }
}