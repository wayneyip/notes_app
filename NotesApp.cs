using System.Collections;

class NotesApp()
{
    private NotesData data;

    public static void Main(string[] args)
    {
        NotesApp app = new NotesApp();

        app.Run();
    }

    public void Run()
    {
        data = new NotesData();

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
        Console.WriteLine("Create Note");
        Console.WriteLine("=====================");

        Console.WriteLine("Enter the title for your new note:");

        string title = Console.ReadLine() ?? string.Empty;
        
        Console.WriteLine("Now write something for your new note:");

        string content = Console.ReadLine() ?? string.Empty;

        data.AddNote(title, content);
        
        IOUtils.WriteEllipses(3);
        Console.WriteLine("New note created!");
        ViewNote(data.GetNotesCount() - 1);

        IOUtils.PromptAnyKey();
    }

    private void ListNotesWithAction(string actionName, Action<int> action)
    {
        bool isSelectingNote = true;

        while (isSelectingNote)
        {
            Console.Clear();
            Console.WriteLine(actionName);
            Console.WriteLine("=====================");

            ListNoteTitles();
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
                if (0 <= index && index < data.GetNotesCount())
                {
                    action(index);
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