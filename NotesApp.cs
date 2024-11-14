using System.Collections;

public class NotesApp
{
    private NotesData data;

    public NotesApp()
    {
        data = new NotesData();
    }

    public static void Main()
    {
        NotesApp app = new();

        app.Run();
    }

    // Main menu 
    //
    public void Run()
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
                    ListNotesWithAction("View Notes", ViewNote);
                    break;
                case "3":
                    ListNotesWithAction("Delete Note", DeleteNote);
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

    private void CreateNote()
    {
        Console.Clear();
        
        // Header
        Console.WriteLine("Create Note");
        Console.WriteLine("=====================");

        // Input title and content
        Console.WriteLine("Enter the title for your new note:");

        string title = Console.ReadLine() ?? string.Empty;
        
        Console.WriteLine("Now write something for your new note:");

        string content = Console.ReadLine() ?? string.Empty;

        // Add note to data
        data.AddNote(title, content);
        
        // Display finished note to user
        IOUtils.WriteEllipses(3);
        Console.WriteLine("New note created!");
        ViewNote(data.GetNotesCount() - 1);

        IOUtils.PromptAnyKey();
    }

    // Lists all notes for the user to select and perform an action.
    // Scalable for future actions, e.g. Edit Note.
    //
    private void ListNotesWithAction(string actionName, Action<int> action)
    {
        bool isSelectingNote = true;

        while (isSelectingNote)
        {
            Console.Clear();

            // Header
            Console.WriteLine(actionName);
            Console.WriteLine("=====================");

            // List of note titles + Back function
            ListNoteTitles();
            Console.WriteLine("0 - [Back to Main Menu]");

            // User input
            string userInput = Console.ReadLine() ?? string.Empty;

            try
            {
                int number = Int32.Parse(userInput);

                // 0 - back to main menu
                if (number == 0)
                {
                    isSelectingNote = false;
                    return;
                }
                // Get list index and perform action
                // (Minus one because the user-facing list is 1-indexed)
                int index = number - 1;
                if (0 <= index && index < data.GetNotesCount())
                {
                    action(index);
                }
                else // index out of bounds
                {
                    Console.WriteLine("Invalid input: no note found at number " + number);
                }
            }
            catch // user input is not an integer
            {
                Console.WriteLine("Invalid input: please enter a number");
            }
            IOUtils.PromptAnyKey();
        }
    }

    private void ViewNote(int index)
    {
        IOUtils.WriteEllipses(3);
        Console.WriteLine(data.GetTitleAt(index));
        Console.WriteLine("-------------------");
        Console.WriteLine(data.GetContentAt(index));
        IOUtils.WriteEllipses(3);
    }

    private void ListNoteTitles()
    {
        List<string> titles = data.GetNoteTitles();

        for (int i = 0; i < titles.Count; i++)
        {
            Console.WriteLine((i + 1) + " - " + titles[i]);
        }
    }

    private void DeleteNote(int index)
    {
        Console.WriteLine("Deleted note: " + data.GetTitleAt(index));
        data.RemoveNoteAt(index);
    }
}