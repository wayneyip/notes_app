using System.Collections;

class NotesApp()
{
    private static List<Note> notes = new List<Note>();

    public static void Main(string[] args)
    {
        bool isAppRunning = true;

        while (isAppRunning)
        {
            Console.Clear();

            Console.WriteLine("Notes by Wayne Yip");
            Console.WriteLine("Main Menu");
            Console.WriteLine("=====================");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1 - Create New Note");
            Console.WriteLine("2 - View Notes");
            Console.WriteLine("3 - Delete Note");
            Console.WriteLine("0 - Exit");

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
                    isAppRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid input: please enter the number for your option (1, 2, 3, or 0)");
                    IOUtils.PromptAnyKey();
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
        
        Console.WriteLine("Now write something for your new note:");

        string content = Console.ReadLine() ?? string.Empty;
        
        Note newNote = new Note(title, content);
        
        notes.Add(newNote);

        IOUtils.WriteEllipses(3);
        Console.WriteLine("New note created!");
        ViewNote(notes.Count - 1);

        IOUtils.PromptAnyKey();
    }

    private static void ListNotesToView()
    {
        bool isSelectingNote = true;

        while (isSelectingNote)
        {
            Console.Clear();
            Console.WriteLine("View Notes");
            Console.WriteLine("=====================");

            ListNotes();
            Console.WriteLine("0 - [Back to Main Menu]");

            string userInput = Console.ReadLine() ?? string.Empty;

            try
            {
                int number = Int32.Parse(userInput);

                if (number == 0)
                {
                    isSelectingNote = false;
                    return;
                }
                int index = number - 1;
                if (0 <= index && index < notes.Count)
                {
                    ViewNote(index);
                }
                else
                {
                    Console.WriteLine("Invalid input: no note found at number " + number);
                }
            }
            catch
            {
                Console.WriteLine("Invalid input: please enter a number");
            }
            IOUtils.PromptAnyKey();
        }
    }

    private static void ViewNote(int index)
    {
        IOUtils.WriteEllipses(3);
        Console.WriteLine(notes[index].Title);
        Console.WriteLine("-------------------");
        Console.WriteLine(notes[index].Content);
        IOUtils.WriteEllipses(3);
    }

    private static void ListNotesToDelete()
    {
        bool isSelectingNote = true;

        while (isSelectingNote)
        {
            Console.Clear();
            Console.WriteLine("Delete Note");
            Console.WriteLine("=====================");

            ListNotes();
            Console.WriteLine("0 - [Back to Main Menu]");

            string userInput = Console.ReadLine() ?? string.Empty;

            try
            {
                int number = Int32.Parse(userInput);

                if (number == 0)
                {
                    isSelectingNote = false;
                    return;
                }
                int index = number - 1;
                if (0 <= index && index < notes.Count)
                {
                    DeleteNote(index);
                }
                else
                {
                    Console.WriteLine("Invalid input: no note found at number " + number);
                }
            }
            catch
            {
                Console.WriteLine("Invalid input: please enter a number");
            }
            IOUtils.PromptAnyKey();
        }
    }

    private static void ListNotes()
    {
        for (int i = 0; i < notes.Count; i++)
        {
            Console.WriteLine((i + 1) + " - " + notes[i].Title);
        }
    }

    private static void DeleteNote(int index)
    {
        Console.WriteLine("Deleted note: " + notes[index].Title);
        notes.RemoveAt(index);
    }
}