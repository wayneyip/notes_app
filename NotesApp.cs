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
            Console.WriteLine("0. Exit");

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
                case "0":
                    appRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid input: please enter the number for your option (1, 2, 3, or 0)");
                    PromptAnyKey();
                    break;
            }
        }
        
        Console.WriteLine("See you later!");
    }

    private static void CreateNote()
    {
        Console.Clear();
        Console.WriteLine("Create Note");
        Console.WriteLine("=====================");

        Console.WriteLine("Enter the title for your new note:");

        string title = Console.ReadLine() ?? string.Empty;
        
        Console.WriteLine("Enter the content for your new note:");

        string content = Console.ReadLine() ?? string.Empty;
        
        Note newNote = new Note(title, content);
        
        notes.Add(newNote);

        Console.WriteLine("New note created!");
        WriteEllipses(3);
        ViewNote(notes.Count - 1);
        WriteEllipses(3);
        PromptAnyKey();
    }

    private static void WriteEllipses(int rows)
    {
        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine(".");
        }
    }

    private static void PromptAnyKey()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void ListNotesToView()
    {
        bool viewingNotes = true;

        while (viewingNotes)
        {
            Console.Clear();
            Console.WriteLine("View Notes");
            Console.WriteLine("=====================");

            ListNotes();
            Console.WriteLine("0. [Back to Main Menu]");

            string userInput = Console.ReadLine() ?? string.Empty;

            try
            {
                int number = Int32.Parse(userInput);

                if (number == 0)
                {
                    viewingNotes = false;
                    return;
                }
                int index = number - 1;
                if (0 <= index && index < notes.Count)
                {
                    ViewNote(index);
                    PromptAnyKey();
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    PromptAnyKey();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                PromptAnyKey();
            }
        }
    }

    private static void ViewNote(int index)
    {
        Console.WriteLine(notes[index].Title);
        Console.WriteLine("-------------------");
        Console.WriteLine(notes[index].Content);
    }

    private static void ListNotesToDelete()
    {
        bool viewingNotes = true;

        while (viewingNotes)
        {
            Console.Clear();
            Console.WriteLine("Delete Note");
            Console.WriteLine("=====================");

            ListNotes();
            Console.WriteLine("0. [Back to Main Menu]");

            string userInput = Console.ReadLine() ?? string.Empty;

            try
            {
                int number = Int32.Parse(userInput);

                if (number == 0)
                {
                    viewingNotes = false;
                    return;
                }
                int index = number - 1;
                if (0 <= index && index < notes.Count)
                {
                    DeleteNote(index);
                    PromptAnyKey();
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    PromptAnyKey();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                PromptAnyKey();
            }
        }
    }

    private static void ListNotes()
    {
        for (int i = 0; i < notes.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + notes[i].Title);
        }
    }

    private static void DeleteNote(int index)
    {
        Console.WriteLine("Deleting note: " + notes[index].Title);
        notes.RemoveAt(index);
    }
}