class NotesApp()
{
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

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("New Note");
                    break;
                case "2":
                    Console.WriteLine("View Notes");
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
}